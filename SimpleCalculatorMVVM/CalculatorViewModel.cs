using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class CalculatorViewModel
    {
        private SimpleCalculator calculator;
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
            calculator = new SimpleCalculator();
            Display = "0";
            AuxiliaryDisplay = "";

            operationChoose = false;
            finalAnswer = false;
        }

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

            operationChoose = true; // операция выбрана
            finalAnswer = false;
        }

        public void SpecialButtonClick(string operation)
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


        public void Clear() // Метод для AC
        {
            calculator.Clear();
            Display = "0";
            AuxiliaryDisplay = "";

            operationChoose = false;
            finalAnswer = false;
        }

        public void Del() // Метод для DEL
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
