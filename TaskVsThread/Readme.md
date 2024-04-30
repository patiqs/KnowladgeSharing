          WithTask elapsed:00:00:00.1156904 Threads:8+14=22    ThreadPool:0+12=12
        WithThread elapsed:00:00:00.7304499 Threads:22+0=22    ThreadPool:12+0=12
  TaskInsideThread elapsed:00:00:00.7857399 Threads:22+0=22    ThreadPool:12+0=12
  ThreadInsideTask elapsed:00:00:50.0421775 Threads:22+25=47   ThreadPool:12+23=35
          WithTask elapsed:00:00:00.1169033 Threads:47+0=47    ThreadPool:35+0=35
        WithThread elapsed:00:00:00.7376121 Threads:47+0=47    ThreadPool:35+0=35
  TaskInsideThread elapsed:00:00:00.8337092 Threads:47+0=47    ThreadPool:35+0=35
  ThreadInsideTask elapsed:00:00:41.1911193 Threads:47+0=47    ThreadPool:35+4=39
]9;4;3;0\// Validating benchmarks:
// ***** BenchmarkRunner: Start   *****
// ***** Found 5 benchmark(s) in total *****
// ***** Building 1 exe(s) in Parallel: Start   *****
// start dotnet  restore /p:UseSharedCompilation=false /p:BuildInParallel=false /m:1 /p:Deterministic=true /p:Optimize=true in c:\git\KnowledgeSharing\TaskVsThread\bin\Release\net8.0\01c0b12a-4816-4ae4-9426-a2ce6d5461d9
// command took 1.19 sec and exited with 0
// start dotnet  build -c Release --no-restore /p:UseSharedCompilation=false /p:BuildInParallel=false /m:1 /p:Deterministic=true /p:Optimize=true in c:\git\KnowledgeSharing\TaskVsThread\bin\Release\net8.0\01c0b12a-4816-4ae4-9426-a2ce6d5461d9
// command took 14.07 sec and exited with 1
// start dotnet  build -c Release --no-restore --no-dependencies /p:UseSharedCompilation=false /p:BuildInParallel=false /m:1 /p:Deterministic=true /p:Optimize=true in c:\git\KnowledgeSharing\TaskVsThread\bin\Release\net8.0\01c0b12a-4816-4ae4-9426-a2ce6d5461d9
// command took 2.49 sec and exited with 0
// ***** Done, took 00:00:17 (17.83 sec)   *****
// Found 5 benchmarks:
//   Sut.WithTask: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
//   Sut.WithTaskAsync: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
//   Sut.WithThread: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
//   Sut.TaskInsideThread: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
//   Sut.ThreadInsideTask: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)

Setup power plan (GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c FriendlyName: High performance)
// **************************
// Benchmark: Sut.WithTask: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
// *** Execute ***
// Launch: 1 / 1
// Execute: dotnet 01c0b12a-4816-4ae4-9426-a2ce6d5461d9.dll --anonymousPipes 121660 121680 --benchmarkName TaskVsThread.Sut.WithTask --job ShortRun --benchmarkId 0 in c:\git\KnowledgeSharing\TaskVsThread\bin\Release\net8.0\01c0b12a-4816-4ae4-9426-a2ce6d5461d9\bin\Release\net8.0
// BeforeAnythingElse

// Benchmark Process Environment Information:
// BenchmarkDotNet v0.13.12
// Runtime=.NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
// GC=Concurrent Workstation
// HardwareIntrinsics=AVX2,AES,BMI1,BMI2,FMA,LZCNT,PCLMUL,POPCNT,AvxVnni,SERIALIZE VectorSize=256
// Job: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)

OverheadJitting  1: 1 op, 143300.00 ns, 143.3000 us/op
WorkloadJitting  1: 1 op, 115060700.00 ns, 115.0607 ms/op

WorkloadPilot    1: 2 op, 230367400.00 ns, 115.1837 ms/op
WorkloadPilot    2: 3 op, 339243300.00 ns, 113.0811 ms/op
WorkloadPilot    3: 4 op, 445293600.00 ns, 111.3234 ms/op
WorkloadPilot    4: 5 op, 551186800.00 ns, 110.2374 ms/op

