using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class DigitButton : IButton
    {
        private int _digit;

        public DigitButton(int digit)
        {
            _digit = digit;
        }

        public string Press() => _digit.ToString();
        public string Type => "Digit"; // Тип кнопки
    }
}
