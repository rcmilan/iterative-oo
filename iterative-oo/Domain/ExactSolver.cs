namespace iterative_oo.Domain;

internal class ExactSolver
{
    public IEnumerable<Expression> DistinctExpressionFor(ProblemStatement problem) => new ExpressionStream().DistinctFor(problem.InputNumbers)
        .Where(expression => expression.Value == problem.DesiredResult);
}