WorkloadWarmup   1: 5 op, 559612200.00 ns, 111.9224 ms/op
WorkloadWarmup   2: 5 op, 556569400.00 ns, 111.3139 ms/op
WorkloadWarmup   3: 5 op, 544751300.00 ns, 108.9503 ms/op

// BeforeActualRun
WorkloadActual   1: 5 op, 561288700.00 ns, 112.2577 ms/op
WorkloadActual   2: 5 op, 551666900.00 ns, 110.3334 ms/op
WorkloadActual   3: 5 op, 561723500.00 ns, 112.3447 ms/op

// AfterActualRun
WorkloadResult   1: 5 op, 561288700.00 ns, 112.2577 ms/op
WorkloadResult   2: 5 op, 551666900.00 ns, 110.3334 ms/op
WorkloadResult   3: 5 op, 561723500.00 ns, 112.3447 ms/op
// GC:  3 2 0 24802168 5
// Threading:  100000 75 5

// AfterAll
// Benchmark Process 109772 has exited with code 0.

Mean = 111.645 ms, StdErr = 0.656 ms (0.59%), N = 3, StdDev = 1.137 ms
Min = 110.333 ms, Q1 = 111.296 ms, Median = 112.258 ms, Q3 = 112.301 ms, Max = 112.345 ms
IQR = 1.006 ms, LowerFence = 109.787 ms, UpperFence = 113.810 ms
ConfidenceInterval = [90.903 ms; 132.388 ms] (CI 99.9%), Margin = 20.742 ms (18.58% of Mean)
Skewness = -0.38, Kurtosis = 0.67, MValue = 2

// ** Remained 4 (80,0%) benchmark(s) to run. Estimated finish 2024-04-30 15:24 (0h 0m from now) **
]9;4;1;20\Setup power plan (GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c FriendlyName: High performance)
// **************************
// Benchmark: Sut.WithTaskAsync: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
// *** Execute ***
// Launch: 1 / 1
// Execute: dotnet 01c0b12a-4816-4ae4-9426-a2ce6d5461d9.dll --anonymousPipes 123200 65612 --benchmarkName TaskVsThread.Sut.WithTaskAsync --job ShortRun --benchmarkId 1 in c:\git\KnowledgeSharing\TaskVsThread\bin\Release\net8.0\01c0b12a-4816-4ae4-9426-a2ce6d5461d9\bin\Release\net8.0
// BeforeAnythingElse

// Benchmark Process Environment Information:
// BenchmarkDotNet v0.13.12
// Runtime=.NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
// GC=Concurrent Workstation
// HardwareIntrinsics=AVX2,AES,BMI1,BMI2,FMA,LZCNT,PCLMUL,POPCNT,AvxVnni,SERIALIZE VectorSize=256
// Job: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)

OverheadJitting  1: 1 op, 165500.00 ns, 165.5000 us/op
WorkloadJitting  1: 1 op, 119038200.00 ns, 119.0382 ms/op

WorkloadPilot    1: 2 op, 230154000.00 ns, 115.0770 ms/op
WorkloadPilot    2: 3 op, 346648200.00 ns, 115.5494 ms/op
WorkloadPilot    3: 4 op, 438801800.00 ns, 109.7005 ms/op
WorkloadPilot    4: 5 op, 569729000.00 ns, 113.9458 ms/op

WorkloadWarmup   1: 5 op, 548792800.00 ns, 109.7586 ms/op
WorkloadWarmup   2: 5 op, 568381400.00 ns, 113.6763 ms/op
WorkloadWarmup   3: 5 op, 550496800.00 ns, 110.0994 ms/op

// BeforeActualRun
WorkloadActual   1: 5 op, 562613200.00 ns, 112.5226 ms/op
WorkloadActual   2: 5 op, 567163200.00 ns, 113.4326 ms/op
WorkloadActual   3: 5 op, 565705300.00 ns, 113.1411 ms/op

// AfterActualRun
WorkloadResult   1: 5 op, 562613200.00 ns, 112.5226 ms/op
WorkloadResult   2: 5 op, 567163200.00 ns, 113.4326 ms/op
WorkloadResult   3: 5 op, 565705300.00 ns, 113.1411 ms/op
// GC:  3 2 0 24402520 5
// Threading:  100000 84 5

