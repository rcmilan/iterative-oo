namespace iterative_oo.Common
{
    internal static class TextReaderExtensions
    {
        /// <summary>
        /// Retorna uma sequência de linhas de entrada até encontrar uma linha nula.
        /// </summary>
        /// <param name="reader">O TextReader de onde as linhas serão lidas.</param>
        /// <param name="prompt">A ação a ser executada antes de ler cada linha.</param>
        /// <returns>Uma sequência de linhas de entrada.</returns>
        public static IEnumerable<string> IncomingLines(this TextReader reader, Action prompt) =>
            reader.NullableIncomingLines(prompt).TakeWhile(line => line is not null);

        /// <summary>
        /// Retorna uma sequência de linhas de entrada, incluindo linhas nulas.
        /// </summary>
        /// <param name="reader">O TextReader de onde as linhas serão lidas.</param>
        /// <param name="prompt">A ação a ser executada antes de ler cada linha.</param>
        /// <returns>Uma sequência de linhas de entrada, incluindo linhas nulas.</returns>
        private static IEnumerable<string> NullableIncomingLines(this TextReader reader, Action prompt)
        {
            while (true)
            {
                prompt();
                yield return reader.ReadLine();
            }
        }
    }
}
