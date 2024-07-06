using iterative_oo.Common;
using iterative_oo.Domain.Expressions;

namespace iterative_oo.Domain;

internal class ExpressionStream
{
    internal IEnumerable<Expression> DistinctFor(IEnumerable<int> inputNumbers) =>
        inputNumbers.IsEmpty() ? Enumerable.Empty<Expression>()
        : [Add(inputNumbers)];

    internal Expression Add(IEnumerable<int> numbers) =>
        numbers.Select<int, Expression>(n => new Literal(n))
            .Aggregate((left, next) => new AddExpression(left, next));
}
