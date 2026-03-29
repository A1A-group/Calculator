using System;

namespace Calculator
{
    /// <summary>
    /// Модель представления для калькулятора.
    /// </summary>
    public class CalculatorViewModel
    {
        private SimpleCalculator calculator;
        private string display;
        private string auxiliaryDisplay;
        private bool operationChoose;
        private bool finalAnswer;

        /// <summary>
        /// Получает или устанавливает текст на дисплее калькулятора.
        /// </summary>
        public string Display
        {
            get => display;
            set => display = value;
        }

        /// <summary>
        /// Получает или устанавливает текст на вспомогательном дисплее.
        /// </summary>
        public string AuxiliaryDisplay
        {
            get => auxiliaryDisplay;
            set => auxiliaryDisplay = value;
        }

        /// <summary>
        /// Конструктор модели представления.
        /// </summary>
        public CalculatorViewModel()
        {
            calculator = new SimpleCalculator();
            Display = "0";
            AuxiliaryDisplay = "";
            operationChoose = false;
            finalAnswer = false;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки числа.
        /// </summary>
        /// <param name="number">Строка с числом.</param>
        public void NumberButtonClick(string number)
        {
            if (finalAnswer) Clear();

            if (Display == "0" || operationChoose)
            {
                Display = number;
            }
            else Display += number;

            operationChoose = false;
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки операции.
        /// </summary>
        /// <param name="operation">Строка с операцией.</param>
        public void OperationButtonClick(string operation)
        {
            double number = double.Parse(Display);

            if (!operationChoose && !finalAnswer)
            {
                calculator.PerformOperation(number);
            }

            Display = calculator.Result.ToString();
            calculator.SetOperation(operation);
            AuxiliaryDisplay = calculator.Result.ToString() + operation;

            operationChoose = true;
            finalAnswer = false;
        }

        /// <summary>
        /// Обрабатывает нажатие специальных кнопок.
        /// </summary>
        /// <param name="operation">Строка с операцией.</param>
        public void SpecialButtonClick(string operation)
        {
            if (!finalAnswer)
            {
                double number = double.Parse(Display);
                switch (operation)
                {
                    case "+/-":
                        number *= -1;
                        Display = number.ToString();
                        break;
                    case ",":
                        if (!Display.Contains(",")) Display += ",";
                        break;
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие кнопки равенства.
        /// </summary>
        public void EqualsClick()
        {
            try
            {
                if (!finalAnswer)
                {
                    double number = double.Parse(Display);
                    calculator.PerformOperation(number);
                    AuxiliaryDisplay += number.ToString() + "=";
                }
                else
                {
                    calculator.RepeatLastOperation();
                    AuxiliaryDisplay = calculator.Result.ToString() + calculator.Operation + "=";
                }

                Display = calculator.Result.ToString();
                finalAnswer = true;
            }
            catch (DivideByZeroException ex)
            {
                Display = "Ошибка";
                AuxiliaryDisplay = ex.Message;
                finalAnswer = true;
            }
        }

        /// <summary>
        /// Очищает все поля и состояния.
        /// </summary>
        public void Clear()
        {
            calculator.Clear();
            Display = "0";
            AuxiliaryDisplay = "";
            operationChoose = false;
            finalAnswer = false;
        }

        /// <summary>
        /// Удаляет последний ввод.
        /// </summary>
        public void Del()
        {
            if (Display.Length > 1)
            {
                Display = Display.Substring(0, Display.Length - 1);
            }
            else
            {
                Display = "0";
                operationChoose = false;
            }
        }
    }
}