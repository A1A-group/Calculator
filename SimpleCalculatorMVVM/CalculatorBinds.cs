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
        public static ICommand HandleKey(KeyEventArgs e, CalculatorViewModel viewModel)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                string number = (e.Key - Key.D0).ToString();
                return new DigitCommand(viewModel, number); /*viewModel.NumberClick(number);*/
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
            {
                string number = (e.Key - Key.NumPad0).ToString();
                return new DigitCommand(viewModel, number); /*viewModel.NumberClick(number);*/
            }
            else
            {
                switch (e.Key)
                {
                    case Key.Add:
                    case Key.OemPlus when Keyboard.Modifiers == ModifierKeys.None:
                        return new OperatorCommand(viewModel, "+"); /*viewModel.OperationClick("+");*/
                        //break;

                    case Key.Subtract:
                    case Key.OemMinus:
                        return new OperatorCommand(viewModel, "-"); /*viewModel.OperationClick("-");*/
                        //break;

                    case Key.Multiply:
                        return new OperatorCommand(viewModel, "*"); /*viewModel.OperationClick("*");*/
                        //break;

                    case Key.Divide:
                    case Key.Oem2: // '/' на основной клавиатуре
                        return new OperatorCommand(viewModel, "/"); /*viewModel.OperationClick("/");*/
                        //break;

                    
                    case Key.Return:
                        return new EqualsCommand(viewModel); /*viewModel.EqualsClick();*/
                        //break;

                    case Key.Back:
                        return new DeleteCommand(viewModel); /*viewModel.DeleteClick();*/
                        //break;

                    case Key.Delete:
                    case Key.Escape:
                        return new ClearCommand(viewModel); /*viewModel.ClearClick();*/
                        //break;

                    case Key.OemComma:
                    case Key.Decimal:
                        return new SpecialOperatorCommand(viewModel, ","); /*viewModel.SpecialOperationClick(",");*/
                        //break;

                    case Key.F9:
                        return new SpecialOperatorCommand(viewModel, "+/-"); /*viewModel.SpecialOperationClick("+/-");*/
                        //break;

                    default:
                        return null;
                }
            }
        }
    }
}