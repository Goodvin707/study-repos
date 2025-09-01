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

namespace _26__1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double x = Convert.ToInt32(TextBoxX.Text);
            double y = Convert.ToInt32(TextBoxY.Text);
            double n = Convert.ToInt32(TextBoxN.Text);
            double k = Convert.ToInt32(TextBoxK.Text);
            double s = 0;
            for (int i = 1; i < n; i++)
                for (int j = 1; j < k; j++)
                    s += (Math.Sin(Math.Pow(y, i)) + (i * x)) / (i + 1) * j;
            label1.Content = s.ToString();
        }
    }
}