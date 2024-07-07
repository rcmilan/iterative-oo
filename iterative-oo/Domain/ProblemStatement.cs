namespace iterative_oo.Domain;

/// <summary>
/// Inicializa uma nova instância da classe <see cref="ProblemStatement"/> com os números de entrada e o resultado desejado.
/// </summary>
/// <param name="input">A sequência de números de entrada.</param>
/// <param name="desiredResult">O resultado desejado.</param>
public class ProblemStatement(IEnumerable<int> input, int desiredResult)
{
    /// <summary>
    /// A sequência de números de entrada.
    /// </summary>
    public readonly IEnumerable<int> InputNumbers = input;

    /// <summary>
    /// O resultado desejado.
    /// </summary>
    public readonly int DesiredResult = desiredResult;

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