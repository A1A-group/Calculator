
namespace CommandsDLL
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
