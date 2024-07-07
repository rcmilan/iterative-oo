namespace iterative_oo.Common;

public static class ObjectExtensions
{
    /// <summary>
    /// Expande um objeto infinitamente utilizando uma função de expansão.
    /// </summary>
    /// <typeparam name="T">O tipo do objeto a ser expandido.</typeparam>
    /// <param name="target">O objeto inicial a ser expandido.</param>
    /// <param name="expansion">A função que define como o objeto será expandido. Deve retornar uma coleção de objetos derivados do objeto atual.</param>
    /// <returns>Uma sequência infinita de objetos gerados pela função de expansão.</returns>
    public static IEnumerable<T> ExpandEndlessly<T>(this T target, Func<T, IEnumerable<T>> expansion)
    {
        var toExpand = new Queue<T>();
        toExpand.Enqueue(target);

        while (toExpand.TryDequeue(out T current))
        {
            yield return current;
            toExpand.EnqueueMany(expansion(current));
        }
    }
}