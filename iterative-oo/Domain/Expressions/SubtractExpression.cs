namespace iterative_oo.Domain.Expressions;

internal class SubtractExpression(Expression left, Expression right) : BinaryExpression(left, right)
{
    protected override string OperatorToString => "-";

    protected override int Combine(int left, int right) => left - right;
}
