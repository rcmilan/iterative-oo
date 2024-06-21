
internal class ProblemStatement
{
    private IEnumerable<int> InputNumbers;

    public ProblemStatement(IEnumerable<int> input)
    {
        InputNumbers = input;
    }

    public override string? ToString() => $"Problem Statement: [{InputNumbersFormattedList}]";

    private string InputNumbersFormattedList => string.Join(", ", InputNumbers.Select(number => $"{number}").ToArray());
}