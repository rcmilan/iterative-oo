using System.Collections;

namespace iterative_oo.Common;

/// <summary>
/// Representa uma partição de uma sequência de elementos.
/// </summary>
/// <typeparam name="T">O tipo dos elementos na partição.</typeparam>
/// <param name="content">O conteúdo da partição.</param>
public class Partition<T>(IEnumerable<T> content) : IEnumerable<T>
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
    /// Divide a sequência em duas partes, onde cada parte é uma partição.
    /// </summary>
    /// <returns>Um enumerável de tuplas representando as duas partes resultantes da divisão.</returns>
    public IEnumerable<(Partition<T> left, Partition<T> right)> SplitAscending() =>
        content.IsEmpty() ? [(Empty, Empty)] : SplitAndPrependLeft(content.First(), content.Skip(1));

    /// <summary>
    /// Precede o primeiro elemento à esquerda de uma sequência dividida.
    /// </summary>
    /// <param name="leftHead">O elemento a ser adicionado à esquerda.</param>
    /// <param name="toSplit">A sequência a ser dividida.</param>
    /// <returns>Um enumerável de tuplas representando as duas partes resultantes da divisão.</returns>
    private IEnumerable<(Partition<T> left, Partition<T> right)> SplitAndPrependLeft(T leftHead, IEnumerable<T> toSplit) =>
        Split(toSplit).Select(split => Partition<T>.Prepend(leftHead, split.left, split.right));

    /// <summary>
    /// Divide uma sequência em duas partes.
    /// </summary>
    /// <param name="sequence">A sequência a ser dividida.</param>
    /// <returns>Um enumerável de tuplas representando as duas partes resultantes da divisão.</returns>
    private IEnumerable<(Partition<T> left, Partition<T> right)> Split(IEnumerable<T> sequence) =>
        sequence.IsEmpty() ? [(Empty, Empty)] : Split(sequence.First(), sequence.Skip(1).AsPartition());

    /// <summary>
    /// Adiciona um elemento à esquerda de uma sequência dividida.
    /// </summary>
    /// <param name="leftHead">O elemento a ser adicionado à esquerda.</param>
    /// <param name="left">A partição da esquerda.</param>
    /// <param name="right">A partição da direita.</param>
    /// <returns>Uma tupla contendo as duas novas partições.</returns>
    private static (Partition<T> left, Partition<T> right) Prepend(T? leftHead, Partition<T> left, Partition<T> right) =>
        (new Partition<T>(new[] { leftHead }.Concat(left)), right);

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

    /// <summary>
    /// Divide uma partição em duas partes.
    /// </summary>
    /// <param name="numbers">A partição a ser dividida.</param>
    /// <returns>Um enumerável de tuplas representando as duas partes resultantes da divisão.</returns>
    private IEnumerable<(Partition<T> left, Partition<T> right)> Split(Partition<T> numbers) =>
        numbers.IsEmpty() ? [(Empty, Empty)] : Split(numbers.First(), numbers.Skip(1).AsPartition());

    /// <summary>
    /// Divide uma partição em duas partes, utilizando o primeiro elemento como referência.
    /// </summary>
    /// <param name="head">O primeiro elemento da partição.</param>
    /// <param name="tail">A partição restante.</param>
    /// <returns>Um enumerável de tuplas representando as duas partes resultantes da divisão.</returns>
    private IEnumerable<(Partition<T> left, Partition<T> right)> Split(T head, Partition<T> tail) =>
        Combine(TrivialSplit(head), Split(tail).ToList());

    /// <summary>
    /// Combina duas coleções de tuplas de partições.
    /// </summary>
    /// <param name="head">A primeira coleção de tuplas de partições.</param>
    /// <param name="tail">A segunda coleção de tuplas de partições.</param>
    /// <returns>Uma coleção combinada de tuplas de partições.</returns>
    private static IEnumerable<(Partition<T> left, Partition<T> right)> Combine(
        IEnumerable<(Partition<T> left, Partition<T> right)> head,
        IEnumerable<(Partition<T> left, Partition<T> right)> tail) =>
        head.SelectMany(split => tail.Select(tuple => (split.left.Concat(tuple.left), split.right.Concat(tuple.right))));

    /// <summary>
    /// Cria uma divisão trivial de um único elemento.
    /// </summary>
    /// <param name="number">O elemento a ser dividido.</param>
    /// <returns>Um enumerável de tuplas representando as duas partes resultantes da divisão trivial.</returns>
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
