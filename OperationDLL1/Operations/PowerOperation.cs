using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationDLL1
{
    public class PowerOperation : IOperation
    {
        public double Calculate(double a, double b) => Math.Pow(a, b);
    }
}
