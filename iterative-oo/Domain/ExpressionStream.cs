using iterative_oo.Common;
using iterative_oo.Domain.Expressions;

namespace iterative_oo.Domain;

internal class ExpressionStream
{
    internal IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) =>
        inputNumbers.Select(n => new Literal(n))
        .AsPartition()
        .Split()
        .Where(split => split.left.Any())
        .Select(split => CreateAdditive(split.left.First(), split.left.Skip(1).AsPartition(), split.right));

    private Expression CreateAdditive(Literal head, IEnumerable<Literal> add, IEnumerable<Literal> subtract)
    {
        return head.Add(add).Subtract(subtract);
    }

}
