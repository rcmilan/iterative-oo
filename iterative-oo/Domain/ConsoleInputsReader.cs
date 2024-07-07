using iterative_oo.Common;

namespace iterative_oo.Domain;

/// <summary>
/// Inicializa uma nova instância da classe <see cref="ConsoleInputsReader"/> com o rótulo especificado.
/// </summary>
/// <param name="label">O rótulo a ser exibido como prompt.</param>
public class ConsoleInputsReader(string label)
{
    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ConsoleInputsReader"/> com o rótulo padrão "Input Numbers: ".
    /// </summary>
    public ConsoleInputsReader() : this("Input Numbers: ") { }

    /// <summary>
    /// Lê todas as entradas da entrada padrão e retorna uma sequência de sequências de números inteiros não negativos.
    /// </summary>
    /// <returns>Uma sequência de sequências de números inteiros não negativos.</returns>
    public IEnumerable<IEnumerable<int>> ReadAll() =>
        Console.In.IncomingLines(Prompt).NonNegativeIntegerSequences();

    /// <summary>
    /// Exibe o prompt para entrada de números.
    /// </summary>
    private void Prompt() => Console.Write(label);
}