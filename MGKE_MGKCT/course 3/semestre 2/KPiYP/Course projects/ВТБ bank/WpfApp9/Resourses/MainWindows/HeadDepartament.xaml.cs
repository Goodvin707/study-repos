using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp9.Resourses.BugReport;
using WpfApp9.Resourses.MessageWinfow;
using WpfApp9.Resourses.RequestsWindow;
using WpfApp9.Resourses.Help;

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для HeadDepartament.xaml
    /// </summary>
    public enum SelectHwindow { select1, select2, select3}
    public partial class HeadDepartament : Window
    {
        public HeadDepartament()
        {
            SplashScreen splashScreen = new SplashScreen("Resourses/Images/pixel.png");
            splashScreen.Show(true);
            InitializeComponent();
        }
        public enum RequestType { TakeoutRequest, VisPassRequest, WorkerPassRequest, TempPass, TempKey }
        private void Ctrl1Executed(object sender, ExecutedRoutedEventArgs e)
        {
            BugReport bugReport = new BugReport();
            bugReport.Show();
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
        TakeoutRequest takeout_request = new TakeoutRequest();
        List<TakeoutRequest> takeoutRequests = new List<TakeoutRequest>();

        TempKey tempKey = new TempKey();
        List<TempKey> tempKeys = new List<TempKey>();

        TempPass tempPass = new TempPass();
        List<TempPass> tempPasss = new List<TempPass>();

        static string connection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source= VTBRequest1.accdb";
        VisitorPassRequest visitorPassRequest = new VisitorPassRequest();
        List<VisitorPassRequest> visitorPassRequests = new List<VisitorPassRequest>();

        WorkerPassRequest workerPassRequest = new WorkerPassRequest();
        List<WorkerPassRequest> workerPassRequests = new List<WorkerPassRequest>();
        OleDbConnection connect = new OleDbConnection(connection);
        public OleDbDataReader SELECT(string query, string connection)
        {

            connect.Open();
            OleDbCommand cmd = new OleDbCommand(query, connect);
            OleDbDataReader read = cmd.ExecuteReader();
            return read;
        }

        private void Maximaze(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;

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

        private void SelectMaimMenuButton(object sender, RoutedEventArgs e)
        {
            var temp = (Button)sender;
            temp.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF0B2A74");

        }

        private void Button_LostFocus(object sender, RoutedEventArgs e)
        {
            var temp = (Button)sender;
            temp.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF568CE6");
        }
        List<Grid> grids = new List<Grid>();

        private void SelectmenuButton(object sender, RoutedEventArgs e)
        {

            grids.Add(gr1_TakeOutReqest);
            grids.Add(gr2_PassageRequests);
            grids.Add(gr5_Messenger);
            grids.Add(gr6_TelephonNumbers);
            var temp = (Button)sender;
            for (int i = 0; i < grids.Count; i++)
            {
                if (temp.Name[temp.Name.Length - 1] == grids[i].Name[2])
                {
                    for (int j = 0; j < grids.Count; j++)
                    {
                        if (j != i)
                            grids[j].Visibility = Visibility.Hidden;
                        else grids[j].Visibility = Visibility.Visible;

                    }
                }
            }
            switch (temp.Name[temp.Name.Length - 1])
            {
                case '1':
                    this.SelectHwindow = SelectetdTable.TakeoutRequestTable;
                    break;
                case '2':
                    this.SelectHwindow = SelectetdTable.WorkerVisitTable;
                    tabLS.SelectedIndex = 0;
                    break;
                case '3':
                    this.SelectHwindow = SelectetdTable.TempPassTable;
                    break;
                case '4':
                    this.SelectHwindow = SelectetdTable.TempKeyTable;
                    break;
                case '5':
                    break;
                case '6':
                    break;
            }
        }



        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

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
                    if (read["Вход"].ToString() == "Да")
                        visitorPassRequest.In = true;
                    else visitorPassRequest.In = false;

                    if (read["Выход"].ToString() == "Да")
                        visitorPassRequest.Out = true;
                    else visitorPassRequest.In = false;

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

                if (VisRequestFIOlead.IsChecked == false)
                {

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
        SelectetdTable SelectHwindow;
        private void ExportToExcel(object sender, ExecutedRoutedEventArgs e)
        {

            if (this.SelectHwindow == SelectetdTable.TakeoutRequestTable)
            {
                SaveWE saveWE = new SaveWE(ref TakeOutRequestDG);
                saveWE.ShowDialog();
            }
            if (this.SelectHwindow == SelectetdTable.VisitorVisTable)
            {
                SaveWE saveWE = new SaveWE(ref VisitorPassRequestDG);
                saveWE.ShowDialog();
            }
            if (this.SelectHwindow == SelectetdTable.WorkerVisitTable)
            {
                SaveWE saveWE = new SaveWE(ref WorkerPassRequestDG);
                saveWE.ShowDialog();
            }
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
                    if (read["Вход"].ToString() == "Да")
                        visitorPassRequest.In = true;
                    else visitorPassRequest.In = false;

                    if (read["Выход"].ToString() == "Да")
                        visitorPassRequest.Out = true;
                    else visitorPassRequest.In = false;
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



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var read = SELECT("SELECT *" +
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
                if (read["Вход"].ToString() == "Да")
                    visitorPassRequest.In = true;
                else visitorPassRequest.In = false;

                if (read["Выход"].ToString() == "Да")
                    visitorPassRequest.Out = true;
                else visitorPassRequest.In = false;
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
                if (read["Вход"].ToString() == "Да")
                    workerPassRequest.In = true;
                else workerPassRequest.In = false;

                if (read["Выход"].ToString() == "Да")
                    workerPassRequest.Out = true;
                else workerPassRequest.In = false;
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
                if (read["Вход"].ToString() == "Да")
                    takeout_request.In = true;
                else takeout_request.In = false;

                if (read["Выход"].ToString() == "Да")
                    takeout_request.Out = true;
                else takeout_request.In = false;
                takeoutRequests.Add(takeout_request);
            }
            TakeOutRequestDG.ItemsSource = takeoutRequests;
            read.Close();
            connect.Close();
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SelectHwindow = SelectetdTable.WorkerVisitTable;
        }

        private void TabItem_GotFocus_1(object sender, RoutedEventArgs e)
        {
            this.SelectHwindow = SelectetdTable.VisitorVisTable;
        }
        private void FindRequest(object sender, RoutedEventArgs e)
        {
            FindString(RequestType.TempPass);
        }

        void FindString(RequestType requestType)
        {
            if (requestType == RequestType.VisPassRequest)
            {
                var VisRequestList = new List<VisitorPassRequest>();
                var read = SELECT("SELECT *" +
                " FROM [Заявка на допуск посетителя]", connection);

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

                    VisRequestList.Add(visitorPassRequest);
                }
                read.Close();
                connect.Close();
                FindTakeout findVisitorPass = new FindTakeout();
                if (findVisitorPass.ShowDialog() == true)
                {
                    var findList = new List<VisitorPassRequest>();
                    if (FindeString.Date != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].Date == FindeString.Date + " 0:00:00")
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.NameRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].NameCreator == FindeString.NameRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.SurnameRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].SurnameCreator == FindeString.SurnameRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.PatronymicRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].PatronymicCreator == FindeString.PatronymicRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.VisitorName != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].VisitorName == FindeString.VisitorName)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.VisitorSurname != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].VisitorSurname == FindeString.VisitorSurname)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.VisitorPatronymic != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].VisitorPatronymic == FindeString.VisitorPatronymic)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.LeadName != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].LeadName == FindeString.LeadName)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.LeadSurnam != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].LeadSurnam == FindeString.LeadSurnam)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.LeadPatronymic != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].LeadPatronymic == FindeString.LeadPatronymic)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.VisitDateWork != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].VisitDateWork == FindeString.VisitDateWork + " 0:00:00")
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.LeaveDateWork != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].LeaveDateWork == FindeString.LeaveDateWork + " 0:00:00")
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.Reason != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].Reason == FindeString.Reason)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.Pass != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].AdressPass == FindeString.Pass)
                                findList.Add(VisRequestList[i]);
                        }

                    /* for (int i = 0; i < VisRequestList.Count; i++)
                     {
                         if (VisRequestList[i].In == FindeString.In)
                             findList.Add(VisRequestList[i]);
                     }

                     for (int i = 0; i < VisRequestList.Count; i++)
                     {
                         if (VisRequestList[i].Out == FindeString.Out)
                             findList.Add(VisRequestList[i]);
                     }*/
                    if (FindeString.RoomNumber != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].RoomNumber == FindeString.RoomNumber)
                                findList.Add(VisRequestList[i]);
                        }
                    var findList2 = findList.Distinct().ToList();
                    VisitorPassRequestDG.ItemsSource = null;
                    VisitorPassRequestDG.ItemsSource = findList2;
                }
            }
            if (requestType == RequestType.WorkerPassRequest)
            {
                var VisRequestList = new List<WorkerPassRequest>();
                var read = SELECT("SELECT *" +
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
                    if (read["Вход"].ToString() == "Да")
                        workerPassRequest.In = true;
                    else workerPassRequest.In = false;

                    if (read["Выход"].ToString() == "Да")
                        workerPassRequest.Out = true;
                    else workerPassRequest.In = false;
                    VisRequestList.Add(workerPassRequest);
                }
                read.Close();
                connect.Close();
                FindWorkerPass findVisitorPass = new FindWorkerPass();
                if (findVisitorPass.ShowDialog() == true)
                {
                    var findList = new List<WorkerPassRequest>();
                    if (FindeString.Date != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].Date == FindeString.Date + " 0:00:00")
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.NameRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].NameCreator == FindeString.NameRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.SurnameRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].SurnameCreator == FindeString.SurnameRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.PatronymicRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].PatronymicCreator == FindeString.PatronymicRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.LeadName != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].LeadName == FindeString.LeadName)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.LeadSurnam != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].LeadSurnam == FindeString.LeadSurnam)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.LeadPatronymic != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].LeadPatronymic == FindeString.LeadPatronymic)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.VisitDateWork != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].StartDateWork == FindeString.VisitDateWork + " 0:00:00")
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.LeaveDateWork != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].EndDateWork == FindeString.LeaveDateWork + " 0:00:00")
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.Reason != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].Reason == FindeString.Reason)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.Pass != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].AdressPass == FindeString.Pass)
                                findList.Add(VisRequestList[i]);
                        }

                    /* for (int i = 0; i < VisRequestList.Count; i++)
                     {
                         if (VisRequestList[i].In == FindeString.In)
                             findList.Add(VisRequestList[i]);
                     }

                     for (int i = 0; i < VisRequestList.Count; i++)
                     {
                         if (VisRequestList[i].Out == FindeString.Out)
                             findList.Add(VisRequestList[i]);
                     }*/
                    if (FindeString.RoomNumber != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].RoomNumber == FindeString.RoomNumber)
                                findList.Add(VisRequestList[i]);
                        }
                    var findList2 = findList.Distinct().ToList();
                    WorkerPassRequestDG.ItemsSource = null;
                    WorkerPassRequestDG.ItemsSource = findList2;
                }
            }
            if (requestType == RequestType.TakeoutRequest)
            {
                var VisRequestList = new List<TakeoutRequest>();
                var read = SELECT("SELECT *" +
           " FROM [Заявка на вынос]", connection);

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

                    VisRequestList.Add(takeout_request);
                }
                read.Close();
                connect.Close();

                FindTakeOutReq findVisitorPass = new FindTakeOutReq();
                if (findVisitorPass.ShowDialog() == true)
                {
                    var findList = new List<TakeoutRequest>();
                    if (FindeString.Date != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].Date == FindeString.Date + " 0:00:00")
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.NameTaker != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].NameTaker == FindeString.NameTaker)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.SunamTaker != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].SunamTaker == FindeString.SunamTaker)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.PatronymicTaker != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].PatronymicTaker == FindeString.PatronymicTaker)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.NameRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].NameRecipient == FindeString.NameRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.SurnameRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].SurnameRecipient == FindeString.SurnameRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.PatronymicRecipient != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].PatronymicRecipient == FindeString.PatronymicRecipient)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.Reason != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].Reason == FindeString.Reason)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.AdressPass != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].AdressPass == FindeString.AdressPass)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.ItemName != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].AdressPass == FindeString.ItemName)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.Count != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].AdressPass == FindeString.Count)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.ModelNumber != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].AdressPass == FindeString.ModelNumber)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.Pass != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].AdressPass == FindeString.Pass)
                                findList.Add(VisRequestList[i]);
                        }
                    if (FindeString.OrganizationName != "")
                        for (int i = 0; i < VisRequestList.Count; i++)
                        {
                            if (VisRequestList[i].AdressPass == FindeString.OrganizationName)
                                findList.Add(VisRequestList[i]);
                        }

                    /* for (int i = 0; i < VisRequestList.Count; i++)
                     {
                         if (VisRequestList[i].In == FindeString.In)
                             findList.Add(VisRequestList[i]);
                     }

                     for (int i = 0; i < VisRequestList.Count; i++)
                     {
                         if (VisRequestList[i].Out == FindeString.Out)
                             findList.Add(VisRequestList[i]);
                     }*/

                    var findList2 = findList.Distinct().ToList();
                    TakeOutRequestDG.ItemsSource = null;
                    TakeOutRequestDG.ItemsSource = findList2;
                }
            }

        }

        private void FindRequestWorker(object sender, RoutedEventArgs e)
        {
            FindString(RequestType.WorkerPassRequest);
        }

        private void FindRequestVisitor(object sender, RoutedEventArgs e)
        {
            FindString(RequestType.VisPassRequest);
        }



        private void FindRequestTakeoutReq(object sender, RoutedEventArgs e)
        {
            FindString(RequestType.TakeoutRequest);
        }

        private void TakeOutRequestDG_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
