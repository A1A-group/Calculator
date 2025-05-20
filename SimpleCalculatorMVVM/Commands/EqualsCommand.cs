using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class EqualsCommand : ICommand
    {
        private CalculatorViewModel viewModel;

        public EqualsCommand(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Execute()
        {
            viewModel.EqualsClick();
        }
    }
}