// AfterAll
// Benchmark Process 69124 has exited with code 0.

Mean = 113.032 ms, StdErr = 0.268 ms (0.24%), N = 3, StdDev = 0.465 ms
Min = 112.523 ms, Q1 = 112.832 ms, Median = 113.141 ms, Q3 = 113.287 ms, Max = 113.433 ms
IQR = 0.455 ms, LowerFence = 112.149 ms, UpperFence = 113.969 ms
ConfidenceInterval = [104.555 ms; 121.510 ms] (CI 99.9%), Margin = 8.477 ms (7.50% of Mean)
Skewness = -0.22, Kurtosis = 0.67, MValue = 2

// ** Remained 3 (60,0%) benchmark(s) to run. Estimated finish 2024-04-30 15:24 (0h 0m from now) **
]9;4;1;40\Setup power plan (GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c FriendlyName: High performance)
// **************************
// Benchmark: Sut.WithThread: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
// *** Execute ***
// Launch: 1 / 1
// Execute: dotnet 01c0b12a-4816-4ae4-9426-a2ce6d5461d9.dll --anonymousPipes 123200 65612 --benchmarkName TaskVsThread.Sut.WithThread --job ShortRun --benchmarkId 2 in c:\git\KnowledgeSharing\TaskVsThread\bin\Release\net8.0\01c0b12a-4816-4ae4-9426-a2ce6d5461d9\bin\Release\net8.0
// BeforeAnythingElse

// Benchmark Process Environment Information:
// BenchmarkDotNet v0.13.12
// Runtime=.NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
// GC=Concurrent Workstation
// HardwareIntrinsics=AVX2,AES,BMI1,BMI2,FMA,LZCNT,PCLMUL,POPCNT,AvxVnni,SERIALIZE VectorSize=256
// Job: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)

OverheadJitting  1: 1 op, 161200.00 ns, 161.2000 us/op
WorkloadJitting  1: 1 op, 832112700.00 ns, 832.1127 ms/op

OverheadJitting  2: 1 op, 400.00 ns, 400.0000 ns/op
WorkloadJitting  2: 1 op, 746346600.00 ns, 746.3466 ms/op

WorkloadWarmup   1: 1 op, 730775600.00 ns, 730.7756 ms/op
WorkloadWarmup   2: 1 op, 735986100.00 ns, 735.9861 ms/op
WorkloadWarmup   3: 1 op, 792958200.00 ns, 792.9582 ms/op

// BeforeActualRun
WorkloadActual   1: 1 op, 759806400.00 ns, 759.8064 ms/op
WorkloadActual   2: 1 op, 737577000.00 ns, 737.5770 ms/op
WorkloadActual   3: 1 op, 838511700.00 ns, 838.5117 ms/op

// AfterActualRun
WorkloadResult   1: 1 op, 759806400.00 ns, 759.8064 ms/op
WorkloadResult   2: 1 op, 737577000.00 ns, 737.5770 ms/op
WorkloadResult   3: 1 op, 838511700.00 ns, 838.5117 ms/op
// GC:  3 3 3 2081584 1
// Threading:  0 0 1

// AfterAll
// Benchmark Process 111872 has exited with code 0.

Mean = 778.632 ms, StdErr = 30.620 ms (3.93%), N = 3, StdDev = 53.035 ms
Min = 737.577 ms, Q1 = 748.692 ms, Median = 759.806 ms, Q3 = 799.159 ms, Max = 838.512 ms
IQR = 50.467 ms, LowerFence = 672.991 ms, UpperFence = 874.860 ms
ConfidenceInterval = [-188.930 ms; 1,746.194 ms] (CI 99.9%), Margin = 967.562 ms (124.26% of Mean)
Skewness = 0.31, Kurtosis = 0.67, MValue = 2

// ** Remained 2 (40,0%) benchmark(s) to run. Estimated finish 2024-04-30 15:24 (0h 0m from now) **
]9;4;1;60\Setup power plan (GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c FriendlyName: High performance)
// **************************
// Benchmark: Sut.TaskInsideThread: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
// *** Execute ***
// Launch: 1 / 1
// Execute: dotnet 01c0b12a-4816-4ae4-9426-a2ce6d5461d9.dll --anonymousPipes 123284 123268 --benchmarkName TaskVsThread.Sut.TaskInsideThread --job ShortRun --benchmarkId 3 in c:\git\KnowledgeSharing\TaskVsThread\bin\Release\net8.0\01c0b12a-4816-4ae4-9426-a2ce6d5461d9\bin\Release\net8.0
// BeforeAnythingElse

