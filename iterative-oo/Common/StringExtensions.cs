namespace iterative_oo.Common;

public static class StringExtensions
{
    public static readonly char[] separators = [' ', '\t'];

    /// <summary>
    /// Retorna uma sequência de sequências de inteiros não negativos a partir de uma sequência de strings.
    /// </summary>
    /// <param name="lines">A sequência de strings contendo os números.</param>
    /// <returns>Uma sequência de sequências de inteiros não negativos.</returns>
    public static IEnumerable<IEnumerable<int>> NonNegativeIntegerSequences(this IEnumerable<string> lines) =>
        lines.Select(line => line.Split(separators, StringSplitOptions.RemoveEmptyEntries))
             .Select(stretches => stretches.Select(stretch =>
             (
                 correct: int.TryParse(stretch, out int value) && value >= 0, value
             )).ToList())
             .Where(matches => matches.AllNonEmpty(tuple => tuple.correct))
             .Select(matches => matches.Select(tuple => tuple.value));

    /// <summary>
    /// Retorna uma sequência de inteiros não negativos únicos a partir de uma sequência de strings.
    /// </summary>
    /// <param name="lines">A sequência de strings contendo os números.</param>
    /// <returns>Uma sequência de inteiros não negativos.</returns>
    public static IEnumerable<int> SingleNonNegativeIntegers(this IEnumerable<string> lines)
    {
        return lines.Select(line => (
            correct: int.TryParse(line, out int value) && value >= 0, value
        ))
        .Where(tuple => tuple.correct)
        .Select(tuple => tuple.value);
    }
}
