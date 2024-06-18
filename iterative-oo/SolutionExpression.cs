namespace iterative_oo
{
    internal class SolutionExpression
    {
        private readonly int Value;

        private readonly IEnumerable<int> UsedNumbers = [];

        private readonly char Op;
        private readonly SolutionExpression? LeftChild;
        private readonly SolutionExpression? RightChild;

        private SolutionExpression(int number)
        {
            Value = number;
            UsedNumbers = [number];
            Op = '\0';
        }

        private SolutionExpression(int value, char op, SolutionExpression lChild, SolutionExpression rChild) : this(value)
        {
            this.UsedNumbers = lChild.UsedNumbers.Union(rChild.UsedNumbers);
            this.Op = op;
            this.LeftChild = lChild;
            this.RightChild = rChild;
        }

        public override string? ToString() => $"{PlainToString(this)} == {this.Value}";

        private static string PlainToString(SolutionExpression expr) => expr.Op == '\0' ? $"{expr.Value}"
                : $"{Parenthesize(expr.LeftChild!)} {expr.Op} {Parenthesize(expr.RightChild!)}";

        private static string Parenthesize(SolutionExpression child) => child.Op == '\0' ? $"{child.Value}" : $"({PlainToString(child)})";

        public static SolutionExpression Solve(InputStatement inputStatement)
        {
            var combiningExpressionsQueue = new Queue<SolutionExpression>(inputStatement.Inputs.Select(n => new SolutionExpression(n)));

            var knownExpressions = new List<SolutionExpression>();

            while (combiningExpressionsQueue.TryDequeue(out SolutionExpression? currentExpression))
            {
                if (currentExpression.Value == inputStatement.TargetResult)
                    return currentExpression;

                IEnumerable<SolutionExpression> combinableWith = knownExpressions
                    .Where(expr => !expr.UsedNumbers.Intersect(currentExpression.UsedNumbers).Any());

                foreach (var existing in combinableWith)
                {
                    combiningExpressionsQueue.Enqueue(currentExpression.CombineWith(existing, '+', currentExpression.Value + existing.Value));
                    combiningExpressionsQueue.Enqueue(currentExpression.CombineWith(existing, '-', currentExpression.Value - existing.Value));
                    combiningExpressionsQueue.Enqueue(existing.CombineWith(currentExpression, '-', existing.Value - currentExpression.Value));
                    combiningExpressionsQueue.Enqueue(currentExpression.CombineWith(existing, '*', currentExpression.Value * existing.Value));

                    if(existing.Value != 0 && currentExpression.Value % existing.Value == 0)
                    {
                        combiningExpressionsQueue.Enqueue(currentExpression.CombineWith(existing, '/', currentExpression.Value / existing.Value));
                    }

                    if (currentExpression.Value != 0 && existing.Value % currentExpression.Value == 0)
                    {
                        combiningExpressionsQueue.Enqueue(existing.CombineWith(currentExpression, '/', existing.Value / currentExpression.Value));
                    }
                }

                knownExpressions.Add(currentExpression);
            }

            return null;
        }

        private SolutionExpression CombineWith(SolutionExpression other, char op, int value) => new SolutionExpression(value, op, this, other);
    }
}