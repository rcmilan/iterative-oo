using iterative_oo;

internal class Program
{
    private static IEnumerable<ProblemStatement> ProblemStatements = new ConsoleProblemReader().ReadAll();

    private static void Main(string[] args)
    {
        ProblemStatements.WriteLinesTo(Console.Out);

        Console.WriteLine("Halt!");
    }
}