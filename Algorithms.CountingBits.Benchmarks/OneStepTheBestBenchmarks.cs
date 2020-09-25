using Algorithms.CountingBits.Library;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;

namespace Algorithms.CountingBits.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.Method)]
    [MarkdownExporter]
    [MarkdownExporterAttribute.GitHub]
    [CategoriesColumn]
    [RankColumn]
    [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1)]
    public class OneStepTheBestBenchmarks
    {
        [Params(1, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767, 65535, 131071, 262143, 524287, 1048575, 2097151, 4194303, 8388607, 16777215, 33554431, 67108863, 134217727, 268435455, 536870911, 1073741823, int.MaxValue)]
        public int Number { get; set; }

        [Benchmark]
        [BenchmarkCategory("OneStep-TheBest")]
        public void BitByBitGetCount()
            => Number.BitByBitGetCount();

        [Benchmark]
        [BenchmarkCategory("OneStep-TheBest")]
        public void BitByBitGetCountRevengeLog2()
            => Number.BitByBitGetCountRevengeLog2();
    }
}