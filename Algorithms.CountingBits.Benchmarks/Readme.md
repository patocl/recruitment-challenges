# Solution proposed for the Counting bits challenge

## Introduction

To solve this problem, I perform deep research over the internet, because isn't a trivial task, so I must refresh my concepts about bitwise operations!

I'd figured that exists 2 way to perform the requested task

**Calculate the values using algorithms composition**

Steps:
- Calculate the number of bits set(1)
- Calculate the bits position in reverse mode
- Create the List with the results obtained

**Calculate all in one single step**

Step:
- Calculate the position for each bit set and count it just using one Loop(same procedure) and compose the result List on the fly.

*My assumption*

>Calculate it using Composition should be faster than One Step

## Implementation

I created 3 classes with all these algorithms on Library folder

- Number of bits
- Position of bits
- PositiveBigCounter (all-in-one mode)

**To improve the perform**
- I'd avoid using the "new" keyword and make it static class and with statics methods
- I'd try to avoid use of Division, Modulus and Square root operations, because are expensive
- In terms on memmory I'd adjust the types used to the minimum possible eg. ``` List<byte>``` instead ``` List<int>``` 

I created many the unit tests, to validate the calculus and ensure that my algorithms are right.

## Selection the best Algorithm

After implemented and validated, I must to select the faster one, so I created a new project to evaluate it using the .NET Library [BenchmarkDotNet](https://benchmarkdotnet.org/index.html) on [github repository](https://github.com/dotnet/BenchmarkDotNet)

### Some Steps to run the Benchmark project

The Solution should be compiled on Release Mode

I prefer to run it from the command line, open a terminal (CMD or Powershell) Ctrl + ~ on Visual Studio

Go to folder solution and run the following commands

Compile the solution on Release Mode

```shell
dotnet build -c Release
```

Execute the Benchamark
```shell
dotnet .\bin\Release\netcoreapp3.1\Algorithms.CountingBits.Benchmarks.dll
```

It's could take a few minutes, the console will start to display the progress work!
When it be finished you will be able to review the results, maybe u just scroll up a bit 

Anyways, I configured the Benchmark project to generate Markdown on folder Results!
The Benchmark has benn categorized, please review each category and was used two

### Results obtained on my own PC

``` ini
Categories=BitCounts  
```
|                                 Method |     Number |       Mean | Error | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------------------- |----------- |-----------:|------:|------:|-----:|-------:|------:|------:|----------:|
|               Precomputed2WordBitCount | 2147483647 |   1.969 ns |    NA | 0.004 |    1 |      - |     - |     - |         - |
|              Precomputed4BytesBitCount | 2147483647 |   2.557 ns |    NA | 0.005 |    2 |      - |     - |     - |         - |
| PreComputedListManualRecursiveBitCount | 2147483647 |  15.780 ns |    NA | 0.033 |    3 |      - |     - |     - |         - |
|                       IteratedBitCount | 2147483647 |  19.940 ns |    NA | 0.041 |    4 |      - |     - |     - |         - |
|                         SparseBitCount | 2147483647 |  20.855 ns |    NA | 0.043 |    5 |      - |     - |     - |         - |
|                          BitByBitCount | 2147483647 |  22.240 ns |    NA | 0.046 |    6 |      - |     - |     - |         - |
|                      RecursiveBitCount | 2147483647 |  74.677 ns |    NA | 0.155 |    7 |      - |     - |     - |         - |
|                       BitArrayBitCount | 2147483647 | 177.627 ns |    NA | 0.369 |    8 | 0.0362 |     - |     - |     152 B |
|                           LinqBitCount | 2147483647 | 481.771 ns |    NA | 1.000 |    9 | 0.0286 |     - |     - |     120 B |

``` ini
Categories=Positions  
```
|                    Method |     Number |     Mean | Error | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |----------- |---------:|------:|------:|-----:|-------:|------:|------:|----------:|
|        BitsPositionByBits | 2147483647 | 143.8 ns |    NA |  1.00 |    1 | 0.0458 |     - |     - |     192 B |
|              BitPositions | 2147483647 | 144.5 ns |    NA |  1.00 |    1 | 0.0458 |     - |     - |     192 B |
| BitsPositionWithoutModule | 2147483647 | 150.7 ns |    NA |  1.04 |    2 | 0.0458 |     - |     - |     192 B |
|   BitsPositionUsingModule | 2147483647 | 161.8 ns |    NA |  1.12 |    3 | 0.0458 |     - |     - |     192 B |
|           LinqBitPosition | 2147483647 | 312.3 ns |    NA |  2.16 |    4 | 0.0629 |     - |     - |     264 B |

``` ini
Categories=OneStep  
```
|                                              Method |     Number |       Mean | Error | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------------------------------- |----------- |-----------:|------:|------:|-----:|-------:|------:|------:|----------:|
|                                    BitByBitGetCount | 2147483647 |   160.1 ns |    NA |  0.70 |    1 | 0.0458 |     - |     - |     192 B |
|                         BitByBitGetCountRevengeLog2 | 2147483647 |   177.9 ns |    NA |  0.78 |    2 | 0.0458 |     - |     - |     192 B |
| PreComputed2WordsBitCountBitsPositionByBitsGetCount | 2147483647 |   225.5 ns |    NA |  0.99 |    3 | 0.0744 |     - |     - |     312 B |
|        Precomputed2WordBitCountBitPositionsGetCount | 2147483647 |   227.1 ns |    NA |  1.00 |    3 | 0.0744 |     - |     - |     312 B |
|                            NetFrameworkModeGetCount | 2147483647 |   991.0 ns |    NA |  4.36 |    4 | 0.1373 |     - |     - |     576 B |
|                                        LinqGetCount | 2147483647 | 2,109.1 ns |    NA |  9.29 |    5 | 0.1945 |     - |     - |     824 B |

``` ini
**Legends**

Categories : All categories of the corresponded method, class, and assembly
Number     : Value of the 'Number' parameter
Mean       : Arithmetic mean of all measurements
Error      : Half of 99.9% confidence interval
StdDev     : Standard deviation of all measurements
Ratio      : Mean of the ratio distribution ([Current]/[Baseline])
RatioSD    : Standard deviation of the ratio distribution ([Current]/[Baseline])
Rank       : Relative position of current benchmark mean among all benchmarks (Arabic style)
Gen 0      : GC Generation 0 collects per 1000 operations
Gen 1      : GC Generation 1 collects per 1000 operations
Gen 2      : GC Generation 2 collects per 1000 operations
Allocated  : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
1 ns       : 1 Nanosecond (0.000000001 sec)
```
---

**Perform a final Test with the bests algorithms**

``` ini
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

**Notes**
BitByBitGetCountRevengeLog2 is the winner for numbers equal or less than 32767

So this give an idea to mix both in one, use BitByBitGetCountRevengeLog2 between [0-32767] and use normal BitbyBitCount to obtain the others.

*Maybe I could get some penalization, I didn't include it on this work.**

---

## Final Step

Implement the function requested by the initial task selecting the *BitByBitGetCount* algorithms, 
this algorithm fullfill on one step the challenge

```csharp
using Algorithms.CountingBits.Library;
using System;
using System.Collections.Generic;

namespace Algorithms.CountingBits
{
    public class PositiveBitCounter
    {
        public IEnumerable<byte> Count(int input)
            => input >= 0 
                ? input.BitByBitGetCount() 
                : throw new ArgumentException("should be positive", nameof(input));
    }
}
```

If we need to calculate the things on different steps, it's clear that the best choice should be *BitPositions* and *Precomputed2WordBitCount*

## Conclusions

Even that maybe isn't the best algorithm to perform the challenge, some considerations to increase the speed could be
- Use a Cache on demand to store the results
- .NET using JIT isn't faster enough than another programming language that can produce native code eg. C, C++, Assembly, etc.
- Penalization calling external functions, to increase the performance I'd should merge the steps on one procedure

**Some notes**
- I'd migrated all projects to .NET Core 3.1 version
- The source code it's clean but I should used more abstraction
- I should include all the references used (links, books, etc.)
- Check if using native functions on C++ with unsafe code on C# could increase the performance (No tested!)
- I didn't contemplated multi-threads
- On the 
- and a long etc. *My technical debts is pending*

I'd really enjoyed performing this challenge!

**Find me around the web**

* My profile on [Linkedin](https://www.linkedin.com/in/patocl/?locale=en_US)
* Collaborating on [GitHub](https://github.com/patocl)
* Learning on [Pluralsight](https://app.pluralsight.com/profile/patocl) 
***