namespace iterative_oo.Common;

/// <summary>
/// Métodos de extensão para operações em filas (Queue).
/// </summary>
public static class QueueExtensions
{
    /// <summary>
    /// Adiciona múltiplos itens a uma fila.
    /// </summary>
    /// <typeparam name="T">O tipo dos elementos na fila.</typeparam>
    /// <param name="target">A fila à qual os itens serão adicionados.</param>
    /// <param name="objects">Os itens a serem adicionados à fila.</param>
    public static void EnqueueMany<T>(this Queue<T> target, IEnumerable<T> objects)
    {
        foreach (T item in objects)
            target.Enqueue(item);
    }
}
