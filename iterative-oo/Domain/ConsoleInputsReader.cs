using iterative_oo.Common;

internal class ConsoleInputsReader
{
    private readonly string PromptLabel;

    public ConsoleInputsReader() : this("Input Numbers: ") { }

    public ConsoleInputsReader(string label)
    {
        this.PromptLabel = label;
    }

    /// <summary>
    /// Lê todas as entradas e retorna uma sequência de declarações de problema.
    /// </summary>
    /// <returns>Uma sequência de objetos ProblemStatement.</returns>
    internal IEnumerable<IEnumerable<int>> ReadAll() =>
        Console.In.IncomingLines(this.Prompt).NonNegativeIntegerSequences();

    /// <summary>
    /// Exibe o prompt para entrada de números.
    /// </summary>
    private void Prompt() => Console.Write(PromptLabel);
}
