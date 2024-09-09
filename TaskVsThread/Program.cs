using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace TaskVsThread;

[ShortRunJob]
[MemoryDiagnoser]
[ThreadingDiagnoser]
public class Sut
{
  private const int N = 1000;
  private const int WAIT_MS = 100;
  private volatile int n = N;
  ManualResetEvent done = new ManualResetEvent(false);

  [Benchmark]
  public void WithTask()
  {
    Task[] tasks = Enumerable.Range(0, N).Select(_ => Task.Run(WorkerAsync)).ToArray();
    done.WaitOne();
    Task.WaitAll(tasks);
  }

  [Benchmark]
  public async Task WithTaskAsync()
  {
    Task[] tasks = Enumerable.Range(0, N).Select(_ => Task.Run(WorkerAsync)).ToArray();
    done.WaitOne();
    await Task.WhenAll(tasks);
  }

  [Benchmark]
  public void WithThread()
  {
    Thread[] threads = Enumerable.Range(0, N).Select(_ =>
    {
      Thread thread = new(WorkerSync);
      thread.Start();
      return thread;
    }).ToArray();

    done.WaitOne();
    foreach (Thread thread in threads) thread.Join();
  }

  [Benchmark]
  public void TaskInsideThread()
  {
    Thread[] threads = Enumerable.Range(0, N).Select(_ =>
    {
      Thread thread = new(() => { WorkerAsync().Wait(); });
      thread.Start();
      return thread;
    }).ToArray();

    done.WaitOne();
    foreach (Thread thread in threads) thread.Join();
  }

  [Benchmark]
  public void ThreadInsideTask()
  {
    Task[] tasks = Enumerable.Range(0, N).Select(_ => Task.Run(WorkerSync)).ToArray();
    Task.WaitAll(tasks);
  }

  private void WorkerSync()
  {
    Thread.Sleep(WAIT_MS);
    JobDone();
  }

  private async Task WorkerAsync()
  {
    await Task.Delay(WAIT_MS);
    JobDone();
  }

  private void JobDone()
  {
    if (Interlocked.Decrement(ref n) == 0) done.Set();
  }
}

public class Program
{
  public static void Main(string[] args)
  {
    Run(sut => sut.WithTask(), nameof(Sut.WithTask));
    Run(sut => sut.WithThread(), nameof(Sut.WithThread));
    Run(sut => sut.TaskInsideThread(), nameof(Sut.TaskInsideThread));
    Run(sut => sut.ThreadInsideTask(), nameof(Sut.ThreadInsideTask));

    Run(sut => sut.WithTask(), nameof(Sut.WithTask));
    Run(sut => sut.WithThread(), nameof(Sut.WithThread));
    Run(sut => sut.TaskInsideThread(), nameof(Sut.TaskInsideThread));
    Run(sut => sut.ThreadInsideTask(), nameof(Sut.ThreadInsideTask));
    Summary summary = BenchmarkRunner.Run<Sut>();
  }

  private static void Run(Action<Sut> func, string name)
  {
    Console.Write($"{name,18} ");
    int threadsBefore = Process.GetCurrentProcess().Threads.Count;
    int threadPoolBefore = ThreadPool.ThreadCount;
    Stopwatch sw = Stopwatch.StartNew();
    func(new Sut());
    sw.Stop();
    int threadsAfter = Process.GetCurrentProcess().Threads.Count;
    int threadPoolAfter = ThreadPool.ThreadCount;
    var threads = $"{threadsBefore}{threadsAfter - threadsBefore:+0;-#}={threadsAfter}";
    var threadPools = $"{threadPoolBefore}{(threadPoolAfter - threadPoolBefore):+0;-#}={threadPoolAfter}";

    Console.WriteLine($"elapsed:{sw.Elapsed} Threads:{threads,-10} ThreadPool:{threadPools}");
  }
}
