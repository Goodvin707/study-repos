using System;
using System.Collections.Generic;
using System.Data.OleDb;
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

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для CreateRequestTakeout.xaml
    /// </summary>
    public partial class CreateRequestTakeout : Window
    {
        TakeoutRequest takeoutRequest1 = new TakeoutRequest();
        
        public CreateRequestTakeout(ref TakeoutRequest takeoutRequest1)
        {
            InitializeComponent();            

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Up(object sender, MouseEventArgs e)
        {
            var temp = (Image)sender;
            temp.Opacity = 0.5;
        }

        private void Down(object sender, MouseEventArgs e)
        {
            var temp = (Image)sender;
            temp.Opacity = 1;
        }
        private void AppClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        OleDbConnection connect = new OleDbConnection(connection);
        static string connection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= VTBRequest1.accdb";

        private void Create(object sender, RoutedEventArgs e)
        {
             takeoutRequest1.NameRecipient = NameCreator.Text;
             takeoutRequest1.SurnameRecipient = SurnameCreator.Text;
             takeoutRequest1.PatronymicRecipient = PatronymicCreator.Text;
             takeoutRequest1.NameTaker = NameTaker.Text;
             takeoutRequest1.SunamTaker = SurnameTaker.Text;
             takeoutRequest1.PatronymicTaker = PatronymicTaker.Text;
             takeoutRequest1.Date = Date.Text;
             takeoutRequest1.Reason = Reason.Text;
             takeoutRequest1.NameRecipient = ItemName.Text;
             takeoutRequest1.OrganizationName = OrgName.Text;
             takeoutRequest1.Count = Count.Text;
             takeoutRequest1.AdressPass = Pass.Text;
             takeoutRequest1.AdressDelivery = DeliveryAdress.Text;

            string sql = string.Format("Insert Into [Заявка на вынос]" +
                           "([Имя инициатора], [Фамилия инициатора], [Отчество инициатора], [Имя лица вынос], [Фамилия лица вынос], [Отчество лица вынос], [Дата и время выноса], [Обоснование выноса], Количество, Наименование, [Адрес доставки имущества], [Серийный номер], [Место выноса]) Values('"
                           + takeoutRequest1.NameRecipient +
                           "', '" + takeoutRequest1.SurnameRecipient +
                           "', '" + takeoutRequest1.PatronymicRecipient +
                           "', '" + takeoutRequest1.NameTaker +
                           "', '" + takeoutRequest1.SunamTaker +
                               "', '" + takeoutRequest1.PatronymicTaker +
                                   "', '" + takeoutRequest1.Date +
                                       "', '" + takeoutRequest1.Reason +
                                           "', '" + takeoutRequest1.Count +
                                               "', '" + takeoutRequest1.ItemName +
                           "', '" + takeoutRequest1.AdressDelivery +
                           "', '" + takeoutRequest1.ModelNumber +
                           "', '" + takeoutRequest1.AdressPass + "')");
            connect.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, connect))
            { cmd.ExecuteNonQuery(); }
            connect.Close();

            DialogResult = true;
        }
    }
}
