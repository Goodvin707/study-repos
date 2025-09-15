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
using WpfApp9.Resourses.RequestsWindow;

namespace WpfApp9.Resourses.MessageWinfow
{
    /// <summary>
    /// Логика взаимодействия для FindTakeOutReq.xaml
    /// </summary>
    public partial class FindTakeOutReq : Window
    {
        public FindTakeOutReq()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FindeString.NameRecipient = NameRec.Text;
            FindeString.SurnameRecipient = SurnameRec.Text;
            FindeString.PatronymicRecipient = PatronymivRec.Text;

            FindeString.NameTaker = TakerName.Text;
            FindeString.SunamTaker = TakerSurname.Text;
            FindeString.PatronymicTaker = TakerPatronymic.Text;

            FindeString.Reason = Reason.Text;
            FindeString.Date = DateWork_dd.Text + "." + DateWork_mm.Text + "." + DateWork_yyyy.Text;
            FindeString.Time = TimeWork_hh.Text + ":" + TimeWork_mm.Text;

            FindeString.Pass = Pass.Text;
            FindeString.AdressPass = Adress.Text;
            FindeString.ItemName = Item.Text;
            FindeString.Count = ItemCount.Text;
            FindeString.ModelNumber = ItemNumber.Text;     




            

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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void NextSmm(object sender, TextChangedEventArgs e)
        {
            if (DateWork_dd.Text.Length == 2)
                DateWork_mm.Focus();
        }

        private void NextSyyyy(object sender, TextChangedEventArgs e)
        {
            if (DateWork_mm.Text.Length == 2)
                DateWork_yyyy.Focus();
        }

        private void NextShh(object sender, TextChangedEventArgs e)
        {
            if (DateWork_yyyy.Text.Length == 4)
                TimeWork_hh.Focus();
        }

        private void NextSm(object sender, TextChangedEventArgs e)
        {
            if (TimeWork_hh.Text.Length == 2)
                TimeWork_mm.Focus();
        }
    }
}
