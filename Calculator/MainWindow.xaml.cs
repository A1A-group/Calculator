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

namespace Calculator
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            viewModel.NumberButtonClick(button.Content.ToString());
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            viewModel.OperationButtonClick(button.Content.ToString());
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            viewModel.EqualsClick();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Clear();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Del();
        }
    }
}
