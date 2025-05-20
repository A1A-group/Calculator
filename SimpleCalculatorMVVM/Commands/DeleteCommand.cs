using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class DeleteCommand : ICommand
    {
        private CalculatorViewModel viewModel;

        public DeleteCommand(CalculatorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public void Execute()
        {
            viewModel.DeleteClick();
        }
    }
}
