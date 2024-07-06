namespace iterative_oo.Common;

internal static class EnumerableExtensions
{
    /// <summary>
    /// Escreve cada elemento da sequência no destino TextWriter, convertendo-o para string.
    /// </summary>
    /// <typeparam name="T">O tipo dos elementos na sequência.</typeparam>
    /// <param name="sequence">A sequência de elementos a serem escritos.</param>
    /// <param name="destination">O TextWriter onde os elementos serão escritos.</param>
    public static void WriteLinesTo<T>(this IEnumerable<T> sequence, TextWriter destination) =>
        sequence.Select(obj => $"{obj}").WriteLinesTo(destination);

    /// <summary>
    /// Escreve cada string da sequência no destino TextWriter.
    /// </summary>
    /// <param name="sequence">A sequência de strings a serem escritas.</param>
    /// <param name="destination">O TextWriter onde as strings serão escritas.</param>
    public static void WriteLinesTo(this IEnumerable<string> sequence, TextWriter destination)
    {
        foreach (var line in sequence)
            destination.WriteLine(line);
    }

    /// <summary>
    /// Verifica se todos os elementos da sequência satisfazem o predicado e se a sequência não está vazia.
    /// </summary>
    /// <typeparam name="T">O tipo dos elementos na sequência.</typeparam>
    /// <param name="sequence">A sequência de elementos a serem verificados.</param>
    /// <param name="predicate">O predicado que cada elemento deve satisfazer.</param>
    /// <returns>True se todos os elementos satisfazem o predicado e a sequência não está vazia; caso contrário, False.</returns>
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

    /// <summary>
    /// Verifica se a sequência está vazia.
    /// </summary>
    /// <typeparam name="T">O tipo dos elementos na sequência.</typeparam>
    /// <param name="sequence">A sequência de elementos a ser verificada.</param>
    /// <returns>True se a sequência estiver vazia; caso contrário, False.</returns>
    public static bool IsEmpty<T>(this IEnumerable<T> sequence) => !sequence.Any();
}
