using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class SpecialButton : IButton
    {
        private string _operation;

        public SpecialButton(string operation)
        {
            _operation = operation;
        }

        public string Press() => _operation;
        public string Type => "Special"; // Тип кнопки
    }
}
