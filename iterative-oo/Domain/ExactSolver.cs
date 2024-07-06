namespace iterative_oo.Domain;

/// <summary>
/// Representa um solucionador exato que encontra expressões distintas que correspondem ao resultado desejado de um problema.
/// </summary>
internal class ExactSolver
{
    /// <summary>
    /// Retorna uma sequência de expressões distintas para a declaração do problema que possuem o valor desejado.
    /// </summary>
    /// <param name="problem">A declaração do problema contendo os números de entrada e o resultado desejado.</param>
    /// <returns>Uma sequência de expressões que possuem o valor desejado.</returns>
    public IEnumerable<Expression> DistinctExpressionFor(ProblemStatement problem) =>
        new ExpressionStream().DistinctFor(problem.InputNumbers)
            .Where(expression => expression.Value == problem.DesiredResult);
}
