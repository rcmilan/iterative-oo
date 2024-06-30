internal class ProblemStatement
{
    private readonly IEnumerable<int> InputNumbers;
    private readonly int DesiredResult;

    public ProblemStatement(IEnumerable<int> input, int desiredResult)
    {
        InputNumbers = input;
        DesiredResult = desiredResult;
    }

    public override string? ToString() => $"Problem Statement: [{InputNumbersFormattedList} -> {DesiredResult}]";

    private string InputNumbersFormattedList => string.Join(", ", InputNumbers.Select(number => $"{number}").ToArray());
}