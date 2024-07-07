using BenchmarkDotNet.Attributes;
using iterative_oo.Common;

namespace iterative_oo_benchmarks.Common;

[MemoryDiagnoser]
public class PartitionBenchmarks
{
    private readonly Partition<int> partition;

    public PartitionBenchmarks()
    {
        // Exemplo de inicialização da partição com números de 1 a 10
        var numbers = Enumerable.Range(1, 10);
        partition = new Partition<int>(numbers);
    }

    [Benchmark]
    public void SplitBenchmark()
    {
        foreach (var tuple in partition.Split())
        {
            // Fazer algo com as partições resultantes
        }
    }

    [Benchmark]
    public void SplitAscendingBenchmark()
    {
        foreach (var tuple in partition.SplitAscending())
        {
            // Fazer algo com as partições ascendentes resultantes
        }
    }
}
