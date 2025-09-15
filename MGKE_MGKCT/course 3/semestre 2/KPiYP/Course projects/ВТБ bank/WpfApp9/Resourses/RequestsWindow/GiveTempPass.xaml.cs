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

namespace WpfApp9.Resourses.RequestsWindow
{
    /// <summary>
    /// Логика взаимодействия для GiveTempPass.xaml
    /// </summary>
    public partial class GiveTempPass : Window
    {
        public GiveTempPass(string name, string surname, string patronymic, string numberTempPass)
        {
            InitializeComponent();
            Name.Text = name;
            Surname.Text = surname;
            Patronymic.Text = patronymic;
            PassNumber.Text = numberTempPass;
        }

        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void AppClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
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

        OleDbConnection connect = new OleDbConnection(connection);
        static string connection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= VTBRequest1.accdb";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckFIO(Name.Text, Surname.Text, Patronymic.Text))
                {
                    string query = "UPDATE [Выдача временных пропусков]" +
                        " SET [Фамилия сдавшего] = @Фамилия_сдавшего, [Имя сдавшего] = @Имя_сдавшего, [Отчество сдавшего] = @Отчество_сдавшего, [Дата и время сдачи] = @Дата" +
                        " WHERE [Номер пропуска] = @Номер_пропуска";

                    OleDbCommand cmd = new OleDbCommand(query, connect);
                    cmd.Parameters.AddWithValue("@Фамилия_сдавшего", Surname.Text);
                    cmd.Parameters.AddWithValue("@Имя_сдавшего", Name.Text);
                    cmd.Parameters.AddWithValue("@Отчество_сдавшего", Patronymic.Text);
                    cmd.Parameters.AddWithValue("@Дата", DateTime.Now.ToString());
                    cmd.Parameters.AddWithValue("@Номер_пропуска", PassNumber.Text);
                    connect.Open();

                    cmd.ExecuteNonQuery();
                    connect.Close();
                    this.Close();
                }
            }
            catch { Console.WriteLine("fail"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Name.Text = "";
            Surname.Text = "";
            Patronymic.Text = "";            
        }
    }
}

