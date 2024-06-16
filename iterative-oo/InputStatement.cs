using System.Text.RegularExpressions;

namespace iterative_oo
{
    internal partial class InputStatement(int desiredResult, params int[] inputNumbers)
    {
        public static readonly InputStatement Empty = new(0, 0);

        public int[] Inputs { get; } = inputNumbers;
        public int TargetResult { get; } = desiredResult;

        public static InputStatement Read()
        {
            Console.Write("Input Numbers: ");

            var inputNumbers = (Console.ReadLine() ?? string.Empty)
                .Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries)
                .Where(v => NumericOnlyRegex().IsMatch(v))
                .Select(int.Parse).ToArray();

            if (inputNumbers.Length == 0)
                return Empty;

            Console.Write("Input Desired Result: ");
            if (!int.TryParse(Console.ReadLine(), out int desiredResult))
                desiredResult = 0;

            return new InputStatement(desiredResult, inputNumbers);
        }

        [GeneratedRegex(@"^[0-9]*$")]
        private static partial Regex NumericOnlyRegex();
    }
}