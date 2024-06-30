using iterative_oo.Common;

internal class ConsoleProblemReader
{
    public ConsoleInputsReader InputsReader { get; } = new ConsoleInputsReader("Input Numbers:\t");

    /// <summary>
    /// Retorna uma sequência de inteiros não negativos lidos da entrada padrão (Console.In) após exibir um prompt.
    /// </summary>
    private IEnumerable<int> DesiredResults =>
        Console.In.IncomingLines(PromptDesiredResult).SingleNonNegativeIntegers();

    /// <summary>
    /// Retorna uma sequência de tuplas contendo uma sequência de inteiros de entrada e um resultado.
    /// </summary>
    private IEnumerable<(IEnumerable<int> inputs, int result)> RawNumbersSequence =>
        this.InputNumberSequences.Zip(DesiredResults, (IEnumerable<int> inputs, int result) => (inputs, result));

    /// <summary>
    /// Retorna uma sequência de sequências de inteiros não negativos lidos da entrada padrão após exibir um prompt.
    /// </summary>
    private IEnumerable<IEnumerable<int>> InputNumberSequences => this.InputsReader.ReadAll();


    /// <summary>
    /// Exibe o prompt para entrada do resultado desejado.
    /// </summary>
    private void PromptDesiredResult() => Console.Write("Input Desired Result:\t");

    /// <summary>
    /// Lê todas as entradas e retorna uma sequência de declarações de problema.
    /// </summary>
    /// <returns>Uma sequência de objetos ProblemStatement.</returns>
    internal IEnumerable<ProblemStatement> ReadAll() =>
        RawNumbersSequence.Select(tuple => new ProblemStatement(tuple.inputs, tuple.result));
}
