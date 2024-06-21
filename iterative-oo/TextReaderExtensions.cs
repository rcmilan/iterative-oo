namespace iterative_oo
{
    internal static class TextReaderExtensions
    {
        public static IEnumerable<string> IncomingLines(this TextReader reader) =>
            reader.NullableIncomingLines().TakeWhile(line => line is not null);

        private static IEnumerable<string> NullableIncomingLines(this TextReader reader)
        {
            while (true)
            {
                yield return reader.ReadLine();
            }
        }
    }
}
