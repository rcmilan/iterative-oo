namespace iterative_oo.Domain;

/// <summary>
/// Representa uma expressão abstrata que pode ser avaliada para obter um valor inteiro.
/// </summary>
internal abstract class Expression
{
    /// <summary>
    /// Obtém o valor resultante da expressão.
    /// </summary>
    public abstract int Value { get; }
}
