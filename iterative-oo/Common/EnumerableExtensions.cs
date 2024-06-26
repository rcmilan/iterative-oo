namespace iterative_oo.Common;

internal static class EnumerableExtensions
{
    public static void WriteLinesTo<T>(this IEnumerable<T> sequence, TextWriter destination) =>
        sequence.Select(obj => $"{obj}").WriteLinesTo(destination);

    public static void WriteLinesTo(this IEnumerable<string> sequence, TextWriter destination)
    {
        foreach (var line in sequence)
            destination.WriteLine(line);
    }

    public static bool AllNonEmpty<T>(this IEnumerable<T> sequence, Func<T, bool> predicate)
    {
        bool any = false;

        foreach (T obj in sequence)
        {
            if (!predicate(obj)) return false;
            any = true;
        }
        return any;
    }
}