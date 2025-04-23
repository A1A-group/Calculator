namespace SimpleCalculatorFactory.Operations
{
    public class SubtractOperation : IOperation
    {
        public double Calculate(double a, double b) => a - b;
    }
}
