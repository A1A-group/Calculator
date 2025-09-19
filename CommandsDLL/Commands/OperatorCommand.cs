using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsDLL
{
    public class OperatorCommand : ICommand
    {
        private CalculatorViewModel viewModel;
        private string operation;

        public OperatorCommand(CalculatorViewModel viewModel, string operation)
        {
            this.viewModel = viewModel;
            this.operation = operation;
        }

        public void Execute()
        {
            viewModel.OperationClick(operation);
        }
    }
}
