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
    /// Логика взаимодействия для CreateRequestPassage.xaml
    /// </summary>
    public partial class CreateRequestPassage : Window
    {
        public CreateRequestPassage()
        {
            InitializeComponent();
        }

        private void Down(object sender, MouseEventArgs e)
        {
            var temp = (Image)sender;
            temp.Opacity = 1;
        }

        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        private void Up(object sender, MouseEventArgs e)
        {
            var temp = (Image)sender;
            temp.Opacity = 0.5;
        }

        private void AppClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();           
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            DialogResult=true; 
        }


        private void Search_LostFocusF(object sender, RoutedEventArgs e)
        {

        }
    }
}
