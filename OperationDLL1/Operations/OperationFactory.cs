using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationDLL1
{
    public static class OperationFactory
    {
        public static IOperation Create(string operation)
        {
            switch (operation)
            {
                case "+":
                    return new AddOperation();
                case "-":
                    return new SubtractOperation();
                case "*":
                    return new MultiplyOperation();
                case "/":
                    return new DivideOperation();
                case "^":
                    return new PowerOperation();
                default:
                    return null;
                    //throw new InvalidOperationException("Неизвестная операция: " + operation);
            }
        }
    }
}