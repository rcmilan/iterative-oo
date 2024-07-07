using BenchmarkDotNet.Attributes;
using iterative_oo.Common;

namespace iterative_oo_benchmarks.Common
{
    [MemoryDiagnoser]
    public class StringExtensionsBenchmarks
    {
        private readonly List<string> lines;

        public StringExtensionsBenchmarks()
        {
            // Exemplo de inicialização com uma lista de strings contendo números inteiros
            lines = new List<string> { "1 2 3", "4 5 6", "7 8 9" };
        }

        [Benchmark]
        public void NonNegativeIntegerSequencesBenchmark()
        {
            var sequences = lines.NonNegativeIntegerSequences().ToList();
        }

        [Benchmark]
        public void SingleNonNegativeIntegersBenchmark()
        {
            var integers = lines.SingleNonNegativeIntegers().ToList();
        }
    }
}
