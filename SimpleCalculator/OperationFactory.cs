using Calculator;
using System;

namespace Calculator
{
    public static class OperationFactory
    {
        public static IOperation Create(string op)
        {
            switch (op)
            {
                case "+": return new AddOperation();
                case "-": return new SubtractOperation();
                case "*": return new MultiplyOperation();
                case "/": return new DivideOperation();
                case "^": return new PowerOperation();
                default: throw new InvalidOperationException("Неизвестная операция");
            }
        }
    }
}
