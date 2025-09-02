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
using WpfApp9.Resourses.BugReport;
using WpfApp9.Resourses.MessageWinfow;

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для Administration.xaml
    /// </summary>
    public partial class ChiefSpecialist : Window
    {
        public ChiefSpecialist()
        {
            InitializeComponent();
        }


        private void Ctrl1Executed(object sender, ExecutedRoutedEventArgs e)
        {
            BugReport bugReport = new BugReport();
            bugReport.Show();
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
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    InPrograss inPrograss3 = new InPrograss("Сообщения", "-Данная функция не является задачей альфа версии \n-Для выполнения операции недостаточно ресурсов");
                    inPrograss3.ShowDialog();
                    break;
                case '6':
                    InPrograss inPrograss2 = new InPrograss("Телефонный справочник", "-Данная функция не является задачей альфа версии \n-Для выполнения операции недостаточно ресурсов");
                    inPrograss2.ShowDialog();
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
    }
}
