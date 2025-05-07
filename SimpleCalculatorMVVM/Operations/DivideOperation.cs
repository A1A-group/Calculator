using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class DivideOperation : IOperation
    {
        public double Calculate(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль");
            return a / b;
        }
    }
}
