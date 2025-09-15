
using System.Data.OleDb;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp9.Resourses.BugReport;
using WpfApp9.Resourses.MessageWinfow;
using WpfApp9.BusinesLogic.MainInfo.PersonalInformation;
using System.Security.Cryptography;
using System.Text;

namespace WpfApp9
{
    public class TextBoxEx : TextBox
    {
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(
            nameof(Placeholder), typeof(string), typeof(TextBoxEx), new PropertyMetadata(""));

        public TextBoxEx()
        {
            DefaultStyleKey = typeof(TextBoxEx);
        }
    }

    public enum StartWin { FirstStart, NotFirstStart}
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            SplashScreen splashScreen = new SplashScreen("Resourses/Images/pixel.png");
            splashScreen.Show(true);
            InitializeComponent();
            
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

        static string connection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= VTBRequest1.accdb";

        public OleDbDataReader SELECT(string query, string connection)
        {
            OleDbConnection connect = new OleDbConnection(connection); // подключаемся к базе данных
            connect.Open(); // открываем базу данных

            OleDbCommand cmd = new OleDbCommand(query, connect); // создаём запрос
            OleDbDataReader read = cmd.ExecuteReader();
            return read;
        }

        private void setLoginInfo(OleDbDataReader reader)
        {
            LogInPerson.Surname = reader["Фамилия"].ToString();
            LogInPerson.Name = reader["Имя"].ToString();
            LogInPerson.Patronymic = reader["Отчество"].ToString();
            LogInPerson.Login = reader["Логин"].ToString();
            LogInPerson.Post = reader["Должность"].ToString();
        }

        void EnterLoginPassword()
        {
            System.Console.WriteLine(GetHash(password.Password));
            NewAccountInformation.StartWin = StartWin.NotFirstStart;
            var read = SELECT("SELECT Логин, Пароль, Фамилия, Имя, Отчество, Должность, [Дата создания], Время FROM [Учетная запись]", connection);
            bool logIn = false;
            passwordStr = password.Password;
            while (read.Read())
            {
                if (login.Text == read["Логин"].ToString() && GetHash(passwordStr) == read["Пароль"].ToString() && read["Должность"].ToString() == "Системный администратор")
                {
                    setLoginInfo(read);
                    Administrator administrator1 = new Administrator();
                    administrator1.Show();
                    this.Close();

                }
                if (login.Text == read["Логин"].ToString() && GetHash(passwordStr) == read["Пароль"].ToString() && read["Должность"].ToString() == "Специалист")
                {
                    setLoginInfo(read);
                    SecurityGuard securityGuard = new SecurityGuard();
                    securityGuard.Show();
                    this.Close();

                }
                if (login.Text == read["Логин"].ToString() && GetHash(passwordStr) == read["Пароль"].ToString() && read["Должность"].ToString() == "Ведущий специалист")
                {
                    setLoginInfo(read);
                    leadingSecialist leadingSecialist = new leadingSecialist();
                    leadingSecialist.Show();
                    this.Close();

                }

                if (login.Text == read["Логин"].ToString() && GetHash(passwordStr) == read["Пароль"].ToString() && read["Должность"].ToString() == "Главный специалист")
                {
                    setLoginInfo(read);
                    ChiefSpecialist ChiefSpecialist = new ChiefSpecialist();
                    ChiefSpecialist.Show();
                    this.Close();

                }

                if (login.Text == read["Логин"].ToString() && GetHash(passwordStr) == read["Пароль"].ToString() && read["Должность"].ToString() == "Начальник отдела режима и защиты объектов")
                {
                    setLoginInfo(read);
                    HeadSecurityDepartament administrator = new HeadSecurityDepartament();
                    administrator.Show();
                    this.Close();

                }

                if (login.Text == read["Логин"].ToString() && GetHash(passwordStr) == read["Пароль"].ToString() && read["Должность"].ToString() == "Начальник управления по обеспечению безопасности")
                {
                    setLoginInfo(read);
                    HeadDepartament headDepartament = new HeadDepartament();
                    headDepartament.Show();
                    this.Close();
                    break;
                }

            }
            if (!logIn) loginErr.Visibility = Visibility.Visible;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e) { EnterLoginPassword(); }

        private void Ctrl1Executed(object sender, ExecutedRoutedEventArgs e)
        {
            BugReport bugReport = new BugReport();
            bugReport.Show();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {
            loginErr.Visibility = Visibility.Hidden;
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            loginErr.Visibility = Visibility.Hidden;
            
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return System.Convert.ToBase64String(hash);
        }
        string passwordStr = "";
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)  EnterLoginPassword();
        }
    }
}
