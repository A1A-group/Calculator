using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleCalculatorMVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorViewModel viewModel;
       
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new CalculatorViewModel();

            DataContext = viewModel;
            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ICommand bindCommand = CalculatorBinds.HandleKey(e, viewModel);
            viewModel.HandleCommand(bindCommand);
            UpdateDisplay();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ICommand command = new DigitCommand(viewModel, button.Content.ToString());
            viewModel.HandleCommand(command);
            UpdateDisplay();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ICommand command = new OperatorCommand(viewModel, button.Content.ToString());
            viewModel.HandleCommand(command);
            UpdateDisplay();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            ICommand command = new EqualsCommand(viewModel);
            viewModel.HandleCommand(command);
            UpdateDisplay();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ICommand command = new ClearCommand(viewModel);
            viewModel.HandleCommand(command);
            UpdateDisplay();
        }

        private void Special_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ICommand command = new SpecialOperatorCommand(viewModel, button.Content.ToString());
            viewModel.HandleCommand(command);
            UpdateDisplay();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            ICommand command = new DeleteCommand(viewModel);
            viewModel.HandleCommand(command);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            Display.Text = viewModel.Display.ToString();
            AuxiliaryDisplay.Text = viewModel.AuxiliaryDisplay.ToString();
        }
    }
}