// Benchmark Process Environment Information:
// BenchmarkDotNet v0.13.12
// Runtime=.NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
// GC=Concurrent Workstation
// HardwareIntrinsics=AVX2,AES,BMI1,BMI2,FMA,LZCNT,PCLMUL,POPCNT,AvxVnni,SERIALIZE VectorSize=256
// Job: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)

OverheadJitting  1: 1 op, 177700.00 ns, 177.7000 us/op
WorkloadJitting  1: 1 op, 1023045000.00 ns, 1.0230 s/op

OverheadJitting  2: 1 op, 700.00 ns, 700.0000 ns/op
WorkloadJitting  2: 1 op, 972861200.00 ns, 972.8612 ms/op

WorkloadWarmup   1: 1 op, 1148744000.00 ns, 1.1487 s/op
WorkloadWarmup   2: 1 op, 1078790700.00 ns, 1.0788 s/op
WorkloadWarmup   3: 1 op, 968695100.00 ns, 968.6951 ms/op

// BeforeActualRun
WorkloadActual   1: 1 op, 973383500.00 ns, 973.3835 ms/op
WorkloadActual   2: 1 op, 949727700.00 ns, 949.7277 ms/op
WorkloadActual   3: 1 op, 994493600.00 ns, 994.4936 ms/op

// AfterActualRun
WorkloadResult   1: 1 op, 973383500.00 ns, 973.3835 ms/op
WorkloadResult   2: 1 op, 949727700.00 ns, 949.7277 ms/op
WorkloadResult   3: 1 op, 994493600.00 ns, 994.4936 ms/op
// GC:  7 5 3 7202736 1
// Threading:  10002 2114 1

// AfterAll
// Benchmark Process 113324 has exited with code 0.

Mean = 972.535 ms, StdErr = 12.930 ms (1.33%), N = 3, StdDev = 22.395 ms
Min = 949.728 ms, Q1 = 961.556 ms, Median = 973.384 ms, Q3 = 983.939 ms, Max = 994.494 ms
IQR = 22.383 ms, LowerFence = 927.981 ms, UpperFence = 1,017.513 ms
ConfidenceInterval = [563.967 ms; 1,381.103 ms] (CI 99.9%), Margin = 408.568 ms (42.01% of Mean)
Skewness = -0.04, Kurtosis = 0.67, MValue = 2

// ** Remained 1 (20,0%) benchmark(s) to run. Estimated finish 2024-04-30 15:24 (0h 0m from now) **
]9;4;1;80\Setup power plan (GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c FriendlyName: High performance)
// **************************
// Benchmark: Sut.ThreadInsideTask: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
// *** Execute ***
// Launch: 1 / 1
// Execute: dotnet 01c0b12a-4816-4ae4-9426-a2ce6d5461d9.dll --anonymousPipes 123284 123268 --benchmarkName TaskVsThread.Sut.ThreadInsideTask --job ShortRun --benchmarkId 4 in c:\git\KnowledgeSharing\TaskVsThread\bin\Release\net8.0\01c0b12a-4816-4ae4-9426-a2ce6d5461d9\bin\Release\net8.0
// BeforeAnythingElse

// Benchmark Process Environment Information:
// BenchmarkDotNet v0.13.12
// Runtime=.NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
// GC=Concurrent Workstation
// HardwareIntrinsics=AVX2,AES,BMI1,BMI2,FMA,LZCNT,PCLMUL,POPCNT,AvxVnni,SERIALIZE VectorSize=256
// Job: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)

OverheadJitting  1: 1 op, 163900.00 ns, 163.9000 us/op
WorkloadJitting  1: 1 op, 47428493500.00 ns, 47.4285 s/op

WorkloadWarmup   1: 1 op, 24514447500.00 ns, 24.5144 s/op
WorkloadWarmup   2: 1 op, 16775125400.00 ns, 16.7751 s/op
WorkloadWarmup   3: 1 op, 13825980300.00 ns, 13.8260 s/op

