
using iterative_oo;
using System.Text.RegularExpressions;

internal class ConsoleProblemReader
{
    private IEnumerable<IEnumerable<int>> RawNumbersSequence => Console.In.IncomingLines().Select(this.ToUnsignedInt);

    private IEnumerable<int> ToUnsignedInt(string line) => Regex.Matches(line, @"\d+")
            .Select(match => match.Value)
            .Select(int.Parse);

    internal IEnumerable<ProblemStatement> ReadAll() => RawNumbersSequence.Select(input => new ProblemStatement(input));
}