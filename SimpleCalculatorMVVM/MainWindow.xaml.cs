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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Получаем начальные значения шрифта из ресурсов
            // Приводим к типу Style и получаем FontSize из Setter
            Style auxiliaryStyle = (Style)this.FindResource("AuxiliaryDisplayStyle");
            Style displayStyle = (Style)this.FindResource("DisplayStyle");
            Style buttonStyle = (Style)this.FindResource("ButtonStyle");
            Style menuItemStyle = (Style)this.FindResource("MenuItemStyle");

            double initialAuxiliaryFontSize = (double)(auxiliaryStyle.Setters[0] as Setter).Value;
            double initialDisplayFontSize = (double)(displayStyle.Setters[0] as Setter).Value;
            double initialButtonFontSize = (double)(buttonStyle.Setters[0] as Setter).Value;
            double initialMenuItemFontSize = (double)(menuItemStyle.Setters[0] as Setter).Value;

            // Устанавливаем новый размер шрифта в зависимости от высоты окна
            double scaleFactor = e.NewSize.Height / this.MinHeight;

            AuxiliaryDisplay.FontSize = initialAuxiliaryFontSize * scaleFactor; // Увеличиваем шрифт для верхнего дисплея
            Display.FontSize = initialDisplayFontSize * scaleFactor; // Увеличиваем шрифт для нижнего дисплея

            // Увеличиваем шрифт для кнопок
            foreach (UIElement element in FindVisualChildren<Button>(this))
            {
                if (element is Button button)
                {
                    button.FontSize = initialButtonFontSize * scaleFactor; // Увеличиваем шрифт для кнопок
                }
            }

            // Увеличиваем шрифт для пунктов меню
            foreach (UIElement element in FindVisualChildren<MenuItem>(this))
            {
                if (element is MenuItem menuItem)
                {
                    double fontSize = initialMenuItemFontSize * scaleFactor; // Увеличиваем шрифт для пунктов меню
                    menuItem.FontSize = (fontSize < 18) ? fontSize : 18;
                }
            }
        }

        // Метод для поиска всех детей визуального дерева
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Это калькулятор. Используйте кнопки для выполнения операций.", "Помощь", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            // Добавить пункт о программе
            MessageBox.Show("Что нибудь написать о программе калькулятор...", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
