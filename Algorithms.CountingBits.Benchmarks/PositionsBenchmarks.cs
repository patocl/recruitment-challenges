using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Algorithms.CountingBits.Library;

namespace Algorithms.CountingBits.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MarkdownExporter]
    [MarkdownExporterAttribute.GitHub]
    [CategoriesColumn]
    [RankColumn]
    [SimpleJob(launchCount: 1, warmupCount: 1, targetCount: 1)]
    public class PositionsBenchmarks
    {
        [Params(int.MaxValue)]
        public int Number { get; set; }

        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Positions")]
        public void BitPositions()
        {
            _ = Positions.BitPositions(Number);
        }

        [Benchmark]
        [BenchmarkCategory("Positions")]
        public void BitsPositionByBits()
        {
            _ = Positions.BitsPositionByBits(Number);
        }

        [Benchmark]
        [BenchmarkCategory("Positions")]
        public void LinqBitPosition()
        {
            _ = Positions.LinqBitPosition(Number);
        }

        [Benchmark]
        [BenchmarkCategory("Positions")]
        public void BitsPositionUsingModule()
        {
            _ = Positions.BitsPositionUsingModule(Number);
        }

        [Benchmark]
        [BenchmarkCategory("Positions")]
        public void BitsPositionWithoutModule()
        {
            _ = Positions.BitsPositionWithoutModule(Number);
        }
    }
}
