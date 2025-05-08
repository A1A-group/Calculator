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
            viewModel.HandleButtonClick(createdButton);
            UpdateDisplay();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        { 
            Button button = (Button)sender;
            IButton createdButton = buttonFactory.CreateButton("Operator", button.Content.ToString());
            viewModel.HandleButtonClick(createdButton);
            UpdateDisplay();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            IButton createdButton = buttonFactory.CreateButton("Equals");
            viewModel.HandleButtonClick(createdButton);
            UpdateDisplay();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            IButton createdButton = buttonFactory.CreateButton("Clear");
            viewModel.HandleButtonClick(createdButton);
            UpdateDisplay();
        }

        private void Special_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            IButton createdButton = buttonFactory.CreateButton("Special", button.Content.ToString());
            viewModel.HandleButtonClick(createdButton);
            UpdateDisplay();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            IButton createdButton = buttonFactory.CreateButton("Delete");
            viewModel.HandleButtonClick(createdButton);
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            Display.Text = viewModel.Display.ToString();
            AuxiliaryDisplay.Text = viewModel.AuxiliaryDisplay.ToString();
        }
    }
}
