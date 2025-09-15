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

namespace WpfApp9.Resourses.MessageWinfow
{
    /// <summary>
    /// Логика взаимодействия для InPrograss.xaml
    /// </summary>
    public partial class InPrograss : Window
    {
        public InPrograss(string functionApp, string Reason)
        {
            InitializeComponent();
            this.functionApp.Text = functionApp;
            this.Reason.Text = Reason;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
