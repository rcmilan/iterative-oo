namespace iterative_oo.Common;

/// <summary>
/// Métodos de extensão para operações em coleções enumeráveis.
/// </summary>
public static class EnumerableExtensions
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

    /// <summary>
    /// Converte a sequência em um objeto do tipo Partition.
    /// </summary>
    /// <typeparam name="T">O tipo dos elementos na sequência.</typeparam>
    /// <param name="sequence">A sequência de elementos a ser convertida.</param>
    /// <returns>Um objeto Partition que encapsula a sequência.</returns>
    public static Partition<T> AsPartition<T>(this IEnumerable<T> sequence) => new(sequence);

    /// <summary>
    /// Extrai o último elemento da sequência, retornando a sequência sem o último elemento e o último elemento.
    /// </summary>
    /// <typeparam name="T">O tipo dos elementos na sequência.</typeparam>
    /// <param name="sequence">A sequência de elementos.</param>
    /// <returns>Um tupla contendo a sequência sem o último elemento e o último elemento.</returns>
    public static (IEnumerable<T> prefix, T last) ExtractLast<T>(this IEnumerable<T> sequence)
    {
        var prefix = new List<T>();

        using IEnumerator<T> enumerator = sequence.GetEnumerator();

        enumerator.MoveNext();
        T last = enumerator.Current;

        while (enumerator.MoveNext())
        {
            prefix.Add(last);
            last = enumerator.Current;
        }

        return (prefix, last);
    }

    /// <summary>
    /// Calcula o produto cartesiano de uma sequência de sequências.
    /// </summary>
    /// <typeparam name="T">O tipo dos elementos nas sequências.</typeparam>
    /// <param name="sequenceOfSequences">A sequência de sequências para calcular o produto cartesiano.</param>
    /// <returns>Uma sequência de sequências representando o produto cartesiano.</returns>
    public static IEnumerable<IEnumerable<T>> CrossProduct<T>(this IEnumerable<IEnumerable<T>> sequenceOfSequences)
    {
        T[][] data = sequenceOfSequences.Select(sequence => sequence.ToArray()).ToArray();
        int[] indices = new int[data.Length];
        int carryOver = 0;

        while (carryOver == 0)
        {
            yield return indices.Select((column, row) => data[row][column]).ToList();

            carryOver = 1;

            for (int row = 0; carryOver > 0 && row < indices.Length; row++)
            {
                indices[row] += 1;
                carryOver = indices[row] / data[row].Length;
                indices[row] = indices[row] % data[row].Length;
            }
        }
    }
}
