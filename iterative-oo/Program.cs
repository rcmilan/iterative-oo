using System.Collections.Immutable;

namespace iterative_oo;

internal class Program
{
    private const int PossibleOps = 4; // +, -, *, /

    static void Main(string[] args)
    {
        bool halt = false;
        do
        {
            Console.Write("Input Numbers: ");
            var inputNumbers = (Console.ReadLine() ?? string.Empty).Split(" ")
                .Select(n => int.TryParse(n, out int r) ? r : 0)
                .Where(n => n > 0).OrderBy(n => n).ToImmutableArray();

            if (inputNumbers.Length != 0)
            {
                Console.Write("Input Desired Result: ");
                if (int.TryParse(Console.ReadLine(), out int desiredResult))
                {
                    Console.WriteLine($"Inputs: {string.Join(';', inputNumbers)} : {desiredResult}");

                    for (int i = PossibleOps * (inputNumbers.Length - 1); i > 0; i--)
                    {
                        Console.WriteLine($"Teste:{i % PossibleOps}");
                    }
                }
                else
                {
                    halt = true;
                }
            }
            else
            {
                halt = true;
            }
        } while (!halt);

        Console.Write("Halt!");
    }
}
