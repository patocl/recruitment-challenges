using Algorithms.CountingBits.Library;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Algorithms.CountingBits.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MarkdownExporter]
    [MarkdownExporterAttribute.GitHub]
    [CategoriesColumn]
    [RankColumn]
    [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1)]
    public class OneStepBenchmarks
    {
        [Params(int.MaxValue)]
        public int Number { get; set; }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("OneStep")]
        public void Precomputed2WordBitCountBitPositionsGetCount() 
            => Number.Precomputed2WordBitCountBitPositionsGetCount();

        [Benchmark]
        [BenchmarkCategory("OneStep")]
        public void BitByBitGetCount() 
            => Number.BitByBitGetCount();

        [Benchmark]
        [BenchmarkCategory("OneStep")]
        public void BitByBitGetCountRevengeLog2()
            => Number.BitByBitGetCountRevengeLog2();

        [Benchmark]
        [BenchmarkCategory("OneStep")]
        public void PreComputed2WordsBitCountBitsPositionByBitsGetCount() 
            => Number.Precomputed2WordBitCountBitsPositionByBitsGetCount();

        [Benchmark]
        [BenchmarkCategory("OneStep")]
        public void LinqGetCount() 
            => Number.LinqGetCount();

        [Benchmark]
        [BenchmarkCategory("OneStep")]
        public void NetFrameworkModeGetCount() 
            => Number.NetFrameworkModeGetCount();
    }
}
