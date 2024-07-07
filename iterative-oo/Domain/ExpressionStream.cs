using iterative_oo.Common;
using iterative_oo.Domain.Expressions;

namespace iterative_oo.Domain;

/// <summary>
/// Representa um fluxo de expressões matemáticas.
/// </summary>
public class ExpressionStream
{
    /// <summary>
    /// Retorna expressões distintas geradas a partir de uma sequência de números inteiros.
    /// </summary>
    /// <param name="inputNumbers">A sequência de números inteiros de entrada.</param>
    /// <returns>Um enumerável de expressões distintas.</returns>
    public IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) =>
        DistinctFor(AsLiterals(inputNumbers), 1, MultiplyAndDivide, CreateAdditive);

    /// <summary>
    /// Retorna expressões distintas geradas a partir de uma sequência de expressões.
    /// </summary>
    /// <param name="elements">A sequência de expressões de entrada.</param>
    /// <param name="minPartitions">O número mínimo de partições.</param>
    /// <param name="partitionExpressionBuilder">Função que constrói expressões a partir de uma partição.</param>
    /// <param name="reduceExpressionBuilder">Função que reduz expressões usando operadores aritméticos.</param>
    /// <returns>Um enumerável de expressões distintas.</returns>
    private static IEnumerable<Expression> DistinctFor(
        IEnumerable<Expression> elements, int minPartitions,
        Func<Partition<Expression>, IEnumerable<Expression>> partitionExpressionBuilder,
        Func<Expression, IEnumerable<Expression>, IEnumerable<Expression>, IEnumerable<Expression>> reduceExpressionBuilder) =>
        elements.Take(2).Count() == 1 ? elements
        : Partitionings.Of(elements)
            .All()
            .Where(partitioning => partitioning.Count() >= minPartitions)
            .SelectMany(partitioning => partitioning.Select(partitionExpressionBuilder).CrossProduct())
            .SelectMany(subexpressions => ThreeWaySplit(subexpressions)
                .SelectMany(split => reduceExpressionBuilder(split.head, split.direct, split.inverse)));

    /// <summary>
    /// Converte uma sequência de números inteiros em uma sequência de expressões literais.
    /// </summary>
    /// <param name="inputNumbers">A sequência de números inteiros de entrada.</param>
    /// <returns>Um enumerável de expressões literais.</returns>
    public static IEnumerable<Expression> AsLiterals(IEnumerable<int> inputNumbers) =>
        inputNumbers.Select(n => new Literal(n));

    /// <summary>
    /// Retorna expressões distintas geradas a partir de uma sequência de expressões usando adição e subtração.
    /// </summary>
    /// <param name="expressions">A sequência de expressões de entrada.</param>
    /// <returns>Um enumerável de expressões distintas.</returns>
    private IEnumerable<Expression> AddAndSubtract(IEnumerable<Expression> expressions) =>
        DistinctFor(expressions, 2, MultiplyAndDivide, CreateAdditive);

    /// <summary>
    /// Retorna expressões distintas geradas a partir de uma sequência de expressões usando multiplicação e divisão.
    /// </summary>
    /// <param name="expressions">A sequência de expressões de entrada.</param>
    /// <returns>Um enumerável de expressões distintas.</returns>
    private IEnumerable<Expression> MultiplyAndDivide(IEnumerable<Expression> expressions) =>
        DistinctFor(expressions, 2, AddAndSubtract, CreateMultiplicative);

    /// <summary>
    /// Cria expressões aditivas a partir de uma expressão principal e sequências de expressões para adição e subtração.
    /// </summary>
    /// <param name="head">A expressão principal.</param>
    /// <param name="add">A sequência de expressões a serem adicionadas.</param>
    /// <param name="subtract">A sequência de expressões a serem subtraídas.</param>
    /// <returns>Um enumerável de expressões aditivas.</returns>
    private IEnumerable<Expression> CreateAdditive(Expression head, IEnumerable<Expression> add, IEnumerable<Expression> subtract) =>
        head.Add(add).TrySubtract(subtract);

    /// <summary>
    /// Cria expressões multiplicativas a partir de uma expressão principal e sequências de expressões para multiplicação e divisão.
    /// </summary>
    /// <param name="head">A expressão principal.</param>
    /// <param name="multiply">A sequência de expressões a serem multiplicadas.</param>
    /// <param name="divide">A sequência de expressões a serem divididas.</param>
    /// <returns>Um enumerável de expressões multiplicativas.</returns>
    private static IEnumerable<Expression> CreateMultiplicative(Expression head, IEnumerable<Expression> multiply, IEnumerable<Expression> divide) =>
        head.Multiply(multiply).TryDivide(divide);

    /// <summary>
    /// Realiza uma divisão tripla das expressões em partições diretas e inversas.
    /// </summary>
    /// <param name="expressions">A sequência de expressões de entrada.</param>
    /// <returns>Um enumerável de tuplas contendo a expressão principal, partições diretas e partições inversas.</returns>
    private static IEnumerable<(Expression head, Partition<Expression> direct, Partition<Expression> inverse)>
        ThreeWaySplit(IEnumerable<Expression> expressions) => expressions.AsPartition()
            .Split()
            .Where(split => split.left.Any())
            .Select(split => (split.left.First(), split.left.Skip(1).AsPartition(), split.right));
}
