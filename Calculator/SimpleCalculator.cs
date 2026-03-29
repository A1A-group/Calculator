using System;

namespace Calculator
{
    /// <summary>
    /// Класс для простого калькулятора.
    /// </summary>
    class SimpleCalculator
    {
        private double result;
        private string operation;
        private double lastOperand;

        /// <summary>
        /// Получает результат последней операции.
        /// </summary>
        public double Result => result;

        /// <summary>
        /// Получает последнюю операцию.
        /// </summary>
        public string Operation => operation;

        /// <summary>
        /// Устанавливает операцию для калькулятора.
        /// </summary>
        /// <param name="operation">Операция в виде строки.</param>
        public void SetOperation(string operation)
        {
            this.operation = operation;
        }

        /// <summary>
        /// Выполняет операцию с заданным числом.
        /// </summary>
        /// <param name="secondNumber">Второе число для операции.</param>
        public void PerformOperation(double secondNumber)
        {
            lastOperand = secondNumber;
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
                case "^":
                    result = Math.Pow(result, secondNumber);
                    break;
                case "/":
                    if (secondNumber != 0)
                        result /= secondNumber;
                    else
                        throw new DivideByZeroException("Деление на ноль!");
                    break;
                default:
                    result = secondNumber;
                    break;
            }
        }

        /// <summary>
        /// Повторяет последнюю операцию.
        /// </summary>
        public void RepeatLastOperation()
        {
            PerformOperation(lastOperand);
        }

        /// <summary>
        /// Очищает результаты калькулятора.
        /// </summary>
        public void Clear()
        {
            result = 0;
            operation = string.Empty;
        }
    }
}
