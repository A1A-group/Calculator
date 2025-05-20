using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class ClearCommand : ICommand
    {
        private CalculatorViewModel viewModel;

        public ClearCommand(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Execute()
        {
            viewModel.ClearClick();
        }
    }
}
