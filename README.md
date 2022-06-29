# RaplReadBenchmark

// * Summary *

BenchmarkDotNet=v0.13.1, OS=ubuntu 20.04
Intel Core i9-9900K CPU 3.60GHz (Coffee Lake), 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.201
  [Host]   : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT
  .NET 6.0 : .NET 6.0.3 (6.0.322.12309), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0

|                                Method |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |
|-------------------------------------- |---------:|---------:|---------:|---------:|------:|--------:|
|                       Read_rapl_value | 957.9 ms |  2.59 ms |  2.42 ms | 958.0 ms |  1.00 |    0.00 |
|           Read_rapl_value_no_fileopen | 148.4 ms | 11.79 ms | 34.77 ms | 164.9 ms |  0.16 |    0.03 |
|    Read_rapl_value_no_fileopen_buffer | 166.4 ms |  0.49 ms |  0.46 ms | 166.5 ms |  0.17 |    0.00 |
| Read_rapl_value_no_fileopen_readtoend | 107.2 ms |  1.35 ms |  2.50 ms | 106.8 ms |  0.11 |    0.00 |

// * Hints *
Outliers
  RaplBench.Read_rapl_value_no_fileopen: .NET 6.0           -> 21 outliers were detected (72.45 ms..154.77 ms)
  RaplBench.Read_rapl_value_no_fileopen_readtoend: .NET 6.0 -> 14 outliers were removed (198.34 ms..205.09 ms)

// * Legends *
  Mean    : Arithmetic mean of all measurements
  Error   : Half of 99.9% confidence interval
  StdDev  : Standard deviation of all measurements
  Median  : Value separating the higher half of all measurements (50th percentile)
  Ratio   : Mean of the ratio distribution ([Current]/[Baseline])
  RatioSD : Standard deviation of the ratio distribution ([Current]/[Baseline])
  1 ms    : 1 Millisecond (0.001 sec)

// * Detailed results *
RaplBench.Read_rapl_value: .NET 6.0(Runtime=.NET 6.0)
Runtime = .NET 6.0.3 (6.0.322.12309), X64 RyuJIT; GC = Concurrent Workstation
Mean = 957.890 ms, StdErr = 0.626 ms (0.07%), N = 15, StdDev = 2.425 ms
Min = 952.338 ms, Q1 = 956.434 ms, Median = 957.984 ms, Q3 = 959.247 ms, Max = 961.672 ms
IQR = 2.813 ms, LowerFence = 952.214 ms, UpperFence = 963.467 ms
ConfidenceInterval = [955.297 ms; 960.482 ms] (CI 99.9%), Margin = 2.592 ms (0.27% of Mean)
Skewness = -0.34, Kurtosis = 2.67, MValue = 2
-------------------- Histogram --------------------
[951.048 ms ; 962.962 ms) | @@@@@@@@@@@@@@@
---------------------------------------------------

RaplBench.Read_rapl_value_no_fileopen: .NET 6.0(Runtime=.NET 6.0)
Runtime = .NET 6.0.3 (6.0.322.12309), X64 RyuJIT; GC = Concurrent Workstation
Mean = 148.377 ms, StdErr = 3.477 ms (2.34%), N = 100, StdDev = 34.769 ms
Min = 72.450 ms, Q1 = 162.127 ms, Median = 164.883 ms, Q3 = 165.591 ms, Max = 167.538 ms
IQR = 3.464 ms, LowerFence = 156.931 ms, UpperFence = 170.788 ms
ConfidenceInterval = [136.585 ms; 160.169 ms] (CI 99.9%), Margin = 11.792 ms (7.95% of Mean)
Skewness = -1.67, Kurtosis = 3.87, MValue = 2
-------------------- Histogram --------------------
[ 62.618 ms ;  82.506 ms) | @@@@@@@@@@@@@@@@@
[ 82.506 ms ; 102.169 ms) |
[102.169 ms ; 125.914 ms) |
[125.914 ms ; 149.472 ms) | @@
[149.472 ms ; 169.136 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
---------------------------------------------------

RaplBench.Read_rapl_value_no_fileopen_buffer: .NET 6.0(Runtime=.NET 6.0)
Runtime = .NET 6.0.3 (6.0.322.12309), X64 RyuJIT; GC = Concurrent Workstation
Mean = 166.410 ms, StdErr = 0.118 ms (0.07%), N = 15, StdDev = 0.455 ms
Min = 165.602 ms, Q1 = 165.988 ms, Median = 166.456 ms, Q3 = 166.760 ms, Max = 167.144 ms
IQR = 0.771 ms, LowerFence = 164.832 ms, UpperFence = 167.916 ms
ConfidenceInterval = [165.923 ms; 166.896 ms] (CI 99.9%), Margin = 0.487 ms (0.29% of Mean)
Skewness = -0.23, Kurtosis = 1.7, MValue = 2
-------------------- Histogram --------------------
[165.360 ms ; 167.386 ms) | @@@@@@@@@@@@@@@
---------------------------------------------------

RaplBench.Read_rapl_value_no_fileopen_readtoend: .NET 6.0(Runtime=.NET 6.0)
Runtime = .NET 6.0.3 (6.0.322.12309), X64 RyuJIT; GC = Concurrent Workstation
Mean = 107.169 ms, StdErr = 0.381 ms (0.36%), N = 43, StdDev = 2.502 ms
Min = 106.461 ms, Q1 = 106.687 ms, Median = 106.779 ms, Q3 = 106.890 ms, Max = 123.155 ms
IQR = 0.203 ms, LowerFence = 106.383 ms, UpperFence = 107.194 ms
ConfidenceInterval = [105.820 ms; 108.519 ms] (CI 99.9%), Margin = 1.350 ms (1.26% of Mean)
Skewness = 6.06, Kurtosis = 38.79, MValue = 2
-------------------- Histogram --------------------
[105.786 ms ; 109.797 ms) | @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
[109.797 ms ; 113.546 ms) |
[113.546 ms ; 117.294 ms) |
[117.294 ms ; 121.043 ms) |
[121.043 ms ; 124.093 ms) | @
---------------------------------------------------
