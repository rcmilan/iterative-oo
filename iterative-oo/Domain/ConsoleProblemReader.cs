using iterative_oo.Common;

internal class ConsoleProblemReader
{
    private IEnumerable<int> DesiredResults => Console.In.IncomingLines(this.PromptDesiredResult).SingleNonNegativeIntegers();

    private IEnumerable<(IEnumerable<int> inputs, int result)> RawNumbersSequence =>
        this.InputNumberSequences.Zip(this.DesiredResults, (IEnumerable<int> inputs, int result) => (inputs, result));

    private IEnumerable<IEnumerable<int>> InputNumberSequences =>
        Console.In.IncomingLines(PromptInputNumbers).NonNegativeIntegerSequences();

    private void PromptInputNumbers() => Console.Write("Input Numbers:\t");

    private void PromptDesiredResult() => Console.Write("Input Desired Result:\t");

    internal IEnumerable<ProblemStatement> ReadAll() => RawNumbersSequence.Select(tuple => new ProblemStatement(tuple.inputs, tuple.result));
}