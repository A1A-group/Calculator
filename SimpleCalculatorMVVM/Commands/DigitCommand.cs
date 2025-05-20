using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCalculatorMVVM
{
    public class DigitCommand : ICommand
    {
        private CalculatorViewModel viewModel;
        private string digit;

        public DigitCommand(CalculatorViewModel viewModel, string digit)
        {
            this.viewModel = viewModel;
            this.digit = digit;
        }

        public void Execute()
        {
            viewModel.NumberClick(digit);
        }
    }
}