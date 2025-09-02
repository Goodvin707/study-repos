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

namespace WpfApp9.Resourses.Help
{
    /// <summary>
    /// Логика взаимодействия для HKhelpxaml.xaml
    /// </summary>
    public partial class HKhelpxaml : Window
    {
        public HKhelpxaml()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HotKeys2.Visibility = Visibility.Visible;
            HotKeys1.Visibility = Visibility.Hidden;
            l1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Visible;
        }

        private void l2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            HotKeys2.Visibility = Visibility.Hidden;
            HotKeys1.Visibility = Visibility.Visible;
            l1.Visibility = Visibility.Visible;
            l2.Visibility = Visibility.Hidden;
        }
    }
}
