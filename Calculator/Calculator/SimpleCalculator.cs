using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class SimpleCalculator
    {
        private double result;
        private IOperation operation;
        private string operationSymbol;
        private double lastOperand;

        public double Result => result;
        public string Operation => operationSymbol;

        public void SetOperation(string operationSymbol)
        {
            this.operation = OperationFactory.Create(operationSymbol);
            this.operationSymbol = operationSymbol;
        }

        public void PerformOperation(double secondNumber)
        {
            lastOperand = secondNumber;
            if (operation != null)
            {
                result = operation.Execute(result, secondNumber);
            }
            else
            {
                result = secondNumber; // первый ввод
            }
        }

        public void RepeatLastOperation()
        {
            PerformOperation(lastOperand);
        }

        public void Clear()
        {
            result = 0;
            operationSymbol = string.Empty;
            operation = null;
        }
    }
}
