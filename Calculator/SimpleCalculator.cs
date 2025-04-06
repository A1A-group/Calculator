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
        private string operation;

        public double Result => result;

        public void SetOperation(string operation)
        {
            this.operation = operation;
        }

        public void PerformOperation(double secondNumber)
        {
            switch (operation)
            {
                case "+":
                    result += secondNumber;
                    break;
                case "-":
                    result -= secondNumber;
                    break;
                case "*":
                    result *= secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result /= secondNumber;
                    else
                        throw new DivideByZeroException("Деление на ноль!");
                    break;

                    // добавить операцию возведения в степень и того чего не хватает в функционале

                default:
                    result = secondNumber;
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
