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
    public class BitCountsBenchmarks
    {
        [Params(int.MaxValue)]
        public int Number { get; set; }

        [Benchmark]
        [BenchmarkCategory("BitCounts")]
        public void IteratedBitCount()
        {
            _ = BitCounts.IteratedBitCount(Number);
        }

        [Benchmark]
        [BenchmarkCategory("BitCounts")]
        public void Precomputed2WordBitCount()
        {
            _ = BitCounts.Precomputed2WordBitCount(Number);
        }

        [Benchmark]
        [BenchmarkCategory("BitCounts")]
        public void Precomputed4BytesBitCount()
        {
            _ = BitCounts.Precomputed4BytesBitCount(Number);
        }

        [Benchmark]
        [BenchmarkCategory("BitCounts")]
        public void PreComputedListManualRecursiveBitCount()
        {
            _ = BitCounts.PreComputedListManualRecursiveBitCount(Number);
        }

        [Benchmark]
        [BenchmarkCategory("BitCounts")]
        public void RecursiveBitCount()
        {
            _ = BitCounts.RecursiveBitCount(Number);
        }

        [Benchmark]
        [BenchmarkCategory("BitCounts")]
        public void SparseBitCount()
        {
            _ = BitCounts.SparseBitCount(Number);
        }

        [Benchmark]
        [BenchmarkCategory("BitCounts")]
        public void BitByBitCount()
        {
            _ = BitCounts.BitByBitCount(Number);
        }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("BitCounts")]
        public void LinqBitCount()
        {
            _ = BitCounts.LinqBitCount(Number);
        }

        [Benchmark]
        [BenchmarkCategory("BitCounts")]
        public void BitArrayBitCount()
        {
            _ = BitCounts.BitArrayBitCount(Number);
        }
    }
}
