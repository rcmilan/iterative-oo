using iterative_oo.Common;
using iterative_oo.Domain;

IEnumerable<ProblemStatement> ProblemStatements = new ConsoleProblemReader().ReadAll();

SolveProblems();

void SolveProblems() =>
    ProblemStatements
        .Select(ExactSolver.DistinctExpressionFor)
        .SelectMany(expressions => Report(expressions, "No solutions for the problem!"))
        .WriteLinesTo(Console.Out);

IEnumerable<string> Report(IEnumerable<Expression> expressions, string onEmpty) => expressions
        .Select((expression, index) => $"{index + 1,3}. {expression} = {expression.Value}")
        .DefaultIfEmpty(onEmpty);