using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class DeleteButton : IButton
    {
        public string Press() => "DEL";
        public string Type => "Delete"; // Тип кнопки
    }
}
