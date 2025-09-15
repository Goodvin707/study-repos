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
    /// Логика взаимодействия для FindWorkerPass.xaml
    /// </summary>
    public partial class FindWorkerPass : Window
    {
        public FindWorkerPass()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FindeString.NameRecipient = NameRec.Text;
            FindeString.SurnameRecipient = SurnameRec.Text;
            FindeString.PatronymicRecipient = PatronymivRec.Text;

            FindeString.LeadName = NameLead.Text;
            FindeString.LeadSurnam = SurnameLead.Text;
            FindeString.LeadPatronymic = PatrinymicLead.Text;

            FindeString.Reason = Reason.Text;
            FindeString.Date = Date_dd.Text + "." + Date_mm.Text + "." + Date_yyyy.Text;
            FindeString.Time = Time_hh.Text + ":" + Time_mm.Text;

            FindeString.VisitDateWork = DateWork_dd.Text + "." + DateWork_mm.Text + "." + DateWork_yyyy.Text;
            FindeString.VisitTime = TimeWork_hh.Text + ":" + TimeWork_mm.Text;

            FindeString.LeaveDateWork = DateFin_dd.Text + "." + DateFin_mm.Text + "." + DateFin_yyyy.Text;
            FindeString.LeaveTimeWork = TimeFin_hh.Text + ":" + TimeFin_mm.Text;

            FindeString.RoomNumber = RoomNum.Text;
            FindeString.Pass = Pass.Text;

            Console.WriteLine(FindeString.Date + "/n" + FindeString.VisitDateWork + " /n" + FindeString.LeaveDateWork);

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

        private void NextCmm(object sender, TextChangedEventArgs e)
        {
            if (Date_dd.Text.Length == 2)
                Date_mm.Focus();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void NextCyyyy(object sender, TextChangedEventArgs e)
        {
            if (Date_mm.Text.Length == 2)
                Date_yyyy.Focus();
        }

        private void NextCM(object sender, TextChangedEventArgs e)
        {
            if (Time_hh.Text.Length == 2)
                Time_mm.Focus();
        }

        private void NextChh(object sender, TextChangedEventArgs e)
        {
            if (Date_yyyy.Text.Length == 4)
                Time_hh.Focus();
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

        private void NextFmm(object sender, TextChangedEventArgs e)
        {
            if (DateFin_dd.Text.Length == 2)
                DateFin_mm.Focus();
        }
    }
}
