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
using System.Windows.Shapes;

namespace SimpleCalculatorMVVM
{
    /// <summary>
    /// Логика взаимодействия для HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow(string theme)
        {
            InitializeComponent();
            ApplyTheme(theme);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void ApplyTheme(string theme)
        {
            ResourceDictionary resourceDict = new ResourceDictionary();

            // Загрузка стилей
            resourceDict.Source = new Uri("pack://application:,,,/ResourseDictionaries/Styles.xaml");
            Resources.MergedDictionaries.Clear();
            Resources.MergedDictionaries.Add(resourceDict);

            // Загрузка темы
            ResourceDictionary themeDict = new ResourceDictionary();
            if (theme.Equals("Dark", StringComparison.OrdinalIgnoreCase))
            {
                themeDict.Source = new Uri("pack://application:,,,/ResourseDictionaries/DarkTheme.xaml");
            }
            else
            {
                themeDict.Source = new Uri("pack://application:,,,/ResourseDictionaries/LightTheme.xaml");
            }

            Resources.MergedDictionaries.Add(themeDict);
        }
    }
}
