using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace Algorithms.CountingBits.Benchmarks
{
    public class Program
    {
        public static void Main()
        {
            _ = BenchmarkRunner.Run(
                new[]
                {
                    BenchmarkConverter.TypeToBenchmarks( typeof(BitCountsBenchmarks)),
                    BenchmarkConverter.TypeToBenchmarks( typeof(PositionsBenchmarks)),
                    BenchmarkConverter.TypeToBenchmarks( typeof(OneStepBenchmarks)),
                    BenchmarkConverter.TypeToBenchmarks( typeof(OneStepTheBestBenchmarks))
                }
            );

        }
    }
}