// BeforeActualRun
WorkloadActual   1: 1 op, 12610802900.00 ns, 12.6108 s/op
WorkloadActual   2: 1 op, 11494458000.00 ns, 11.4945 s/op
WorkloadActual   3: 1 op, 10273541500.00 ns, 10.2735 s/op

// AfterActualRun
WorkloadResult   1: 1 op, 12610802900.00 ns, 12.6108 s/op
WorkloadResult   2: 1 op, 11494458000.00 ns, 11.4945 s/op
WorkloadResult   3: 1 op, 10273541500.00 ns, 10.2735 s/op
// GC:  0 0 0 1461752 1
// Threading:  10000 6 1

// AfterAll
// Benchmark Process 127864 has exited with code 0.

Mean = 11.460 s, StdErr = 0.675 s (5.89%), N = 3, StdDev = 1.169 s
Min = 10.274 s, Q1 = 10.884 s, Median = 11.494 s, Q3 = 12.053 s, Max = 12.611 s
IQR = 1.169 s, LowerFence = 9.131 s, UpperFence = 13.806 s
ConfidenceInterval = [-9.868 s; 32.787 s] (CI 99.9%), Margin = 21.327 s (186.11% of Mean)
Skewness = -0.03, Kurtosis = 0.67, MValue = 2

// ** Remained 0 (0,0%) benchmark(s) to run. Estimated finish 2024-04-30 15:26 (0h 0m from now) **
]9;4;1;100\Successfully reverted power plan (GUID: 8c5e7fda-e8bf-4a96-9a85-a6e23a8c635c FriendlyName: High performance)
// ***** BenchmarkRunner: Finish  *****

// * Export *
  BenchmarkDotNet.Artifacts\results\TaskVsThread.Sut-report.csv
  BenchmarkDotNet.Artifacts\results\TaskVsThread.Sut-report-github.md
  BenchmarkDotNet.Artifacts\results\TaskVsThread.Sut-report.html

// * Detailed results *
Sut.WithTask: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
Runtime = .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 111.645 ms, StdErr = 0.656 ms (0.59%), N = 3, StdDev = 1.137 ms
Min = 110.333 ms, Q1 = 111.296 ms, Median = 112.258 ms, Q3 = 112.301 ms, Max = 112.345 ms
IQR = 1.006 ms, LowerFence = 109.787 ms, UpperFence = 113.810 ms
ConfidenceInterval = [90.903 ms; 132.388 ms] (CI 99.9%), Margin = 20.742 ms (18.58% of Mean)
Skewness = -0.38, Kurtosis = 0.67, MValue = 2
-------------------- Histogram --------------------
[110.304 ms ; 112.374 ms) | @@@
---------------------------------------------------

Sut.WithTaskAsync: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
Runtime = .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 113.032 ms, StdErr = 0.268 ms (0.24%), N = 3, StdDev = 0.465 ms
Min = 112.523 ms, Q1 = 112.832 ms, Median = 113.141 ms, Q3 = 113.287 ms, Max = 113.433 ms
IQR = 0.455 ms, LowerFence = 112.149 ms, UpperFence = 113.969 ms
ConfidenceInterval = [104.555 ms; 121.510 ms] (CI 99.9%), Margin = 8.477 ms (7.50% of Mean)
Skewness = -0.22, Kurtosis = 0.67, MValue = 2
-------------------- Histogram --------------------
[112.100 ms ; 113.856 ms) | @@@
---------------------------------------------------

Sut.WithThread: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
Runtime = .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 778.632 ms, StdErr = 30.620 ms (3.93%), N = 3, StdDev = 53.035 ms
Min = 737.577 ms, Q1 = 748.692 ms, Median = 759.806 ms, Q3 = 799.159 ms, Max = 838.512 ms
IQR = 50.467 ms, LowerFence = 672.991 ms, UpperFence = 874.860 ms
ConfidenceInterval = [-188.930 ms; 1,746.194 ms] (CI 99.9%), Margin = 967.562 ms (124.26% of Mean)
Skewness = 0.31, Kurtosis = 0.67, MValue = 2
-------------------- Histogram --------------------
[700.428 ms ; 796.956 ms) | @@
[796.956 ms ; 886.776 ms) | @
---------------------------------------------------

