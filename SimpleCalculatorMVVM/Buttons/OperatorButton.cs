using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class OperatorButton : IButton
    {
        private string _operation;

        public OperatorButton(string operation)
        {
            _operation = operation;
        }

        public string Press() => _operation;
    }
}
