using BenchmarkDotNet.Attributes;
using iterative_oo.Common;

namespace iterative_oo_benchmarks.Common
{
    [MemoryDiagnoser]
    public class PartitioningsBenchmarks
    {
        private readonly List<int> sequence;

        public PartitioningsBenchmarks()
        {
            // Exemplo de inicialização com uma sequência de números inteiros
            sequence = Enumerable.Range(1, 10).ToList();
        }

        [Benchmark]
        public void AllBenchmark()
        {
            var partitionings = new Partitionings<int>(sequence);
            var allPartitions = partitionings.All().ToList();
        }
    }
}
