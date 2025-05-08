using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class PowerOperation : IOperation
    {
        public double Calculate(double a, double b) => Math.Pow(a, b);
    }
}
