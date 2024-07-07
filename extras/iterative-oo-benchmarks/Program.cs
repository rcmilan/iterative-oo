using BenchmarkDotNet.Running;

namespace iterative_oo_benchmarks;

internal class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run(typeof(Program).Assembly);
    }
}