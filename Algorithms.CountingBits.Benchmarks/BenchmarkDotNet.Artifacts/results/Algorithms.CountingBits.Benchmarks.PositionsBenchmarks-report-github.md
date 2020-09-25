``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.508 (2004/?/20H1)
Intel Core i7-4790 CPU 3.60GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=3.1.402
  [Host]     : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  Job-HWZFPC : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT

IterationCount=1  LaunchCount=1  WarmupCount=1  
Categories=Positions  

```
|                    Method |     Number |     Mean | Error | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------- |---------:|------:|------:|-----:|-------:|------:|------:|----------:|
|        BitsPositionByBits | 2147483647 | 143.8 ns |    NA |  1.00 |    1 | 0.0458 |     - |     - |     192 B |
|              BitPositions | 2147483647 | 144.5 ns |    NA |  1.00 |    1 | 0.0458 |     - |     - |     192 B |
| BitsPositionWithoutModule | 2147483647 | 150.7 ns |    NA |  1.04 |    2 | 0.0458 |     - |     - |     192 B |
|   BitsPositionUsingModule | 2147483647 | 161.8 ns |    NA |  1.12 |    3 | 0.0458 |     - |     - |     192 B |
|           LinqBitPosition | 2147483647 | 312.3 ns |    NA |  2.16 |    4 | 0.0629 |     - |     - |     264 B |
