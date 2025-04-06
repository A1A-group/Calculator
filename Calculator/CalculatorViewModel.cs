using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalculatorViewModel
    {
        private Calculator calculator;
        private string display;
        private string auxiliryDisplay;

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
            calculator = new Calculator();
            Display = "0";
            AuxiliaryDisplay = "";
        }

        public void NumberButtonClick(string number)
        {
            if (Display == "0")
                Display = number;
            else
                Display += number;
        }

        public void OperationButtonClick(string operation)
        {
            double number = double.Parse(Display);
            calculator.PerformOperation(number);
            calculator.SetOperation(operation);
            Display = "0";
            AuxiliaryDisplay = number.ToString() + operation;
        }

        public void EqualsClick()
        {
            double number = double.Parse(Display);
            calculator.PerformOperation(number);
            Display = calculator.Result.ToString();
            AuxiliaryDisplay += number.ToString() + "=";
        }

        public void Clear() // Метод для AC
        {
            calculator.Clear();
            Display = "0";
            AuxiliaryDisplay = "";
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
            }
        }
    }
}
