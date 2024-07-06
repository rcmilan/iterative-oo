namespace iterative_oo.Domain.Expressions;

/// <summary>
/// Representa uma expressão de adição.
/// </summary>
internal class AddExpression : Expression
{
    /// <summary>
    /// Obtém o valor da expressão de adição. A soma dos valores das expressões da esquerda e da direita.
    /// </summary>
    public override int Value => Left.Value + Right.Value;

    private readonly Expression Left;
    private readonly Expression Right;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="AddExpression"/> com as expressões da esquerda e da direita.
    /// </summary>
    /// <param name="left">A expressão à esquerda do operador de adição.</param>
    /// <param name="right">A expressão à direita do operador de adição.</param>
    public AddExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    /// <summary>
    /// Retorna uma string que representa a expressão de adição.
    /// </summary>
    /// <returns>Uma string que representa a expressão de adição.</returns>
    public override string? ToString() => $"{Left} + {Right}";
}
