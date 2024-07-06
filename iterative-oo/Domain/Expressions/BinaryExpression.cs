namespace iterative_oo.Domain.Expressions;

/// <summary>
/// Classe abstrata que representa uma expressão binária.
/// </summary>
internal abstract class BinaryExpression : Expression
{
    private readonly Expression left;
    private readonly Expression right;

    /// <summary>
    /// Valor resultante da combinação das expressões esquerda e direita.
    /// </summary>
    public override int Value => Combine(left.Value, right.Value);

    /// <summary>
    /// Texto que representa o operador da expressão binária.
    /// </summary>
    protected abstract string OperatorToString { get; }

    /// <summary>
    /// Construtor da classe BinaryExpression.
    /// </summary>
    /// <param name="left">Expressão à esquerda da operação binária.</param>
    /// <param name="right">Expressão à direita da operação binária.</param>
    protected BinaryExpression(Expression left, Expression right)
    {
        this.left = left;
        this.right = right;
    }

    /// <summary>
    /// Combinação das expressões esquerda e direita para calcular o valor resultante.
    /// </summary>
    /// <param name="left">Valor da expressão à esquerda.</param>
    /// <param name="right">Valor da expressão à direita.</param>
    /// <returns>O resultado da combinação das expressões.</returns>
    protected abstract int Combine(int left, int right);

    /// <summary>
    /// Retorna uma representação textual da expressão binária no formato "left OperatorToString right".
    /// </summary>
    /// <returns>A representação textual da expressão binária.</returns>
    public override string? ToString() => $"{left} {OperatorToString} {right}";
}
