using iterative_oo;

while (true)
{
    var input = InputStatement.Read();

    if (input == InputStatement.Empty)
        break;

    var solution = SolutionExpression.Solve(input);

    Console.WriteLine(solution?.ToString() ?? "No Solution!");
}

Console.WriteLine("Halt!");
