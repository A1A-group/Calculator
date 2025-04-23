using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PowerOperation : IOperation
    {
        public double Execute(double a, double b) => Math.Pow(a, b);
    }
}
