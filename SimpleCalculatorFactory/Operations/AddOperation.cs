namespace SimpleCalculatorFactory.Operations
{
    public class AddOperation : IOperation
    {
        public double Calculate(double a, double b) => a + b;
    }
}
