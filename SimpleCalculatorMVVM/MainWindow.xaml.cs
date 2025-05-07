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
using Calculator;
using SimpleCalculatorFactory;
using SimpleCalculatorMVVM;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorViewModel viewModel;
        private ButtonFactory buttonFactory;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new CalculatorViewModel();
            buttonFactory = new ButtonFactory();
            DataContext = viewModel;
            this.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CalculatorBinds.HandleKey(e, viewModel);
            UpdateDisplay();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            IButton createdButton = buttonFactory.CreateButton("Digit", button.Content.ToString());
            viewModel.NumberButtonClick(createdButton.Press());
            UpdateDisplay();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            IButton createdButton = buttonFactory.CreateButton("Operator", button.Content.ToString());
            viewModel.OperationButtonClick(createdButton.Press());
            UpdateDisplay();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            IButton equalsButton = buttonFactory.CreateButton("Equals");
            viewModel.EqualsClick();
            UpdateDisplay();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            IButton clearButton = buttonFactory.CreateButton("Clear");
            viewModel.Clear();
            UpdateDisplay();
        }

        private void Special_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            IButton specialButton = buttonFactory.CreateButton("Special", button.Content.ToString());
            viewModel.SpecialButtonClick(button.Content.ToString());
            UpdateDisplay();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            IButton deleteButton = buttonFactory.CreateButton("Delete");
            viewModel.Del();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            Display.Text = viewModel.Display.ToString();
            AuxiliaryDisplay.Text = viewModel.AuxiliaryDisplay.ToString();
        }
    }
}
