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
using WpfApp9.Resourses.Help;

namespace WpfApp9.Resourses.MessageWinfow
{
    /// <summary>
    /// Логика взаимодействия для Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HKhelpxaml hKhelpxaml = new HKhelpxaml();
            hKhelpxaml.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Exporthelp exporthelp = new Exporthelp();
            exporthelp.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            adminhelp adminhelp = new adminhelp();
            adminhelp.ShowDialog();
        }
    }
}