Sut.TaskInsideThread: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
Runtime = .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 972.535 ms, StdErr = 12.930 ms (1.33%), N = 3, StdDev = 22.395 ms
Min = 949.728 ms, Q1 = 961.556 ms, Median = 973.384 ms, Q3 = 983.939 ms, Max = 994.494 ms
IQR = 22.383 ms, LowerFence = 927.981 ms, UpperFence = 1,017.513 ms
ConfidenceInterval = [563.967 ms; 1,381.103 ms] (CI 99.9%), Margin = 408.568 ms (42.01% of Mean)
Skewness = -0.04, Kurtosis = 0.67, MValue = 2
-------------------- Histogram --------------------
[929.347 ms ;   963.558 ms) | @
[963.558 ms ; 1,004.319 ms) | @@
---------------------------------------------------

Sut.ThreadInsideTask: ShortRun(IterationCount=3, LaunchCount=1, WarmupCount=3)
Runtime = .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2; GC = Concurrent Workstation
Mean = 11.460 s, StdErr = 0.675 s (5.89%), N = 3, StdDev = 1.169 s
Min = 10.274 s, Q1 = 10.884 s, Median = 11.494 s, Q3 = 12.053 s, Max = 12.611 s
IQR = 1.169 s, LowerFence = 9.131 s, UpperFence = 13.806 s
ConfidenceInterval = [-9.868 s; 32.787 s] (CI 99.9%), Margin = 21.327 s (186.11% of Mean)
Skewness = -0.03, Kurtosis = 0.67, MValue = 2
-------------------- Histogram --------------------
[ 9.210 s ; 10.989 s) | @
[10.989 s ; 13.116 s) | @@
---------------------------------------------------

// * Summary *

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
12th Gen Intel Core i5-1235U, 1 CPU, 12 logical and 10 physical cores
.NET SDK 8.0.200
  [Host]   : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2
  ShortRun : .NET 8.0.2 (8.0.224.6711), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

| Method           | Mean        | Error        | StdDev      | Gen0      | Completed Work Items | Lock Contentions | Gen1      | Gen2      | Allocated |
|----------------- |------------:|-------------:|------------:|----------:|---------------------:|-----------------:|----------:|----------:|----------:|
| WithTask         |    111.6 ms |     20.74 ms |     1.14 ms |  600.0000 |           20000.0000 |          15.0000 |  400.0000 |         - |   4.73 MB |
| WithTaskAsync    |    113.0 ms |      8.48 ms |     0.46 ms |  600.0000 |           20000.0000 |          16.8000 |  400.0000 |         - |   4.65 MB |
| WithThread       |    778.6 ms |    967.56 ms |    53.04 ms | 3000.0000 |                    - |                - | 3000.0000 | 3000.0000 |   1.99 MB |
| TaskInsideThread |    972.5 ms |    408.57 ms |    22.40 ms | 7000.0000 |           10002.0000 |        2114.0000 | 5000.0000 | 3000.0000 |   6.87 MB |
| ThreadInsideTask | 11,459.6 ms | 21,327.29 ms | 1,169.02 ms |         - |           10000.0000 |           6.0000 |         - |         - |   1.39 MB |

// * Legends *
  Mean                 : Arithmetic mean of all measurements
  Error                : Half of 99.9% confidence interval
  StdDev               : Standard deviation of all measurements
  Gen0                 : GC Generation 0 collects per 1000 operations
  Completed Work Items : The number of work items that have been processed in ThreadPool (per single operation)
  Lock Contentions     : The number of times there was contention upon trying to take a Monitor's lock (per single operation)
  Gen1                 : GC Generation 1 collects per 1000 operations
  Gen2                 : GC Generation 2 collects per 1000 operations
  Allocated            : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 ms                 : 1 Millisecond (0.001 sec)

// * Diagnostic Output - ThreadingDiagnoser *

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
Run time: 00:02:55 (175.58 sec), executed benchmarks: 5

Global total time: 00:03:13 (193.63 sec), executed benchmarks: 5
// * Artifacts cleanup *
Artifacts cleanup is finished
]9;4;0;0\