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

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для AcceMess.xaml
    /// </summary>
    public partial class AcceMess : Window
    {
        public AcceMess()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Login.Text = NewAccountInformation.Login;
            Password.Text = NewAccountInformation.Password;
            name.Text = NewAccountInformation.Name;
            Surname.Text = NewAccountInformation.Surname;
            Petronymic.Text = NewAccountInformation.Petronymic;
            Post.Text = NewAccountInformation.Post;
            
        }
    }
}
