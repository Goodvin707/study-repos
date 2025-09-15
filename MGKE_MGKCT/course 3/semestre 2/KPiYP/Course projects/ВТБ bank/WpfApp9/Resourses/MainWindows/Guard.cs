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
using WpfApp9.Resourses.BugReport;
using WpfApp9.Resourses.MessageWinfow;

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для Administration.xaml
    /// </summary>
    public partial class leadingSecialist : Window
    {
        public leadingSecialist()
        {
            InitializeComponent();
        }

        private void Ctrl1Executed(object sender, ExecutedRoutedEventArgs e)
        {
            BugReport bugReport = new BugReport();
            bugReport.Show();
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
            if(this.WindowState == WindowState.Normal)
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
            temp.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF2562BB");
        }
        List<Grid> grids = new List<Grid>();

        private void SelectmenuButton(object sender, RoutedEventArgs e)
        {

            grids.Add(gr1_TakeOutReqest);
            grids.Add(gr2_PassageRequests);
            grids.Add(gr3_TemporaryPass);
            grids.Add(gr4_TemporaryKey);
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

        private void createTempKey(object sender, RoutedEventArgs e)
        {
            TakeTampKey tampKey = new TakeTampKey();
            tampKey.ShowDialog();
        }
        private void createTempPass(object sender, RoutedEventArgs e)
        {
            TakeTempPass tampPass = new TakeTempPass();
            tampPass.ShowDialog();            
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
                        " BETWEEN  #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now.AddDays(-1)) +
                        "# " + "And #" + String.Format("{0:yyyy/MM/dd}", DateTime.Now) + "#", connection);
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
                    tempPass.SunamGiver = read.GetValue(6).ToString();
                    tempPass.NameGiver = read.GetValue(7).ToString();
                    tempPass.PatronymicGiver = read.GetValue(8).ToString();
                    tempPass.DateReturn = read.GetValue(9).ToString();

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
                else TempPPatronymicCreator.Visibility = Visibility.Visible;

                if (TempPDate.IsChecked == false)
                    TempPDateCol.Visibility = Visibility.Collapsed;
                else TempPDateCol.Visibility = Visibility.Visible;

                if (TempPNameTaker.IsChecked == false)
                    TempPNameTakerCol.Visibility = Visibility.Collapsed;
                else TempPNameTaker.Visibility = Visibility.Visible;

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
        private void LogOut(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

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

                if (TempPPatronymicCreator.IsChecked == false)
                    TempPPatronymicCreatorCol.Visibility = Visibility.Collapsed;
                else TempPPatronymicCreator.Visibility = Visibility.Visible;

                if (TempKDate.IsChecked == false)
                    TempKDateCol.Visibility = Visibility.Collapsed;
                else TempKDateCol.Visibility = Visibility.Visible;

                if (TempKNameTaker.IsChecked == false)
                    TempKNameTakerCol.Visibility = Visibility.Collapsed;
                else TempKNameTaker.Visibility = Visibility.Visible;

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

            if (this.SelectHwindow == SelectetdTable.TempKeyTable)
            {
                SaveWE saveWE = new SaveWE(ref TakeOutRequestDG);
                saveWE.Show();
            }
            if (this.SelectHwindow == SelectetdTable.TempPassTable)
            {
                SaveWE saveWE = new SaveWE(ref WorkerPassRequestDG);
                saveWE.ShowDialog();
            }
            if (this.SelectHwindow == SelectetdTable.TakeoutRequestTable)
            {
                SaveWE saveWE = new SaveWE(ref VisitorPassRequestDG);
                saveWE.ShowDialog();
            }
            if (this.SelectHwindow == SelectetdTable.VisitorVisTable)
            {
                SaveWE saveWE = new SaveWE(ref VisitorPassRequestDG);
                saveWE.ShowDialog();
            }
            if (this.SelectHwindow == SelectetdTable.WorkerVisitTable)
            {
                SaveWE saveWE = new SaveWE(ref VisitorPassRequestDG);
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
           var read = SELECT("SELECT [Номер пропуска], [Фамилия получателя], [Имя получателя], [Отчество получателя], [Дата и время выдачи], Основание, [Фамилия сдавшего], [Имя сдавшего], [Отчество сдавшего], [Дата и время сдачи] FROM [Выдача временных пропусков]", connection);

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
        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SelectHwindow = SelectetdTable.WorkerVisitTable;
        }

        private void TabItem_GotFocus_1(object sender, RoutedEventArgs e)
        {
            this.SelectHwindow = SelectetdTable.VisitorVisTable;
        }
    }
}
