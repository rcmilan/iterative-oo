using BenchmarkDotNet.Attributes;
using iterative_oo.Common;

namespace iterative_oo_benchmarks.Common;

[MemoryDiagnoser]
public class ObjectExtensionsBenchmarks
{
    private readonly Func<int, IEnumerable<int>> expansionFunction = n => [n + 1];

    [Benchmark]
    public void ExpandEndlesslyBenchmark()
    {
        var target = 0;
        var expanded = target.ExpandEndlessly(expansionFunction);

        // Limitando a execução para um número fixo de iterações para fins de benchmark
        int limit = 1000;
        int count = 0;

        foreach (var item in expanded)
        {
            count++;
            if (count >= limit)
                break;
        }
    }
}
