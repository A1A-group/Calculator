using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class ButtonFactory
    {
        public IButton CreateButton(string type, string content = null)
        {
            switch (type)
            {
                case "Digit":
                    return new DigitButton(int.Parse(content));
                case "Operator":
                    return new OperatorButton(content);
                case "Equals":
                    return new EqualsButton();
                case "Clear":
                    return new ClearButton();
                case "Delete":
                    return new DeleteButton();
                case "Special":
                    return new SpecialButton(content);
                default:
                    throw new ArgumentException("Неверный тип кнопки");
            }
        }
    }
}
