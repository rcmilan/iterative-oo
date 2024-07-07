using BenchmarkDotNet.Attributes;
using iterative_oo.Common;
using iterative_oo.Domain.Expressions;

namespace iterative_oo_benchmarks.Common;

[MemoryDiagnoser]
public class ExpressionExtensionsBenchmarks
{
    private IEnumerable<iterative_oo.Domain.Expression> expressions;

    [Params(1000)]
    public int N;

    [GlobalSetup]
    public void GlobalSetup()
    {
        expressions = Enumerable.Range(1, N).Select(i => new Literal(i)).ToList();
    }

    [Benchmark]
    public void AddExpressions()
    {
        var head = new Literal(0); // Starting with a base expression

        ExpressionExtensions.Add(head, expressions);
    }

    [Benchmark]
    public void TrySubtractExpressions()
    {
        var head = new Literal(N * 2); // Starting with a base expression

        ExpressionExtensions.TrySubtract(head, expressions);
    }

    [Benchmark]
    public void MultiplyExpressions()
    {
        var head = new Literal(1); // Starting with a base expression

        ExpressionExtensions.Multiply(head, expressions);
    }

    [Benchmark]
    public void TryDivideExpressions()
    {
        var head = new Literal(N * N); // Starting with a base expression

        ExpressionExtensions.TryDivide(head, expressions);
    }
}
