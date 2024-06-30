namespace iterative_oo.Common;

internal static class TextReaderExtensions
{
    public static IEnumerable<string> IncomingLines(this TextReader reader, Action prompt) =>
        reader.NullableIncomingLines(prompt).TakeWhile(line => line is not null);

    private static IEnumerable<string> NullableIncomingLines(this TextReader reader, Action prompt)
    {
        while (true)
        {
            prompt();
            yield return reader.ReadLine();
        }
    }
}
