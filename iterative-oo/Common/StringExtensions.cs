namespace iterative_oo.Common;

internal static class StringExtensions
{
    public static IEnumerable<IEnumerable<int>> NonNegativeIntegerSequences(this IEnumerable<string> lines) =>
        lines.Select(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
        .Select(stretches => stretches.Select(stretch =>
        (
            correct: int.TryParse(stretch, out int value) && value >= 0, value
        )).ToList())
        .Where(matches => matches.AllNonEmpty(tuple => tuple.correct))
        .Select(matches => matches.Select(tuple => tuple.value));

}
