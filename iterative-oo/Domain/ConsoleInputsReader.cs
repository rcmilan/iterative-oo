﻿using iterative_oo.Common;

internal class ConsoleInputsReader
{
    private readonly string PromptLabel;

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ConsoleInputsReader"/> com o rótulo padrão "Input Numbers: ".
    /// </summary>
    public ConsoleInputsReader() : this("Input Numbers: ") { }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="ConsoleInputsReader"/> com o rótulo especificado.
    /// </summary>
    /// <param name="label">O rótulo a ser exibido como prompt.</param>
    public ConsoleInputsReader(string label)
    {
        PromptLabel = label;
    }

    /// <summary>
    /// Lê todas as entradas da entrada padrão e retorna uma sequência de sequências de números inteiros não negativos.
    /// </summary>
    /// <returns>Uma sequência de sequências de números inteiros não negativos.</returns>
    internal IEnumerable<IEnumerable<int>> ReadAll() =>
        Console.In.IncomingLines(Prompt).NonNegativeIntegerSequences();

    /// <summary>
    /// Exibe o prompt para entrada de números.
    /// </summary>
    private void Prompt() => Console.Write(PromptLabel);
}
