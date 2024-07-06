using iterative_oo.Domain;
using iterative_oo.Domain.Expressions;

namespace iterative_oo.Common;

/// <summary>
/// Métodos de extensão para operações com expressões.
/// </summary>
internal static class ExpressionExtensions
{
    /// <summary>
    /// Adiciona várias expressões à expressão principal, produzindo uma nova expressão de adição.
    /// </summary>
    /// <param name="head">A expressão principal à qual as outras expressões serão adicionadas.</param>
    /// <param name="others">As expressões a serem adicionadas à expressão principal.</param>
    /// <returns>Uma nova expressão que representa a adição da expressão principal com as outras expressões.</returns>
    public static Expression Add(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new AddExpression(current, other));

    /// <summary>
    /// Subtrai várias expressões da expressão principal, produzindo uma nova expressão de subtração.
    /// </summary>
    /// <param name="head">A expressão principal da qual as outras expressões serão subtraídas.</param>
    /// <param name="others">As expressões a serem subtraídas da expressão principal.</param>
    /// <returns>Uma nova expressão que representa a subtração da expressão principal pelas outras expressões.</returns>
    public static Expression Subtract(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new SubtractExpression(current, other));
}
