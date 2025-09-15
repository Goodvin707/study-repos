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
    /// Логика взаимодействия для TakeTampKey.xaml
    /// </summary>
    public partial class TakeTampKey : Window
    {
        public TakeTampKey()
        {
            InitializeComponent();
        }

        TempKey tempKey = new TempKey();
        OleDbConnection connect = new OleDbConnection(connection);
        static string connection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= VTBRequest1.accdb";

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        public bool CheckFIO(string name, string surname, string patronymic)
        {
            string specsim = @"!@#$%^&*()_+=-?:;№ /.,\}{][|1234567890<>";
            for (int i = 0; i < surname.Length; i++)
            {
                for (int j = 0; j < specsim.Length; j++)
                    if (surname[i] == specsim[j])
                    {

                        return false;
                    }

            }
            for (int i = 0; i < name.Length; i++)
            {
                for (int j = 0; j < specsim.Length; j++)
                    if (name[i] == specsim[j])
                    {

                        return false;
                    }
            }
            for (int i = 0; i < patronymic.Length; i++)
            {
                for (int j = 0; j < specsim.Length; j++)
                    if (patronymic[i] == specsim[j])
                    {

                        return false;
                    }

            }
            return true;
        }
        private void CreateRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFIO(Name.Text, Surname.Text, Patronymic.Text))
                {
                    string query = "INSERT INTO [Выдача запасных ключей] ([Фамилия получателя],[Имя получателя],[Отчество получателя],Основание,[Дата и время выдачи],[Номер ключа]) VALUES (@Фамилия_получателя, @Имя_получателя, @Отчество_получателя, @Основание, @Дата, @Номер_ключа)";
                    OleDbCommand cmd = new OleDbCommand(query, connect);
                    cmd.Parameters.AddWithValue("@Фамилия_получателя",Surname.Text);
                    cmd.Parameters.AddWithValue("@Имя_получателя", Name.Text);
                    cmd.Parameters.AddWithValue("@Отчество_получателя", Patronymic.Text);
                    cmd.Parameters.AddWithValue("@Основание", Reason.Text);
                    cmd.Parameters.AddWithValue("@Дата", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@Номер_ключа", KeyName.Text);
                    connect.Open();

                    cmd.ExecuteNonQuery(); 
                    connect.Close();
                    this.Close();
                }
            }
            catch { }
        }
    }
}
