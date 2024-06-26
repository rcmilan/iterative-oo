using iterative_oo.Common;

internal class ConsoleProblemReader
{
    private IEnumerable<IEnumerable<int>> RawNumbersSequence => Console.In.IncomingLines().NonNegativeIntegerSequences();

    internal IEnumerable<ProblemStatement> ReadAll() => RawNumbersSequence.Select(input => new ProblemStatement(input));
}