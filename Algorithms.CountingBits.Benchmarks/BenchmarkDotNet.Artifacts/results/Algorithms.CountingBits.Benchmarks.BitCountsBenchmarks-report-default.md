
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Core i7-4790 CPU 3.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.402
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-HWZFPC : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT

IterationCount=1  LaunchCount=1  WarmupCount=1  
Categories=BitCounts  

                                 Method |     Number |       Mean | Error | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
--------------------------------------- |----------- |-----------:|------:|------:|-----:|-------:|------:|------:|----------:|
               Precomputed2WordBitCount | 2147483647 |   1.969 ns |    NA | 0.004 |    1 |      - |     - |     - |         - |
              Precomputed4BytesBitCount | 2147483647 |   2.557 ns |    NA | 0.005 |    2 |      - |     - |     - |         - |
 PreComputedListManualRecursiveBitCount | 2147483647 |  15.780 ns |    NA | 0.033 |    3 |      - |     - |     - |         - |
                       IteratedBitCount | 2147483647 |  19.940 ns |    NA | 0.041 |    4 |      - |     - |     - |         - |
                         SparseBitCount | 2147483647 |  20.855 ns |    NA | 0.043 |    5 |      - |     - |     - |         - |
                          BitByBitCount | 2147483647 |  22.240 ns |    NA | 0.046 |    6 |      - |     - |     - |         - |
                      RecursiveBitCount | 2147483647 |  74.677 ns |    NA | 0.155 |    7 |      - |     - |     - |         - |
                       BitArrayBitCount | 2147483647 | 177.627 ns |    NA | 0.369 |    8 | 0.0362 |     - |     - |     152 B |
                           LinqBitCount | 2147483647 | 481.771 ns |    NA | 1.000 |    9 | 0.0286 |     - |     - |     120 B |
