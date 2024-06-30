internal class ProblemStatement
{
    private readonly IEnumerable<int> InputNumbers;
    private readonly int DesiredResult;

    /// <summary>
    /// Inicializa uma nova instância da classe ProblemStatement com os números de entrada e o resultado desejado.
    /// </summary>
    /// <param name="input">A sequência de números de entrada.</param>
    /// <param name="desiredResult">O resultado desejado.</param>
    public ProblemStatement(IEnumerable<int> input, int desiredResult)
    {
        InputNumbers = input;
        DesiredResult = desiredResult;
    }

    /// <summary>
    /// Retorna uma representação em string da declaração de problema.
    /// </summary>
    /// <returns>Uma string que representa a declaração de problema.</returns>
    public override string? ToString() => $"Problem Statement: [{InputNumbersFormattedList} -> {DesiredResult}]";

    /// <summary>
    /// Formata a lista de números de entrada como uma string separada por vírgulas.
    /// </summary>
    private string InputNumbersFormattedList => string.Join(", ", InputNumbers.Select(number => $"{number}").ToArray());
}
