using System;

namespace SimpleCalculatorMVVM
{
    /// <summary>
    /// Фасад для работы с SimpleCalculator, инкапсулирует вычислительную логику.
    /// </summary>
    public class CalculatorFacade
    {
        private readonly SimpleCalculator calculator;

        public CalculatorFacade()
        {
            calculator = new SimpleCalculator();
        }

        public double Result => calculator.Result;
        public string Operation => calculator.Operation;

        public void SetOperation(string operation)
        {
            calculator.SetOperation(operation);
        }

        public void PerformOperation(double secondNumber)
        {
            calculator.PerformOperation(secondNumber);
        }

        public void RepeatLastOperation()
        {
            calculator.RepeatLastOperation();
        }

        public void Clear()
        {
            calculator.Clear();
        }
    }
}