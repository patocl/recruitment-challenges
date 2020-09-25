``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Core i7-4790 CPU 3.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.402
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-HWZFPC : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT

IterationCount=1  LaunchCount=1  WarmupCount=1  
Categories=OneStep-TheBest  

```
|                      Method |     Number |      Mean | Error | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----------- |----------:|------:|-----:|-------:|------:|------:|----------:|
|            **BitByBitGetCount** |          **1** |  **53.67 ns** |    **NA** |    **3** | **0.0153** |     **-** |     **-** |      **64 B** |
|            BitByBitGetCount |          3 |  55.87 ns |    NA |    4 | 0.0153 |     - |     - |      64 B |
|            BitByBitGetCount |          7 |  57.25 ns |    NA |    5 | 0.0153 |     - |     - |      64 B |
|            BitByBitGetCount |         15 |  81.17 ns |    NA |   10 | 0.0229 |     - |     - |      96 B |
|            BitByBitGetCount |         31 |  85.85 ns |    NA |   11 | 0.0229 |     - |     - |      96 B |
|            BitByBitGetCount |         63 |  86.65 ns |    NA |   11 | 0.0229 |     - |     - |      96 B |
|            BitByBitGetCount |        127 |  87.02 ns |    NA |   11 | 0.0229 |     - |     - |      96 B |
|            BitByBitGetCount |        255 | 110.73 ns |    NA |   15 | 0.0324 |     - |     - |     136 B |
|            BitByBitGetCount |        511 | 111.43 ns |    NA |   15 | 0.0324 |     - |     - |     136 B |
|            BitByBitGetCount |       1023 | 112.13 ns |    NA |   15 | 0.0324 |     - |     - |     136 B |
|            BitByBitGetCount |       2047 | 113.81 ns |    NA |   16 | 0.0324 |     - |     - |     136 B |
|            BitByBitGetCount |       4095 | 116.33 ns |    NA |   17 | 0.0324 |     - |     - |     136 B |
|            BitByBitGetCount |       8191 | 116.82 ns |    NA |   17 | 0.0324 |     - |     - |     136 B |
|            BitByBitGetCount |      16383 | 121.41 ns |    NA |   19 | 0.0324 |     - |     - |     136 B |
|            BitByBitGetCount |      32767 | 121.06 ns |    NA |   19 | 0.0324 |     - |     - |     136 B |
|            BitByBitGetCount |      65535 | 142.60 ns |    NA |   21 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |     131071 | 144.54 ns |    NA |   22 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |     262143 | 147.45 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |     524287 | 152.95 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |    1048575 | 151.99 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |    2097151 | 147.45 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |    4194303 | 149.60 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |    8388607 | 150.34 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |   16777215 | 151.72 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |   33554431 | 156.53 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |   67108863 | 155.88 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |  134217727 | 157.42 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |  268435455 | 157.45 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount |  536870911 | 158.44 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount | 1073741823 | 160.48 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
|            BitByBitGetCount | 2147483647 | 158.50 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
| **BitByBitGetCountRevengeLog2** |          **1** |  **38.99 ns** |    **NA** |    **1** | **0.0153** |     **-** |     **-** |      **64 B** |
| BitByBitGetCountRevengeLog2 |          3 |  39.36 ns |    NA |    1 | 0.0153 |     - |     - |      64 B |
| BitByBitGetCountRevengeLog2 |          7 |  44.73 ns |    NA |    2 | 0.0153 |     - |     - |      64 B |
| BitByBitGetCountRevengeLog2 |         15 |  69.11 ns |    NA |    6 | 0.0229 |     - |     - |      96 B |
| BitByBitGetCountRevengeLog2 |         31 |  71.13 ns |    NA |    7 | 0.0229 |     - |     - |      96 B |
| BitByBitGetCountRevengeLog2 |         63 |  75.82 ns |    NA |    8 | 0.0229 |     - |     - |      96 B |
| BitByBitGetCountRevengeLog2 |        127 |  77.12 ns |    NA |    9 | 0.0229 |     - |     - |      96 B |
| BitByBitGetCountRevengeLog2 |        255 | 102.37 ns |    NA |   12 | 0.0324 |     - |     - |     136 B |
| BitByBitGetCountRevengeLog2 |        511 | 106.03 ns |    NA |   13 | 0.0324 |     - |     - |     136 B |
| BitByBitGetCountRevengeLog2 |       1023 | 108.87 ns |    NA |   14 | 0.0324 |     - |     - |     136 B |
| BitByBitGetCountRevengeLog2 |       2047 | 110.43 ns |    NA |   15 | 0.0324 |     - |     - |     136 B |
| BitByBitGetCountRevengeLog2 |       4095 | 112.64 ns |    NA |   15 | 0.0324 |     - |     - |     136 B |
| BitByBitGetCountRevengeLog2 |       8191 | 118.72 ns |    NA |   18 | 0.0324 |     - |     - |     136 B |
| BitByBitGetCountRevengeLog2 |      16383 | 132.40 ns |    NA |   20 | 0.0324 |     - |     - |     136 B |
| BitByBitGetCountRevengeLog2 |      32767 | 118.04 ns |    NA |   18 | 0.0324 |     - |     - |     136 B |
| BitByBitGetCountRevengeLog2 |      65535 | 148.88 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |     131071 | 150.86 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |     262143 | 151.87 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |     524287 | 153.20 ns |    NA |   23 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |    1048575 | 162.29 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |    2097151 | 158.80 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |    4194303 | 163.44 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |    8388607 | 160.06 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |   16777215 | 161.99 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |   33554431 | 164.73 ns |    NA |   24 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |   67108863 | 171.18 ns |    NA |   25 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |  134217727 | 170.66 ns |    NA |   25 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |  268435455 | 176.87 ns |    NA |   26 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 |  536870911 | 172.40 ns |    NA |   25 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 | 1073741823 | 178.53 ns |    NA |   26 | 0.0458 |     - |     - |     192 B |
| BitByBitGetCountRevengeLog2 | 2147483647 | 173.71 ns |    NA |   25 | 0.0458 |     - |     - |     192 B |
