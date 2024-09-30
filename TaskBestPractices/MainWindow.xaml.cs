using System.Diagnostics;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Reflection;
using System.Security.Cryptography;

namespace TaskBestPractices
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    public MainWindow()
    {
      InitializeComponent();
      _ = new DispatcherTimer(TimeSpan.FromMilliseconds(50), DispatcherPriority.Background, UpdateUi, Dispatcher.CurrentDispatcher);
    }

    readonly ConcurrentQueue<Log> _logQueue = new ConcurrentQueue<Log>();
    volatile int _id = 0;

    private void UpdateUi(object? sender, EventArgs e)
    {
      while (_logQueue.TryDequeue(out var log))
      {
        LogWindow.Text += $"{log.At:mm:ss.fff} {log.Message}{Environment.NewLine}";
        while (LogWindow.Text.Count(c => c == '\n') > 20)
        {
          var idx = LogWindow.Text.IndexOf(Environment.NewLine, StringComparison.InvariantCulture) + Environment.NewLine.Length;
          LogWindow.Text = LogWindow.Text.Substring(idx, LogWindow.Text.Length - idx);
        }
      }
    }

    private async void Button_Good_Click(object sender, RoutedEventArgs e)
    {
      var state = Start(sender);
      await TryCatch(ATaskThatThrows, state);
      Finish(sender, state);
    }

    private void Button_Deadlock_Click(object sender, RoutedEventArgs e)
    {
      var state = Start(sender);
      InvokeDeadlock().Wait();
      Finish(sender, state);
    }

    private async void Button_ConfigureAwait_Click(object sender, RoutedEventArgs e)
    {
      var state = Start(sender);
      await TryCatch(InvokeConfigureAwait, state).ConfigureAwait(false);
      Finish(sender, state);
    }

    private void Button_ConfigureAwait_NoLock_Click(object sender, RoutedEventArgs e)
    {
      var state = Start(sender);
      TryCatch(
        ()=>InvokeConfigureAwait().ContinueWith(_ => { Finish(sender, state); })
        , state);
    }

    private void Button_AsyncVoid_Click(object sender, RoutedEventArgs e)
    {
      var state = Start(sender);
      TryCatch(
       async ()=> InvokeAsyncVoid(sender, state)
      ,state);
      Finish(sender, state);
    }

    private object Start(object sender)
    {
      var state = Interlocked.Increment(ref _id);
      _cancellationTokenSource.Cancel();
      _cancellationTokenSource = new CancellationTokenSource();
      (sender as Button)!.Background = Brushes.Red;
      _logQueue.Enqueue($"{state} Start");
      return state;
    }
    
    private void Finish(object sender, object state)
    {
      _logQueue.Enqueue($"{state} Finishing");
      (sender as Button)!.Background = Brushes.LawnGreen;
      _logQueue.Enqueue($"{state} Finished");
    }

    private async Task TryCatch(Func<Task> task, object state)
    {
      try
      {
        await task();
      }
      catch (Exception e)
      {
        _logQueue.Enqueue($"{state} {e.Message}");
      }
    }

    private async Task ATaskThatThrows()
    {
      await Task.Delay(3000, _cancellationTokenSource.Token);
      throw new Exception("!!!!!!!!!!!!!!!!!");
    }

    private async Task InvokeDeadlock() => await Task.Run(ATaskThatThrows, _cancellationTokenSource.Token );
    private async Task InvokeConfigureAwait() => await Task.Run(ATaskThatThrows, _cancellationTokenSource.Token ).ConfigureAwait(false);
    private async void InvokeAsyncVoid(object sender, object state) => ATaskThatThrows().ContinueWith(_ => Finish(sender, state));

  }
}

public record Log(string Message)
{
  public DateTimeOffset At = DateTimeOffset.Now;

  public static implicit operator Log(string message) => new Log(message);
}