using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculatorMVVM
{
    public class SpecialOperatorCommand : ICommand
    {
        private CalculatorViewModel viewModel;
        private string specialOperation;

        public SpecialOperatorCommand(CalculatorViewModel viewModel, string specialOperation)
        {
            this.viewModel = viewModel;
            this.specialOperation = specialOperation;
        }

        public void Execute()
        {
            viewModel.SpecialOperationClick(specialOperation);
        }
    }
}
