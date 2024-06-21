namespace iterative_oo
{
    internal static class EnumerableExtensions
    {
        public static void WriteLinesTo<T>(this IEnumerable<T> sequence, TextWriter destination) =>
            sequence.Select(obj => $"{obj}").WriteLinesTo(destination);

        public static void WriteLinesTo(this IEnumerable<string> sequence, TextWriter destination)
        {
            foreach (var line in sequence)
                destination.WriteLine(line);
        }
    }
}