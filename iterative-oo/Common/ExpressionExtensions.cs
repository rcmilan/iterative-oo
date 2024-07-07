using iterative_oo.Domain;
using iterative_oo.Domain.Expressions;

namespace iterative_oo.Common;

/// <summary>
/// Métodos de extensão para operações com expressões.
/// </summary>
public static class ExpressionExtensions
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
    /// Tenta subtrair várias expressões da expressão principal, produzindo uma sequência de novas expressões de subtração.
    /// </summary>
    /// <param name="head">A expressão principal da qual as outras expressões serão subtraídas.</param>
    /// <param name="others">As expressões a serem subtraídas da expressão principal.</param>
    /// <returns>Uma sequência de expressões que representam a subtração da expressão principal pelas outras expressões.</returns>
    public static IEnumerable<Expression> TrySubtract(this Expression head, IEnumerable<Expression> others)
    {
        Expression current = head;
        foreach (var other in others)
        {
            if (other.Value == 0 || current.Value - other.Value < 0)
                yield break;

            current = new SubtractExpression(current, other);
        }

        yield return current;
    }

    /// <summary>
    /// Multiplica várias expressões pela expressão principal, produzindo uma nova expressão de multiplicação.
    /// </summary>
    /// <param name="head">A expressão principal que será multiplicada pelas outras expressões.</param>
    /// <param name="others">As expressões a serem multiplicadas pela expressão principal.</param>
    /// <returns>Uma nova expressão que representa a multiplicação da expressão principal com as outras expressões.</returns>
    public static Expression Multiply(this Expression head, IEnumerable<Expression> others) =>
        others.Aggregate(head, (current, other) => new MultiplyExpression(current, other));

    /// <summary>
    /// Tenta dividir a expressão principal por várias outras expressões, produzindo uma sequência de novas expressões de divisão.
    /// </summary>
    /// <param name="head">A expressão principal que será dividida pelas outras expressões.</param>
    /// <param name="others">As expressões pelas quais a expressão principal será dividida.</param>
    /// <returns>Uma sequência de expressões que representam a divisão da expressão principal pelas outras expressões.</returns>
    public static IEnumerable<Expression> TryDivide(this Expression head, IEnumerable<Expression> others)
    {
        Expression current = head;
        foreach (var other in others)
        {
            if (other.Value == 0 || current.Value % other.Value != 0)
                yield break;

            current = new DivideExpression(current, other);
        }

        yield return current;
    }
}
