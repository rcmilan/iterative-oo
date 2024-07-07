using BenchmarkDotNet.Attributes;
using iterative_oo.Common;

namespace iterative_oo_benchmarks.Common;

[MemoryDiagnoser]
public class EnumerableExtensionsBenchmarks
{
    private IEnumerable<int> numbers;
    private IEnumerable<string> strings;
    private TextWriter destination;

    [Params(1000)]
    public int N;

    [GlobalSetup]
    public void GlobalSetup()
    {
        numbers = Enumerable.Range(1, N);
        strings = Enumerable.Range(1, N).Select(i => i.ToString());
        destination = new StringWriter();
    }

    [Benchmark]
    public void AllNonEmpty()
    {
        numbers.AllNonEmpty(x => x > 0);
    }

    [Benchmark]
    public void IsEmpty()
    {
        numbers.IsEmpty();
    }

    [Benchmark]
    public void AsPartition()
    {
        numbers.AsPartition();
    }

    [Benchmark]
    public void ExtractLast()
    {
        numbers.ExtractLast();
    }

    [Benchmark]
    public void CrossProduct()
    {
        var sequences = new List<IEnumerable<int>>
        {
            Enumerable.Range(1, 10),
            Enumerable.Range(1, 10),
            Enumerable.Range(1, 10)
        };
        sequences.CrossProduct().ToList();
    }
}
