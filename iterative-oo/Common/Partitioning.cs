using System.Collections;

namespace iterative_oo.Common;

/// <summary>
/// Representa uma coleção de partições.
/// </summary>
/// <typeparam name="T">O tipo dos elementos nas partições.</typeparam>
public class Partitioning<T>(IEnumerable<Partition<T>> partitions) : IEnumerable<Partition<T>>
{
    /// <summary>
    /// Inicializa a coleção de partições com um array de partições.
    /// </summary>
    /// <param name="partitions">As partições para inicializar a coleção.</param>
    public Partitioning(params Partition<T>[] partitions) : this((IEnumerable<Partition<T>>)partitions) { }

    /// <summary>
    /// Retorna um enumerador que itera através das partições.
    /// </summary>
    /// <returns>O enumerador das partições.</returns>
    public IEnumerator<Partition<T>> GetEnumerator() => partitions.GetEnumerator();

    /// <summary>
    /// Retorna um enumerador não genérico que itera através das partições.
    /// </summary>
    /// <returns>O enumerador não genérico das partições.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Expande a última partição da coleção em novas partições.
    /// </summary>
    /// <returns>Um enumerável de novas coleções de partições resultantes da expansão.</returns>
    public IEnumerable<Partitioning<T>> Expand()
    {
        (IEnumerable<Partition<T>> prefix, Partition<T> last) = partitions.ExtractLast();

        return Partitioning<T>.Expand(prefix.ToList(), last);
    }

    /// <summary>
    /// Expande a última partição com um prefixo específico.
    /// </summary>
    /// <param name="prefix">O prefixo das partições antes da última partição.</param>
    /// <param name="last">A última partição a ser expandida.</param>
    /// <returns>Um enumerável de novas coleções de partições resultantes da expansão.</returns>
    private static IEnumerable<Partitioning<T>> Expand(List<Partition<T>> prefix, Partition<T> last) =>
        last.SplitAscending()
            .Where(tuple => tuple.left.Any() && tuple.right.Any())
            .Select(tuple => new[] { tuple.left, tuple.right })
            .Select(expansion => prefix.Concat(expansion))
            .Select(p => new Partitioning<T>(p));
}
