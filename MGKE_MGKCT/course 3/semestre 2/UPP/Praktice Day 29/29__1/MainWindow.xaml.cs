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

namespace _29__1
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

        private void MouseEnter(object sender, MouseEventArgs e)
        {
            Random random = new Random();
            int x = random.Next(0, (int)this.Width - (int)button1.Width);
            int y = random.Next(0, (int)this.Height - (int)button1.Height);
            button1.Margin = new Thickness(x, y, (int)this.Width - x - (int)button1.Width, (int)this.Height - y - (int)button1.Height);
        }
    }
}