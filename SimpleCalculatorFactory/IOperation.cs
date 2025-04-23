using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorFactory.Operations
{
    public interface IOperation
    {
        double Calculate(double a, double b);
    }
}

