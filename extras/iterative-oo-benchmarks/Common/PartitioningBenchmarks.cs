using BenchmarkDotNet.Attributes;
using iterative_oo.Common;

namespace iterative_oo_benchmarks.Common;

[MemoryDiagnoser]
public class PartitioningBenchmarks
{
    private readonly List<Partition<int>> partitions;

    public PartitioningBenchmarks()
    {
        // Exemplo de inicialização com algumas partições de números inteiros
        partitions = new List<Partition<int>>
        {
            new Partition<int>(Enumerable.Range(1, 10)),
            new Partition<int>(Enumerable.Range(11, 10)),
            new Partition<int>(Enumerable.Range(21, 10))
        };
    }

    [Benchmark]
    public void ExpandBenchmark()
    {
        var partitioning = new Partitioning<int>(partitions);
        var expanded = partitioning.Expand().ToList();
    }
}
