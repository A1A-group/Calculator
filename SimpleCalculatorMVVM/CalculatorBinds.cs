using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleCalculatorMVVM
{
    public static class CalculatorBinds
    {
        public static void HandleKey(KeyEventArgs e, CalculatorViewModel viewModel)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                string number = (e.Key - Key.D0).ToString();
                viewModel.NumberButtonClick(number);
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                string number = (e.Key - Key.NumPad0).ToString();
                viewModel.NumberButtonClick(number);
            }
            else
            {
                switch (e.Key)
                {
                    case Key.Add:
                    case Key.OemPlus when Keyboard.Modifiers == ModifierKeys.None:
                        viewModel.OperationButtonClick("+");
                        break;

                    case Key.Subtract:
                    case Key.OemMinus:
                        viewModel.OperationButtonClick("-");
                        break;

                    case Key.Multiply:
                        viewModel.OperationButtonClick("*");
                        break;

                    case Key.Divide:
                    case Key.Oem2: // '/' на основной клавиатуре
                        viewModel.OperationButtonClick("/");
                        break;

                    
                    case Key.Return:
                        viewModel.EqualsClick();
                        break;

                    case Key.Back:
                        viewModel.Del();
                        break;

                    case Key.Delete:
                    case Key.Escape:
                        viewModel.Clear();
                        break;

                    case Key.OemComma:
                    case Key.Decimal:
                        viewModel.SpecialButtonClick(",");
                        break;

                    case Key.F9:
                        viewModel.SpecialButtonClick("+/-");
                        break;
                }
            }
        }
    }
}