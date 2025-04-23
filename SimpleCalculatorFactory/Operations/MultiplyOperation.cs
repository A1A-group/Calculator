namespace SimpleCalculatorFactory.Operations
{
    public class MultiplyOperation : IOperation
    {
        public double Calculate(double a, double b) => a * b;
    }
}
