using iterative_oo.Common;
using iterative_oo.Domain;

internal class Program
{
    private static IEnumerable<ProblemStatement> ProblemStatements = new ConsoleProblemReader().ReadAll();

    private static void Main(string[] args)
    {
        //ProductionBehavior();
        ExpressionStreamDemo();
    }

    static void ExpressionStreamDemo() => InputNumbersSequence
        .Select(new ExpressionStream().DistinctFor)
        .SelectMany(expressions => Report(expressions, "No expressions found!"))
        .WriteLinesTo(Console.Out);

    static void ProductionBehavior() =>
        ProblemStatements
            .Select(problem => new ExactSolver().DistinctExpressionFor(problem))
            .SelectMany(expressions => Report(expressions, "No solutions for the problem!"))
            .WriteLinesTo(Console.Out);

    private static IEnumerable<IEnumerable<int>> InputNumbersSequence => new ConsoleInputsReader().ReadAll();

    private static IEnumerable<string> Report(IEnumerable<Expression> expressions, string onEmpty) => expressions
            .Select((expression, index) => $"{index + 1, 3}. {expression} = {expression.Value}")
            .DefaultIfEmpty(onEmpty);
}