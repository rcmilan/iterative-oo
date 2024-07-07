namespace iterative_oo.Common;

/// <summary>
/// Métodos de extensão para criar instâncias de <see cref="Partitionings{T}"/>.
/// </summary>
public static class Partitionings
{
    /// <summary>
    /// Cria uma instância de <see cref="Partitionings{T}"/> a partir de uma sequência de elementos.
    /// </summary>
    /// <typeparam name="T">O tipo dos elementos na sequência.</typeparam>
    /// <param name="sequence">A sequência de elementos a ser particionada.</param>
    /// <returns>Uma nova instância de <see cref="Partitionings{T}"/>.</returns>
    public static Partitionings<T> Of<T>(IEnumerable<T> sequence) => new(sequence);
}

/// <summary>
/// Representa uma coleção de partições de uma sequência de elementos.
/// </summary>
/// <typeparam name="T">O tipo dos elementos nas partições.</typeparam>
/// <remarks>
/// Inicializa a coleção de partições com uma sequência de elementos.
/// </remarks>
/// <param name="sequence">A sequência de elementos a ser particionada.</param>
public class Partitionings<T>(IEnumerable<T> sequence)
{
    private readonly IEnumerable<T> Sequence = sequence.ToList();

    /// <summary>
    /// Retorna todas as possíveis partições da sequência de elementos.
    /// </summary>
    /// <returns>Um enumerável de todas as possíveis partições da sequência de elementos.</returns>
    public IEnumerable<Partitioning<T>> All() =>
        new Partitioning<T>(Sequence.AsPartition())
            .ExpandEndlessly(partitioning => partitioning.Expand());
}
