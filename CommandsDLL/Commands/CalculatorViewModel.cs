using SimpleCalculatorMVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsDLL
{
    public class CalculatorViewModel
    {
        private CalculatorFacade calculator;
        private string display;
        private string auxiliryDisplay;

        private bool operationChoose;
        private bool finalAnswer;

        public string Display
        {
            get => display;
            set
            {
                display = value;
            }
        }

        public string AuxiliaryDisplay
        {
            get => auxiliryDisplay;
            set
            {
                auxiliryDisplay = value;
            }
        }

        public CalculatorViewModel()
        {
            calculator = new CalculatorFacade();
            Display = "0";
            AuxiliaryDisplay = "";

            operationChoose = false;
            finalAnswer = false;
        }

        public void HandleCommand(ICommand command)
        {
            command?.Execute();
        }

        public void NumberClick(string number)
        {
            if (finalAnswer) ClearClick();

            if (Display == "0" || operationChoose)
            {
                Display = number;
            }
            else Display += number;

            operationChoose = false;
        }

        public void OperationClick(string operation)
        {
            double number = double.Parse(Display);

            if (!operationChoose && !finalAnswer)
            {
                calculator.PerformOperation(number);
            }

            Display = calculator.Result.ToString();
            calculator.SetOperation(operation);
            AuxiliaryDisplay = calculator.Result.ToString() + operation;

            operationChoose = true; // операция выбрана
            finalAnswer = false;
        }

        public void SpecialOperationClick(string operation)
        {
            if (!finalAnswer)
            {
                double number = double.Parse(Display);
                switch (operation)
                {
                    case "+/-":
                        number *= -1; // Изменяем знак
                        Display = number.ToString();
                        break;
                    case ",":
                        if (!Display.Contains(",")) Display += ","; // Добавляем запятую
                        break;
                }
            }
        }

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

        public void ClearClick() // Метод для AC
        {
            calculator.Clear();
            Display = "0";
            AuxiliaryDisplay = "";

            operationChoose = false;
            finalAnswer = false;
        }

        public void DeleteClick() // Метод для DEL
        {
            if (Display.Length > 1)
            {
                Display = Display.Substring(0, Display.Length - 1);
            }
            else
            {
                Display = "0"; // Если у нас остается пустая строка, устанавливаем "0"
                operationChoose = false;
            }
        }
    }
}