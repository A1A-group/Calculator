using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        private double result;
        private string operation;

        public double Result => result;

        public void SetOperation(string operation)
        {
            this.operation = operation;
        }

        public void PerformOperation(double number)
        {
            switch (operation)
            {
                case "+":
                    result += number;
                    break;
                case "-":
                    result -= number;
                    break;
                case "*":
                    result *= number;
                    break;
                case "/":
                    if (number != 0)
                        result /= number;
                    else
                        throw new DivideByZeroException("Деление на ноль!");
                    break;
                default:
                    result = number;
                    break;
            }
        }

        public void Clear()
        {
            result = 0;
            operation = string.Empty;
        }
    }
}
