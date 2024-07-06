using System.Collections;

namespace iterative_oo.Common;

/// <summary>
/// Representa uma partição de uma sequência de elementos.
/// </summary>
/// <typeparam name="T">O tipo dos elementos na partição.</typeparam>
/// <remarks>
/// Inicializa a partição com um conteúdo específico.
/// </remarks>
/// <param name="content">O conteúdo da partição.</param>
internal class Partition<T>(IEnumerable<T> content) : IEnumerable<T>
{
    /// <summary>
    /// Inicializa a partição com um array de elementos.
    /// </summary>
    /// <param name="content">Os elementos para inicializar a partição.</param>
    public Partition(params T[] content) : this((IEnumerable<T>)content)
    {
    }

    /// <summary>
    /// Retorna uma partição vazia.
    /// </summary>
    public static Partition<T> Empty => new(Enumerable.Empty<T>());

    /// <summary>
    /// Concatena esta partição com outra partição.
    /// </summary>
    /// <param name="other">A outra partição a ser concatenada.</param>
    /// <returns>Uma nova partição resultante da concatenação.</returns>
    private Partition<T> Concat(Partition<T> other) => new(content.Concat(other));

    /// <summary>
    /// Divide a partição em duas partes.
    /// </summary>
    /// <returns>Um enumerável de tuplas representando as duas partes resultantes da divisão.</returns>
    public IEnumerable<(Partition<T> left, Partition<T> right)> Split() => Split(content.AsPartition());

    private IEnumerable<(Partition<T> left, Partition<T> right)> Split(Partition<T> numbers) =>
        numbers.IsEmpty() ? [(Empty, Empty)]
        : Split(numbers.First(), numbers.Skip(1).AsPartition());

    private IEnumerable<(Partition<T> left, Partition<T> right)> Split(T head, Partition<T> tail) =>
        Combine(TrivialSplit(head), Split(tail).ToList());

    private static IEnumerable<(Partition<T> left, Partition<T> right)> Combine(
        IEnumerable<(Partition<T> left, Partition<T> right)> head,
        IEnumerable<(Partition<T> left, Partition<T> right)> tail) =>
        head.SelectMany(split => tail.Select(tuple => (split.left.Concat(tuple.left), split.right.Concat(tuple.right))));

    private static IEnumerable<(Partition<T> left, Partition<T> right)> TrivialSplit(T number) =>
    [
        (new Partition<T>(number), Empty),
        (Empty, new Partition<T>(number)),
    ];

    /// <summary>
    /// Retorna um enumerador que itera através dos elementos da partição.
    /// </summary>
    /// <returns>O enumerador dos elementos da partição.</returns>
    public IEnumerator<T> GetEnumerator() => content.GetEnumerator();

    /// <summary>
    /// Retorna um enumerador não genérico que itera através dos elementos da partição.
    /// </summary>
    /// <returns>O enumerador não genérico dos elementos da partição.</returns>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
