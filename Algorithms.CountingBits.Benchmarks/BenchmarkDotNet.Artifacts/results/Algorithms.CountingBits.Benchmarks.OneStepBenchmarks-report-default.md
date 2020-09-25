
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Core i7-4790 CPU 3.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.402
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-HWZFPC : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT

IterationCount=1  LaunchCount=1  WarmupCount=1  
Categories=OneStep  

                                              Method |     Number |       Mean | Error | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
---------------------------------------------------- |----------- |-----------:|------:|------:|-----:|-------:|------:|------:|----------:|
                                    BitByBitGetCount | 2147483647 |   160.1 ns |    NA |  0.70 |    1 | 0.0458 |     - |     - |     192 B |
                         BitByBitGetCountRevengeLog2 | 2147483647 |   177.9 ns |    NA |  0.78 |    2 | 0.0458 |     - |     - |     192 B |
 PreComputed2WordsBitCountBitsPositionByBitsGetCount | 2147483647 |   225.5 ns |    NA |  0.99 |    3 | 0.0744 |     - |     - |     312 B |
        Precomputed2WordBitCountBitPositionsGetCount | 2147483647 |   227.1 ns |    NA |  1.00 |    3 | 0.0744 |     - |     - |     312 B |
                            NetFrameworkModeGetCount | 2147483647 |   991.0 ns |    NA |  4.36 |    4 | 0.1373 |     - |     - |     576 B |
                                        LinqGetCount | 2147483647 | 2,109.1 ns |    NA |  9.29 |    5 | 0.1945 |     - |     - |     824 B |
