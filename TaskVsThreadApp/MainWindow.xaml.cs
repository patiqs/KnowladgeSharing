using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace TaskVsThreadApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      _= new DispatcherTimer(TimeSpan.FromMilliseconds(50), DispatcherPriority.Background, Animate, Dispatcher.CurrentDispatcher);
    }

    private volatile int _progress =0;
    private readonly Stopwatch _stopwatch = new Stopwatch();

    private void Animate(object? sender, EventArgs e)
    {
      Animation.Value = (Animation.Value + 1)%Animation.Maximum;
      Process process = Process.GetCurrentProcess();
      var numberOfThreads = process.Threads.Count;
      UsedThreadsText.Content = $"Threads: {ThreadPool.ThreadCount}/{numberOfThreads}";
      Progress.Value = _progress;
      Elapsed.Content = $"Elapsed: {_stopwatch.Elapsed}";
    }

    private void BlockingWaiter()
    {
      Thread.Sleep(3000);
      Interlocked.Increment(ref _progress);
    }

    private async Task AsyncWaiter()
    {
      await Task.Delay(3000);
      Interlocked.Increment(ref _progress);
    }

    private void ThreadClick(object sender, RoutedEventArgs e)
    {
      Start(sender);
      BlockingWaiter();
      Finish(sender);
    }

    private void DeadlockClick(object sender, RoutedEventArgs e)
    {
      Start(sender);
      AsyncWaiter().Wait();
      Finish(sender);
    }

    private void TaskRunClick(object sender, RoutedEventArgs e)
    {
      Start(sender);
      Task.Run(() => AsyncWaiter().Wait()).Wait();
      Finish(sender);
    }

    private void TaskRunAsyncClick(object sender, RoutedEventArgs e)
    {
      Start(sender);
      Task.Run(() => AsyncWaiter().Wait())
          .ContinueWith(_ =>
          {
            if (Dispatcher.CheckAccess())
              Finish(sender);
            else
            {
              Dispatcher.Invoke(() => Finish(sender));
            }
          });
    }

    private async void TaskClick(object sender, RoutedEventArgs e)
    {
      Start(sender);
      await AsyncWaiter();
      Finish(sender);
    }

    private async void BlockingClick(object sender, RoutedEventArgs e)
    {
      Start(sender);
      await Multi(() => Task.Run(BlockingWaiter), 100);
      Finish(sender);
    }

    private async void NonBlockingClick(object sender, RoutedEventArgs e)
    {
      Start(sender);
      await Multi(AsyncWaiter, 1000);
      Finish(sender);
    }

    private void Start(object sender)
    {
      _progress = 0;
      Progress.Maximum = 1;
      (sender as Button)!.Background = Brushes.Red;
      _stopwatch.Restart();
    }

    private void Finish(object sender)
    {
      _stopwatch.Stop();
      (sender as Button)!.Background = Brushes.LawnGreen;
    }


    private async Task Multi(Func<Task> funcToTest, int times)
    {
      Progress.Maximum = times;
      await Task.Delay(1).ConfigureAwait(false);
      var tasks = Enumerable.Repeat(funcToTest, times).Select(task => task()).ToArray();
      await Task.WhenAll(tasks);
    }
  }
}
