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
using WpfApp9.BusinesLogic.MainInfo.PersonalInformation;
using WpfApp9.Resourses.RequestsWindow;

namespace WpfApp9.Resourses.MessageWinfow
{
    /// <summary>
    /// Логика взаимодействия для Find.xaml
    /// </summary>
    public partial class Find : Window
    {
        public Find()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FindeString.NameRecipient = NameRec.Text;
            FindeString.SurnameRecipient = SurnameRec.Text;
            FindeString.PatronymicRecipient = PatronymivRec.Text;
            FindeString.NameGiver = NameGiv.Text;
            FindeString.SunamGiver = SurnameGiv.Text;
            FindeString.PatronymicGiver = PatrinymicGiv.Text;
            FindeString.Reason = Reason.Text;
            FindeString.Date = Date.Text;
            FindeString.DateReturn = DateReturn.Text;
            FindeString.TempPassNumber = PassNum.Text;
            DialogResult = true;
            this.Close();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Up(object sender, MouseEventArgs e)
        {

        }

        private void Down(object sender, MouseEventArgs e)
        {

        }

        private void AppClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
