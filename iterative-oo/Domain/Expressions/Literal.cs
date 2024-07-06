namespace iterative_oo.Domain.Expressions;

/// <summary>
/// Representa uma expressão literal que contém um valor inteiro.
/// </summary>
internal class Literal : Expression
{
    /// <summary>
    /// Obtém o valor literal da expressão.
    /// </summary>
    public override int Value { get; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Literal"/> com o valor especificado.
    /// </summary>
    /// <param name="value">O valor literal da expressão.</param>
    public Literal(int value)
    {
        Value = value;
    }

    /// <summary>
    /// Retorna uma string que representa o valor literal da expressão.
    /// </summary>
    /// <returns>Uma string que representa o valor literal da expressão.</returns>
    public override string? ToString() => $"{Value}";
}
