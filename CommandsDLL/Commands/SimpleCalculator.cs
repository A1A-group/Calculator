using OperationsDLL;
namespace SimpleCalculatorMVVM
{
    class SimpleCalculator
    {
        private double result;
        private string operation;
        private double lastOperand;

        public double Result => result;
        public string Operation => operation;

        public void SetOperation(string operation)
        {
            this.operation = operation;
        }

        public void PerformOperation(double secondNumber)
        {
            lastOperand = secondNumber;

            IOperation op = OperationFactory.Create(operation);

            if (op == null)
            {
                result = secondNumber;
            }
            else
            {
                result = op.Calculate(result, secondNumber);
            }
        }

        public void RepeatLastOperation()
        {
            PerformOperation(lastOperand);
        }

        public void Clear()
        {
            result = 0;
            operation = string.Empty;
        }
    }
}
