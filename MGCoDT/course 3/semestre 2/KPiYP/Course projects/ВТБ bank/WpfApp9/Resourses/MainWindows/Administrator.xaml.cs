
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp9.BusinesLogic.MainInfo.PersonalInformation;
using WpfApp9.Resourses.BugReport;
using WpfApp9.Resourses.Help;
using WpfApp9.Resourses.MessageWinfow;


namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>

    /// 
    public enum chach { LoginIsG, PasswordIsG, NameIsG, SurnameIsG, PatronymicIsG, NotG }

    public enum SelectetdTable{ TakeoutRequestTable, WorkerVisitTable,VisitorVisTable, TempKeyTable, TempPassTable, AccountTable,DeleteAccountTable }
    public partial class Administrator : Window
    {
        public Administrator()
        {
            SplashScreen splashScreen = new SplashScreen("Resourses/Images/pixel.png");
            splashScreen.Show(true);

            InitializeComponent();

        }
        SelectetdTable selectetdTable;
        
        private void Ctrl1Executed(object sender, ExecutedRoutedEventArgs e)
        {
            BugReport bugReport = new BugReport();
            bugReport.Show();
        }

        private void AppClose(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Maximaze(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                CreateAccountGrid.HorizontalAlignment = HorizontalAlignment.Center;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                CreateAccountGrid.HorizontalAlignment = HorizontalAlignment.Left;
            }
            mainpanelSesurityGuard.Width = this.Width;

        }

        private void Minimaze(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
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

        private void SelectMaimMenuButton(object sender, RoutedEventArgs e)
        {
            var temp = (Button)sender;
            temp.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF568CE6");
        }

        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
        }
        List<Grid> grids = new List<Grid>();
        List<Button> grids2 = new List<Button>();
        private void SelectmenuButton(object sender, RoutedEventArgs e)
        {

            grids2.Add(adminbutton1);
            grids2.Add(adminbutton4);
            grids2.Add(adminbutton5);

            grids.Add(gr1_CreateAccount);
            grids.Add(gr2_AccountSettings);
            grids.Add(gr3_AllHistory);
            grids.Add(gr4_DataBase);
            grids.Add(gr5_DeleteAccount);
            grids.Add(gr6_Message);
            grids.Add(gr7_TelephoneNumbers);
            var temp = (Button)sender;
            for (int i = 0; i < grids.Count; i++)
            {
                if (temp.Name[temp.Name.Length - 1] == grids[i].Name[2])
                {
                    for (int j = 0; j < grids.Count; j++)
                    {
                        if (j != i)
                        {
                            grids[j].Visibility = Visibility.Hidden;

                        }
                        else grids[j].Visibility = Visibility.Visible;
                    }
                }
            }
            for (int i = 0; i < grids2.Count; i++)
            {
                if (temp.Name[temp.Name.Length - 1] == grids2[i].Name[grids2[i].Name.Length - 1])
                {
                    for (int j = 0; j < grids2.Count; j++)
                    {
                        if (j != i)                        
                            grids2[j].IsEnabled = true;                        
                        else grids2[j].IsEnabled = false;
                    }
                }
            }
            switch (temp.Name[temp.Name.Length - 1])
            {
                case '1':
                    break;
                case '2':
                    InPrograss inPrograss1 = new InPrograss("Настройки учетной записи", "-Данная функция не является задачей альфа версии \n-Для выполнения операции недостаточно ресурсов");
                    inPrograss1.ShowDialog();
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    this.selectetdTable = SelectetdTable.DeleteAccountTable;
                    break;
                case '6':
                    InPrograss inPrograss3 = new InPrograss("Сообщения", "-Данная функция не является задачей альфа версии \n-Для выполнения операции недостаточно ресурсов");
                    inPrograss3.ShowDialog();
                    break;
                case '7':
                    InPrograss inPrograss2 = new InPrograss("Телефонный справочник", "-Данная функция не является задачей альфа версии \n-Для выполнения операции недостаточно ресурсов");
                    inPrograss2.ShowDialog();
                    break;
            }
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

        private void PasswordVisable(object sender, RoutedEventArgs e)
        {
            if (PasswordVis.IsChecked == true)
            {
                password.Text = passwordBox.Password;
                passwordBox.Visibility = Visibility.Hidden;
                password.Visibility = Visibility.Visible;
            }
            else
            {
                passwordBox.Password = password.Text;
                passwordBox.Visibility = Visibility.Visible;
                password.Visibility = Visibility.Hidden;
            }
        }
        private void CreateAccount(object sender, RoutedEventArgs e)
        {
            chach CheckLogin = chach.LoginIsG;
            chach CheckPassword = chach.PasswordIsG;
            chach CheckName = chach.NameIsG;
            chach CheckSurname = chach.SurnameIsG;
            chach CheckPatronymic = chach.PatronymicIsG;

            NewAccountInformation.Login = Login.Text;
            NewAccountInformation.Password = passwordBox.Password;
            NewAccountInformation.Petronymic = Patronymic.Text;
            NewAccountInformation.Post = Post.Text;
            NewAccountInformation.Name = Name.Text;
            NewAccountInformation.Surname = Surname.Text;




            List<Account> tempAcc = new List<Account>();



            var read = SELECT("SELECT Логин, Фамилия, Имя, Отчество, Должность, [Дата создания], Время FROM [Учетная запись]", connection);
            while (read.Read())
            {
                account = new Account();
                account.Login = read.GetValue(0).ToString();
                account.Surname = read.GetValue(1).ToString();
                account.Name = read.GetValue(2).ToString();
                account.Patronymic = read.GetValue(3).ToString();
                account.Post = read.GetValue(4).ToString();
                account.Date = read.GetValue(5).ToString();
                account.Time = read.GetValue(6).ToString();
                tempAcc.Add(account);
            }
            connect.Close();
            string specsim = @"!@#$%^&*()_+=-?:;№ /.,\}{][|1234567890<>";

            for (int i = 0; i < tempAcc.Count; i++)
            {
                if (tempAcc[i].Login == NewAccountInformation.Login)
                {
                    CheckLogin = chach.NotG;
                    ChLogin.Visibility = Visibility.Visible;
                    break;
                }
                else for (int j = 0; j < specsim.Length; j++)
                    {
                        try
                        {
                            if (NewAccountInformation.Login[0] == specsim[j] || (NewAccountInformation.Login.Length >= 20 || NewAccountInformation.Login.Length <= 6))
                            {
                                CheckLogin = chach.NotG;
                                ChLogin.Visibility = Visibility.Visible;
                            }
                        }
                        catch
                        {
                            CheckLogin = chach.NotG;
                            ChLogin.Visibility = Visibility.Visible;
                            break;
                        }
                    }

            }

            if (NewAccountInformation.Password.Length < 8)
            {
                CheckPassword = chach.NotG;
                ChPassword.Visibility = Visibility.Visible;
            }
            if (NewAccountInformation.Surname.Length > 0)
                for (int i = 0; i < NewAccountInformation.Surname.Length; i++)
                {
                    for (int j = 0; j < specsim.Length; j++)
                        if (NewAccountInformation.Surname[i] == specsim[j] || NewAccountInformation.Surname.Length < 1)
                        {
                            CheckSurname = chach.NotG;
                            ChFIO.Visibility = Visibility.Visible;
                            break;
                        }

                }
            else
            {
                CheckName = chach.NotG;
                ChFIO.Visibility = Visibility.Visible;
            }
            if (NewAccountInformation.Name.Length > 0)
                for (int i = 0; i < NewAccountInformation.Name.Length; i++)
                {
                    for (int j = 0; j < specsim.Length; j++)
                        if (NewAccountInformation.Name[i] == specsim[j])
                        {
                            CheckName = chach.NotG;
                            ChFIO.Visibility = Visibility.Visible;
                            break;
                        }
                }
            else
            {
                CheckName = chach.NotG;
                ChFIO.Visibility = Visibility.Visible;
            }
            if (NewAccountInformation.Petronymic.Length > 0)
                for (int i = 0; i < NewAccountInformation.Petronymic.Length; i++)
                {
                    for (int j = 0; j < specsim.Length; j++)
                        if (NewAccountInformation.Petronymic[i] == specsim[j] || NewAccountInformation.Petronymic.Length < 1)
                        {
                            CheckPatronymic = chach.NotG;
                            ChFIO.Visibility = Visibility.Visible;
                            break;
                        }

                }
            else
            {
                CheckName = chach.NotG;
                ChFIO.Visibility = Visibility.Visible;
            }

            if (CheckSurname == chach.SurnameIsG && CheckName == chach.NameIsG && CheckPatronymic == chach.PatronymicIsG &&
                CheckLogin == chach.LoginIsG && CheckPassword == chach.PasswordIsG)
            {


                AcceMess acceMess = new AcceMess();
                acceMess.ShowDialog();
                if (acceMess.DialogResult == true)
                {
                    string sql = string.Format("Insert Into [Учетная запись]" +
                           "(Логин, Пароль, Фамилия, Имя, Отчество, Должность, [Дата создания], Время) Values('" + NewAccountInformation.Login +
                           "', '" + GetHash(NewAccountInformation.Password) +
                           "', '" + NewAccountInformation.Surname +
                           "', '" + NewAccountInformation.Name +
                           "', '" + NewAccountInformation.Petronymic +
                           "', '" + NewAccountInformation.Post +
                           "', '" + DateTime.Now.ToShortDateString() +
                           "', '" + DateTime.Now.ToShortTimeString() + "')");
                    connect.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, connect))
                    { cmd.ExecuteNonQuery(); }
                    connect.Close();
                }
                else
                {

                }
            }
        }

        private void Search_GotFocus(object sender, RoutedEventArgs e)
        {
            Search.FontStyle = FontStyles.Normal;
            Search.Foreground = Brushes.Black;
            if (Search.Text == "Поиск:")
                Search.Text = "";
        }

        private void Search_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Search.Text == "")
                Search.Text = "Поиск:";
            Search.FontStyle = FontStyles.Italic;
            Search.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFC5BABA"); ;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

 
 // получаем данные


        Account account = new Account();
        List<Account> Accounts = new List<Account>();

        TakeoutRequest takeout_request = new TakeoutRequest();
        List<TakeoutRequest> takeoutRequests = new List<TakeoutRequest>();



        TempPass tempPass = new TempPass();
        List<TempPass> tempPasss = new List<TempPass>();
        TempKey tempKey = new TempKey();
        List<TempKey> tempKeys = new List<TempKey>();
        OleDbConnection connect = new OleDbConnection(connection);
        static string connection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= VTBRequest1.accdb";
        VisitorPassRequest visitorPassRequest = new VisitorPassRequest();
        List<VisitorPassRequest> visitorPassRequests = new List<VisitorPassRequest>();

        WorkerPassRequest workerPassRequest = new WorkerPassRequest();
        List<WorkerPassRequest> workerPassRequests = new List<WorkerPassRequest>();

        public OleDbDataReader SELECT(string query, string connection)
        {
            
            connect.Open(); 
            OleDbCommand cmd = new OleDbCommand(query, connect); 
            OleDbDataReader read = cmd.ExecuteReader();
            return read;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                      
            var read = SELECT("SELECT Логин, Фамилия, Имя, Отчество, Должность, [Дата создания], Время FROM [Учетная запись]", connection);
            while (read.Read())
            {
                account = new Account();
                account.Login = read.GetValue(0).ToString();
                account.Surname = read.GetValue(1).ToString();
                account.Name = read.GetValue(2).ToString();
                account.Patronymic = read.GetValue(3).ToString();
                account.Post = read.GetValue(4).ToString();
                account.Date = read.GetValue(5).ToString();
                account.Time = read.GetValue(6).ToString();
                Accounts.Add(account);
            }
            AccountsDG.ItemsSource = Accounts;           
           read.Close();
            connect.Close();

            read = SELECT("SELECT [Номер пропуска], [Фамилия получателя], [Имя получателя], [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего], [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи] FROM [Выдача временных пропусков]", connection);

            while (read.Read())
            {
                tempPass = new TempPass();
                tempPass.Pass = read.GetValue(0).ToString();
                tempPass.SurnameRecipient = read.GetValue(1).ToString();
                tempPass.NameRecipient = read.GetValue(2).ToString();
                tempPass.PatronymicRecipient = read.GetValue(3).ToString();
                tempPass.Date = read.GetValue(4).ToString();
                tempPass.Reason = read.GetValue(5).ToString();
                tempPass.SunamGiver = read.GetValue(6).ToString();
                tempPass.NameGiver = read.GetValue(7).ToString();
                tempPass.PatronymicGiver = read.GetValue(8).ToString();
                tempPass.DateReturn = read.GetValue(9).ToString();

                tempPasss.Add(tempPass);
            }
            TempPassRequestDG.ItemsSource = tempPasss;
            read.Close();
            connect.Close();
            read = SELECT("SELECT [Номер ключа], [Фамилия получателя], [Имя получателя], [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего], [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи] FROM [Выдача запасных ключей]", connection);

            while (read.Read())
            {
                tempKey = new TempKey();
                tempKey.Key = read.GetValue(0).ToString();
                tempKey.SurnameRecipient = read.GetValue(1).ToString();
                tempKey.NameRecipient = read.GetValue(2).ToString();
                tempKey.PatronymicRecipient = read.GetValue(3).ToString();
                tempKey.Date = read.GetValue(4).ToString();
                tempKey.Reason = read.GetValue(5).ToString();
                tempKey.SunamGiver = read.GetValue(6).ToString();
                tempKey.NameGiver = read.GetValue(7).ToString();
                tempKey.PatronymicGiver = read.GetValue(8).ToString();
                tempKey.DateReturn = read.GetValue(9).ToString();

                tempKeys.Add(tempKey);
            }
            TempKeyRequestDG.ItemsSource = tempKeys;
            read.Close();
            connect.Close();

            read = SELECT("SELECT *" +
            " FROM [Заявка на допуск посетителя] WHERE [Дата и время создания]" +
            " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddYears(-1)).Replace('.', '-') +
            "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
        
            while (read.Read())
            {
                visitorPassRequest = new VisitorPassRequest();
                visitorPassRequest.RequestNumber = read["Номер заявки"].ToString();
                visitorPassRequest.SurnameCreator = read["Фамилия инициатора"].ToString();
                visitorPassRequest.NameCreator = read["Имя инициатора"].ToString();
                visitorPassRequest.PatronymicCreator = read["Отчество инициатора"].ToString();
                visitorPassRequest.Date = read["Дата и время создания"].ToString();
                visitorPassRequest.Reason = read["Обоснование"].ToString();
                visitorPassRequest.LeadSurnam = read["Фамилия руководителя"].ToString();
                visitorPassRequest.LeadName = read["Имя руководителя"].ToString();
                visitorPassRequest.LeadPatronymic = read["Отчество руководителя"].ToString();
                visitorPassRequest.AdressPass = read["Место прохода"].ToString();
                visitorPassRequest.VisitorSurname = read["Фамилия посетителя"].ToString();
                visitorPassRequest.VisitorName = read["Имя посетителя"].ToString();
                visitorPassRequest.VisitorPatronymic = read["Отчество посетителя"].ToString();
                visitorPassRequest.VisitDateWork = read["Дата прибытия"].ToString();
                visitorPassRequest.LeaveDateWork = read["Дата убытия"].ToString();

                visitorPassRequests.Add(visitorPassRequest);
            }
            VisitorPassRequestDG.ItemsSource = visitorPassRequests;
            read.Close();
            connect.Close();                            
            
                read = SELECT("SELECT *" +
                    " FROM [Заявка на допуск сотрудников]", connection);
            
            while (read.Read())
            {
                workerPassRequest = new WorkerPassRequest();
                workerPassRequest.RequestNumber = read["Номер заявки"].ToString();
                workerPassRequest.SurnameCreator = read["Фамилия инициатора"].ToString();
                workerPassRequest.NameCreator = read["Имя инициатора"].ToString();
                workerPassRequest.PatronymicCreator = read["Отчество инициатора"].ToString();
                workerPassRequest.Date = read["Дата"].ToString();
                workerPassRequest.Reason = read["Обоснование доступа"].ToString();
                workerPassRequest.LeadSurnam = read["Фамилия руководителя"].ToString();
                workerPassRequest.LeadName = read["Имя руководителя"].ToString();
                workerPassRequest.LeadPatronymic = read["Отчество руководителя"].ToString();
                workerPassRequest.AdressPass = read["Адрес помещения для доступа"].ToString();
                workerPassRequest.StartDateWork = read["Дата и время начала работы"].ToString();
                workerPassRequest.EndDateWork = read["Дата и время окончания работы"].ToString();
                workerPassRequest.RoomNumber = read["Номер помещения"].ToString();
                workerPassRequests.Add(workerPassRequest);
            }
            WorkerPassRequestDG.ItemsSource = workerPassRequests;
            read.Close();
            connect.Close();

            read = SELECT("SELECT *" +
            " FROM [Заявка на вынос] WHERE [Дата и время выноса]" +
             " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddYears(-1)).Replace('.', '-') +
             "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
        
                while (read.Read())
                {
                    takeout_request = new TakeoutRequest();
                    takeout_request.RequestNumber = read["Номер заявки"].ToString();
                    takeout_request.SurnameRecipient = read["Фамилия инициатора"].ToString();
                    takeout_request.NameRecipient = read["Имя инициатора"].ToString();
                    takeout_request.PatronymicRecipient = read["Отчество инициатора"].ToString();
                    takeout_request.Date = read["Дата и время выноса"].ToString();
                    takeout_request.Reason = read["Обоснование выноса"].ToString();
                    takeout_request.SunamTaker = read["Фамилия лица вынос"].ToString();
                    takeout_request.NameTaker = read["Имя лица вынос"].ToString();
                    takeout_request.PatronymicTaker = read["Отчество лица вынос"].ToString();
                    takeout_request.AdressPass = read["Место выноса"].ToString();
                    takeout_request.AdressDelivery = read["Адрес доставки имущества"].ToString();
                    takeout_request.ItemName = read["Наименование"].ToString();
                    takeout_request.Count = read["Количество"].ToString();
                    takeout_request.OrganizationName = read["Наименование организации"].ToString();
                    takeout_request.ModelNumber = read["Серийный номер"].ToString();

                    takeoutRequests.Add(takeout_request);
                }
                TakeOutRequestDG.ItemsSource = takeoutRequests;
                read.Close();
                connect.Close();



                Accounts.Clear();
                read = SELECT("SELECT Логин, Фамилия, Имя, Отчество, Должность, [Дата создания], Время FROM [Учетная запись]", connection);
                while (read.Read())
                {
                    account = new Account();
                    account.Login = read.GetValue(0).ToString();
                    account.Surname = read.GetValue(1).ToString();
                    account.Name = read.GetValue(2).ToString();
                    account.Patronymic = read.GetValue(3).ToString();
                    account.Post = read.GetValue(4).ToString();
                    account.Date = read.GetValue(5).ToString();
                    account.Time = read.GetValue(6).ToString();
                    Accounts.Add(account);
                }
                AccountsDG2.ItemsSource = Accounts;
                read.Close();
                connect.Close();            

        }

       
        
        
        private void AccountsDG_Loaded(object sender, RoutedEventArgs e)
        {            
            PostAcc.SelectedIndex = PostAcc.Items.Count - 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Accounts.Clear();
                string value = "";
                ComboBoxItem selectedItem = (ComboBoxItem)(PostAcc.SelectedValue);
                value = (string)(selectedItem.Content);
                AccountsDG.ItemsSource = null;
                OleDbDataReader read;
                if (value != "Все")
                    read = SELECT("SELECT Логин, Фамилия, Имя, Отчество, Должность, [Дата создания], Время FROM [Учетная запись] WHERE Должность = '" + value + "'", connection);
                else read = SELECT("SELECT Логин, Фамилия, Имя, Отчество, Должность, [Дата создания], Время FROM [Учетная запись]", connection);
                while (read.Read())
                {
                    account = new Account();
                    account.Login = read.GetValue(0).ToString();
                    account.Surname = read.GetValue(1).ToString();
                    account.Name = read.GetValue(2).ToString();
                    account.Patronymic = read.GetValue(3).ToString();
                    account.Post = read.GetValue(4).ToString();
                    account.Date = read.GetValue(5).ToString();
                    account.Time = read.GetValue(6).ToString();
                    Accounts.Add(account);
                }
                AccountsDG.ItemsSource = Accounts;
                read.Close();
                connect.Close();

                if (loginAcc.IsChecked == false)
                    LoginColAcc.Visibility = Visibility.Collapsed;
                else LoginColAcc.Visibility = Visibility.Visible;

                if (DateRegAcc.IsChecked == false)
                    DateColAcc.Visibility = Visibility.Collapsed;
                else DateRegAcc.Visibility = Visibility.Visible;

                if (TimeRegAcc.IsChecked == false)
                    TimeColAcc.Visibility = Visibility.Collapsed;
                else TimeColAcc.Visibility = Visibility.Visible;

                if (SurnameAcc.IsChecked == false)
                    SurnameColAcc.Visibility = Visibility.Collapsed;
                else SurnameColAcc.Visibility = Visibility.Visible;

                if (NameAcc.IsChecked == false)
                    NameColAcc.Visibility = Visibility.Collapsed;
                else NameColAcc.Visibility = Visibility.Visible;

                if (PatronymicAcc.IsChecked == false)
                    PatronymicColAcc.Visibility = Visibility.Collapsed;
                else PatronymicColAcc.Visibility = Visibility.Visible;

                if (PostAccc.IsChecked == false)
                    PostColAcc.Visibility = Visibility.Collapsed;
                else PostColAcc.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {

            }
        }

        private void selectAllAcc_Checked(object sender, RoutedEventArgs e)
        {
            loginAcc.IsChecked = true;
            DateRegAcc.IsChecked = true;
            TimeRegAcc.IsChecked = true;
            SurnameAcc.IsChecked = true;
            NameAcc.IsChecked = true;
            PatronymicAcc.IsChecked = true;
            PostAccc.IsChecked = true;
        }

        private void selectAcc_Checked(object sender, RoutedEventArgs e)
        {
            if(loginAcc.IsChecked == true && DateRegAcc.IsChecked == true && TimeRegAcc.IsChecked == true
                && SurnameAcc.IsChecked == true && NameAcc.IsChecked == true && PatronymicAcc.IsChecked == true && PostAccc.IsChecked == true)
                selectAllAcc.IsChecked = true;
        }

        private void selectAcc_Unchecked(object sender, RoutedEventArgs e)
        {
            selectAllAcc.IsChecked = false;
        }

       
        
        
        private void PostAcc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                tempPasss.Clear();
                string value = "";
                ComboBoxItem selectedItem = (ComboBoxItem)(TempPDateCB.SelectedValue);
                value = (string)(selectedItem.Content);
                TempPassRequestDG.ItemsSource = null;
                OleDbDataReader read;
                if (value == "За последний день")
                {
                    read = SELECT("SELECT [Номер пропуска], [Фамилия получателя], [Имя получателя]," +
                        " [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего]," +
                        " [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи]" +
                        " FROM [Выдача временных пропусков] WHERE [Дата и время выдачи]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последнюю неделю")
                {
                    read = SELECT("SELECT [Номер пропуска], [Фамилия получателя], [Имя получателя]," +
                        " [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего]," +
                        " [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи]" +
                        " FROM [Выдача временных пропусков] WHERE [Дата и время выдачи]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-7)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последний месяц")
                {
                    read = SELECT("SELECT [Номер пропуска], [Фамилия получателя], [Имя получателя]," +
                        " [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего]," +
                        " [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи]" +
                        " FROM [Выдача временных пропусков] WHERE [Дата и время выдачи]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddMonths(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else
                {
                    read = SELECT("SELECT [Номер пропуска], [Фамилия получателя], [Имя получателя]," +
                        " [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего]," +
                        " [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи]" +
                        " FROM [Выдача временных пропусков] WHERE [Дата и время выдачи]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddYears(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                while (read.Read())
                {
                    tempPass = new TempPass();
                    tempPass.Pass = read.GetValue(0).ToString();
                    tempPass.SurnameRecipient = read.GetValue(1).ToString();
                    tempPass.NameRecipient = read.GetValue(2).ToString();
                    tempPass.PatronymicRecipient = read.GetValue(3).ToString();
                    tempPass.Date = read.GetValue(4).ToString();
                    tempPass.Reason = read.GetValue(5).ToString();
                    tempPass.SunamGiver = read["Фамилия сдавшего"].ToString();
                    tempPass.NameGiver = read["Имя сдавшего"].ToString();
                    tempPass.PatronymicGiver = read["Отчество сдавшего"].ToString();
                    tempPass.DateReturn = read["Дата и время сдачи"].ToString();

                    tempPasss.Add(tempPass);
                }
                TempPassRequestDG.ItemsSource = tempPasss;
                read.Close();
                connect.Close();

                if (TempPPass.IsChecked == false)
                    TempPPassCol.Visibility = Visibility.Collapsed;
                else TempPPassCol.Visibility = Visibility.Visible;

                if (TempPNameCreator.IsChecked == false)
                    TempPNameCreatorCol.Visibility = Visibility.Collapsed;
                else TempPNameCreatorCol.Visibility = Visibility.Visible;

                if (TempPSurnameCreator.IsChecked == false)
                    TempPSurnameCreatorCol.Visibility = Visibility.Collapsed;
                else TempPSurnameCreatorCol.Visibility = Visibility.Visible;

                if (TempPPatronymicCreator.IsChecked == false)
                    TempPPatronymicCreatorCol.Visibility = Visibility.Collapsed;
                else TempPPatronymicCreatorCol.Visibility = Visibility.Visible;

                if (TempPDate.IsChecked == false)
                    TempPDateCol.Visibility = Visibility.Collapsed;
                else TempPDateCol.Visibility = Visibility.Visible;

                if (TempPNameTaker.IsChecked == false)
                    TempPNameTakerCol.Visibility = Visibility.Collapsed;
                else TempPNameTakerCol.Visibility = Visibility.Visible;

                if (TempPSurnaeTaker.IsChecked == false)
                    TempPSurnaeTakerCol.Visibility = Visibility.Collapsed;
                else TempPSurnaeTakerCol.Visibility = Visibility.Visible;

                if (TempPPatronymicTaker.IsChecked == false)
                    TempPPatronymicTakerCol.Visibility = Visibility.Collapsed;
                else TempPPatronymicTakerCol.Visibility = Visibility.Visible;

                if (TempPReasonPass.IsChecked == false)
                    TempPReasonPassCol.Visibility = Visibility.Collapsed;
                else TempPReasonPassCol.Visibility = Visibility.Visible;

                if (TempPDateReturn.IsChecked == false)
                    TempPDateReturnCol.Visibility = Visibility.Collapsed;
                else TempPDateReturnCol.Visibility = Visibility.Visible;
                connect.Close();
            }
            catch (Exception)
            {

            }
        }

        private void selectAllTempPassFilt_Checked(object sender, RoutedEventArgs e)
        {
            TempPDateReturn.IsChecked = true;
            TempPReasonPass.IsChecked = true;
            TempPPatronymicTaker.IsChecked = true;
            TempPSurnaeTaker.IsChecked = true;
            TempPNameTaker.IsChecked = true;
            TempPDate.IsChecked = true;
            TempPPatronymicCreator.IsChecked = true;
            TempPSurnameCreator.IsChecked = true;
            TempPNameCreator.IsChecked = true;
            TempPPass.IsChecked = true;

        }
        private void selectTempPass_Checked(object sender, RoutedEventArgs e)
        {
            if (TempPDateReturn.IsChecked == true && TempPReasonPass.IsChecked == true
                && TempPPatronymicTaker.IsChecked == true && TempPSurnaeTaker.IsChecked == true && TempPNameTaker.IsChecked == true
                && TempPDate.IsChecked == true && TempPPatronymicCreator.IsChecked == true && TempPSurnameCreator.IsChecked == true && TempPNameCreator.IsChecked == true && TempPPass.IsChecked == true)
                selectAllTempPassFilt.IsChecked = true;
        }

        private void selectTempPass_Unchecked(object sender, RoutedEventArgs e)
        {
            selectAllTempPassFilt.IsChecked = false;
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            TempPDateCB.SelectedIndex = 3;            
        }

      
        
        
        
        private void TempKPass_Checked(object sender, RoutedEventArgs e)
        {
            if (TempKDateReturn.IsChecked == true && TempKReasonPass.IsChecked == true
                && TempKPatronymicTaker.IsChecked == true && TempKSurnaeTaker.IsChecked == true && TempKNameTaker.IsChecked == true
                && TempKDate.IsChecked == true && TempKPatronymicCreator.IsChecked == true && TempKSurnameCreator.IsChecked == true && TempKNameCreator.IsChecked == true && TempKPass.IsChecked == true)
                SelectAllTempKey.IsChecked = true;
            }

        private void TempKPass_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectAllTempKey.IsChecked = false;
        }

        private void SelectAllTempKey_Checked(object sender, RoutedEventArgs e)
        {
            TempKDateReturn.IsChecked = true;
            TempKReasonPass.IsChecked = true;
            TempKPatronymicTaker.IsChecked = true;
            TempKSurnaeTaker.IsChecked = true;
            TempKNameTaker.IsChecked = true;
            TempKDate.IsChecked = true;
            TempKPatronymicCreator.IsChecked = true;
            TempKSurnameCreator.IsChecked = true;
            TempKNameCreator.IsChecked = true;
            TempKPass.IsChecked = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                tempKeys.Clear();
                string value = "";
                ComboBoxItem selectedItem = (ComboBoxItem)(SelectDateTampKeyCB.SelectedValue);
                value = (string)(selectedItem.Content);
                TempKeyRequestDG.ItemsSource = null;
                OleDbDataReader read;
                if (value == "За последний день")
                {
                    read = SELECT("SELECT [Номер ключа], [Фамилия получателя], [Имя получателя]," +
                        " [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего]," +
                        " [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи]" +
                        " FROM [Выдача запасных ключей] WHERE [Дата и время выдачи]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последнюю неделю")
                {
                    read = SELECT("SELECT [Номер ключа], [Фамилия получателя], [Имя получателя]," +
                        " [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего]," +
                        " [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи]" +
                        " FROM [Выдача запасных ключей] WHERE [Дата и время выдачи]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-7)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последний месяц")
                {
                    read = SELECT("SELECT [Номер ключа], [Фамилия получателя], [Имя получателя]," +
                        " [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего]," +
                        " [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи]" +
                        " FROM [Выдача запасных ключей] WHERE [Дата и время выдачи]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddMonths(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else
                {
                    read = SELECT("SELECT [Номер ключа], [Фамилия получателя], [Имя получателя]," +
                        " [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего]," +
                        " [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи]" +
                        " FROM [Выдача запасных ключей] WHERE [Дата и время выдачи]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddYears(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                while (read.Read())
                {
                    tempKey = new TempKey();
                    tempKey.Key = read.GetValue(0).ToString();
                    tempKey.SurnameRecipient = read.GetValue(1).ToString();
                    tempKey.NameRecipient = read.GetValue(2).ToString();
                    tempKey.PatronymicRecipient = read.GetValue(3).ToString();
                    tempKey.Date = read.GetValue(4).ToString();
                    tempKey.Reason = read.GetValue(5).ToString();
                    tempKey.SunamGiver = read.GetValue(6).ToString();
                    tempKey.NameGiver = read.GetValue(7).ToString();
                    tempKey.PatronymicGiver = read.GetValue(8).ToString();
                    tempKey.DateReturn = read.GetValue(9).ToString();

                    tempKeys.Add(tempKey);
                }
                TempKeyRequestDG.ItemsSource = tempKeys;
                read.Close();
                connect.Close();

                if (TempKPass.IsChecked == false)
                    TempKPassCol.Visibility = Visibility.Collapsed;
                else TempKPassCol.Visibility = Visibility.Visible;

                if (TempKNameCreator.IsChecked == false)
                    TempKNameCreatorCol.Visibility = Visibility.Collapsed;
                else TempKNameCreatorCol.Visibility = Visibility.Visible;

                if (TempKSurnameCreator.IsChecked == false)
                    TempKSurnameCreatorCol.Visibility = Visibility.Collapsed;
                else TempKSurnameCreatorCol.Visibility = Visibility.Visible;

                if (TempKPatronymicCreator.IsChecked == false)
                    TempKPatronymicCreatorCol.Visibility = Visibility.Collapsed;
                else TempKPatronymicCreatorCol.Visibility = Visibility.Visible;

                if (TempKDate.IsChecked == false)
                    TempKDateCol.Visibility = Visibility.Collapsed;
                else TempKDateCol.Visibility = Visibility.Visible;

                if (TempKNameTaker.IsChecked == false)
                    TempKNameTakerCol.Visibility = Visibility.Collapsed;
                else TempKNameTakerCol.Visibility = Visibility.Visible;

                if (TempKSurnaeTaker.IsChecked == false)
                    TempKSurnaeTakerCol.Visibility = Visibility.Collapsed;
                else TempKSurnaeTakerCol.Visibility = Visibility.Visible;

                if (TempKPatronymicTaker.IsChecked == false)
                    TempKPatronymicTakerCol.Visibility = Visibility.Collapsed;
                else TempKPatronymicTakerCol.Visibility = Visibility.Visible;

                if (TempKReasonPass.IsChecked == false)
                    TempKReasonPassCol.Visibility = Visibility.Collapsed;
                else TempKReasonPassCol.Visibility = Visibility.Visible;

                if (TempKDateReturn.IsChecked == false)
                    TempKDateReturnCol.Visibility = Visibility.Collapsed;
                else TempKDateReturnCol.Visibility = Visibility.Visible;
            }
            catch (Exception) { }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                visitorPassRequests.Clear();
                string value = "";
                ComboBoxItem selectedItem = (ComboBoxItem)(SelectDatePassRequestVisDG.SelectedValue);
                value = (string)(selectedItem.Content);
                VisitorPassRequestDG.ItemsSource = null;
                OleDbDataReader read;
                if (value == "За последний день")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на допуск посетителя] WHERE [Дата и время создания]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последнюю неделю")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на допуск посетителя] WHERE [Дата и время создания]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-7)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последний месяц")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на допуск посетителя] WHERE [Дата и время создания]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddMonths(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на допуск посетителя] WHERE [Дата и время создания]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddYears(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                while (read.Read())
                {
                    visitorPassRequest = new VisitorPassRequest();
                    visitorPassRequest.RequestNumber = read["Номер заявки"].ToString();
                    visitorPassRequest.SurnameCreator = read["Фамилия инициатора"].ToString();
                    visitorPassRequest.NameCreator = read["Имя инициатора"].ToString();
                    visitorPassRequest.PatronymicCreator = read["Отчество инициатора"].ToString();
                    visitorPassRequest.Date = read["Дата и время создания"].ToString();
                    visitorPassRequest.Reason = read["Обоснование"].ToString();
                    visitorPassRequest.LeadSurnam = read["Фамилия руководителя"].ToString();
                    visitorPassRequest.LeadName = read["Имя руководителя"].ToString();
                    visitorPassRequest.LeadPatronymic = read["Отчество руководителя"].ToString();
                    visitorPassRequest.AdressPass = read["Место прохода"].ToString();
                    visitorPassRequest.VisitorSurname = read["Фамилия посетителя"].ToString();
                    visitorPassRequest.VisitorName = read["Имя посетителя"].ToString();
                    visitorPassRequest.VisitorPatronymic = read["Отчество посетителя"].ToString();
                    visitorPassRequest.VisitDateWork = read["Дата прибытия"].ToString();
                    visitorPassRequest.LeaveDateWork = read["Дата убытия"].ToString();

                    visitorPassRequests.Add(visitorPassRequest);
                }
                VisitorPassRequestDG.ItemsSource = visitorPassRequests;
                read.Close();
                connect.Close();
                if (VisRequestName.IsChecked == false)
                    VisRequestNameCol.Visibility = Visibility.Collapsed;
                else VisRequestNameCol.Visibility = Visibility.Visible;

                if (VisRequestFIOcreatort.IsChecked == false)
                {
                    VisRequestSurnameCol.Visibility = Visibility.Collapsed;
                    VisRequestNameCol.Visibility = Visibility.Collapsed;
                    VisRequestPatronyminCol.Visibility = Visibility.Collapsed;
                }
                else 
                {
                    VisRequestSurnameCol.Visibility = Visibility.Visible;
                    VisRequestNameCol.Visibility = Visibility.Visible;
                    VisRequestPatronyminCol.Visibility = Visibility.Visible;
                }

                if (VisRequestNed.IsChecked == false)
                    VisRequestAdresPassCol.Visibility = Visibility.Collapsed;
                else VisRequestAdresPassCol.Visibility = Visibility.Visible;

                if (VisRequestDateVis.IsChecked == false)
                    VisRequestStartCol.Visibility = Visibility.Collapsed;
                else VisRequestStartCol.Visibility = Visibility.Visible;

                if (VisRequestDateLeave.IsChecked == false)
                    VisRequestEndDateCol.Visibility = Visibility.Collapsed;
                else VisRequestEndDateCol.Visibility = Visibility.Visible;

                if (VisRequestFIOlead.IsChecked == false) {

                    VisRequestLeadSurnameCol.Visibility = Visibility.Collapsed;
                    VisRequestLeadNameCol.Visibility = Visibility.Collapsed;
                    VisRequestLeadPatronymicCol.Visibility = Visibility.Collapsed;
                }
                else
                {
                    VisRequestLeadSurnameCol.Visibility = Visibility.Visible;
                    VisRequestLeadNameCol.Visibility = Visibility.Visible;
                    VisRequestLeadPatronymicCol.Visibility = Visibility.Visible;
                }

                if (VisRequestFIOVisitor.IsChecked == false)
                {

                    VisRequestVisSurnameCol.Visibility = Visibility.Collapsed;
                    VisRequestVisNameCol.Visibility = Visibility.Collapsed;
                    VisRequestVisPatronymicCol.Visibility = Visibility.Collapsed;
                }
                else
                {
                    VisRequestVisSurnameCol.Visibility = Visibility.Visible;
                    VisRequestVisNameCol.Visibility = Visibility.Visible;
                    VisRequestVisPatronymicCol.Visibility = Visibility.Visible;
                }

                if (VisRequestReason.IsChecked == false)
                    VisRequestReasonCol.Visibility = Visibility.Collapsed;
                else VisRequestReasonCol.Visibility = Visibility.Visible;

                if (VisRequestCreate.IsChecked == false)
                    VisRequestCreatDateCol.Visibility = Visibility.Collapsed;
                else VisRequestCreatDateCol.Visibility = Visibility.Visible;
            }
            catch (Exception) { }
        }
        private void SelectAllVisRequest_Checked(object sender, RoutedEventArgs e)
        {
            VisRequestName.IsChecked = true;
            VisRequestFIOcreatort.IsChecked = true;
            VisRequestNed.IsChecked = true;
            VisRequestDateVis.IsChecked = true;
            VisRequestDateLeave.IsChecked = true;
            VisRequestFIOlead.IsChecked = true;
            VisRequestFIOVisitor.IsChecked = true;
            VisRequestReason.IsChecked = true;
            VisRequestCreate.IsChecked = true;
        }

        private void VisRequestCreate_Checked(object sender, RoutedEventArgs e)
        {
            if (VisRequestName.IsChecked == true && VisRequestFIOcreatort.IsChecked == true
                 && VisRequestNed.IsChecked == true && VisRequestDateVis.IsChecked == true && VisRequestDateLeave.IsChecked == true
                 && VisRequestFIOlead.IsChecked == true && VisRequestFIOVisitor.IsChecked == true && VisRequestReason.IsChecked == true && VisRequestCreate.IsChecked == true)
                SelectAllVisRequest.IsChecked = true;
        }      

        private void VisRequestCreate_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectAllVisRequest.IsChecked = false;
        }

        private void TabItem_Loaded_1(object sender, RoutedEventArgs e)
        {
            SelectDatePassRequestVisDG.SelectedIndex = 3;
        }
        private void selectAllWorkerVisFilt_Checked(object sender, RoutedEventArgs e)
        {
            WorkRequestNameR.IsChecked = true;
            WorkRequestFIOcreator.IsChecked = true;
            WorkRequestCreatDate.IsChecked = true;
            WorkRequestEndDate.IsChecked = true;
            WorkRequestReason.IsChecked = true;
            WorkRequestRomNum.IsChecked = true;
            WorkRequestLeadFIO.IsChecked = true;
            WorkRequestStart.IsChecked = true;
            WorkRequestRomNum.IsChecked = true;
            WorkRequestAdressPass.IsChecked = true;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void WorkRequestRomNum_Checked(object sender, RoutedEventArgs e)
        {
            if (WorkRequestNameR.IsChecked == true && WorkRequestFIOcreator.IsChecked == true
            && WorkRequestCreatDate.IsChecked == true && WorkRequestEndDate.IsChecked == true && WorkRequestReason.IsChecked == true
            && WorkRequestRomNum.IsChecked == true && WorkRequestLeadFIO.IsChecked == true && WorkRequestStart.IsChecked == true && WorkRequestRomNum.IsChecked == true && WorkRequestAdressPass.IsChecked == true)
                selectAllWorkerVisFilt.IsChecked = true;
        }

        private void WorkRequestRomNum_Unchecked(object sender, RoutedEventArgs e)
        {
            selectAllWorkerVisFilt.IsChecked = false;
        }

        private void TabItem_Loaded_2(object sender, RoutedEventArgs e)
        {
            WorkerVisitRequestCB.SelectedIndex = 3;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                workerPassRequests.Clear();
                string value = "";
                ComboBoxItem selectedItem = (ComboBoxItem)(WorkerVisitRequestCB.SelectedValue);
                value = (string)(selectedItem.Content);
                WorkerPassRequestDG.ItemsSource = null;
                OleDbDataReader read;
                if (value == "За последний день")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на допуск сотрудников] WHERE Дата" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последнюю неделю")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на допуск сотрудников] WHERE Дата" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-7)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последний месяц")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на допуск сотрудников] WHERE Дата" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddMonths(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на допуск сотрудников] WHERE Дата" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddYears(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                while (read.Read())
                {
                    workerPassRequest = new WorkerPassRequest();
                    workerPassRequest.RequestNumber = read["Номер заявки"].ToString();
                    workerPassRequest.SurnameCreator = read["Фамилия инициатора"].ToString();
                    workerPassRequest.NameCreator = read["Имя инициатора"].ToString();
                    workerPassRequest.PatronymicCreator = read["Отчество инициатора"].ToString();
                    workerPassRequest.Date = read["Дата"].ToString();
                    workerPassRequest.Reason = read["Обоснование доступа"].ToString();
                    workerPassRequest.LeadSurnam = read["Фамилия руководителя"].ToString();
                    workerPassRequest.LeadName = read["Имя руководителя"].ToString();
                    workerPassRequest.LeadPatronymic = read["Отчество руководителя"].ToString();
                    workerPassRequest.AdressPass = read["Адрес помещения для доступа"].ToString();
                    workerPassRequest.StartDateWork = read["Дата и время начала работы"].ToString();
                    workerPassRequest.EndDateWork = read["Дата и время окончания работы"].ToString();
                    workerPassRequest.RoomNumber = read["Номер помещения"].ToString();
                    workerPassRequests.Add(workerPassRequest);
                }
                WorkerPassRequestDG.ItemsSource = workerPassRequests;
                read.Close();
                connect.Close();

                 if (WorkRequestNameR.IsChecked == false)
                    WorkRequestNameRCol.Visibility = Visibility.Collapsed;
                else WorkRequestNameRCol.Visibility = Visibility.Visible;

                if (WorkRequestFIOcreator.IsChecked == false)
                {
                    WorkRequestSurnameCol.Visibility = Visibility.Collapsed;
                    WorkRequestNameCol.Visibility = Visibility.Collapsed;
                    WorkRequestPatronyminCol.Visibility = Visibility.Collapsed;
                }
                else
                {
                    WorkRequestSurnameCol.Visibility = Visibility.Visible;
                    WorkRequestNameCol.Visibility = Visibility.Visible;
                    WorkRequestPatronyminCol.Visibility = Visibility.Visible;
                }

                if (WorkRequestRomNum.IsChecked == false)
                    WorkRequestAdresPassCol.Visibility = Visibility.Collapsed;
                else WorkRequestAdresPassCol.Visibility = Visibility.Visible;

                if (WorkRequestStart.IsChecked == false)
                    WorkRequestStartCol.Visibility = Visibility.Collapsed;
                else WorkRequestStartCol.Visibility = Visibility.Visible;

                if (WorkRequestEndDate.IsChecked == false)
                    WorkRequestEndDateCol.Visibility = Visibility.Collapsed;
                else WorkRequestEndDateCol.Visibility = Visibility.Visible;

                if (WorkRequestAdressPass.IsChecked == false)
                    WorkRequestAdressPass.Visibility = Visibility.Collapsed;
                else WorkRequestAdressPass.Visibility = Visibility.Visible;
                
                if (WorkRequestLeadFIO.IsChecked == false)
                {
                    WorkRequestLeadSurnameCol.Visibility = Visibility.Collapsed;
                    WorkRequestLeadNameCol.Visibility = Visibility.Collapsed;
                    WorkRequestLeadPatronymicCol.Visibility = Visibility.Collapsed;
                }
                else
                {
                    WorkRequestLeadSurnameCol.Visibility = Visibility.Visible;
                    WorkRequestLeadNameCol.Visibility = Visibility.Visible;
                    WorkRequestLeadPatronymicCol.Visibility = Visibility.Visible;
                }
                if (WorkRequestReason.IsChecked == false)
                    WorkRequestReasonCol.Visibility = Visibility.Collapsed;
                else WorkRequestReasonCol.Visibility = Visibility.Visible;

                if (WorkRequestCreatDate.IsChecked == false)
                    WorkRequestCreatDateCol.Visibility = Visibility.Collapsed;
                else WorkRequestCreatDateCol.Visibility = Visibility.Visible;
            }
            catch (Exception) { }
        }

        private void TKRequesName_Checked(object sender, RoutedEventArgs e)
        {
            if (TKRequesName.IsChecked == true && TKRequesFIOCreator.IsChecked == true
                    && TKRequesDateCreate.IsChecked == true && TKRequesAdressDeli.IsChecked == true && TKRequesFIOTaker.IsChecked == true
                    && TKRequesPass.IsChecked == true && TKRequesCount.IsChecked == true && TKRequesReason.IsChecked == true && TKRequesNameOrg.IsChecked == true
                    && TKRequesNameSiresNumber.IsChecked == true && TKRequesItemName.IsChecked == true)
                SelectAllTKFilter.IsChecked = true;
        }

        private void TKRequesName_Unchecked(object sender, RoutedEventArgs e)
        {
            SelectAllTKFilter.IsChecked = false;
        }

        private void SelectAllTKFilter_Checked(object sender, RoutedEventArgs e)
        {
            TKRequesName.IsChecked = true;
            TKRequesFIOCreator.IsChecked = true;
            TKRequesDateCreate.IsChecked = true;
            TKRequesAdressDeli.IsChecked = true;
            TKRequesFIOTaker.IsChecked = true;
            TKRequesPass.IsChecked = true;
            TKRequesCount.IsChecked = true;
            TKRequesReason.IsChecked = true;
            TKRequesNameOrg.IsChecked = true;
            TKRequesNameSiresNumber.IsChecked = true;
            TKRequesItemName.IsChecked = true;
        }
        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return System.Convert.ToBase64String(hash);
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                takeoutRequests.Clear();
                string value = "";
                ComboBoxItem selectedItem = (ComboBoxItem)(SelectTKDateCB.SelectedValue);
                value = (string)(selectedItem.Content);
                TakeOutRequestDG.ItemsSource = null;
                OleDbDataReader read;
                if (value == "За последний день")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на вынос] WHERE [Дата и время выноса]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последнюю неделю")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на вынос] WHERE [Дата и время выноса]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-7)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else if (value == "За последний месяц")
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на вынос] WHERE [Дата и время выноса]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddMonths(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                else
                {
                    read = SELECT("SELECT *" +
                        " FROM [Заявка на вынос] WHERE [Дата и время выноса]" +
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddYears(-1)).Replace('.', '-') +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now).Replace('.', '/') + "#", connection);
                }
                while (read.Read())
                {
                    takeout_request = new TakeoutRequest();
                    takeout_request.RequestNumber = read["Номер заявки"].ToString();
                    takeout_request.SurnameRecipient = read["Фамилия инициатора"].ToString();
                    takeout_request.NameRecipient = read["Имя инициатора"].ToString();
                    takeout_request.PatronymicRecipient = read["Отчество инициатора"].ToString();
                    takeout_request.Date = read["Дата и время выноса"].ToString();
                    takeout_request.Reason = read["Обоснование выноса"].ToString();
                    takeout_request.SunamTaker = read["Фамилия лица вынос"].ToString();
                    takeout_request.NameTaker = read["Имя лица вынос"].ToString();
                    takeout_request.PatronymicTaker = read["Отчество лица вынос"].ToString();
                    takeout_request.AdressPass = read["Место выноса"].ToString();
                    takeout_request.AdressDelivery = read["Адрес доставки имущества"].ToString();
                    takeout_request.ItemName = read["Наименование"].ToString();
                    takeout_request.Count = read["Количество"].ToString();
                    takeout_request.OrganizationName = read["Наименование организации"].ToString();
                    takeout_request.ModelNumber = read["Серийный номер"].ToString();

                    takeoutRequests.Add(takeout_request);
                }
          
                TakeOutRequestDG.ItemsSource = takeoutRequests;
                read.Close();
                connect.Close();
                if (TKRequesName.IsChecked == false)
                    TKRequesNameCol.Visibility = Visibility.Collapsed;
                else TKRequesNameCol.Visibility = Visibility.Visible;

                if (TKRequesFIOCreator.IsChecked == false)
                {
                    TKRequesSurnameCreatorCol.Visibility = Visibility.Collapsed;
                    TKRequesNameCreatorCol.Visibility = Visibility.Collapsed;
                    TKRequesPatronymicCreatorCol.Visibility = Visibility.Collapsed;
                }
                else
                {
                    TKRequesSurnameCreatorCol.Visibility = Visibility.Visible;
                    TKRequesNameCreatorCol.Visibility = Visibility.Visible;
                    TKRequesPatronymicCreatorCol.Visibility = Visibility.Visible;
                }

                if (TKRequesPass.IsChecked == false)
                    TKRequesPassCol.Visibility = Visibility.Collapsed;
                else TKRequesPassCol.Visibility = Visibility.Visible;

                if (TKRequesDateCreate.IsChecked == false)
                    TKRequesDateCreateCol.Visibility = Visibility.Collapsed;
                else TKRequesDateCreateCol.Visibility = Visibility.Visible;

                if (TKRequesReason.IsChecked == false)
                    TKRequesReasonCol.Visibility = Visibility.Collapsed;
                else TKRequesReasonCol.Visibility = Visibility.Visible;

                if (TKRequesNameOrg.IsChecked == false)
                    TKRequesNameOrgCol.Visibility = Visibility.Collapsed;
                else TKRequesNameOrgCol.Visibility = Visibility.Visible;

                if (TKRequesAdressDeli.IsChecked == false)
                    TKRequesAdressDeliCol.Visibility = Visibility.Collapsed;
                else TKRequesAdressDeliCol.Visibility = Visibility.Visible;

                if (TKRequesNameSiresNumber.IsChecked == false)
                    TKRequesNameSiresNumberCol.Visibility = Visibility.Collapsed;
                else TKRequesNameSiresNumberCol.Visibility = Visibility.Visible;

                if (TKRequesFIOTaker.IsChecked == false)
                {

                    TKRequesSurnameTakerCol.Visibility = Visibility.Collapsed;
                    TKRequesNameTakerCol.Visibility = Visibility.Collapsed;
                    TKRequesPatronymicTakerCol.Visibility = Visibility.Collapsed;
                }
                else
                {
                    TKRequesSurnameTakerCol.Visibility = Visibility.Visible;
                    TKRequesNameTakerCol.Visibility = Visibility.Visible;
                    TKRequesPatronymicTakerCol.Visibility = Visibility.Visible;
                }

                if (TKRequesCount.IsChecked == false)
                    TKRequesCountCol.Visibility = Visibility.Collapsed;
                else TKRequesCountCol.Visibility = Visibility.Visible;

                if (TKRequesItemName.IsChecked == false)
                    TKRequesItemNameCol.Visibility = Visibility.Collapsed;
                else TKRequesItemNameCol.Visibility = Visibility.Visible;
            }
            catch (Exception) { }
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
                
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            try
            {
                Accounts.Clear();
                string value = "";
                ComboBoxItem selectedItem = (ComboBoxItem)(PostAcc2.SelectedValue);
                value = (string)(selectedItem.Content);
                AccountsDG2.ItemsSource = null;
                OleDbDataReader read;
                if (value != "Все")
                    read = SELECT("SELECT Логин, Фамилия, Имя, Отчество, Должность, [Дата создания], Время FROM [Учетная запись] WHERE Должность = '" + value + "'", connection);
                else read = SELECT("SELECT Логин, Фамилия, Имя, Отчество, Должность, [Дата создания], Время FROM [Учетная запись]", connection);
                while (read.Read())
                {
                    account = new Account();
                    account.Login = read.GetValue(0).ToString();
                    account.Surname = read.GetValue(1).ToString();
                    account.Name = read.GetValue(2).ToString();
                    account.Patronymic = read.GetValue(3).ToString();
                    account.Post = read.GetValue(4).ToString();
                    account.Date = read.GetValue(5).ToString();
                    account.Time = read.GetValue(6).ToString();
                    Accounts.Add(account);
                }
                AccountsDG2.ItemsSource = Accounts;
                read.Close();
                connect.Close();

                if (loginAcc2.IsChecked == false)
                    LoginColAcc2.Visibility = Visibility.Collapsed;
                else LoginColAcc2.Visibility = Visibility.Visible;

                if (DateRegAcc2.IsChecked == false)
                    DateColAcc2.Visibility = Visibility.Collapsed;
                else DateRegAcc2.Visibility = Visibility.Visible;

                if (TimeRegAcc2.IsChecked == false)
                    TimeColAcc2.Visibility = Visibility.Collapsed;
                else TimeColAcc2.Visibility = Visibility.Visible;

                if (SurnameAcc2.IsChecked == false)
                    SurnameColAcc2.Visibility = Visibility.Collapsed;
                else SurnameColAcc2.Visibility = Visibility.Visible;

                if (NameAcc2.IsChecked == false)
                    NameColAcc2.Visibility = Visibility.Collapsed;
                else NameColAcc2.Visibility = Visibility.Visible;

                if (PatronymicAcc2.IsChecked == false)
                    PatronymicColAcc2.Visibility = Visibility.Collapsed;
                else PatronymicColAcc2.Visibility = Visibility.Visible;

                if (PostAccc2.IsChecked == false)
                    PostColAcc2.Visibility = Visibility.Collapsed;
                else PostColAcc2.Visibility = Visibility.Visible;

            }
            catch (Exception)
            {

            }
        }

        private void selectAllAcc_Checked2(object sender, RoutedEventArgs e)
        {
            loginAcc2.IsChecked = true;
            DateRegAcc2.IsChecked = true;
            TimeRegAcc2.IsChecked = true;
            SurnameAcc2.IsChecked = true;
            NameAcc2.IsChecked = true;
            PatronymicAcc2.IsChecked = true;
            PostAccc2.IsChecked = true;
        }

        private void selectAcc_Checked2(object sender, RoutedEventArgs e)
        {
            if (loginAcc2.IsChecked == true && DateRegAcc2.IsChecked == true && TimeRegAcc2.IsChecked == true
                && SurnameAcc2.IsChecked == true && NameAcc2.IsChecked == true && PatronymicAcc2.IsChecked == true && PostAccc2.IsChecked == true)
                selectAllAcc2.IsChecked = true;
        }

        private void selectAcc_Unchecked2(object sender, RoutedEventArgs e)
        {
            selectAllAcc2.IsChecked = false;
        }

        private async void DeleteByID(string FieldNAme, string TableName, string ID)
        {
            try
            {
                using (var cnn = new OleDbConnection(connection))
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM "+TableName+" WHERE "+FieldNAme+" = @id";
                    cmd.Parameters.AddWithValue("@id", ID);
                    await cnn.OpenAsync();
                    var deleted = await cmd.ExecuteNonQueryAsync();
                    Trace.WriteLine($"Удалено {deleted}");
                    
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }

        private void ButtonRemoveTakeOutReuest_Click(object sender, RoutedEventArgs e)
        {
            var temp = TakeOutRequestDG.SelectedItem as TakeoutRequest;
            if (temp != null)
            {
                DeleteByID("[Номер заявки]", "[Заявка на вынос]", temp.RequestNumber);

                int SelectedIndex = TakeOutRequestDG.SelectedIndex;
                takeoutRequests.RemoveAt(SelectedIndex);
                TakeOutRequestDG.ItemsSource = null;
                TakeOutRequestDG.Items.Clear();
                TakeOutRequestDG.ItemsSource = takeoutRequests;
            }
        }
        private void ButtonRemoveAccount_Click(object sender, RoutedEventArgs e)
        {
            var temp = AccountsDG.SelectedItem as Account;
            if (temp != null)
            {
                DeleteByID("Логин", "[Учетная запись]", temp.Login);

                int SelectedIndex = AccountsDG.SelectedIndex;
                Accounts.RemoveAt(SelectedIndex);
                AccountsDG.ItemsSource = null;
                AccountsDG.Items.Clear();
                AccountsDG.ItemsSource = Accounts;
            }
        }
        private void ButtonRemoveTempPass_Click(object sender, RoutedEventArgs e)
        {
            var temp = TempPassRequestDG.SelectedItem as TempPass;
            if (temp != null)
            {
                DeleteByID("[Номер пропуска]", "[Выдача временных пропусков]", temp.Pass);

                int SelectedIndex = TempPassRequestDG.SelectedIndex;
                tempPasss.RemoveAt(SelectedIndex);
                TempPassRequestDG.ItemsSource = null;
                TempPassRequestDG.Items.Clear();
                TempPassRequestDG.ItemsSource = tempPasss;
            }
        }
        private void ButtonRemoveTempKey_Click(object sender, RoutedEventArgs e)
        {
            var temp = TempKeyRequestDG.SelectedItem as TempKey;
            if (temp != null)
            {
                DeleteByID("[Номер ключа]", "[Выдача запасных ключей]", temp.Key);

                int SelectedIndex = TempKeyRequestDG.SelectedIndex;
                tempKeys.RemoveAt(SelectedIndex);
                TempKeyRequestDG.ItemsSource = null;
                TempKeyRequestDG.Items.Clear();
                TempKeyRequestDG.ItemsSource = tempKeys;
            }
        }

        private void ButtonRemoveWorkerVisit_Click(object sender, RoutedEventArgs e)
        {
            var temp = WorkerPassRequestDG.SelectedItem as WorkerPassRequest;
            if (temp != null)
            {
                DeleteByID("[Номер заявки]", "[Заявка на допуск сотрудников]", temp.RequestNumber);

                int SelectedIndex = WorkerPassRequestDG.SelectedIndex;
                workerPassRequests.RemoveAt(SelectedIndex);
                WorkerPassRequestDG.ItemsSource = null;
                WorkerPassRequestDG.Items.Clear();
                WorkerPassRequestDG.ItemsSource = workerPassRequests;
            }
        }
        private void ButtonRemoveVisitorVisit_Click(object sender, RoutedEventArgs e)
        {
            var temp = VisitorPassRequestDG.SelectedItem as VisitorPassRequest;
            if (temp != null)
            {
                DeleteByID("[Номер заявки]", "[Заявка на допуск посетителя]", temp.RequestNumber);

                int SelectedIndex = VisitorPassRequestDG.SelectedIndex;
                visitorPassRequests.RemoveAt(SelectedIndex);
                VisitorPassRequestDG.ItemsSource = null;
                VisitorPassRequestDG.Items.Clear();
                VisitorPassRequestDG.ItemsSource = visitorPassRequests;
            }
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            this.selectetdTable = SelectetdTable.WorkerVisitTable;
        }

        private void TabItem_GotFocus_1(object sender, RoutedEventArgs e)
        {
            this.selectetdTable = SelectetdTable.TempKeyTable;
        }

        private void TabItem_GotFocus_2(object sender, RoutedEventArgs e)
        {
            this.selectetdTable = SelectetdTable.TempPassTable;
        }

        private void TabItem_GotFocus_3(object sender, RoutedEventArgs e)
        {
            this.selectetdTable = SelectetdTable.AccountTable;
        }

        private void TabItem_GotFocus_4(object sender, RoutedEventArgs e)
        {
            this.selectetdTable = SelectetdTable.VisitorVisTable;
        }

        private void TabItem_GotFocus_5(object sender, RoutedEventArgs e)
        {
            this.selectetdTable = SelectetdTable.TakeoutRequestTable;
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChLogin.Visibility = Visibility.Hidden;
        }

        private void FioCh(object sender, TextChangedEventArgs e)
        {
            ChFIO.Visibility = Visibility.Hidden;
        }
        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChPassword.Visibility = Visibility.Hidden;
        }

        private void Button_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        private void Button_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            var temp = AccountsDG2.SelectedItem as Account;
            if (temp != null)
            {
                DeleteByID("Логин", "[Учетная запись]", temp.Login);

                int SelectedIndex = AccountsDG2.SelectedIndex;
                Accounts.RemoveAt(SelectedIndex);
                AccountsDG2.ItemsSource = null;
                AccountsDG2.Items.Clear();
                AccountsDG2.ItemsSource = Accounts;
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ChPassword.Visibility = Visibility.Hidden;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            about about = new about();
            about.Show();
        }
    }
}
