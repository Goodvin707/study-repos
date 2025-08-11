using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Numerics;
using System.Security.Cryptography;
using System.IO;
using System.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///

    public class SexticEase : EasingFunctionBase
    {
        protected override double EaseInCore(double normalizedTime) => normalizedTime;
        protected override Freezable CreateInstanceCore() => new SexticEase();
    }

    public partial class MainWindow : Window
    {
        RadioButton[] ButtonList = new RadioButton[11];
        Grid[] GridList = new Grid[11];
        Grid Grtemp = new Grid();
        bool[] statusLab = new bool[11];
        bool[] CompliteStatus = new bool[11];
        int IDlab = 0;
        public MainWindow()
        {
            InitializeComponent();

            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;

            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;

            for (int i = 0; i < statusLab.Length; i++)
                statusLab[i] = false;

            CompliteStatus[0] = true;
            CompliteStatus[1] = true;
            CompliteStatus[2] = true;
            CompliteStatus[3] = true;
            CompliteStatus[4] = true;
            CompliteStatus[5] = true;
            CompliteStatus[6] = true;
            CompliteStatus[7] = true;
            CompliteStatus[8] = true;
            CompliteStatus[9] = true;
            CompliteStatus[10] = true;

            ButtonList[0] = l1;
            ButtonList[0].IsChecked = true;
            ButtonList[1] = l2;
            ButtonList[2] = l3;
            ButtonList[3] = l4;
            ButtonList[4] = l5;
            ButtonList[5] = l6;
            ButtonList[6] = l7;
            ButtonList[7] = l8;
            ButtonList[8] = l9;
            ButtonList[9] = l10;
            ButtonList[10] = l11;

            GridList[0] = laboratory_work;
            GridList[1] = laboratory_work2;
            GridList[2] = laboratory_work3;
            GridList[3] = laboratory_work4;
            GridList[4] = laboratory_work5;
            GridList[5] = laboratoryWork_6;
            GridList[6] = laboratory_work7;
            GridList[7] = laboratory_work8;
            GridList[8] = laboratory_work9;
            GridList[9] = laboratory_work10;
            GridList[10] = laboratory_work11;

            grlistfor11.Add(lr111);
            grlistfor11.Add(lr1211);
            grlistfor11.Add(lr121);
            grlistfor11.Add(lr131);
            grlistfor11.Add(lr141);
            grlistfor11.Add(lr1511);
            grlistfor11.Add(lr151);
            grlistfor11.Add(lr161);
            grlistfor11.Add(lr171);
            grlistfor11.Add(lr181);
            grlistfor11.Add(lr191);
            grlistfor11.Add(lr1101);
            grlistfor11.Add(lr1111);
        }
        RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider();
        private void App_Off(object sender, RoutedEventArgs e) => this.Close();

        private void Minimaz(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is ListBox && !e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IDlab++;
            if (IDlab > ButtonList.Length - 1)
                IDlab = 0;
            ButtonList[IDlab].IsChecked = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            IDlab--;
            if (IDlab < 0)
                IDlab = ButtonList.Length - 1;
            ButtonList[IDlab].IsChecked = true;
        }

        public void Move(int hight, int width, int from, int to, double time)
        {
            Grid newLab = new Grid();
            newLab.Margin = new Thickness(0, 100, 0, 0);
            newLab.Height = hight;
            newLab.HorizontalAlignment = HorizontalAlignment.Left;
            newLab.VerticalAlignment = VerticalAlignment.Top;
            newLab.Width = width;

            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();

            if (IDlab == 0)
            {
                if (CompliteStatus[0] == true && IDlab == 0)
                {
                    string imageLocation = "pack://application:,,,/Images/l1.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L1;
            }
            if (IDlab == 1)
            {
                if (CompliteStatus[1] == true && IDlab == 1)
                {
                    string imageLocation = "pack://application:,,,/Images/l2.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L2;
            }
            if (IDlab == 2)
            {
                if (CompliteStatus[2] == true && IDlab == 2)
                {
                    string imageLocation = "pack://application:,,,/Images/l3.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L3;
            }
            if (IDlab == 3)
            {
                if (CompliteStatus[3] == true && IDlab == 3)
                {
                    string imageLocation = "pack://application:,,,/Images/l4.png";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L4;
            }
            if (IDlab == 4)
            {
                if (CompliteStatus[4] == true && IDlab == 4)
                {
                    string imageLocation = "pack://application:,,,/Images/l5.png";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L5;
            }
            if (IDlab == 5)
            {
                if (CompliteStatus[5] == true && IDlab == 5)
                {
                    string imageLocation = "pack://application:,,,/Images/l6.bmp";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L6;
            }
            if (IDlab == 6)
            {
                if (CompliteStatus[6] == true && IDlab == 6)
                {
                    laboratory_work7.Visibility = Visibility.Visible;
                    string imageLocation = "pack://application:,,,/Images/l7.png";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L7;
            }
            if (IDlab == 7)
            {
                if (CompliteStatus[7] == true && IDlab == 7)
                {
                    
                    string imageLocation = "pack://application:,,,/Images/l8.png";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L8;
            }
            if (IDlab == 8)
            {
                if (CompliteStatus[8] == true && IDlab == 8)
                {
                    string imageLocation = "pack://application:,,,/Images/l9.png";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L9;
            }
            if (IDlab == 9)
            {
                if (CompliteStatus[9] == true && IDlab == 9)
                {
                    string imageLocation = "pack://application:,,,/Images/l10.bmp";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L10;
            }
            if (IDlab == 10)
            {
                if (CompliteStatus[10] == true && IDlab == 10)
                {
                    string imageLocation = "pack://application:,,,/Images/l11.png";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                else
                {
                    string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                    image.Source = new BitmapImage(new Uri(imageLocation));
                }
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
                newLab.MouseLeftButtonDown += L11;
            }
            if (CompliteStatus[IDlab] == false)
            {
                string imageLocation = "pack://application:,,,/Images/labInprogress.jpg";
                image.Source = new BitmapImage(new Uri(imageLocation));
                myBrush.ImageSource = image.Source;
                newLab.Background = myBrush;
                Grtemp = newLab;
                mainGrid.Children.Add(newLab);
            }
            TranslateTransform tr = new TranslateTransform();
            newLab.RenderTransform = tr;
            DoubleAnimation anim2X = new DoubleAnimation();
            anim2X.From = from;
            anim2X.To = to;
            anim2X.Duration = TimeSpan.FromSeconds(time);
            anim2X.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.XProperty, anim2X);
        }
        int hi = 229;
        int wi = 646;
        double speed = 0.25;

        private void L1_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 0;
            status.Text = "Лабораторная работа № 1";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L2_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 1;
            status.Text = "Лабораторная работа № 2";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L3_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 2;
            status.Text = "Лабораторная работа № 3";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L4_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 3;
            status.Text = "Лабораторная работа № 4";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L5_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 4;
            status.Text = "Лабораторная работа № 5";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L6_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 5;
            status.Text = "Лабораторная работа № 6";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L7_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 6;
            status.Text = "Лабораторная работа № 7";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L8_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 7;
            status.Text = "Лабораторная работа № 8";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L9_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 8;
            status.Text = "Лабораторная работа № 9";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L10_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 9;
            status.Text = "Лабораторная работа № 10";
            Move(hi, wi, 1000, 277, speed);
        }
        private void L11_Checked(object sender, RoutedEventArgs e)
        {
            IDlab = 10;
            status.Text = "Лабораторная работа № 11";
            Move(hi, wi, 1000, 277, speed);
        }
        Label tempL = new Label();
        bool stst = true;
        private void L1(object sender, RoutedEventArgs e)
        {
            laboratory_work.Visibility = Visibility.Visible;
            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        TextBox textBox2 = new TextBox();
        TextBox textBox4 = new TextBox();
        TextBox textBox6 = new TextBox();
        ListBox s = new ListBox();
        private void L2(object sender, RoutedEventArgs e)
        {
            laboratory_work2.Visibility = Visibility.Visible;
            ListBox listBox = new ListBox();
            listBox.HorizontalAlignment = HorizontalAlignment.Left;
            listBox.VerticalAlignment = VerticalAlignment.Top;
            listBox.Visibility = Visibility.Hidden;
            listBox.Margin = new Thickness(12, 70, 0, 0);
            listBox.Height = 95;
            listBox.Width = 205;
            listBox.SelectionChanged += listBox1_SelectedIndexChanged;
            s = listBox;
            gr1.Children.Add(s);

            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        private void L3(object sender, RoutedEventArgs e)
        {
            laboratory_work3.Visibility = Visibility.Visible;
            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        private void L4(object sender, RoutedEventArgs e)
        {
            laboratory_work4.Visibility = Visibility.Visible;
            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }

        private void L5(object sender, RoutedEventArgs e)
        {
            laboratory_work5.Visibility = Visibility.Visible;
            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        private void L6(object sender, RoutedEventArgs e)
        {
            laboratoryWork_6.Visibility = Visibility.Visible;
            ShifrGrid_LR6.Opacity = 0;
            ShifrGrid_LR6_Copy.Opacity = 0;
            
            if (sts)
            {
                ShifrGrid_LR6_Copy.Visibility = Visibility.Visible;
                ShifrGrid_LR6_Copy.Opacity = 1;
                butKey_LR6_Copy1.Visibility = Visibility.Visible;
            }
            else
            {
                ShifrGrid_LR6_Copy.Visibility = Visibility.Hidden;
                ShifrGrid_LR6_Copy.Opacity = 0;
                butKey_LR6_Copy1.Visibility = Visibility.Hidden;
            }
            if (!sts)
            {
                AnumGridEL4_LR6.Visibility = Visibility.Visible;
                butGen_LR6_Copy.Visibility = Visibility.Visible;

            }
            if (grigshifrlr6)
            {
                ShifrGrid_LR6.Visibility = Visibility.Visible;
                ShifrGrid_LR6.Opacity = 1;
            }
            else
            {
                ShifrGrid_LR6.Visibility = Visibility.Hidden;
                ShifrGrid_LR6.Opacity = 0;
            }

            AnimGrid.Interval = new TimeSpan(0, 0, 0, 0, 50);
            AnimGrid.Tick += new EventHandler(dispatcherTimer_Tick1);

            AnimText1.Interval = new TimeSpan(0, 0, 0, 0, 10);
            AnimText1.Tick += new EventHandler(dispatcherTimer_Tick2);

            OpacityShifr.Interval = new TimeSpan(0, 0, 0, 0, 10);
            OpacityShifr.Tick += new EventHandler(dispatcherTimer_Tick5);

            ShifrGridTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            ShifrGridTimer.Tick += new EventHandler(dispatcherTimer_Tick3);

            ShifrGridTimer2.Interval = new TimeSpan(0, 0, 0, 0, 50);
            ShifrGridTimer2.Tick += new EventHandler(dispatcherTimer_Tick4);

            animationforgrids.Interval = new TimeSpan(0, 0, 0, 0, 50);
            animationforgrids.Tick += new EventHandler(dispatcherTimer_TickForgrids);

            animationforgridsTxt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            animationforgridsTxt.Tick += new EventHandler(dispatcherTimer_TickForgrids2);


            ShifGrid_1.Interval = new TimeSpan(0, 0, 0, 0, 50);
            ShifGrid_1.Tick += new EventHandler(dispatcherTimer_TickOP_);

            OpacityShifr_1.Interval = new TimeSpan(0, 0, 0, 0, 10);
            OpacityShifr_1.Tick += new EventHandler(dispatcherTimer_TickOP);

            timerFor2Shifr_LR6.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timerFor2Shifr_LR6.Tick += new EventHandler(dispatcherTimer_TickShifr2);


            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                laboratoryWork_6.Visibility = Visibility.Visible;
                cl.IsEnabled = true;
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        private void L7(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ID" + IDlab);

                laboratory_work7.Visibility = Visibility.Visible;
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            
        }
        private void L8(object sender, RoutedEventArgs e)
        {

            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                laboratory_work8.Visibility = Visibility.Visible;
                lr8.Visibility = Visibility.Visible;
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        private void L9(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("ку ку епта");
            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                laboratory_work9.Visibility = Visibility.Visible;
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        private void L10(object sender, RoutedEventArgs e)
        {
            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                laboratory_work10.Visibility = Visibility.Visible;
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        private void L11(object sender, RoutedEventArgs e)
        {
            if (CompliteStatus[IDlab] == true && statusLab[IDlab] == false)
            {
                laboratory_work11.Visibility = Visibility.Visible;
                Grtemp.IsEnabled = false;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = 0;
                animY.To = -400;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = true;
            }
        }
        //--------------------------------------------------------------------------+--------------------+----------------------------------------------------------------------------------------
        //                                                                          |       События      |
        //--------------------------------------------------------------------------+--------------------+----------------------------------------------------------------------------------------
        // 1----------------------------------------------------------------
        private void SixVar_Click(object sender, RoutedEventArgs e)
        {
            stst = false;
            double P = Math.Pow(10, -5); // P = 10 ^ -5
            int V = 10 * 30; // V = 10 паролей/день = 10 * 30 = 300 паролей/месяц
            int T = 1; // T = 1 месяц
            double S_ = V * T / P; // Нижняя граница S*
            int PowerA = 128; // (26)a_z  +  (10)0_9  +  (26)A_Z + (33)А_Я + (33)а_я
            double S;
            int l = 0;
            do
            {
                l++;
                S = Math.Pow(PowerA, l);
            } while (S_ >= Math.Pow(PowerA, l));
            temp.Text = "Нижняя граница S* числа всевозможных паролей: " + S_;
            temp.Text += "\r\nМинимальная длина пароля:" + l;
            temp.Text += "\r\nЧисло всевозможных паролей при минимальной длине: " + S;
        }

        private void ElevenVar_Click(object sender, RoutedEventArgs e)
        {
            stst = true;
            double P = Math.Pow(10, -6); // P = 10 ^ -6
            int V = 11 * 20160; // V = 11 паролей/мин * 20160 паролей/мес
            int T = 2; // T = 2 месяц
            double S_ = V * T / P; // Нижняя граница S*
            int PowerA = 62; // (26)a_z  +  (10)0_9  +  (26)A_Z
            double S;
            int l = 0;
            do
            {
                l++;
                S = Math.Pow(PowerA, l);
            } while (S_ >= Math.Pow(PowerA, l));
            temp.Text = "Нижняя граница S* числа всевозможных паролей: " + S_;
            temp.Text += "\r\nМинимальная длина пароля: " + l;
            temp.Text += "\r\nЧисло всевозможных паролей при минимальной длине: " + S;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int L;
            // bool success = int.TryParse(temp2.Text, out L);
            string tem = temp2.Text;
            L = Convert.ToInt32(tem);
            // if (!success)
            //   temp2.Text = "";
            string password = "";
            Random symbol = new Random();
            for (long i = 0; i < L; i++)
            {
                int task = symbol.Next(1, 6);
                switch (task)
                {
                    case 1:
                        password += Convert.ToChar(symbol.Next(65, 91)); // генерация символа A_Z
                        break;
                    case 2:
                        password += Convert.ToChar(symbol.Next(97, 123)); // генерация символа a_z
                        break;
                    case 3:
                        password += Convert.ToChar(symbol.Next(48, 58)); // генерация цифры 0_9
                        break;
                    case 4:
                        password += Convert.ToChar(symbol.Next(1040, 1072)); // генерация символа А_Я
                        break;
                    case 5:
                        password += Convert.ToChar(symbol.Next(1072, 1104)); // генерация символа а_я
                        break;
                }
            }
            temp31.Text = password;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            int M; // длина пароля
            int Q; // какая-то бадяга для пароля
            string id = temp4.Text;
            string pass = "";
            Random symbol = new Random();
            if (stst) // 11-й вариант
            {
                M = 9;
                Q = id.Length % 5;
                for (int i = 1; i <= M; i++)
                {
                    if (i >= 1 && i <= 1 + Q)
                        pass += Convert.ToChar(symbol.Next(33, 43)); // генерация символов из множества {!,”,#,$,%,&,’,(,),*}
                    if (i > 1 + Q && i < 9)
                        pass += Convert.ToChar(symbol.Next(1072, 1104)); // генерация символа а_я
                    if (i == 9)
                        pass += Convert.ToChar(symbol.Next(48, 58)); // генерация цифры 0_9
                }
            }
            else // 6-й вариант
            {
                M = 11;
                Q = id.Length % 8;
                for (int i = 1; i <= M; i++)
                {
                    if (i <= 2) pass += Convert.ToChar(symbol.Next(48, 58)); // генерация цифры 0_9
                    if (i > 2 && i <= 3 + Q) pass += Convert.ToChar(symbol.Next(65, 91)); // генерация символа A_Z
                    if (i > 3 + Q && i <= 11) pass += Convert.ToChar(symbol.Next(33, 43)); // генерация символов из множества {!,”,#,$,%,&,’,(,),*}
                }
            }
            temptext5.Text = pass;
        }

        // 2----------------------------------------------------------------
        private void Button_ClickBuiltSquare(object sender, RoutedEventArgs e)
        {
            int[,] arr51 = {
                { 21, 24, 2, 3,  15},
                { 1, 6, 16, 22, 20},
                { 14,  12, 19, 7, 13},
                {  25,  5, 17, 10, 8},
                { 4, 18, 11, 23, 9}};
            int[,] arr52 = {
                { 2, 18, 1, 23, 21},
                { 12, 25, 5, 4, 19},
                { 16, 9, 15, 14, 11},
                { 13, 3, 24, 17, 8},
                { 22, 10, 20, 7, 6}};
            int[,] arr53 = {
                { 4, 24, 10, 15, 12},
                { 25, 13, 14, 6, 7},
                { 3, 18, 22, 20, 2},
                { 17, 9, 11, 5, 23},
                { 16, 1, 8, 19, 21}};
            int[,] arr61 = {
                { 22, 36,  7,  2,  9, 35},
                { 26, 18, 31, 10,  5, 21},
                { 13, 23, 15, 24, 28,  8},
                { 12,  4, 14, 34, 30, 17},
                {  6,  1, 33, 25, 19, 27},
                { 32, 29, 11, 16, 22, 3}};
            int[,] arr62 = {
                { 18, 28, 3, 12, 15, 35},
                { 32, 11, 14, 17, 4, 33},
                { 20, 9, 24, 13, 16, 29},
                { 21, 27, 10, 25, 23, 5},
                { 1, 30, 34, 8, 31, 7},
                { 19, 6, 26, 36, 22, 2}};
            int[,] arr63 = {
                { 8, 10, 24, 4, 32, 33},
                { 29, 20, 28, 21, 1, 12},
                { 36, 5, 22, 14, 3, 31},
                { 2, 27, 18, 30, 25, 9},
                { 17, 26, 6, 35, 16, 11},
                { 19, 23, 13, 7, 34, 15}};

            List<int[,]> list = new List<int[,]>();
            list.Add(arr51);
            list.Add(arr52);
            list.Add(arr53);
            list.Add(arr61);
            list.Add(arr62);
            list.Add(arr63);
            Button tempB = new Button();
            tempB = (Button)sender;
            int i = Convert.ToInt32(tempB.Name[1].ToString());
            string txt = MagicSquare(EnterWord_LR2.Text, list[i - 1], (int)Math.Sqrt(list[i - 1].Length));
            Globalmatrix = list[i - 1];
            RezultMG_LR2.Text = txt.ToUpper();
        }

        static string MagicSquare(string word, int[,] array, int hight_wight)
        {
            string FinalWord = "";
            for (int i = 0; i < hight_wight; i++)
            {
                for (int j = 0; j < hight_wight; j++)
                {
                    for (int symbol = 0; symbol < word.Length; symbol++)
                    {
                        if (array[i, j] == symbol + 1)
                            FinalWord += word[symbol];
                    }
                }
            }
            return FinalWord;
        }

        private void Button_ClickChooseSquare(object sender, RoutedEventArgs e)
        {
            checkGEN = false;
            NewSq_LR2.Visibility = Visibility.Hidden;
            textBox6.Visibility = Visibility.Hidden;
            if (EnterWord_LR2.Text.Length > 25)
            {
                a1.Visibility = Visibility.Hidden;
                a2.Visibility = Visibility.Hidden;
                a3.Visibility = Visibility.Hidden;
            }
            else
            {
                a1.Visibility = Visibility.Visible;
                a2.Visibility = Visibility.Visible;
                a3.Visibility = Visibility.Visible;
            }
            if (EnterWord_LR2.Text.Length > 36)
            {
                a4.Visibility = Visibility.Hidden;
                a5.Visibility = Visibility.Hidden;
                a6.Visibility = Visibility.Hidden;
            }
            else
            {
                a4.Visibility = Visibility.Visible;
                a5.Visibility = Visibility.Visible;
                a6.Visibility = Visibility.Visible;
            }
        }

        static public int[,] generation_LvL_1_1(int[,] matrix)
        {
            int len = (int)Math.Sqrt(matrix.Length);
            int[,] temp = new int[len, len];
            for (int i = len - 1; i >= 0; i--)
            {
                for (int j = len - 1; j >= 0; j--)
                    temp[len - 1 - i, len - 1 - j] = matrix[j, i];
            }
            return temp;
        }

        static public int[,] generation_LvL_1_2(int[,] matrix)
        {
            int len = (int)Math.Sqrt(matrix.Length);
            int[,] temp = new int[len, len];
            for (int i = 0; i < len; i++)
            {
                for (int j = len - 1; j >= 0; j--)
                    temp[i, j] = matrix[j, i];
            }
            return temp;
        }

        static public int[,] generation_LvL_2_1(int[,] matrix)
        {
            int len = (int)Math.Sqrt(matrix.Length);
            int[,] temp = new int[len, len];
            for (int i = 0; i < len; i++)
            {
                for (int j = len - 1; j >= 0; j--)
                    temp[i, len - 1 - j] = matrix[i, j];
            }
            return temp;
        }

        static public int[,] generation_LvL_2_2(int[,] matrix)
        {
            int len = (int)Math.Sqrt(matrix.Length);
            int[,] temp = new int[len, len];
            for (int i = len - 1; i >= 0; i--)
            {
                for (int j = 0; j < len; j++)
                    temp[len - i - 1, j] = matrix[i, j];
            }
            return temp;
        }

        static public int[,] RandomMatrix(List<int[,]> list)
        {
            Random rand = new Random();
            int ID = rand.Next(0, 6);
            int count = (int)Math.Sqrt(list[ID].Length);

            Random next = new Random();
            int num = next.Next(0, 8);

            if (num == 0 || num == 1)
            {
                Console.WriteLine("1");
                list[ID] = generation_LvL_1_1(list[ID]);
                return list[ID];
            }

            if (num == 2 || num == 3)
            {
                Console.WriteLine("2");
                list[ID] = generation_LvL_1_2(list[ID]);
                return list[ID];
            }

            if (num == 4 || num == 5)
            {
                Console.WriteLine("3");
                list[ID] = generation_LvL_2_1(list[ID]);
                return list[ID];
            }

            if (num == 6 || num == 7)
            {
                Console.WriteLine("4");
                list[ID] = generation_LvL_2_2(list[ID]);
                return list[ID];
            }
            return generation_LvL_2_2(list[ID]);
        }

        int[,] Globalmatrix;
        private void Button_ClickGenSquare(object sender, RoutedEventArgs e)
        {

            a1.Visibility = Visibility.Hidden;
            a2.Visibility = Visibility.Hidden;
            a3.Visibility = Visibility.Hidden;
            a4.Visibility = Visibility.Hidden;
            a5.Visibility = Visibility.Hidden;
            a6.Visibility = Visibility.Hidden;
            NewSq_LR2.Visibility = Visibility.Visible;

            checkGEN = true;
            NewSq_LR2.Text = "";

            int[,] matrix1 =
              {{21,24,2,3,15 },
                {1 ,6,16,22,20},
                {14,12,19,7,13},
                {25,5,17,10,8 },
                {4,18,11,23,9 }};
            int[,] matrix2 =
              { {2,18,1,23,21 },
                {12,25,5,4,19 },
                {16,9,15,14,11 },
                {13,3,24,17,8 },
                {22,10,20,7,6 } };
            int[,] matrix3 =
              { {4,24,10,15,12 },
                {25,13,14,6,7 },
                {3,18,22,20,2 },
                {17,9,11,5,23 },
                {16,1,8,19,21 } };

            int[,] matrix4 =
              { {22,36,7,2,9,35 },
                {26,18,31,10,5,21 },
                {13,23,15,24,28,8 },
                {12,4,14,34,30,17 },
                {6,1,33,25,19,27 },
                {32,29,11,16,20,3 } };
            int[,] matrix5 =
              { {8,10,24,4,32,33 },
                {29,20,28,21,1,12 },
                {36,5,22,14,3,31 },
                {2,27,18,30,25,9 },
                {17,26,6,35,16,11 },
                {19,23,13,7,34,15 } }; ;
            int[,] matrix6 =
              { {18,28,3,12,15,35 },
                {32,11,14,17,4,33 },
                {20,9,24,13,16,29 },
                {21,27,10,25,23,5 },
                {1,30,34,8,31,7   },
                {19,6,26,36,22,2  }};

            List<int[,]> MatrixList = new List<int[,]>();
            MatrixList.Add(matrix1);
            MatrixList.Add(matrix2);
            MatrixList.Add(matrix3);
            MatrixList.Add(matrix4);
            MatrixList.Add(matrix5);
            MatrixList.Add(matrix6);

            int[,] MatrixLis = RandomMatrix(MatrixList);

            for (int j = 0; j < (int)Math.Sqrt(MatrixLis.Length); j++)
            {
                string str = "";
                for (int l = 0; l < (int)Math.Sqrt(MatrixLis.Length); l++)
                    str += MatrixLis[j, l] + "\t";
                str += "\n\n";
                NewSq_LR2.Text += str;
            }
            Globalmatrix = MatrixLis;
            string txt = MagicSquare(EnterWord_LR2.Text, MatrixLis, (int)Math.Sqrt(MatrixLis.Length));
            RezultMG_LR2.Text = txt.ToUpper();
        }
        private void TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            s.Visibility = Visibility.Hidden;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // Метод шиф. табллиц
        {
            RezultSifrMETODtable_LR2.Text = "";
            ShowShifr_LR2.Text = "";
            if (s.SelectedIndex != -1)
            {
                string tabCR = s.SelectedItem.ToString();
                int m = 0, n = 0;
                if (tabCR.Length == 3)
                {
                    m = Convert.ToInt16(tabCR[0].ToString());
                    n = Convert.ToInt16(tabCR[2].ToString());
                }
                else
                {
                    if (tabCR[1] == tabCR[tabCR.IndexOf('x')]) // первое число однозначное
                        m = Convert.ToInt16(tabCR[0].ToString());
                    else // // первое число двузначное
                        m = Convert.ToInt16(tabCR[0].ToString() + tabCR[1].ToString());
                    if (tabCR[tabCR.Length - 2] == tabCR[tabCR.IndexOf('x')]) // второе число однозначное
                        n = Convert.ToInt16(tabCR[tabCR.Length - 1].ToString());
                    else // второе число двузначное
                        n = Convert.ToInt16(tabCR[tabCR.Length - 2].ToString() + tabCR[tabCR.Length - 1].ToString());
                }
                string s1 = EnterWord_LR2.Text.ToUpper();
                int gind = 0;
                char[,] mass = new char[m, n];
                while (s1.Length != mass.Length) // Шифратор-деширатор
                    s1 += " ";
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        mass[j, i] = s1[gind];
                        if (gind == s1.Length - 1)
                            break;
                        gind++;
                    }
                }
                string final = "";
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        ShowShifr_LR2.Text += $"{mass[i, j]} ";
                        final += mass[i, j];
                    }
                    ShowShifr_LR2.Text += "\r\n";
                }
                RezultSifrMETODtable_LR2.Text += final;
            }
            s.Visibility = Visibility.Hidden;
            DeShifr_LR2.Text = EnterWord_LR2.Text;
        }
        private void Button_Click42(object sender, RoutedEventArgs e)
        {
            s.Visibility = Visibility.Hidden;
        }

        bool checkGEN = false;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)//в момент нажатия
        {
            s.Items.Clear();
            List<int> vs = new List<int>();
            if (EnterWord_LR2.Text.Length < 4)
                goto there;
            int x = EnterWord_LR2.Text.Length;
        thisPlace:
            int n = 2;
            while (n != x)
            {
                if (x % n == 0)
                    vs.Add(n);
                n++;
            }
            for (int i = 0; i < vs.Count; i++)
                s.Items.Add(vs[i].ToString() + "x" + (x / vs[i]).ToString());
            if (s.Items.Count == 0)
            {
                x++;
                goto thisPlace;
            }
        there:;
            s.Visibility = Visibility.Visible;

            if (EnterWord_LR2.Text.Length > 25 && !checkGEN)
            {
                a1.Visibility = Visibility.Hidden;
                a2.Visibility = Visibility.Hidden;
                a3.Visibility = Visibility.Hidden;

                a4.Margin = a1.Margin;
                a5.Margin = a2.Margin;
                a6.Margin = a3.Margin;
            }
            else
            {
                a4.Margin = new Thickness(59, 212, 0, 0);
                a5.Margin = new Thickness(209, 212, 0, 0);
                a6.Margin = new Thickness(363, 212, 0, 0);

                a1.Visibility = Visibility.Visible;
                a2.Visibility = Visibility.Visible;
                a3.Visibility = Visibility.Visible;
                a4.Visibility = Visibility.Visible;
                a5.Visibility = Visibility.Visible;
                a6.Visibility = Visibility.Visible;

                if (checkGEN)
                {
                    a1.Visibility = Visibility.Hidden;
                    a2.Visibility = Visibility.Hidden;
                    a3.Visibility = Visibility.Hidden;
                    a4.Visibility = Visibility.Hidden;
                    a5.Visibility = Visibility.Hidden;
                    a6.Visibility = Visibility.Hidden;
                    string txt = MagicSquare(EnterWord_LR2.Text, Globalmatrix, (int)Math.Sqrt(Globalmatrix.Length));
                    RezultMG_LR2.Text = txt;
                }
            }
            if (!checkGEN && EnterWord_LR2.Text.Length > 25 && Globalmatrix.Length == 25)
            {
                RezultMG_LR2.Text = "Несовместимая матрица";
            }
            if (EnterWord_LR2.Text.Length > 36 && !checkGEN)
            {
                a4.Visibility = Visibility.Hidden;
                a5.Visibility = Visibility.Hidden;
                a6.Visibility = Visibility.Hidden;




                RezultMG_LR2.Text = "Введено слишком большое слово";
            }
            else
            {
                a4.Visibility = Visibility.Visible;
                a5.Visibility = Visibility.Visible;
                a6.Visibility = Visibility.Visible;

                if (checkGEN)
                {
                    a1.Visibility = Visibility.Hidden;
                    a2.Visibility = Visibility.Hidden;
                    a3.Visibility = Visibility.Hidden;
                    a4.Visibility = Visibility.Hidden;
                    a5.Visibility = Visibility.Hidden;
                    a6.Visibility = Visibility.Hidden;
                    string txt = MagicSquare(EnterWord_LR2.Text, Globalmatrix, (int)Math.Sqrt(Globalmatrix.Length));
                    RezultMG_LR2.Text = txt.ToUpper();

                    if (EnterWord_LR2.Text.Length > 25 && checkGEN && Globalmatrix.Length == 25)
                        RezultMG_LR2.Text = "Несовместимая матрица";
                    else
                    {
                        if (EnterWord_LR2.Text.Length > 36)
                            RezultMG_LR2.Text = "Неверная длинна слова";
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Help_LR6.Visibility = Visibility.Hidden;
            Help2_LR6.Visibility = Visibility.Hidden;            

            if (statusLab[IDlab] == true && IDlab != 9)
            {

                Grtemp.IsEnabled = true;
                TranslateTransform tr = new TranslateTransform();
                GridList[IDlab].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = -400;
                animY.To = 0;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[IDlab] = false;                
              
            }
            if (statusLab[9] == true && IDlab == 9)
            {
                Console.WriteLine(IDlab + " " + punkt);
                if (punkt == 0)
                {
                    Grtemp.IsEnabled = true;
                    TranslateTransform tr = new TranslateTransform();
                    GridList[9].RenderTransform = tr;
                    DoubleAnimation animY = new DoubleAnimation();
                    animY.From = -400;
                    animY.To = 0;
                    animY.Duration = TimeSpan.FromSeconds(speed);
                    animY.EasingFunction = new SexticEase();
                    tr.BeginAnimation(TranslateTransform.YProperty, animY);
                    statusLab[9] = false;
                }
                
                if (punkt == 1)
                {
                    Grtemp.IsEnabled = true;
                    TranslateTransform tr = new TranslateTransform();
                    GridList[5].RenderTransform = tr;
                    DoubleAnimation animY = new DoubleAnimation();
                    animY.From = -400;
                    animY.To = 0;
                    animY.Duration = TimeSpan.FromSeconds(speed);
                    animY.EasingFunction = new SexticEase();
                    tr.BeginAnimation(TranslateTransform.YProperty, animY);
                    statusLab[5] = false;
                    punkt = 0;
                }
                if(punkt == 2)
                {
                    laboratory_work7.Visibility = Visibility.Visible;
                    Grtemp.IsEnabled = false;
                    TranslateTransform tr = new TranslateTransform();
                    GridList[6].RenderTransform = tr;
                    DoubleAnimation animY = new DoubleAnimation();
                    animY.From = -400;
                    animY.To = 0;
                    animY.Duration = TimeSpan.FromSeconds(speed);
                    animY.EasingFunction = new SexticEase();
                    tr.BeginAnimation(TranslateTransform.YProperty, animY);
                    statusLab[6] = true;
                    punkt = 0;
                }
            }


        }
        int punkt = 0;
        bool creating_LR9 = false;
        bool sts;
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ShowShifr_LR2.Visibility = Visibility.Visible;
            textBox2.Margin = new Thickness(12, 332, 0, 0);
            textBox4.Margin = new Thickness(12, 361, 17, 0);
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowShifr_LR2.Visibility = Visibility.Hidden;
            textBox2.Margin = new Thickness(12, 115, 0, 0);
            textBox4.Margin = new Thickness(12, 144, 17, 0);
        }

        // 3----------------------------------------------------------------
        private void Cezar_Button_LR3_MouseEnter(object sender, MouseEventArgs e)
        {
            Cezar_Button_LR3.Foreground = Brushes.Black;
        }

        private void Cezar_Button_LR3_MouseLeave(object sender, MouseEventArgs e)
        {
            Cezar_Button_LR3.Foreground = Brushes.White;
        }

        private void Trisemus_Button_LR3_MouseEnter(object sender, MouseEventArgs e)
        {
            Trisemus_Button_LR3.Foreground = Brushes.Black;
        }

        private void Trisemus_Button_LR3_MouseLeave(object sender, MouseEventArgs e)
        {
            Trisemus_Button_LR3.Foreground = Brushes.White;
        }

        private void Pleifer_Button_LR3_MouseEnter(object sender, MouseEventArgs e)
        {
            Pleifer_Button_LR3.Foreground = Brushes.Black;
        }

        private void Pleifer_Button_LR3_MouseLeave(object sender, MouseEventArgs e)
        {
            Pleifer_Button_LR3.Foreground = Brushes.White;
        }
        private string IdentificateLenguage(string text)
        {
            string word = text;
            word = word.ToUpper().Replace(" ", "");
            try
            {
                int lanch = Convert.ToInt32(word[0]);
                // 65 - 91 A_Z
                // 1040 - 1072 А_Я
                bool RusLeng = false;
                bool EngLeng = false;

                if (lanch > 64 && lanch < 91) // Eng
                {
                    EngLeng = true;
                }
                else if (lanch > 1039 && lanch < 1072) // Rus
                {
                    RusLeng = true;
                }
                else
                {
                    moment.Text = "Language is not defined";
                    moment.Foreground = Brushes.Red;
                }
                for (int i = 0; i < word.Length; i++)
                {
                    lanch = Convert.ToInt32(word[i]);
                    if (RusLeng)
                    {
                        if (lanch > 1039 && lanch < 1072) // Rus
                        {
                            RusLeng = true;
                            moment.Text = "Rus";
                        }
                        else
                        {
                            RusLeng = false;
                            moment.Text = "Language is not defined";
                            moment.Foreground = Brushes.Red;
                            break;
                        }
                    }
                    else if (EngLeng)
                    {
                        if (lanch > 64 && lanch < 91) // Eng
                        {
                            EngLeng = true;
                            moment.Text = "Eng";
                        }
                        else
                        {
                            EngLeng = false;
                            moment.Text = "Language is not defined";
                            moment.Foreground = Brushes.Red;
                            break;
                        }
                    }
                }
                if (RusLeng) { moment.Foreground = Brushes.White; moment.Text = "Использовать:"; return "Rus"; }
                else if (EngLeng) { moment.Foreground = Brushes.White; moment.Text = "Использовать:"; return "Eng"; }
                else
                {
                    moment.Text = "Language is not defined";
                    moment.Foreground = Brushes.Red;
                }

            }
            catch (Exception)
            {
                moment.Foreground = Brushes.White;
                moment.Text = "Использовать:";
            }
            return "Language is not defined";
        }
        private void CheckLnguge_LR3(object sender, TextChangedEventArgs e)
        {
            IdentificateLenguage(EnterWord_LR3.Text);
            if (moment.Text == "Language is not defined")
            {
                Cezar_Button_LR3.Visibility = Visibility.Hidden;
                Pleifer_Button_LR3.Visibility = Visibility.Hidden;
                Trisemus_Button_LR3.Visibility = Visibility.Hidden;
            }
            else
            {
                Cezar_Button_LR3.Visibility = Visibility.Visible;
                Pleifer_Button_LR3.Visibility = Visibility.Visible;
                Trisemus_Button_LR3.Visibility = Visibility.Visible;
            }

        }
        static string CezarShifr(int k, string s, string lenguage)
        {
            string alfabetUp = "";
            switch (lenguage)
            {
                case "Rus":
                    alfabetUp = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    break;
                case "Eng":
                    alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
            }
            string alfabetLow = alfabetUp.ToLower();
            string itog = "";
            for (int i = 0; i < s.Length; i++)
            {
                // пробел
                if (s[i] == ' ')
                    itog += " ";
                // буква Большая
                if (char.IsUpper(s[i]))
                {
                    for (int j = 0; j < alfabetUp.Length; j++)
                    {
                        if (alfabetUp[j] == s[i])
                            itog += alfabetUp[(alfabetUp.Length + j + k) % alfabetUp.Length];
                    }
                }
                // буква маленькая
                else
                {
                    for (int j = 0; j < alfabetLow.Length; j++)
                    {
                        if (alfabetLow[j] == s[i])
                            itog += alfabetLow[(alfabetLow.Length + j + k) % alfabetLow.Length];
                    }
                }
            }
            return itog;
        }
        static string TrisemusShifr(string s, int a, int b, int c, string menu)
        {
            string alfabetUp = "";
            Console.WriteLine("Выберите язык");
            switch (menu)
            {
                case "Rus": alfabetUp = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,."; break;
                case "Eng": alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ,."; break;
            }
            string alfabetLow = alfabetUp.ToLower();
            Console.WriteLine("Введите сообщение");
            string itog = "";
            Console.WriteLine(s);
            for (int i = 0; i < s.Length; i++)
            {
                int k = a * i * i + b * i + c;
                //int k = a * i + b;
                // не буква
                if (!char.IsLetter(s[i]))
                    itog += s[i];
                // буква Большая
                if (char.IsUpper(s[i]))
                {
                    for (int j = 0; j < alfabetUp.Length; j++)
                    {
                        if (alfabetUp[j] == s[i])
                            itog += alfabetUp[(alfabetUp.Length + j + k) % alfabetUp.Length];
                    }
                }
                // буква маленькая
                else
                {
                    for (int j = 0; j < alfabetLow.Length; j++)
                    {
                        if (alfabetLow[j] == s[i])
                            itog += alfabetLow[(alfabetLow.Length + j + k) % alfabetLow.Length];
                    }
                }
            }
            return itog;
        }
        static string PleyferShifr(string message, string key, string menu)
        {
            if (key == "") { return ""; }
            string alfabetUp = "";
            Console.WriteLine("Выберите язык");

            int n = 0, m = 0;
            switch (menu)
            {
                case "Rus": alfabetUp = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"; n = 4; m = 8; break;
                case "Eng": alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; n = 5; m = 5; break;
            }
            Console.WriteLine("Введите сообщение");

            Console.WriteLine("Введите ключ");
            string itog = "";
            message = message.ToUpper().Replace(" ", "");
            key = key.ToUpper().Replace(" ", "");
            char[,] keyMatrix = new char[n, m];
            string finalKEY = "";
            for (int i = key.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[i] == key[j] && i != j && i > j)
                    {
                        finalKEY += key[j];
                        break;
                    }
                }
            }
            int id = key.Length - 1;
            do
            {
                try
                {
                    if (key[id] == finalKEY[0])


                    {
                        key = key.Remove(id, 1);
                        finalKEY = finalKEY.Remove(0, 1);
                    }
                    id--;
                }
                catch (Exception)
                {

                }
            } while (finalKEY.Length != 0);
            Console.WriteLine(key);

            key = key.ToUpper();
            key += alfabetUp;
            for (int i = key.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[i] == key[j] && i != j && i > j)
                    {
                        finalKEY += key[j];
                        break;
                    }
                }
            }
            id = key.Length - 1;
            do
            {
                try
                {
                    if (key[id] == finalKEY[0])
                    {
                        key = key.Remove(id, 1);
                        finalKEY = finalKEY.Remove(0, 1);
                    }
                }
                catch (Exception) { }
                id--;
            } while (finalKEY.Length != 0);
            Console.WriteLine(key);

            int ids = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    keyMatrix[i, j] = key[ids];
                    Console.Write($"{keyMatrix[i, j]} ");
                    ids++;
                }
                Console.WriteLine();
            }

            List<string> duos = new List<string>();
            string sts = "";
            try
            {
                sts = message[0] + "";
            }
            catch (Exception) { }
            for (int i = 1; i < message.Length; i++)
            {
                if (message[i - 1] == message[i])
                    sts += "X";
                sts += message[i];
            }
            if (sts.Length % 2 != 0) sts += "X";
            Console.WriteLine(sts);

            for (int i = 1; i < sts.Length; i += 2)
            {
                string fg = "";
                fg += sts[i - 1];
                fg += sts[i];
                Console.WriteLine(fg);
                duos.Add(fg);
            }
            for (int i = 0; i < sts.Length / 2; i++)
                Console.Write(duos[i] + "  ");
            Console.WriteLine();

            string duo;
            int indJ1 = 0;
            int indI1 = 0;
            int indJ2 = 0;
            int indI2 = 0;
            for (int id_ = 0; id_ < sts.Length / 2; id_++)
            {
                duo = duos[id_];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (Convert.ToChar(duo[0]) == Convert.ToChar(keyMatrix[i, j]))
                        {
                            indJ1 = j;
                            indI1 = i;
                        }
                        if (Convert.ToString(duo[1]) == Convert.ToString(keyMatrix[i, j]))
                        {
                            indJ2 = j;
                            indI2 = i;
                        }
                    }
                }
                try
                {
                    if (indJ1 == indJ2) // В одном столбце
                    {
                        if (indJ1 == n - 1)
                            itog += keyMatrix[0, indJ1];
                        else
                            itog += keyMatrix[indI1 + 1, indJ1];
                        if (indJ2 == m - 1)
                            itog += keyMatrix[0, indJ2];
                        else
                            itog += keyMatrix[indI2 + 1, indJ2];
                    }
                    if (indI1 == indI2) // В одной строке
                    {
                        if (indJ1 == n - 1)
                            itog += keyMatrix[indI1, 0];
                        else
                            itog += keyMatrix[indI1, indJ1 + 1];
                        if (indJ2 == m - 1)
                            itog += keyMatrix[indI2, 0];
                        else
                            itog += keyMatrix[indI2, indJ2 + 1];
                    }
                    if (indJ1 != indJ2 && indI1 != indI2) // Образуют прямоугольник
                    {
                        itog += keyMatrix[indI1, indJ2];
                        itog += keyMatrix[indI2, indJ1];
                    }
                }
                catch (Exception) { }
            }
            return itog;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void ShowShifr_LR2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UseCezar_LR3(object sender, RoutedEventArgs e)
        {
            Cezar_LR3.Visibility = Visibility.Visible;
            Pleifer_LR3.Visibility = Visibility.Hidden;
            Trisemus_LR3.Visibility = Visibility.Hidden;
            Cezar_EnterWord_LR3.Text = EnterWord_LR3.Text;
        }

        private void UseTrisemus_LR3(object sender, RoutedEventArgs e)
        {
            Cezar_LR3.Visibility = Visibility.Hidden;
            Pleifer_LR3.Visibility = Visibility.Hidden;
            Trisemus_LR3.Visibility = Visibility.Visible;
            Trisemus_EnterWord_LR3.Text = EnterWord_LR3.Text;
        }

        private void UsePleifer_LR3(object sender, RoutedEventArgs e)
        {
            Cezar_LR3.Visibility = Visibility.Hidden;
            Pleifer_LR3.Visibility = Visibility.Visible;
            Trisemus_LR3.Visibility = Visibility.Hidden;
            Pleifer_EnterWord_LR3.Text = EnterWord_LR3.Text;
        }

        private void returnTOmain_LR3(object sender, RoutedEventArgs e)
        {
            Cezar_LR3.Visibility = Visibility.Hidden;
            Pleifer_LR3.Visibility = Visibility.Hidden;
            Trisemus_LR3.Visibility = Visibility.Hidden;
        }
        // События 3 лабы Для Цезаря
        private void ReloadText_Cezar_LR3(object sender, TextChangedEventArgs e)
        {
            try { Cezar_Shifr_LR3.Text = CezarShifr(Convert.ToInt32(Cezar_RunPoint_LR3.Text), Cezar_EnterWord_LR3.Text, IdentificateLenguage(Cezar_EnterWord_LR3.Text)); } catch (Exception) { };
            Cezar_DEsifr_LR3.Text = Cezar_EnterWord_LR3.Text;
            if (Cezar_Shifr_LR3.Text == "")
            {
                Cezar_DEsifr_LR3.Text = "";
            }
            EnterWord_LR3.Text = Cezar_EnterWord_LR3.Text;
        }
        private void RedactEnterWord_LR3(object sender, RoutedEventArgs e)
        {
            Cezar_EnterWord_LR3.IsReadOnly = false;
        }
        private void IsRead_Cezar_LR3(object sender, MouseButtonEventArgs e)
        {
            Cezar_EnterWord_LR3.IsReadOnly = true;
        }
        private void UPrun_Cezar_LR3(object sender, RoutedEventArgs e)
        {
            Cezar_RunPoint_LR3.Text = (Convert.ToInt32(Cezar_RunPoint_LR3.Text) + 1).ToString();
            Cezar_Shifr_LR3.Text = CezarShifr(Convert.ToInt32(Cezar_RunPoint_LR3.Text), Cezar_EnterWord_LR3.Text, IdentificateLenguage(Cezar_EnterWord_LR3.Text));
            Cezar_DEsifr_LR3.Text = Cezar_EnterWord_LR3.Text;
        }
        private void DOWNrun_Cezar_LR3(object sender, RoutedEventArgs e)
        {
            Cezar_RunPoint_LR3.Text = (Convert.ToInt32(Cezar_RunPoint_LR3.Text) - 1).ToString();
            // if (Convert.ToInt32(Cezar_RunPoint_LR3.Text) < 0)
            // Cezar_RunPoint_LR3.Text = (Convert.ToInt32(Cezar_RunPoint_LR3.Text) + 1).ToString();
            Cezar_Shifr_LR3.Text = CezarShifr(Convert.ToInt32(Cezar_RunPoint_LR3.Text), Cezar_EnterWord_LR3.Text, IdentificateLenguage(Cezar_EnterWord_LR3.Text));
            Cezar_DEsifr_LR3.Text = Cezar_EnterWord_LR3.Text;
        }

        // События 3 лабы Для Трисемуса
        private void ReloadText_Trisemus_LR3(object sender, TextChangedEventArgs e)
        {
            Trisemus_Shifr_LR3.Text = TrisemusShifr(Trisemus_EnterWord_LR3.Text, Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text), IdentificateLenguage(Trisemus_EnterWord_LR3.Text));
            Trisemus_DEsifr_LR3.Text = Trisemus_EnterWord_LR3.Text;
            if (Trisemus_Shifr_LR3.Text == "")
            {
                Trisemus_DEsifr_LR3.Text = "";
            }
            if (IdentificateLenguage(Trisemus_EnterWord_LR3.Text) == "Language is not defined")
            {
                Trisemus_Shifr_LR3.Text = "";
                Trisemus_DEsifr_LR3.Text = "";
            }
            EnterWord_LR3.Text = Trisemus_EnterWord_LR3.Text;
        }
        private void RedactEnterWord_Trisemus_LR3(object sender, RoutedEventArgs e)
        {
            Trisemus_EnterWord_LR3.IsReadOnly = false;
        }
        private void reloatShifr_LR3(object sender, TextChangedEventArgs e)
        {

        }
        private void KeyAup_LR3(object sender, RoutedEventArgs e)
        {
            Trisemus_RunPoint_LR3_1.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text) + 1).ToString();
            Trisemus_Shifr_LR3.Text = TrisemusShifr(Trisemus_EnterWord_LR3.Text, Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text), IdentificateLenguage(Trisemus_EnterWord_LR3.Text));
        }
        private void KeyAdown_LR3(object sender, RoutedEventArgs e)
        {
            Trisemus_RunPoint_LR3_1.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text) - 1).ToString();
            //      if (Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text) < 0)
            //         Trisemus_RunPoint_LR3_1.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text) + 1).ToString();
            Trisemus_Shifr_LR3.Text = TrisemusShifr(Trisemus_EnterWord_LR3.Text, Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text), IdentificateLenguage(Trisemus_EnterWord_LR3.Text));
        }
        private void KeyBup_LR3(object sender, RoutedEventArgs e)
        {
            Trisemus_RunPoint_LR3_2.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text) + 1).ToString();
            Trisemus_Shifr_LR3.Text = TrisemusShifr(Trisemus_EnterWord_LR3.Text, Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text), IdentificateLenguage(Trisemus_EnterWord_LR3.Text));
        }
        private void KeyBdown_LR3(object sender, RoutedEventArgs e)
        {
            Trisemus_RunPoint_LR3_2.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text) - 1).ToString();
            //    if (Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text) < 0)
            //        Trisemus_RunPoint_LR3_2.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text) + 1).ToString();
            Trisemus_Shifr_LR3.Text = TrisemusShifr(Trisemus_EnterWord_LR3.Text, Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text), IdentificateLenguage(Trisemus_EnterWord_LR3.Text));
        }
        private void KeyCup_LR3(object sender, RoutedEventArgs e)
        {
            Trisemus_RunPoint_LR3_3.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text) + 1).ToString();
            Trisemus_Shifr_LR3.Text = TrisemusShifr(Trisemus_EnterWord_LR3.Text, Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text), IdentificateLenguage(Trisemus_EnterWord_LR3.Text));
        }
        private void KeyCdown_LR3(object sender, RoutedEventArgs e)
        {
            Trisemus_RunPoint_LR3_3.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text) - 1).ToString();
            //   if (Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text) < 0)
            //      Trisemus_RunPoint_LR3_3.Text = (Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text) + 1).ToString();
            Trisemus_Shifr_LR3.Text = TrisemusShifr(Trisemus_EnterWord_LR3.Text, Convert.ToInt32(Trisemus_RunPoint_LR3_1.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_2.Text), Convert.ToInt32(Trisemus_RunPoint_LR3_3.Text), IdentificateLenguage(Trisemus_EnterWord_LR3.Text));
        }
        private void IsRead_Trisemus_LR3(object sender, MouseButtonEventArgs e)
        {
            Trisemus_EnterWord_LR3.IsReadOnly = true;
        }

        // События 3 лабы Для Плейфера
        private void ReloadInfo_Pleifer_LR3(object sender, TextChangedEventArgs e)
        {
            Pleifer_DEshifr_LR3.Text = Pleifer_EnterWord_LR3.Text;
            Pleifer_Shifr_LR3.Text = PleyferShifr(Pleifer_EnterWord_LR3.Text, Pleifer_Key_LR3.Text, IdentificateLenguage(Pleifer_EnterWord_LR3.Text));
            if (Pleifer_Shifr_LR3.Text == "")
                Pleifer_DEshifr_LR3.Text = "";
            if (IdentificateLenguage(Pleifer_EnterWord_LR3.Text) != IdentificateLenguage(Pleifer_Shifr_LR3.Text))
                Pleifer_Shifr_LR3.Text = "";
            if (IdentificateLenguage(Pleifer_Shifr_LR3.Text) == "Language is not defined")
                Pleifer_DEshifr_LR3.Text = "";
            EnterWord_LR3.Text = Pleifer_EnterWord_LR3.Text;
        }
        private void RedactEnterWord_Pleifer_LR3(object sender, RoutedEventArgs e)
        {
            Pleifer_EnterWord_LR3.IsReadOnly = false;
        }
        private void ReloadSifrFromKey_LR3(object sender, TextChangedEventArgs e)
        {
            Pleifer_Shifr_LR3.Text = PleyferShifr(Pleifer_EnterWord_LR3.Text, Pleifer_Key_LR3.Text, IdentificateLenguage(Pleifer_EnterWord_LR3.Text));
            Pleifer_DEshifr_LR3.Text = Pleifer_EnterWord_LR3.Text;
            if (IdentificateLenguage(Pleifer_Key_LR3.Text) == "Language is not defined")
            {
                Pleifer_Shifr_LR3.Text = "";
                Pleifer_DEshifr_LR3.Text = "";
            }
            if (IdentificateLenguage(Pleifer_Key_LR3.Text) != IdentificateLenguage(Pleifer_EnterWord_LR3.Text))
                Pleifer_DEshifr_LR3.Text = "";
        }
        private void IsRead_Pleifer_LR3(object sender, MouseButtonEventArgs e)
        {
            Pleifer_EnterWord_LR3.IsReadOnly = true;
        }

        // 4----------------------------------------------------------------
        // События 4 лабы для 1-го задания
        private void RandomNumber_LR4(object sender, RoutedEventArgs e)
        {
            Game_LR4.Margin = new Thickness(39, 345, 0, 0);
            Rand_LR4.Visibility = Visibility.Hidden;
            Game_LR4.Visibility = Visibility.Visible;
            R_but1_LR4.Visibility = Visibility.Visible;
            txtOt_LR4.Visibility = Visibility.Visible;
            R_but2_LR4.Visibility = Visibility.Visible;
            R_but3_LR4.Visibility = Visibility.Visible;
            R_but4_LR4.Visibility = Visibility.Visible;
            R_but5_LR4.Visibility = Visibility.Visible;
            R_but6_LR4.Visibility = Visibility.Visible;
            Rand_From_LR4.Visibility = Visibility.Visible;
            Rand_To_LR4.Visibility = Visibility.Visible;
            txtDo_LR4.Visibility = Visibility.Visible;
            txtDo_LR4.Visibility = Visibility.Visible;
            txtGenNum_LR4.Visibility = Visibility.Visible;
            num1_LR4.Visibility = Visibility.Visible;
            num2_LR4.Visibility = Visibility.Visible;
            num3_LR4.Visibility = Visibility.Visible;
            num4_LR4.Visibility = Visibility.Visible;
            num5_LR4.Visibility = Visibility.Visible;
            num6_LR4.Visibility = Visibility.Visible;
            num7_LR4.Visibility = Visibility.Visible;
            num8_LR4.Visibility = Visibility.Visible;
            num9_LR4.Visibility = Visibility.Visible;
            num10_LR4.Visibility = Visibility.Visible;
            txtnum1.Visibility = Visibility.Visible;
            txtnum2.Visibility = Visibility.Visible;
            txtnum3.Visibility = Visibility.Visible;
            txtnum4.Visibility = Visibility.Visible;
            txtnum5.Visibility = Visibility.Visible;
            txtnum6.Visibility = Visibility.Visible;
            txtnum7.Visibility = Visibility.Visible;
            txtnum8.Visibility = Visibility.Visible;
            txtnum9.Visibility = Visibility.Visible;
            txtnum10.Visibility = Visibility.Visible;
            EnterNumber_LR4.Visibility = Visibility.Hidden;
            But_LR4.Visibility = Visibility.Hidden;
            cow.Visibility = Visibility.Hidden;
            cow2.Visibility = Visibility.Hidden;
            bul.Visibility = Visibility.Hidden;
            bul2.Visibility = Visibility.Hidden;
            Console.WriteLine(Number);
        }
        int Number;
        private void R_but1_LR4_Checked(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            num1_LR4.Text = r.Next(3, 13).ToString();
            num2_LR4.Text = r.Next(3, 13).ToString();
            num3_LR4.Text = r.Next(3, 13).ToString();
            num4_LR4.Text = r.Next(3, 13).ToString();
            num5_LR4.Text = r.Next(3, 13).ToString();
            num6_LR4.Text = r.Next(3, 13).ToString();
            num7_LR4.Text = r.Next(3, 13).ToString();
            num8_LR4.Text = r.Next(3, 13).ToString();
            num9_LR4.Text = r.Next(3, 13).ToString();
            num10_LR4.Text = r.Next(3, 13).ToString();
        }

        private void R_but2_LR4_Checked(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int[] set = { -3, 0, 6, 9, 12, 15 };
            num1_LR4.Text = set[r.Next(0, 6)].ToString();
            num2_LR4.Text = set[r.Next(0, 6)].ToString();
            num3_LR4.Text = set[r.Next(0, 6)].ToString();
            num4_LR4.Text = set[r.Next(0, 6)].ToString();
            num5_LR4.Text = set[r.Next(0, 6)].ToString();
            num6_LR4.Text = set[r.Next(0, 6)].ToString();
            num7_LR4.Text = set[r.Next(0, 6)].ToString();
            num8_LR4.Text = set[r.Next(0, 6)].ToString();
            num9_LR4.Text = set[r.Next(0, 6)].ToString();
            num10_LR4.Text = set[r.Next(0, 6)].ToString();
        }

        private void R_but3_LR4_Checked(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            double[] b = { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };
            double n = r.Next(3, 13);
            if (n == 12)
                num1_LR4.Text = "12";
            else
                num1_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num2_LR4.Text = "12";
            else
                num2_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num3_LR4.Text = "12";
            else
                num3_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num4_LR4.Text = "12";
            else
                num4_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num5_LR4.Text = "12";
            else
                num5_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num6_LR4.Text = "12";
            else
                num6_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num7_LR4.Text = "12";
            else
                num7_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num8_LR4.Text = "12";
            else
                num8_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num9_LR4.Text = "12";
            else
                num9_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
            n = r.Next(3, 13);
            if (n == 12)
                num10_LR4.Text = "12";
            else
                num10_LR4.Text = (n + b[r.Next(0, b.Length)]).ToString();
        }

        private void R_but4_LR4_Checked(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            double[] arr = new double[131];
            int count = 0;
            for (double i = -2.3; i < 10.7; i += 0.1)
                arr[count++] = Math.Round(i, 1);
            num1_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num2_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num3_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num4_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num5_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num6_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num7_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num8_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num9_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
            num10_LR4.Text = arr[r.Next(0, arr.Length)].ToString();
        }

        private void R_but5_LR4_Checked(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int[] set = { -30, 10, 63, 59, 120, 175 };
            num1_LR4.Text = set[r.Next(0, 6)].ToString();
            num2_LR4.Text = set[r.Next(0, 6)].ToString();
            num3_LR4.Text = set[r.Next(0, 6)].ToString();
            num4_LR4.Text = set[r.Next(0, 6)].ToString();
            num5_LR4.Text = set[r.Next(0, 6)].ToString();
            num6_LR4.Text = set[r.Next(0, 6)].ToString();
            num7_LR4.Text = set[r.Next(0, 6)].ToString();
            num8_LR4.Text = set[r.Next(0, 6)].ToString();
            num9_LR4.Text = set[r.Next(0, 6)].ToString();
            num10_LR4.Text = set[r.Next(0, 6)].ToString();
        }

        private void R_but6_LR4_Checked(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            double[] set = new double[16];
            for (int i = 0; i < set.Length; i++)
                set[i] = Math.Pow(10, -i);
            num1_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num2_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num3_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num4_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num5_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num6_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num7_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num8_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num9_LR4.Text = set[r.Next(0, set.Length)].ToString();
            num10_LR4.Text = set[r.Next(0, set.Length)].ToString();
        }

        // События 4 лабы для 2-го задания
        private void StartGame_LR4(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Number = random.Next(1000, 10000);
            Rand_LR4.Margin = new Thickness(39, 345, 0, 0);
            Rand_LR4.Visibility = Visibility.Visible;
            EnterNumber_LR4.Visibility = Visibility.Visible;
            But_LR4.Visibility = Visibility.Visible;
            cow.Visibility = Visibility.Visible;
            cow2.Visibility = Visibility.Visible;
            bul.Visibility = Visibility.Visible;
            bul2.Visibility = Visibility.Visible;
            Game_LR4.Visibility = Visibility.Hidden;
            txtOt_LR4.Visibility = Visibility.Hidden;
            R_but1_LR4.Visibility = Visibility.Hidden;
            R_but2_LR4.Visibility = Visibility.Hidden;
            R_but3_LR4.Visibility = Visibility.Hidden;
            R_but4_LR4.Visibility = Visibility.Hidden;
            R_but5_LR4.Visibility = Visibility.Hidden;
            R_but6_LR4.Visibility = Visibility.Hidden;
            Rand_From_LR4.Visibility = Visibility.Hidden;
            Rand_To_LR4.Visibility = Visibility.Hidden;
            txtDo_LR4.Visibility = Visibility.Hidden;
            txtDo_LR4.Visibility = Visibility.Hidden;
            txtGenNum_LR4.Visibility = Visibility.Hidden;
            num1_LR4.Visibility = Visibility.Hidden;
            num2_LR4.Visibility = Visibility.Hidden;
            num3_LR4.Visibility = Visibility.Hidden;
            num4_LR4.Visibility = Visibility.Hidden;
            num5_LR4.Visibility = Visibility.Hidden;
            num6_LR4.Visibility = Visibility.Hidden;
            num7_LR4.Visibility = Visibility.Hidden;
            num8_LR4.Visibility = Visibility.Hidden;
            num9_LR4.Visibility = Visibility.Hidden;
            num10_LR4.Visibility = Visibility.Hidden;
            txtnum1.Visibility = Visibility.Hidden;
            txtnum2.Visibility = Visibility.Hidden;
            txtnum3.Visibility = Visibility.Hidden;
            txtnum4.Visibility = Visibility.Hidden;
            txtnum5.Visibility = Visibility.Hidden;
            txtnum6.Visibility = Visibility.Hidden;
            txtnum7.Visibility = Visibility.Hidden;
            txtnum8.Visibility = Visibility.Hidden;
            txtnum9.Visibility = Visibility.Hidden;
            txtnum10.Visibility = Visibility.Hidden;
        }

        private void Gen_From_LR4(object sender, TextChangedEventArgs e)
        {
            try
            {
                Random random = new Random();
                if (Rand_To_LR4.Text != "")
                {
                    num1_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num2_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num3_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num4_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num5_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num6_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num7_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num8_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num9_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num10_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                }
            }
            catch (FormatException) { }
        }

        private void Gen_To_LR4(object sender, TextChangedEventArgs e)
        {
            Random random = new Random();
            try
            {
                if (Rand_From_LR4.Text != "")
                {
                    num1_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num2_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num3_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num4_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num5_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num6_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num7_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num8_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num9_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                    num10_LR4.Text = Math.Round(random.NextDouble() * (Convert.ToDouble(Rand_From_LR4.Text) + Convert.ToDouble(Rand_To_LR4.Text)), 3).ToString();
                }
            }
            catch (FormatException) { }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            bool gameStatus = true;
            string Stado = Number.ToString();

            int countCows = 4, countBuls = 0; try
            {
                for (int i = 0; i < Stado.Length; i++)
                {
                    if (Stado[i] == EnterNumber[i] && EnterNumber.Length == 4)
                        countBuls++; // кол - во быков
                    Console.WriteLine(Stado[i] + "    " + EnterNumber[i]);
                }
            }
            catch (Exception) { }
            countCows -= countBuls; //кол- во коров
            cow.Text = countCows.ToString();
            bul.Text = countBuls.ToString();
            if (countBuls == 4)
                gameStatus = false;
            if (!gameStatus) { }
        }
        string EnterNumber;
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            EnterNumber = EnterNumber_LR4.Text;
        }
        //-----------лр5--------------------------
        string language_LR5;
        private void EnterMessage_LR5_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = EnterMessage_LR5.Text.ToUpper().Replace(" ", "");
            string alfabetUp;
            b_lr5l.IsEnabled = true;
            char[,] km;
            int gind = 0;
            AlfTable_LR5.Text = "";
            if (EnterMessage_LR5.Text == "")
            {
                b_lr5l.IsEnabled = false;
                ListOfMatrixes_LR5.Items.Clear();
                FKey_LR5.Clear();
                SKey_LR5.Clear();

                Stage1_LR5.Text = "Здесь будет отображена последовательность шифрования";
                Stage2_LR5.Text = "";
                ErDefMessage_LR5.Content = "";
                ShowHow_LR5.Text = "";
                goto skipThis;
            }
            string entmsUp = EnterMessage_LR5.Text.ToUpper().Replace(" ", "");
            int fint;
            try { fint = Convert.ToInt32(entmsUp[0]); }
            catch (IndexOutOfRangeException) { goto skipThis; }
            if (fint > 64 && fint < 91) // Eng
            {
                for (int i = 0; i < entmsUp.Length; i++)
                {
                    if (Convert.ToInt32(entmsUp[i]) <= 64 || Convert.ToInt32(entmsUp[i]) >= 91)
                    {
                        language_LR5 = "None";
                        ErDefMessage_LR5.Content = "Язык не определён";
                        ErDefMessage_LR5.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFDE2E2E");
                        ListOfMatrixes_LR5.Items.Clear();
                        b_lr5l.IsEnabled = false;
                        goto skipThis;
                    }
                }
                language_LR5 = "Eng";
                ErDefMessage_LR5.Content = "Английский";
                ErDefMessage_LR5.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF4CB965");

                alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                gind = 0;
                AlfTable_LR5.Text += "    ";
                for (int i = 0; i < 5; i++)
                    AlfTable_LR5.Text += i + 1 + "   ";
                AlfTable_LR5.Text += "\n";
                for (int i = 0; i < 5; i++)
                {
                    AlfTable_LR5.Text += i + 1 + "  ";
                    for (int j = 0; j < 5; j++)
                    {
                        if (alfabetUp[gind] == 'H')
                            AlfTable_LR5.Text += alfabetUp[gind] + "  ";
                        else
                        {
                            if (alfabetUp[gind] != 'I')
                                AlfTable_LR5.Text += alfabetUp[gind] + "   ";
                            else
                            {
                                AlfTable_LR5.Text += alfabetUp[gind] + "/";
                                j--;
                            }
                        }
                        gind++;
                    }
                    AlfTable_LR5.Text += "\n";
                }
            }
            else if (fint > 1039 && fint < 1072) // Rus
            {
                for (int i = 0; i < entmsUp.Length; i++)
                {
                    if (Convert.ToInt32(entmsUp[i]) <= 1039 || Convert.ToInt32(entmsUp[i]) >= 1072)
                    {
                        language_LR5 = "None";
                        ErDefMessage_LR5.Content = "Язык не определён";
                        ErDefMessage_LR5.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFDE2E2E");
                        ListOfMatrixes_LR5.Items.Clear();
                        b_lr5l.IsEnabled = false;
                        goto skipThis;
                    }
                }
                language_LR5 = "Rus";
                ErDefMessage_LR5.Content = "Русский";
                ErDefMessage_LR5.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF4CB965");

                alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ,-:";
                gind = 0;
                AlfTable_LR5.Text += "  ";
                for (int i = 0; i < 6; i++)
                    AlfTable_LR5.Text += "   " + (i + 1);
                AlfTable_LR5.Text += "\n";
                for (int i = 0; i < 6; i++)
                {
                    AlfTable_LR5.Text += i + 1 + "  ";
                    for (int j = 0; j < 6; j++)
                    {
                        if (alfabetUp[gind] == 'Ж' || alfabetUp[gind] == 'Л' || alfabetUp[gind] == 'Ш' || alfabetUp[gind] == 'Щ' || alfabetUp[gind] == 'М' || alfabetUp[gind] == 'И' || alfabetUp[gind] == 'Ч')
                            AlfTable_LR5.Text += alfabetUp[gind] + "  ";
                        else
                            AlfTable_LR5.Text += alfabetUp[gind] + "   ";
                        gind++;
                    }
                    AlfTable_LR5.Text += "\n";
                }
            }
            else
            {
                language_LR5 = "None";
                ErDefMessage_LR5.Content = "Язык не определён";
                ErDefMessage_LR5.Foreground = (Brush)new BrushConverter().ConvertFrom("#FFDE2E2E");
                ListOfMatrixes_LR5.Items.Clear();
                b_lr5l.IsEnabled = false;
                goto skipThis;
            }


            ListOfMatrixes_LR5.Items.Clear();
            List<int> vs = new List<int>();
            if (s.Length < 8)
                goto alitDown;
            int x = s.Length;
        thisPlace:
            int p = 2;
            while (p != x)
            {
                if (x % p == 0)
                    vs.Add(p);
                p++;
            }
            for (int i = 0; i < vs.Count; i++)
                ListOfMatrixes_LR5.Items.Add(vs[i].ToString() + "x" + (x / vs[i]).ToString());
            if (ListOfMatrixes_LR5.Items.Count == 0)
            {
                x++;
                goto thisPlace;
            }


        alitDown:
            gind = 0;
            switch (language_LR5)
            {
                case "Rus":
                    alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ,-:";
                    km = new char[6, 6];
                    for (int i = 0; i < km.GetLength(0); i++)
                    {
                        for (int j = 0; j < km.GetLength(1); j++)
                        {
                            km[i, j] = alfabetUp[gind];
                            gind++;
                        }
                    }
                    s = s.ToUpper();
                    break;
                case "Eng":
                    alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    km = new char[5, 5];
                    gind = 0;
                    for (int i = 0; i < km.GetLength(0); i++)
                    {
                        for (int j = 0; j < km.GetLength(1); j++)
                        {
                            km[i, j] = alfabetUp[gind];
                            if (alfabetUp[gind] == 'I')
                                j--;
                            gind++;
                        }
                    }
                    s = s.ToUpper().Replace(" ", "").Replace("I", "J");
                    break;
                default:
                    km = new char[5, 5];
                    break;
            }

            Stage1_LR5.Text = "";
            Stage2_LR5.Text = "";
            for (int i = 0; i < s.Length; i++)
                Stage1_LR5.Text += s[i] + " ";
            Stage1_LR5.Text += "\n";

            string strcoords = "";
            for (int k = 0; k < s.Length; k++)
            {
                for (int i = 0; i < km.GetLength(0); i++)
                {
                    for (int j = 0; j < km.GetLength(1); j++)
                    {
                        if (s[k] == km[i, j])
                        {
                            Stage1_LR5.Text += j + 1 + " ";
                            strcoords += j;
                        }
                    }
                }
            }
            Stage1_LR5.Text += "\n";
            for (int k = 0; k < s.Length; k++)
            {
                for (int i = 0; i < km.GetLength(0); i++)
                {
                    for (int j = 0; j < km.GetLength(1); j++)
                    {
                        if (s[k] == km[i, j])
                        {
                            Stage1_LR5.Text += i + 1 + " ";
                            strcoords += i;
                        }
                    }
                }
            }
            Stage1_LR5.Text += "\n";
            for (int i = 1; i < strcoords.Length; i += 2)
                Stage1_LR5.Text += (Convert.ToInt32(strcoords[i - 1].ToString()) + 1).ToString() + "" + (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            for (int i = 0; i < strcoords.Length; i += 2)
                Stage2_LR5.Text += (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            Stage2_LR5.Text += "\n";
            for (int i = 1; i < strcoords.Length; i += 2)
                Stage2_LR5.Text += (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            string result = "";
            for (int i = 1; i < strcoords.Length; i += 2)
                result += km[Convert.ToInt32(strcoords[i].ToString()), Convert.ToInt32(strcoords[i - 1].ToString())] + " ";
            Stage2_LR5.Text += "\n" + result;
            Shifr_LR5_Copy.Text = result;
            Deshifr_LR5_Copy.Text = s;
        skipThis:;
        }
        int Rows_LR5 = 0, Columns_LR5 = 0;
        private void ListOfMatrixes_LR5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListOfMatrixes_LR5.SelectedIndex != -1)
            {
                FKey_LR5.Text = "";
                SKey_LR5.Text = "";
                FKey_LR5.IsEnabled = true;
                SKey_LR5.IsEnabled = true;
                string tabCR = ListOfMatrixes_LR5.SelectedItem.ToString();
                if (tabCR.Length == 3)
                {
                    Rows_LR5 = Convert.ToInt16(tabCR[0].ToString());
                    Columns_LR5 = Convert.ToInt16(tabCR[2].ToString());
                }
                else
                {
                    if (tabCR[1] == tabCR[tabCR.IndexOf('x')]) // первое число однозначное
                        Rows_LR5 = Convert.ToInt16(tabCR[0].ToString());
                    else // первое число двузначное
                        Rows_LR5 = Convert.ToInt16(tabCR[0].ToString() + tabCR[1].ToString());
                    if (tabCR[tabCR.Length - 2] == tabCR[tabCR.IndexOf('x')]) // второе число однозначное
                        Columns_LR5 = Convert.ToInt16(tabCR[tabCR.Length - 1].ToString());
                    else // второе число двузначное
                        Columns_LR5 = Convert.ToInt16(tabCR[tabCR.Length - 2].ToString() + tabCR[tabCR.Length - 1].ToString());
                }
                FKey_LR5.MaxLength = Columns_LR5;
                SKey_LR5.MaxLength = Rows_LR5;
            }
            else
            {
                FKey_LR5.Text = "";
                SKey_LR5.Text = "";
                FKey_LR5.IsEnabled = false;
                SKey_LR5.IsEnabled = false;
                Accept_LR5.IsEnabled = false;
            }
        }
        static int[] ConvertToNum(int CR_LR5, string alfabetUp, string Key)
        {
            int[] arr = new int[CR_LR5];
            int gind = 0;
            for (int i = 0; i < alfabetUp.Length; i++)
            {
                for (int j = 0; j < Key.Length; j++)
                {
                    if (alfabetUp[i] == Key[j])
                    {
                        arr[j] = gind;
                        if (gind == arr.Length - 1)
                            break;
                        gind++;
                    }
                }
            }
            return arr;
        }
        private void Accept_LR5_Click(object sender, RoutedEventArgs e)
        {
            ShowHow_LR5.Foreground = Brushes.Black;
            ShowHow_LR5.TextWrapping = TextWrapping.NoWrap;
            string alfabetUp = "";
            switch (language_LR5)
            {
                case "Eng":
                    alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
                case "Rus":
                    alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    break;
                case "None":
                    goto skipThisShit;
            }
            string s = EnterMessage_LR5.Text.ToUpper().Replace(" ", ""); // "Терминатор прибывает седьмого в полночь"
            string firstKey = FKey_LR5.Text.ToUpper().Replace(" ", ""); // длина ключа должна быть строго равна Rows_LR5
            string secondKey = SKey_LR5.Text.ToUpper().Replace(" ", ""); // длина ключа должна быть строго равна Columns_LR5
            string itog = "";
            char[,] table = new char[Rows_LR5, Columns_LR5];
            int gind = 0;

            if (WriteByRows_LR5.IsChecked == true)
            {
                for (int i = 0; i < Rows_LR5; i++) // строки
                {
                    for (int j = 0; j < Columns_LR5; j++) // столбцы
                    {
                        table[i, j] = s[gind];
                        if (gind == s.Length - 1)
                            break;
                        gind++;
                    }
                }
            }
            if (WriteByCols_LR5.IsChecked == true)
            {
                for (int i = 0; i < Columns_LR5; i++) // строки
                {
                    for (int j = 0; j < Rows_LR5; j++) // столбцы
                    {
                        table[j, i] = s[gind];
                        if (gind == s.Length - 1)
                            break;
                        gind++;
                    }
                }
            }

            int[] arr;
            if (NumOrLetF_LR5)
            {
                arr = new int[Columns_LR5];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = Convert.ToInt32(firstKey[i].ToString());
            }
            else
                arr = ConvertToNum(Columns_LR5, alfabetUp, firstKey);
            ShowHow_LR5.Text = "";
            for (int i = 0; i < firstKey.Length; i++)
                ShowHow_LR5.Text += firstKey[i] + " ";
            ShowHow_LR5.Text += "\n";
            for (int i = 0; i < arr.Length; i++)
                ShowHow_LR5.Text += arr[i] + " ";
            ShowHow_LR5.Text += "\n";

            for (int i = 0; i < Rows_LR5; i++)
            {
                for (int j = 0; j < Columns_LR5; j++)
                    ShowHow_LR5.Text += $"{table[i, j]} ";
                ShowHow_LR5.Text += "\n";
            }

            try
            {
                char[,] newTable = new char[Rows_LR5, Columns_LR5];
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < table.GetLength(0); j++)
                        newTable[j, arr[i]] = table[j, i];
                }
                ShowHow_LR5.Text += "\n";
                for (int i = 0; i < newTable.GetLength(0); i++)
                {
                    ShowHow_LR5.Text += secondKey[i] + " |";
                    for (int j = 0; j < newTable.GetLength(1); j++)
                        ShowHow_LR5.Text += newTable[i, j] + " ";
                    ShowHow_LR5.Text += "\n";
                }
                ShowHow_LR5.Text += "\n";

                if (NumOrLetS_LR5)
                {
                    arr = new int[Rows_LR5];
                    for (int i = 0; i < arr.Length; i++)
                        arr[i] = Convert.ToInt32(secondKey[i].ToString());
                }
                else
                    arr = ConvertToNum(Rows_LR5, alfabetUp, secondKey);
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                        table[arr[i], j] = newTable[i, j];
                }
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        ShowHow_LR5.Text += table[i, j] + " ";
                        itog += table[i, j];
                    }
                    ShowHow_LR5.Text += "\n";
                }

                string tabtxt = "";
                for (int i = 0; i < itog.Length; i++)
                {
                    if (i != 0 && i % 5 == 0)
                        tabtxt += " ";
                    tabtxt += itog[i];
                }
                Shifr_LR5.Text = tabtxt;
                Deshifr_LR5.Text = s;
            }
            catch (Exception)
            {
                ShowHow_LR5.Foreground = Brushes.Red;
                ShowHow_LR5.TextWrapping = TextWrapping.Wrap;
                ShowHow_LR5.Text += "При попытке записи строки/столбца возникла неоднозначность.\nПроверьте правильность ввода ключей.";
                Shifr_LR5.Text = "";
                Deshifr_LR5.Text = "";
            }
        skipThisShit:;
        }
        private void CheckBox_Checked_LR5(object sender, RoutedEventArgs e)
        {
            AlfTable_LR5.Visibility = Visibility.Visible;
            Stage1_LR5.Visibility = Visibility.Visible;
            Stage2_LR5.Visibility = Visibility.Visible;
        }
        private void CheckBox_Unchecked_LR5(object sender, RoutedEventArgs e)
        {
            AlfTable_LR5.Visibility = Visibility.Hidden;
            Stage1_LR5.Visibility = Visibility.Hidden;
            Stage2_LR5.Visibility = Visibility.Hidden;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string s = EnterMessage_LR5.Text.ToUpper().Replace(" ", "");
            string alfabetUp;
            char[,] km;
            int gind = 0;
            switch (SwitchMethod_LR5.SelectedIndex)
            {
                case 0:
                    Offset_LR5.Visibility = Visibility.Hidden;
                    Polibiy_UpPoint_LR5.Visibility = Visibility.Hidden;
                    Polibiy_DownPoint_LR5.Visibility = Visibility.Hidden;
                    M3Key_LR5.Visibility = Visibility.Visible;
                    M3Key_LR5.Visibility = Visibility.Hidden;
                    switch (language_LR5)
                    {
                        case "Rus":
                            alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ,-:";
                            km = new char[6, 6];
                            for (int i = 0; i < km.GetLength(0); i++)
                            {
                                for (int j = 0; j < km.GetLength(1); j++)
                                {
                                    km[i, j] = alfabetUp[gind];
                                    gind++;
                                }
                            }
                            s = s.ToUpper();
                            break;
                        case "Eng":
                            alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                            km = new char[5, 5];
                            gind = 0;
                            for (int i = 0; i < km.GetLength(0); i++)
                            {
                                for (int j = 0; j < km.GetLength(1); j++)
                                {
                                    km[i, j] = alfabetUp[gind];
                                    if (alfabetUp[gind] == 'I')
                                        j--;
                                    gind++;
                                }
                            }
                            s = s.ToUpper().Replace(" ", "").Replace("I", "J");
                            break;
                        default:
                            km = new char[5, 5];
                            break;
                    }

                    Stage1_LR5.Text = "";
                    for (int i = 0; i < s.Length; i++)
                        Stage1_LR5.Text += s[i] + " ";
                    Stage1_LR5.Text += "\n";

                    string strcoords = "";
                    for (int k = 0; k < s.Length; k++)
                    {
                        for (int i = 0; i < km.GetLength(0); i++)
                        {
                            for (int j = 0; j < km.GetLength(1); j++)
                            {
                                if (s[k] == km[i, j])
                                {
                                    Stage1_LR5.Text += j + 1 + " ";
                                    strcoords += j;
                                }
                            }
                        }
                    }
                    Stage1_LR5.Text += "\n";
                    for (int k = 0; k < s.Length; k++)
                    {
                        for (int i = 0; i < km.GetLength(0); i++)
                        {
                            for (int j = 0; j < km.GetLength(1); j++)
                            {
                                if (s[k] == km[i, j])
                                {
                                    Stage1_LR5.Text += i + 1 + " ";
                                    strcoords += i;
                                }
                            }
                        }
                    }
                    Stage1_LR5.Text += "\n";
                    for (int i = 1; i < strcoords.Length; i += 2)
                        Stage1_LR5.Text += (Convert.ToInt32(strcoords[i - 1].ToString()) + 1).ToString() + "" + (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
                    string result = "";
                    for (int i = 1; i < strcoords.Length; i += 2)
                        result += km[Convert.ToInt32(strcoords[i].ToString()), Convert.ToInt32(strcoords[i - 1].ToString())] + " ";
                    Shifr_LR5_Copy.Text = result;
                    Deshifr_LR5_Copy.Text = s;
                    break;
                case 1:
                    Offset_LR5.Visibility = Visibility.Visible;
                    Polibiy_UpPoint_LR5.Visibility = Visibility.Visible;
                    Polibiy_DownPoint_LR5.Visibility = Visibility.Visible;
                    M3Key_LR5.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    Offset_LR5.Visibility = Visibility.Hidden;
                    Polibiy_UpPoint_LR5.Visibility = Visibility.Hidden;
                    Polibiy_DownPoint_LR5.Visibility = Visibility.Hidden;
                    M3Key_LR5.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void Polibiy_UpPoint_LR5_Click(object sender, RoutedEventArgs e)
        {
            Offset_LR5.Text = (Convert.ToInt32(Offset_LR5.Text) + 1).ToString();
            string s = EnterMessage_LR5.Text.ToUpper().Replace(" ", "");
            string alfabetUp;
            char[,] km;
            int gind = 0;
            switch (language_LR5)
            {
                case "Rus":
                    alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ,-:";
                    km = new char[6, 6];
                    for (int i = 0; i < km.GetLength(0); i++)
                    {
                        for (int j = 0; j < km.GetLength(1); j++)
                        {
                            km[i, j] = alfabetUp[gind];
                            gind++;
                        }
                    }
                    s = s.ToUpper();
                    break;
                case "Eng":
                    alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    km = new char[5, 5];
                    gind = 0;
                    for (int i = 0; i < km.GetLength(0); i++)
                    {
                        for (int j = 0; j < km.GetLength(1); j++)
                        {
                            km[i, j] = alfabetUp[gind];
                            if (alfabetUp[gind] == 'I')
                                j--;
                            gind++;
                        }
                    }
                    s = s.ToUpper().Replace(" ", "").Replace("I", "J");
                    break;
                default:
                    km = new char[5, 5];
                    break;
            }
            Stage1_LR5.Text = "";
            Stage2_LR5.Text = "";
            for (int i = 0; i < s.Length; i++)
                Stage1_LR5.Text += s[i] + " ";
            Stage1_LR5.Text += "\n";
            string strcoords = "";
            for (int k = 0; k < s.Length; k++)
            {
                for (int i = 0; i < km.GetLength(0); i++)
                {
                    for (int j = 0; j < km.GetLength(1); j++)
                    {
                        if (s[k] == km[i, j])
                        {
                            Stage1_LR5.Text += j + 1 + " ";
                            strcoords += j;
                        }
                    }
                }
            }
            Stage1_LR5.Text += "\n";
            for (int k = 0; k < s.Length; k++)
            {
                for (int i = 0; i < km.GetLength(0); i++)
                {
                    for (int j = 0; j < km.GetLength(1); j++)
                    {
                        if (s[k] == km[i, j])
                        {
                            Stage1_LR5.Text += i + 1 + " ";
                            strcoords += i;
                        }
                    }
                }
            }
            Stage1_LR5.Text += "\n";
            int n = Convert.ToInt32(Offset_LR5.Text.ToString());
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    strcoords += strcoords[0];
                    strcoords = strcoords.Remove(0, 1);
                }
            }
            for (int i = 1; i < strcoords.Length; i += 2)
                Stage1_LR5.Text += (Convert.ToInt32(strcoords[i - 1].ToString()) + 1).ToString() + "" + (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            for (int i = 0; i < strcoords.Length; i += 2)
                Stage2_LR5.Text += (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            Stage2_LR5.Text += "\n";
            for (int i = 1; i < strcoords.Length; i += 2)
                Stage2_LR5.Text += (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            string result = "";
            for (int i = 1; i < strcoords.Length; i += 2)
                result += km[Convert.ToInt32(strcoords[i].ToString()), Convert.ToInt32(strcoords[i - 1].ToString())] + " ";
            Stage2_LR5.Text += "\n" + result;
            Shifr_LR5_Copy.Text = result;
            Deshifr_LR5_Copy.Text = EnterMessage_LR5.Text.ToUpper();
        }
        private void Polibiy_DownPoint_LR5_Click(object sender, RoutedEventArgs e)
        {
            if (Offset_LR5.Text != "0")
                Offset_LR5.Text = (Convert.ToInt32(Offset_LR5.Text) - 1).ToString();
            string s = EnterMessage_LR5.Text.ToUpper().Replace(" ", "");
            string alfabetUp;
            char[,] km;
            int gind = 0;
            switch (language_LR5)
            {
                case "Rus":
                    alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ,-:";
                    km = new char[6, 6];
                    for (int i = 0; i < km.GetLength(0); i++)
                    {
                        for (int j = 0; j < km.GetLength(1); j++)
                        {
                            km[i, j] = alfabetUp[gind];
                            gind++;
                        }
                    }
                    s = s.ToUpper();
                    break;
                case "Eng":
                    alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    km = new char[5, 5];
                    gind = 0;
                    for (int i = 0; i < km.GetLength(0); i++)
                    {
                        for (int j = 0; j < km.GetLength(1); j++)
                        {
                            km[i, j] = alfabetUp[gind];
                            if (alfabetUp[gind] == 'I')
                                j--;
                            gind++;
                        }
                    }
                    s = s.ToUpper().Replace(" ", "").Replace("I", "J");
                    break;
                default:
                    km = new char[5, 5];
                    break;
            }
            Stage1_LR5.Text = "";
            Stage2_LR5.Text = "";
            for (int i = 0; i < s.Length; i++)
                Stage1_LR5.Text += s[i] + " ";
            Stage1_LR5.Text += "\n";
            string strcoords = "";
            for (int k = 0; k < s.Length; k++)
            {
                for (int i = 0; i < km.GetLength(0); i++)
                {
                    for (int j = 0; j < km.GetLength(1); j++)
                    {
                        if (s[k] == km[i, j])
                        {
                            Stage1_LR5.Text += j + 1 + " ";
                            strcoords += j;
                        }
                    }
                }
            }
            Stage1_LR5.Text += "\n";
            for (int k = 0; k < s.Length; k++)
            {
                for (int i = 0; i < km.GetLength(0); i++)
                {
                    for (int j = 0; j < km.GetLength(1); j++)
                    {
                        if (s[k] == km[i, j])
                        {
                            Stage1_LR5.Text += i + 1 + " ";
                            strcoords += i;
                        }
                    }
                }
            }
            Stage1_LR5.Text += "\n";
            int n = Convert.ToInt32(Offset_LR5.Text.ToString());
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    strcoords += strcoords[0];
                    strcoords = strcoords.Remove(0, 1);
                }
            }
            for (int i = 1; i < strcoords.Length; i += 2)
                Stage1_LR5.Text += (Convert.ToInt32(strcoords[i - 1].ToString()) + 1).ToString() + "" + (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            for (int i = 0; i < strcoords.Length; i += 2)
                Stage2_LR5.Text += (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            Stage2_LR5.Text += "\n";
            for (int i = 1; i < strcoords.Length; i += 2)
                Stage2_LR5.Text += (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            string result = "";
            for (int i = 1; i < strcoords.Length; i += 2)
                result += km[Convert.ToInt32(strcoords[i].ToString()), Convert.ToInt32(strcoords[i - 1].ToString())] + " ";
            Stage2_LR5.Text += "\n" + result;
            Shifr_LR5_Copy.Text = result;
            Deshifr_LR5_Copy.Text = EnterMessage_LR5.Text.ToUpper();
        }
        private void M3Key_LR5_TextChanged(object sender, TextChangedEventArgs e)
        {
            AlfTable_LR5.Text = "";
            string s = EnterMessage_LR5.Text.ToUpper().Replace(" ", "");
            string alfabetUp = "";
            char[,] km;
            int gind = 0;
            switch (language_LR5)
            {
                case "Rus":
                    alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ,-:";
                    km = new char[6, 6];
                    for (int i = 0; i < km.GetLength(0); i++)
                    {
                        for (int j = 0; j < km.GetLength(1); j++)
                        {
                            km[i, j] = alfabetUp[gind];
                            gind++;
                        }
                    }
                    s = s.ToUpper();
                    break;
                case "Eng":
                    alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    km = new char[5, 5];
                    gind = 0;
                    for (int i = 0; i < km.GetLength(0); i++)
                    {
                        for (int j = 0; j < km.GetLength(1); j++)
                        {
                            km[i, j] = alfabetUp[gind];
                            if (alfabetUp[gind] == 'I')
                                j--;
                            gind++;
                        }
                    }
                    break;
                default:
                    km = new char[5, 5];
                    break;
            }

            s = s.ToUpper().Replace(" ", "");
            string key = M3Key_LR5.Text;
            key = key.Replace(" ", "");
            string finalKEY = "";
            for (int i = key.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[i] == key[j] && i != j && i > j)
                    {
                        finalKEY += key[j];
                        break;
                    }
                }
            }
            int id = key.Length - 1;
            do
            {
                try
                {
                    if (key[id] == finalKEY[0])
                    {
                        key = key.Remove(id, 1);
                        finalKEY = finalKEY.Remove(0, 1);
                    }
                    id--;
                }
                catch (Exception) { }
            } while (finalKEY.Length != 0);

            key = key.ToUpper();
            key += alfabetUp;
            for (int i = key.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < key.Length; j++)
                {
                    if (key[i] == key[j] && i != j && i > j)
                    {
                        finalKEY += key[j];
                        break;
                    }
                }
            }
            id = key.Length - 1;
            do
            {
                try
                {
                    if (key[id] == finalKEY[0])
                    {
                        key = key.Remove(id, 1);
                        finalKEY = finalKEY.Remove(0, 1);
                    }
                }
                catch (Exception) { }
                id--;
            } while (finalKEY.Length != 0);

            AlfTable_LR5.Text += "   ";
            for (int i = 0; i < km.GetLength(0); i++)
                AlfTable_LR5.Text += i + 1 + "   ";
            AlfTable_LR5.Text += "\n";
            int ids = 0;
            int Iind = 0;
            for (int i = 0; i < km.GetLength(0); i++)
            {
                AlfTable_LR5.Text += i + 1 + "  ";
                for (int j = 0; j < km.GetLength(1); j++)
                {
                    if (ids < key.Length)
                        km[i, j] = key[ids];
                    if (key[ids] != 'I')
                        AlfTable_LR5.Text += key[ids] + "   ";
                    else
                    {
                        Iind = ids;
                        AlfTable_LR5.Text += key[ids] + "/";
                        j--;
                    }
                    ids++;
                }
                AlfTable_LR5.Text += "\n";
            }
            s = s.Replace('I', key[Iind + 1]);

            Stage1_LR5.Text = "";
            Stage2_LR5.Text = "";
            for (int i = 0; i < s.Length; i++)
                Stage1_LR5.Text += s[i] + " ";
            Stage1_LR5.Text += "\n";

            string strcoords = "";
            for (int k = 0; k < s.Length; k++)
            {
                for (int i = 0; i < km.GetLength(0); i++)
                {
                    for (int j = 0; j < km.GetLength(1); j++)
                    {
                        if (s[k] == km[i, j])
                        {
                            Stage1_LR5.Text += j + 1 + " ";
                            strcoords += j;
                        }
                    }
                }
            }
            Stage1_LR5.Text += "\n";
            for (int k = 0; k < s.Length; k++)
            {
                for (int i = 0; i < km.GetLength(0); i++)
                {
                    for (int j = 0; j < km.GetLength(1); j++)
                    {
                        if (s[k] == km[i, j])
                        {
                            Stage1_LR5.Text += i + 1 + " ";
                            strcoords += i;
                        }
                    }
                }
            }
            Stage1_LR5.Text += "\n";
            for (int i = 1; i < strcoords.Length; i += 2)
                Stage1_LR5.Text += (Convert.ToInt32(strcoords[i - 1].ToString()) + 1).ToString() + "" + (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            for (int i = 0; i < strcoords.Length; i += 2)
                Stage2_LR5.Text += (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            Stage2_LR5.Text += "\n";
            for (int i = 1; i < strcoords.Length; i += 2)
                Stage2_LR5.Text += (Convert.ToInt32(strcoords[i].ToString()) + 1).ToString() + " ";
            string result = "";
            for (int i = 1; i < strcoords.Length; i += 2)
                result += km[Convert.ToInt32(strcoords[i].ToString()), Convert.ToInt32(strcoords[i - 1].ToString())] + " ";
            Stage2_LR5.Text += "\n" + result;
            Shifr_LR5_Copy.Text = result;
            Deshifr_LR5_Copy.Text = s;
        }
        private void b_lr5l_Click(object sender, RoutedEventArgs e)
        {
            labo_LR5.Visibility = Visibility.Hidden;
            Tgr_LR5.Visibility = Visibility.Visible;
        }
        private void FKey_LR5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FKey_LR5.Text.Length == FKey_LR5.MaxLength && SKey_LR5.Text.Length == SKey_LR5.MaxLength)
                Accept_LR5.IsEnabled = true;
            else
                Accept_LR5.IsEnabled = false;
        }
        private void SKey_LR5_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FKey_LR5.Text.Length == FKey_LR5.MaxLength && SKey_LR5.Text.Length == SKey_LR5.MaxLength)
                Accept_LR5.IsEnabled = true;
            else
                Accept_LR5.IsEnabled = false;
        }
        private void M3Key_LR5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string alfabetUp;
            e.Handled = char.IsDigit(e.Text, 0);
            if (language_LR5 == "Eng")
            {
                alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                e.Handled = !alfabetUp.Contains(e.Text.ToUpper());
            }
            else if (language_LR5 == "Rus")
            {
                alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ,-:";
                e.Handled = !alfabetUp.Contains(e.Text.ToUpper());
            }
        }
        bool NumOrLetF_LR5; // t - num f - let
        private void FKey_LR5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string alfabetUp = "";
            if (FKey_LR5.Text == "")
            {
                if (char.IsNumber(e.Text, 0))
                    NumOrLetF_LR5 = true;
                if (char.IsLetter(e.Text, 0))
                {
                    NumOrLetF_LR5 = false;
                    if (language_LR5 == "Eng")
                        alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    if (language_LR5 == "Rus")
                        alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    if (!alfabetUp.Contains(e.Text[e.Text.Length - 1].ToString().ToUpper()))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
            else
            {
                if (NumOrLetF_LR5) // num
                    e.Handled = !char.IsNumber(e.Text, e.Text.Length - 1);
                else // let
                {
                    e.Handled = !char.IsLetter(e.Text, e.Text.Length - 1);
                    if (language_LR5 == "Eng")
                        alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    if (language_LR5 == "Rus")
                        alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    if (!alfabetUp.Contains(e.Text[e.Text.Length - 1].ToString().ToUpper()))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
        }
        bool NumOrLetS_LR5; // t - num f - let
        private void SKey_LR5_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string alfabetUp = "";
            if (SKey_LR5.Text == "")
            {
                if (char.IsNumber(e.Text, 0))
                    NumOrLetS_LR5 = true;
                if (char.IsLetter(e.Text, 0))
                {
                    NumOrLetS_LR5 = false;
                    if (language_LR5 == "Eng")
                        alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    if (language_LR5 == "Rus")
                        alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    if (!alfabetUp.Contains(e.Text[e.Text.Length - 1].ToString().ToUpper()))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
            else
            {
                if (NumOrLetS_LR5) // num
                    e.Handled = !char.IsNumber(e.Text, e.Text.Length - 1);
                else // let
                {
                    e.Handled = !char.IsLetter(e.Text, e.Text.Length - 1);
                    if (language_LR5 == "Eng")
                        alfabetUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    if (language_LR5 == "Rus")
                        alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
                    if (!alfabetUp.Contains(e.Text[e.Text.Length - 1].ToString().ToUpper()))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
            }
        }
        private void ShowOrNotHow_LR5_Checked(object sender, RoutedEventArgs e)
        {
            ShowHow_LR5.Visibility = Visibility.Visible;
        }
        private void ShowOrNotHow_LR5_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowHow_LR5.Visibility = Visibility.Hidden;
        }
        private void ToDoubleReplace_LR5(object sender, RoutedEventArgs e)
        {
            labo_LR5.Visibility = Visibility.Visible;
            Tgr_LR5.Visibility = Visibility.Hidden;
        }

//----------лабораторная работа 6---!!!! WARNING - ДРЕМУЧИЙ ЛЕС !!!!-----------

//списки гридов
List<Grid> AnimGridList = new List<Grid>();//к 1 заданию
        List<Grid> GridAnuim = new List<Grid>();//к 2 заданию
        int stadiy;
        bool checkText1, checkText2;
        //таймера
        DispatcherTimer AnimGrid = new DispatcherTimer();
        DispatcherTimer AnimText1 = new DispatcherTimer();
        DispatcherTimer OpacityShifr = new DispatcherTimer();
        DispatcherTimer timerFor2Shifr_LR6 = new DispatcherTimer();
        DispatcherTimer animationforgrids = new DispatcherTimer();
        DispatcherTimer animationforgridsTxt = new DispatcherTimer();
        DispatcherTimer ShifGrid_1 = new DispatcherTimer();
        DispatcherTimer OpacityShifr_1 = new DispatcherTimer();
        DispatcherTimer ShifrGridTimer = new DispatcherTimer();
        DispatcherTimer ShifrGridTimer2 = new DispatcherTimer();

        //-----------------------Задание №1----------------------------
        //----------------------Алгоритм RSA---------------------------

        private void Button_Click_5(object sender, RoutedEventArgs e)//Событие на подсказку
        {
            TranslateTransform tr = new TranslateTransform();
            Help_LR6.RenderTransform = tr;
            DoubleAnimation animY = new DoubleAnimation();
            animY.From = Help_LR6.Margin.Top;
            animY.To = 253;
            animY.Duration = TimeSpan.FromSeconds(0.5);
            animY.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.YProperty, animY);
            Help_LR6.Visibility = Visibility.Visible;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)//переход к этапу шифрования
        {
            if (creating_LR9)
            {
                //GlobalKey_LR6 PersonalKey_LR6 cl
                keyU_LR10.Text = GlobalKey_LR6.Text.Split('-')[0];
                keyU2_LR10.Text = GlobalKey_LR6.Text.Split('-')[1];
                key_LR10.Text = PersonalKey_LR6.Text.Split('-')[0];
                key2_LR10.Text = PersonalKey_LR6.Text.Split('-')[1];

                Grtemp.IsEnabled = true;
                TranslateTransform tr = new TranslateTransform();
                GridList[5].RenderTransform = tr;
                DoubleAnimation animY = new DoubleAnimation();
                animY.From = -400;
                animY.To = 0;
                animY.Duration = TimeSpan.FromSeconds(speed);
                animY.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.YProperty, animY);
                statusLab[5] = false;
                punkt = 0;
            }
            else
            {
                AnimGridList.Clear();
                butGen_LR6.Visibility = Visibility.Hidden;
                ButShif_LR6.Visibility = Visibility.Visible;
                ShifrGrid_LR6.Visibility = Visibility.Visible;
                stadiy = 0;
                grigshifrlr6 = true;

                AnimGridList.Add(AnimGrid1_LR6);
                AnimGridList.Add(AnimGrid2_LR6);
                AnimGridList.Add(AnimGrid3_LR6);
                AnimGridList.Add(AnimGrid4_LR6);
                AnimGrid.Start();
                AnimText1.Start();
                OpacityShifr.Start();
                ButShif_LR6.IsEnabled = false;
            }


        }
        private void Button_Click_7(object sender, RoutedEventArgs e)//переход к этапу генерации ключей
        {
            AnimGridList.Clear();

            butGen_LR6.Visibility = Visibility.Visible;
            ButShif_LR6.Visibility = Visibility.Hidden;
            grigshifrlr6 = false;

            stadiy = 4;
            AnimGridList.Add(AnimGrid1_LR6);
            AnimGridList.Add(AnimGrid2_LR6);
            AnimGridList.Add(AnimGrid3_LR6);
            AnimGridList.Add(AnimGrid4_LR6);
            ShifrGridTimer.Start();
            ShifrGridTimer2.Start();
            butGen_LR6.IsEnabled = false;
        }
        bool grigshifrlr6;
        private void Button_Click_8(object sender, RoutedEventArgs e)//смена заданий
        {
            TranslateTransform tr = new TranslateTransform();
            ShifrGrid2_LR6.RenderTransform = tr;
            DoubleAnimation animX = new DoubleAnimation();
            animX.From = 0;
            animX.To = -800;
            animX.Duration = TimeSpan.FromSeconds(0.5);
            animX.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.XProperty, animX);
            if (!sts) {
                butGen_LR6_Copy.Visibility = Visibility.Visible;
                AnumGridEL4_LR6.Visibility = Visibility.Visible;
                txt_LR6.Visibility = Visibility.Visible;
            }
            else
            {
                butKey_LR6_Copy1.Visibility = Visibility.Visible;
                ShifrGrid_LR6_Copy.Visibility = Visibility.Visible;
            }

        }
        private void Button_Click_6(object sender, RoutedEventArgs e)//скрыть подсказку
        {
            TranslateTransform tr = new TranslateTransform();
            Help_LR6.RenderTransform = tr;
            DoubleAnimation animY = new DoubleAnimation();
            animY.From = 253;
            animY.To = -253;
            animY.Duration = TimeSpan.FromSeconds(0.5);
            animY.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.YProperty, animY);
        }
        private void StackSimpleNumber_M_LR6_SelectionChanged(object sender, SelectionChangedEventArgs e)//генерация е
        {
            PersonalKey_LR6.Text = "";
            if (StackSimpleNumber_M_LR6.SelectedIndex > -1)
            {
                e_ = Convert.ToInt64(StackSimpleNumber_M_LR6.SelectedItem.ToString());
                GlobalKey_LR6.Text = e_ + "-" + n;
                AnimGrid3_LR6.IsEnabled = true;
                Calculate_d(m, e_);
                txt2_LR6.Foreground = Brushes.Green;

       //         int dfgh = 0;
                int max = StackSimpleNumber_M_LR1.Items.Count;               
                
            }
            else
            {                
                GlobalKey_LR6.IsEnabled = false;
                PersonalKey_LR6.IsEnabled = false;
            }
            //if (StackSimpleNumber_M_LR1.Items.Count == 0) { }
        }
        private void Calculate_e(long m)
        {
            for (int i = 3; i < m; i++)
            {
                if (!Prost(i) || NOD(i, m) == 1)
                { 
                    for (int j = 2; j < 1000; j++)
                    {
                        if ((i * j) % m == 1)
                        {
                            StackSimpleNumber_M_LR6.Items.Add(i);
                            break;
                        }
                    }
                    continue;
                }

            }
        }
       private void Calculate_d(long m,  long e)
        {
            StackSimpleNumber_M_LR1.Items.Clear();
            for (int i = 2; i < 1000; i++)
            {
                if ((i*e) % m == 1)
                    StackSimpleNumber_M_LR1.Items.Add(i);
            }
        }
        long NOD(long a, long b)
        {
            while (a > 0 && b > 0)
                if (a > b)
                    a %= b;
                else
                    b %= a;
            return a + b;
        }

        private static bool Prost(long x)
        {
            bool isSimple = true;
            for (int i = 2; i < x; i++)
            {
                if (x % i == 0)
                {
                    isSimple = false;
                    break;
                }
            }
            if (isSimple)
                return false;
            else return true;
        }
        long p = 0, q = 0, n, m, e_, d;
        private void Creater1Key_LR6(object sender, TextChangedEventArgs e)
        {
            keyStst_LR6.IsChecked = false;
            checkText1 = false;
            checkText2 = false;
            string str1 = TB1for_Key_LR6.Text;
            string str2 = TB2for_Key_LR6.Text;
            TxtS1_LR6.Foreground = Brushes.Black;

            StackSimpleNumber_M_LR6.Items.Clear();
            StackSimpleNumber_M_LR1.Items.Clear();

            if (TB1for_Key_LR6.Text != "" && TB2for_Key_LR6.Text != "")
            {
                try
                {
                    Console.WriteLine(str1 + "  " + str2);
                    p = Convert.ToInt64(str1);
                    q = Convert.ToInt64(str2);
                    if (p != 0 && q != 0)
                    {
                        checkText1 = true;
                        checkText2 = true;
                    }

                }
                catch (Exception)
                {
                    checkText1 = false;
                    checkText2 = false;
                    block();
                }
            }
            Console.WriteLine(checkText1 + "   " + checkText2);
            if (checkText1 && checkText2 && !Prost(p) && !Prost(q))
            {
                Console.WriteLine(p + "   " + q);

                m = (p - 1) * (q - 1);
                Calculate_e(m);
                n = p * q;                
                AnimGrid2_LR6.IsEnabled = true;
                TxtS1_LR6.Foreground = Brushes.Green;
            }
            else
            {
                TxtS1_LR6.Foreground = Brushes.Red;
                block();

                txt2_LR6.Foreground = Brushes.Black;
            }
        }

        private void StackSimpleNumber_M_LR6_MouseDown(object sender, DependencyPropertyChangedEventArgs e)
        {
            for (int i = 0; i < StackSimpleNumber_M_LR6.Items.Count;i++)
            {
                long temp = Convert.ToInt64(StackSimpleNumber_M_LR6.Items[i].ToString());
                Calculate_d(m, temp);
                if (StackSimpleNumber_M_LR1.Items.Count == 0)
                {
                    StackSimpleNumber_M_LR6.Items.RemoveAt(i);
                    StackSimpleNumber_M_LR1.Items.Clear();
                }
            }
        }
        private void crypt_LR6(object sender, TextChangedEventArgs e)
        {
            if(Key_Shifr_LR6.Text.Split('-').Length == 2)
                butt_LR5.IsEnabled = true;
            else butt_LR5.IsEnabled = false;
        }
        
        private void Key_Shifr_LR6_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (Key_DeShifr_LR6.Text.Split('-').Length == 2)
                butt2_LR6.IsEnabled = true;
            else butt2_LR6.IsEnabled = false;
        }



        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void StackSimpleNumber_M_LR1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StackSimpleNumber_M_LR6.SelectedIndex > -1 && StackSimpleNumber_M_LR1.SelectedIndex > -1)
            {
                try
                {
                    txt2_LR1.Foreground = Brushes.Green;
                    PersonalKey_LR6.Text = StackSimpleNumber_M_LR1.SelectedItem.ToString() + "-" + n;
                    d = Convert.ToInt64(StackSimpleNumber_M_LR1.SelectedItem);

                    AnimGrid4_LR6.IsEnabled = true;
                    butGen_LR6.IsEnabled = true;
                }
                catch (Exception) { }
            }
            else
            {
                StackSimpleNumber_M_LR1.Items.Clear();
                butGen_LR6.IsEnabled = false;
                GlobalKey_LR6.IsEnabled = false;
                PersonalKey_LR6.IsEnabled = false;
            }

        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;
            img.Width -= 10;
            img.Height -= 10;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;
            img.Width += 10;
            img.Height += 10;
        }

        private void stage1_LR6(object sender, MouseButtonEventArgs e)
        {
            Key_Shifr_LR6.IsEnabled = true;            
        }
        char[] characters = new char[] {' ', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                        'Э', 'Ю', 'Я','1','2','3','4','5','6','7','8','9','0','a','b','c','d'
        ,'e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        
        private List<string> RSA_Endoce(string s, long e, long n)
        {
            var Encod = new List<string>();

            var InputSymbol = new List<int>();
            for (int i = 0; i < s.Length;i++)
            {
                InputSymbol.Add(s[i]);
            }
            for(int i = 0; i < InputSymbol.Count; i++)
            {
                Encod.Add((BigInteger.Pow(InputSymbol[i], (int)e) % n).ToString());
            }
            
            return Encod;
        }
        

        private void cript_LR6(object sender, MouseButtonEventArgs e)
        {
            ShifrRezult_LR6.Text = "";
            var result = new List<string>();
            try
            {
                result = RSA_Endoce(TextForShifr_LR6.Text, Convert.ToInt32(Key_Shifr_LR6.Text.Split('-')[0]),Convert.ToInt32(Key_Shifr_LR6.Text.Split('-')[1]));
            }
            catch (Exception)
            {
                butt_LR5.IsEnabled = false;
            }
            for (int i = 0; i < result.Count; i++)
            {
                try { ShifrRezult_LR6.Text += Convert.ToInt32(result[i]) + " "; }
                catch (Exception) { }
            }
            ShifrRezult_LR6.IsEnabled = true;
            butt1_LR6.IsEnabled = true;

            for (int i = 0; i < TextForShifr_LR6.Text.Length; i++)
            {
                try
                {
                    if ((int)TextForShifr_LR6.Text[i] >= Convert.ToInt32(Key_Shifr_LR6.Text.Split('-')[1]))
                    {
                        var result1 = MessageBox.Show(
                         "Текущий ключ не подходит для дальнейшего шифрования, возможны искажения информации!\n\n\nЖелаете продолжить?",
                         "Предупреждение", MessageBoxButton.YesNo);
                        if (result1 == MessageBoxResult.No)
                        {
                            AnimGridList.Clear();
                            butGen_LR6.Visibility = Visibility.Visible;
                            ButShif_LR6.Visibility = Visibility.Hidden;
                            grigshifrlr6 = false;

                            stadiy = 4;
                            AnimGridList.Add(AnimGrid1_LR6);
                            AnimGridList.Add(AnimGrid2_LR6);
                            AnimGridList.Add(AnimGrid3_LR6);
                            AnimGridList.Add(AnimGrid4_LR6);
                            ShifrGridTimer.Start();
                            ShifrGridTimer2.Start();
                            butGen_LR6.IsEnabled = false;
                            GlobalKey_LR6.IsEnabled = true;
                            PersonalKey_LR6.IsEnabled = true;
                            TextForShifr_LR6.Text = "";
                            Key_Shifr_LR6.Text = "";
                            Key_Shifr_LR6.IsEnabled = false;
                            butt_LR5.IsEnabled = false;
                            butt4_LR.IsEnabled = false;
                        }
                        break;
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void butt1_LR6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Key_DeShifr_LR6.IsEnabled = true;
        }

        private void butt2_LR6_MouseDown(object sender, MouseButtonEventArgs e)
        {

            string[] arr = ShifrRezult_LR6.Text.Split(' ');
            int[] array = new int[arr.Length];
            for(int i = 0; i < arr.Length - 1; i++)
            {
                array[i] = Convert.ToInt32(arr[i]);
                Console.Write(array[i] + " ");
            }
            try
            {
                TextForShifr_LR6.Text = RSA_Dedoce(array, Convert.ToInt32(Key_DeShifr_LR6.Text.Split('-')[0]), Convert.ToInt32(Key_DeShifr_LR6.Text.Split('-')[1]));
            }
            catch (Exception) { }
        }
        private string RSA_Dedoce(int[] arr, long d, long n)
        {
            string result = "";
            for (int i = 0; i < arr.Length;i++)
                result += (char)(BigInteger.Pow(arr[i], (int)d) % n);
            return result;
        }
        private void TextForShifr_LR6_TextChanged(object sender, TextChangedEventArgs e)
        {
            butt4_LR.IsEnabled = true;
        }

        private void block()
        {
            AnimGrid2_LR6.IsEnabled = false;
            AnimGrid4_LR6.IsEnabled = false;
            AnimGrid3_LR6.IsEnabled = false;
            txt2_LR1.Foreground = Brushes.Black;
            butGen_LR6.IsEnabled = false;
        }



        //-----------Всяка жесть----------
        private void dispatcherTimer_Tick1(object sender, EventArgs e)// к Button_Click4
        {
            if (stadiy == 4)
                AnimGrid.Stop();
            else
            {
                TranslateTransform tr = new TranslateTransform();
                AnimGridList[stadiy].RenderTransform = tr;
                DoubleAnimation animX = new DoubleAnimation();
                animX.From = AnimGridList[stadiy].Margin.Left;
                animX.To = 800;
                animX.Duration = TimeSpan.FromSeconds(0.5);
                animX.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.XProperty, animX);
                stadiy++;
            }
        }

        private void dispatcherTimer_Tick2(object sender, EventArgs e)// к Button_Click4
        {
            if (stadia.Opacity <= 0.0)
            {
                AnimText1.Stop();
                Console.WriteLine(ShifrGrid_LR6.Opacity);
            }
            else
                stadia.Opacity -= 0.02;
        }
        private void dispatcherTimer_Tick5(object sender, EventArgs e)// к Button_Click4
        {
            if (ShifrGrid_LR6.Opacity > 1.0)
            {
                OpacityShifr.Stop();
                Console.WriteLine(ShifrGrid_LR6.Opacity);
                ButShif_LR6.IsEnabled = true;
            }
            else
                ShifrGrid_LR6.Opacity += 0.02;
        }
        private void dispatcherTimer_Tick3(object sender, EventArgs e)// к Button_Click7
        {
            if (ShifrGrid_LR6.Opacity <= 0)
            {
                ShifrGridTimer.Stop();
                ShifrGrid_LR6.Opacity = 0;
                Console.WriteLine(ShifrGrid_LR6.Opacity);
                butGen_LR6.IsEnabled = true;
                ShifrGrid_LR6.Visibility = Visibility.Hidden;
            }
            else
            {
                ShifrGrid_LR6.Opacity -= 0.02;
                stadia.Opacity += 0.02;
            }
        }
        private void dispatcherTimer_Tick4(object sender, EventArgs e)// к Button_Click7
        {
            if (stadiy == 0)
                ShifrGridTimer2.Stop();
            else
            {
                stadiy--;
                TranslateTransform tr = new TranslateTransform();
                AnimGridList[stadiy].RenderTransform = tr;
                DoubleAnimation animX = new DoubleAnimation();
                animX.From = 800;
                animX.To = 0;
                animX.Duration = TimeSpan.FromSeconds(0.5);
                animX.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.XProperty, animX);
            }
        }
        //------------------------THE END------------------------------



        //-----------------------Задание №2----------------------------
        //-------------------Алгоритм Эль-Гамаля-----------------------
        private void butGen_LR6_Copy_Click_2(object sender, RoutedEventArgs e)//переход к этапу шифрования
        {
            sts = true;
            butGen_LR6_Copy.Visibility = Visibility.Hidden;
            butKey_LR6_Copy1.Visibility = Visibility.Visible;
            ShifrGrid_LR6_Copy.Visibility = Visibility.Visible;
            GridAnuim.Clear();
            GridAnuim.Add(AnumGridEL4_LR6);
            animationforgrids.Start();
            animationforgridsTxt.Start();
            timerFor2Shifr_LR6.Start();
            butKey_LR6_Copy1.IsEnabled = false;

            stadiy = 0;
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)//смена задания
        {            
            TranslateTransform tr = new TranslateTransform();
            ShifrGrid2_LR6.RenderTransform = tr;
            DoubleAnimation animX = new DoubleAnimation();
            animX.From = -800;
            animX.To = 0;
            animX.Duration = TimeSpan.FromSeconds(0.5);
            animX.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.XProperty, animX);
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)// подсказка
        {
            Help2_LR6.Visibility = Visibility.Visible;
            TranslateTransform tr = new TranslateTransform();
            Help2_LR6.RenderTransform = tr;
            DoubleAnimation animY = new DoubleAnimation();
            animY.From = Help_LR6.Margin.Top;
            animY.To = 253;
            animY.Duration = TimeSpan.FromSeconds(0.5);
            animY.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.YProperty, animY);

        }
        private void Button_Click_6_(object sender, RoutedEventArgs e)//скрыть подсказку
        {
            TranslateTransform tr = new TranslateTransform();
            Help2_LR6.RenderTransform = tr;
            DoubleAnimation animY = new DoubleAnimation();
            animY.From = 253;
            animY.To = -253;
            animY.Duration = TimeSpan.FromSeconds(0.5);
            animY.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.YProperty, animY);
        }
        private void Button_Click_12(object sender, RoutedEventArgs e)//переход к этапу генерации ключей
        {
            AnimGridList.Clear();

            butGen_LR6_Copy.Visibility = Visibility.Visible;
            butKey_LR6_Copy1.Visibility = Visibility.Hidden;
            stadiy = 4;
            sts = false;
            GridAnuim.Add(AnumGridEL4_LR6);
            OpacityShifr_1.Start();
            ShifGrid_1.Start();
            butGen_LR6_Copy.IsEnabled = false;
        }


        BigInteger power(BigInteger a, int b, int n) // a^b mod n - возведение a в степень b по модулю n
        {
            BigInteger tmp = a;
            BigInteger sum = tmp;
            for (int i = 1; i < b; i++)
            {
                for (int j = 1; j < a; j++)
                {
                    sum += tmp;
                    if (sum >= n)
                        sum -= n;
                }
                tmp = sum;
            }
            return tmp;
        }
        BigInteger mul(BigInteger a, BigInteger b, int n) // a*b mod n - умножение a на b по модулю n
        {
            BigInteger sum = 0;
            for (int i = 0; i < b; i++)
            {
                sum += a;
                if (sum >= n)
                    sum -= n;
            }
            return sum;
        }

        int  x, p_;
        BigInteger g,y;

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {

        }
        List<BigInteger> root = new List<BigInteger>();
        static BigInteger FactNaive(int n)
        {
            BigInteger r = 1;
            for (int i = 2; i <= n; ++i)
                r *= i;
            return r;
        }
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            try
            {
                for (BigInteger i = 0; i < p_; i++)
                    if (NOD((long)i, (long)p_) == 1)
                        if (BigInteger.Pow(i, (p_ - 1) / 2) != 1 % p_)
                            if (BigInteger.Pow(i, (int)FactNaive(p_ - 1)) != 1 % p_)
                                root.Add(i);
            }
            catch (Exception) { }
        }

        Random Random = new Random();

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {

        }

        private void TextForShifr_LR1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            arr1_LR6.IsEnabled = true;
        }

        private void arr1_LR6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Key_Shifr_LR1.IsEnabled = true;
            Key_Shifr_LR1.Text = key5_LR6.Text;
            ShifrRezult_LR1.Text = key2_LR6.Text;
            ShifrRezult_LR1_Copy.Text = key3_LR6.Text;
            ShifrRezult_LR1_Copy1.Text = key1_LR6.Text;
        }

        private void ib_LR6(object sender, TextChangedEventArgs e)
        {

        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Key_DeShifr_LR1_Copy.Text = key4_LR6.Text;
            Key_DeShifr_LR1_Copy.IsEnabled = true;
        }

        private void vl_L6(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {

        }

        int k;
        int creatRoot(int p)
        {
            List<int> root = new List<int>();
            List<int> rootList = new List<int>();
        egain:
            root.Clear();
            rootList.Clear();
            for (int i = 2; i < p -1;i++)
            {
                if ((p - 1) % i == 0)
                    root.Add(i);
            }
            for (int i = 2; i < p-1;i++)
            {
                for (int j = 0; j < root.Count; j++)
                {
                    if (BigInteger.Pow(i, root[j] - 1) % 11 != 0)
                        rootList.Add(i);
                    else break;
                }
            }
            try { return rootList[Random.Next(0, rootList.Count - 1)]; }
            catch (Exception)
            {
                goto egain;
            }
        }
        private void Button_Click_Key_create_15(object sender, RoutedEventArgs e)
        {
            /*  p_ = 593;
              g = 123;            
              x = 8;
              y = BigInteger.Pow(g, x) % p_;
              k = (int)(Rand() % (p - 2) + 1); // 1 < k < (p-1)
              key2_LR6.Text = p_.ToString();
              key3_LR6.Text = g.ToString();
              key1_LR6.Text = y.ToString();
              key4_LR6.Text = x.ToString();
              key5_LR6.Text = k.ToString();*/

            do { p_ = Random.Next(131, 571); } while (Prost(p_));
            g = creatRoot(p_);
            x = Random.Next(1, p_ - 1);
            y = BigInteger.Pow(g, x) % p_;
            k = (int)(Rand() % (p - 2) + 1);
            key2_LR6.Text = p_.ToString();
            key3_LR6.Text = g.ToString();
            key1_LR6.Text = y.ToString();
            key4_LR6.Text = x.ToString();
            key5_LR6.Text = k.ToString();
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            crypt(Convert.ToInt32(ShifrRezult_LR1.Text), Convert.ToInt32(ShifrRezult_LR1_Copy.Text), Convert.ToInt32(ShifrRezult_LR1_Copy1.Text), TextForShifr_LR1.Text.ToLower());
            TextForShifr_LR1_Copy.IsEnabled = true;
        }

        private void Key_Shifr_LR1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShifrRezult_LR1.IsEnabled = true;
        }

        private void ShifrRezult_LR1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShifrRezult_LR1_Copy.IsEnabled = true;
        }

        private void ShifrRezult_LR1_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShifrRezult_LR1_Copy1.IsEnabled = true;
        }

        private void ShifrRezult_LR1_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {
            arrtoshifu.IsEnabled = true;
        }

        private void TextForShifr_LR1_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            arrtokey.IsEnabled = true;
        }

        private void Key_DeShifr_LR1_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {
            Key_DeShifr_LR1.IsEnabled = true;
            if (Key_DeShifr_LR1_Copy.Text == x.ToString())
                decrypt(p_, x, TextForShifr_LR1_Copy.Text);
        }

        private void arrtokey_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextForShifr_LR1.Text = Key_DeShifr_LR1.Text;
            Key_DeShifr_LR1_Copy.Text = "";
        }

        private void Key_DeShifr_LR1_TextChanged(object sender, TextChangedEventArgs e)
        {
            arrtokey_Copy.IsEnabled = true;
        }

        private int Rand() //Ф-я получения случайного числа
        {
            Random random = new Random();
            return random.Next();
        }
        int firstKirill;
        string temps;
        void crypt(int p, BigInteger g, int k, string strIn)
        {
            TextForShifr_LR1_Copy.Text = "";
            if (strIn.Length > 0)
            {
                char[] temp = new char[strIn.Length - 1];
                temp = strIn.ToCharArray();
                for (int i = 0; i <= strIn.Length - 1; i++)
                {
                    int m = (int)temp[i];
                    firstKirill = (int)'а';
                    if (m > 0)
                    {
                        BigInteger a = power(g, k, p);
                        BigInteger b = mul(power(y, k, p), m, p);
                        TextForShifr_LR1_Copy.Text = TextForShifr_LR1_Copy.Text + a + " " + b + " ";

                        BigInteger ta = power(g, k, p);
                        BigInteger tb = mul(power(y, k, p), firstKirill, p);
                        temps = ta + " " + tb + " ";
                    }
                }
            }
        }

        void decrypt(int p, int x, string strIn)
        {
            BigInteger stag = 0,nomt = 0;
            if (strIn.Length > 0)
            {
                Key_DeShifr_LR1.Text = "";
                string[] strA = strIn.Split(' ');

                string[] tstrA = temps.Split(' ');
                for (int i = 0; i < tstrA.Length - 1; i += 2)
                {
                    char[] a = new char[tstrA[i].Length];
                    char[] b = new char[tstrA[i + 1].Length];
                    int ai = 0;
                    int bi = 0;
                    a = tstrA[i].ToCharArray();
                    b = tstrA[i + 1].ToCharArray();
                    for (int j = 0; (j < a.Length); j++)
                        ai = ai * 10 + (int)(a[j] - 48);
                    for (int j = 0; (j < b.Length); j++)
                        bi = bi * 10 + (int)(b[j] - 48);
                    if ((ai != 0) && (bi != 0))
                    {
                        BigInteger deM = mul(bi, power(ai, p - 1 - x, p), p);// m=b*(a^x)^(-1)mod p =b*a^(p-1-x)mod p - трудно было  найти нормальную формулу, в ней вся загвоздка
                        Console.WriteLine("p = " + p_ + "x = " + x);
                        stag = 1040 - deM;
                        nomt = deM;
                    }
                }


                if (strA.Length > 0)
                {
                    for (int i = 0; i < strA.Length - 1; i += 2)
                    {
                        char[] a = new char[strA[i].Length];
                        char[] b = new char[strA[i + 1].Length];
                        int ai = 0;
                        int bi = 0;
                        a = strA[i].ToCharArray();
                        b = strA[i + 1].ToCharArray();
                        for (int j = 0; (j < a.Length); j++)
                            ai = ai * 10 + (int)(a[j] - 48);
                        for (int j = 0; (j < b.Length); j++)
                            bi = bi * 10 + (int)(b[j] - 48);
                        if ((ai != 0) && (bi != 0))
                        {
                            Console.WriteLine("--------");
                            BigInteger deM = mul(bi, power(ai, p - 1 - x, p), p);// m=b*(a^x)^(-1)mod p =b*a^(p-1-x)mod p - трудно было  найти нормальную формулу, в ней вся загвоздка
                            Console.WriteLine("p = " + p_ + "x = " + x);
                            char m;
                            Console.WriteLine(nomt +"  " + (nomt + 31));
                            if (deM >= (int)nomt && deM <= (int)nomt + 31)
                               m  = (char)(deM + stag);                           
                            else m = (char)deM;
                            Console.WriteLine(deM + stag + " <=");
                            Console.WriteLine(deM + "--");
                            Key_DeShifr_LR1.Text = (Key_DeShifr_LR1.Text + m).ToUpper();
                        }
                    }
                }
            }
        }

        //-----------Всякая жесть----------
        private void dispatcherTimer_TickForgrids(object sender, EventArgs e)// к butGen_LR6_Copy_Click_2
        {
            if (stadiy == 1)
                animationforgrids.Stop();
            else
            {
                TranslateTransform tr = new TranslateTransform();
                GridAnuim[stadiy].RenderTransform = tr;
                DoubleAnimation animX = new DoubleAnimation();
                animX.From = 126;
                animX.To = 800;
                animX.Duration = TimeSpan.FromSeconds(0.5);
                animX.EasingFunction = new SexticEase();
                tr.BeginAnimation(TranslateTransform.XProperty, animX);
                stadiy++;
            }
        }
        private void dispatcherTimer_TickForgrids2(object sender, EventArgs e)// к butGen_LR6_Copy_Click_2
        {
            if (txt_LR6.Opacity <= 0)
                animationforgridsTxt.Stop();
            else
                txt_LR6.Opacity -= 0.02;
        }
        private void dispatcherTimer_TickShifr2(object sender, EventArgs e)// к butGen_LR6_Copy_Click_2
        {
            if (ShifrGrid_LR6_Copy.Opacity >= 1)
            {
                timerFor2Shifr_LR6.Stop();
                butKey_LR6_Copy1.IsEnabled = true;
            }
            else
                ShifrGrid_LR6_Copy.Opacity += 0.02;
        }
        private void dispatcherTimer_TickOP(object sender, EventArgs e)// к Button_Click12
        {
            if (ShifrGrid_LR6_Copy.Opacity <= 0)
            {
                OpacityShifr_1.Stop();
                ShifrGrid_LR6_Copy.Opacity = 0;
                Console.WriteLine(ShifrGrid_LR6_Copy.Opacity);
                butGen_LR6_Copy.IsEnabled = true;
                ShifrGrid_LR6_Copy.Visibility = Visibility.Hidden;
            }
            else
            {
                ShifrGrid_LR6_Copy.Opacity -= 0.02;
                txt_LR6.Opacity += 0.02;
                AnumGridEL4_LR6.Opacity += 0.02;
            }
        }

        private void dispatcherTimer_TickOP_(object sender, EventArgs e) // к Button_Click12
        {
            TranslateTransform tr = new TranslateTransform();
            GridAnuim[0].RenderTransform = tr;
            DoubleAnimation animX = new DoubleAnimation();
            animX.From = 800;
            animX.To = 0;
            animX.Duration = TimeSpan.FromSeconds(0.5);
            animX.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.XProperty, animX);
            ShifGrid_1.Stop();
            butGen_LR6_Copy.IsEnabled = true;
        }
        //------------------------THE END------------------------------
        
        //----------------------lr7------------------------------------
        static int ComputeSecretKey(int a, int b, int n)
        {
            int tmp = a;
            int sum = tmp;
            for (int i = 1; i < b; i++)
            {
                for (int j = 1; j < a; j++)
                {
                    sum += tmp;
                    if (sum >= n)
                        sum -= n;
                }
                tmp = sum;
            }
            return tmp;
        }
        private void SimpleNum1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SimpleNum2_LR7.Items.Clear();
            if (SimpleNum1_LR7.Text != "")
            {
                int num = Convert.ToInt32(SimpleNum1_LR7.Text);
                int d = 2;
                while (d <= Math.Sqrt(num))
                {
                    if (num % d == 0) // не простое число
                    {
                        SimpleNum2_LR7.IsEnabled = false;

                        EnterSecKey_LR7.IsEnabled = false;
                        GenSecKey_LR7.IsEnabled = false;
                        ViewedSecKey_LR7.IsEnabled = false;
                        ShowSecKey_Lr7.IsEnabled = false;
                        SecKey_Lr7.IsEnabled = false;

                        goto thisPlace_LR7;
                    }
                    d++;
                }
                SimpleNum2_LR7.IsEnabled = true;
                int ii;
                for (int i = Convert.ToInt32(SimpleNum1_LR7.Text) - 1; i > 1; i--)
                {
                    ii = 2;
                    while (ii <= Math.Sqrt(i))
                    {
                        if (i % ii == 0) // не простое число
                            goto alitdown;
                        ii++;
                    }
                    SimpleNum2_LR7.Items.Add(i);
                alitdown:;
                }
            }
            else
            {
                SimpleNum2_LR7.IsEnabled = false;

                EnterSecKey_LR7.IsEnabled = false;
                GenSecKey_LR7.IsEnabled = false;
                ViewedSecKey_LR7.IsEnabled = false;
                ShowSecKey_Lr7.IsEnabled = false;
                SecKey_Lr7.IsEnabled = false;
            }
        thisPlace_LR7:;
        }
        private void SimpleNum1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void SimpleNum1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void PasswordBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void SecKey_Lr7_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (SecKey_Lr7.Password != "")
                OK1_LR7.IsEnabled = true;
            else
                OK1_LR7.IsEnabled = false;
        }
        private void ViewedSecKey_LR7_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void ViewedSecKey_LR7_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void EnterSecKey_LR7_Checked(object sender, RoutedEventArgs e)
        {
            GenSecKey_LR7.IsChecked = false;
            SecKey_Lr7.Password = "";
        }
        private void EnterSecKey_LR7_Unchecked(object sender, RoutedEventArgs e)
        {
            GenSecKey_LR7.IsChecked = true;
        }
        private void GenSecKey_LR7_Checked(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            EnterSecKey_LR7.IsChecked = false;
            string sr = r.Next(10, 101).ToString();
            SecKey_Lr7.Password = sr;
            ViewedSecKey_LR7.Text = sr;
        }
        private void GenSecKey_LR7_Unchecked(object sender, RoutedEventArgs e)
        {
            EnterSecKey_LR7.IsChecked = true;
        }
        private void ShowSecKey_Lr7_Checked(object sender, RoutedEventArgs e)
        {
            SecKey_Lr7.Visibility = Visibility.Hidden;
            ViewedSecKey_LR7.Visibility = Visibility.Visible;
            ViewedSecKey_LR7.Text = SecKey_Lr7.Password;
        }
        private void ShowSecKey_Lr7_Unchecked(object sender, RoutedEventArgs e)
        {
            SecKey_Lr7.Visibility = Visibility.Visible;
            ViewedSecKey_LR7.Visibility = Visibility.Hidden;
            SecKey_Lr7.Password = ViewedSecKey_LR7.Text;
        }

        int b_LR7;
        private void OK1_LR7_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int p = Convert.ToInt32(SimpleNum1_LR7.Text), g = Convert.ToInt32(SimpleNum2_LR7.Text); // простые числа g < p

            int a;
            if (ShowSecKey_Lr7.IsChecked == true)
                a = Convert.ToInt32(ViewedSecKey_LR7.Text);
            else
                a = Convert.ToInt32(SecKey_Lr7.Password);
            b_LR7 = r.Next(5, 78); // секр. ключи

            int A, B; // открытые ключи
            int s; // секр. ключ

            A = ComputeSecretKey(g, a, p);
            Akey_LR7.Text = A.ToString();
            B = ComputeSecretKey(g, b_LR7, p);
            Bkey_LR7.Text = B.ToString();
            s = ComputeSecretKey(A, b_LR7, p);
            Skey_LR7.Text = s.ToString();
            ImitGrid_LR7.IsEnabled = true;
        }

        private void ImitY_LR7_Checked(object sender, RoutedEventArgs e)
        {
            ImitN_LR7.IsChecked = false;
            Sbes_LR7.Visibility = Visibility.Visible;
        }
        private void ImitY_LR7_Unchecked(object sender, RoutedEventArgs e)
        {
            ImitN_LR7.IsChecked = true;
        }
        private void ImitN_LR7_Checked(object sender, RoutedEventArgs e)
        {
            ImitY_LR7.IsChecked = false;
            Sbes_LR7.Visibility = Visibility.Hidden;
        }
        private void ImitN_LR7_Unchecked(object sender, RoutedEventArgs e)
        {
            ImitY_LR7.IsChecked = true;
        }

        private void OK2_LR7_Click(object sender, RoutedEventArgs e)
        {
            if (ImitY_LR7.IsChecked == true)
            {
                Sbes_LR7.Visibility = Visibility.Visible;
                Random r = new Random();
                string[] names = new string[] { "Ирина", "Иван", "Костя", "Максим", "Мария", "Анна", "Фёдор", "Марк", "Ева", "Артур" };
                Sobes_LR7.Content = "Собеседник: " + names[r.Next(0, names.Length)];

                int p = Convert.ToInt32(SimpleNum1_LR7.Text), g = Convert.ToInt32(SimpleNum2_LR7.Text); // простые числа g < p
                int a;
                if (ShowSecKey_Lr7.IsChecked == true)
                    a = Convert.ToInt32(ViewedSecKey_LR7.Text);
                else
                    a = Convert.ToInt32(SecKey_Lr7.Password);
                int b = b_LR7; // секр. ключи
                int A, B; // открытые ключи
                int s; // секр. ключ
                A = ComputeSecretKey(g, a, p);
                Akey_LR7_Copy.Text = A.ToString();
                B = ComputeSecretKey(g, b, p);
                Bkey_LR7_Copy.Text = B.ToString();
                s = ComputeSecretKey(B, a, p);
                Skey_LR7_Copy.Text = s.ToString();
            }
            Cong1_Lr7.Visibility = Visibility.Visible;
            Cong2_Lr7.Visibility = Visibility.Visible;
        }

        private void SimpleNum2_LR7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SimpleNum2_LR7.SelectedIndex != -1)
            {
                EnterSecKey_LR7.IsEnabled = true;
                GenSecKey_LR7.IsEnabled = true;
                ViewedSecKey_LR7.IsEnabled = true;
                ShowSecKey_Lr7.IsEnabled = true;
                SecKey_Lr7.IsEnabled = true;
            }
        }

        private void ViewedSecKey_LR7_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ViewedSecKey_LR7.Text != "")
                OK1_LR7.IsEnabled = true;
            else
                OK1_LR7.IsEnabled = false;
        }

        private void ToZ2_LR7_Click(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation thiknessAnimation = new ThicknessAnimation();
            thiknessAnimation.From = Z2_LR7.Margin;
            thiknessAnimation.To = new Thickness(787 - 570, 315, 0, 0);
            thiknessAnimation.Duration = TimeSpan.FromSeconds(0.5);
            Z2_LR7.BeginAnimation(MarginProperty, thiknessAnimation);
        }

        private void FromZ2_LR7_Click(object sender, RoutedEventArgs e)
        {
            ThicknessAnimation thiknessAnimation = new ThicknessAnimation();
            thiknessAnimation.From = Z2_LR7.Margin;
            thiknessAnimation.To = new Thickness(204 + 595, 315, 0, 0);
            thiknessAnimation.Duration = TimeSpan.FromSeconds(0.5);
            Z2_LR7.BeginAnimation(MarginProperty, thiknessAnimation);
        }
        string hesh = "";
        private void ToMD5_LR7_Click(object sender, RoutedEventArgs e)
        {

            StreamWriter sw = new StreamWriter("inpmsg_LR7.txt");
            sw.Write(Inp_LR7.Text);
            sw.Close();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = @"Test.exe";
            p.Start();
            Thread.Sleep(100);
            p.Start();

            StreamReader sr = new StreamReader("inpshifr_LR7.txt");
            MD5_LR7.Text = sr.ReadLine();
            sr.Close();
            if (creating_LR9)
            {
                Hesh_LR10.Text = MD5_LR7.Text;
                hesh = MD5_LR7.Text;
                if (punkt == 2)
                {
                    laboratory_work7.Visibility = Visibility.Visible;
                    Grtemp.IsEnabled = false;
                    TranslateTransform tr = new TranslateTransform();
                    GridList[6].RenderTransform = tr;
                    DoubleAnimation animY = new DoubleAnimation();
                    animY.From = -400;
                    animY.To = 0;
                    animY.Duration = TimeSpan.FromSeconds(speed);
                    animY.EasingFunction = new SexticEase();
                    tr.BeginAnimation(TranslateTransform.YProperty, animY);
                    statusLab[6] = true;
                    punkt = 0;
                }
            }
        }

        private void Cong1_Lr7_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Cong1_Lr7.Visibility = Visibility.Hidden;
            Cong2_Lr7.Visibility = Visibility.Hidden;
        }
        //---------------------------8---------------------------------
        //---------------------------9---------------------------------
        private void n1_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void k1_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void s1_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void m1_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void v1_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void n2_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void t2_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void s2_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void k3_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void t3_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }
        private void s3_LR9_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void n1_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void k1_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void s1_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void m1_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void v1_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void n2_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void t2_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void s2_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            butGen_LR6.IsEnabled = true;
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            butGen_LR6.IsEnabled = false;
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            lr8.Visibility = Visibility.Hidden;
            lr81.Visibility = Visibility.Visible;
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            lr81.Visibility = Visibility.Hidden;
            lr8.Visibility = Visibility.Visible;
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            lr81.Visibility = Visibility.Hidden;
            lr82.Visibility = Visibility.Visible;
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            lr82.Visibility = Visibility.Hidden;
            lr81.Visibility = Visibility.Visible;
        }
        private void k3_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }
        private void t3_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void s3_LR9_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        public static double Round_LR9(double value, int digits)
        {
            double scale = Math.Pow(10.0, digits);
            double round = Math.Floor(value * scale + 0.5);
            return Math.Sign(value) * round / scale;
        }

        private void Apply1_LR9_Click(object sender, RoutedEventArgs e) // БЛЯТЬ
        {
            try
            {
                int n = int.Parse(n1_LR9.Text);
                int k = int.Parse(k1_LR9.Text);
                int s = int.Parse(s1_LR9.Text);
                int m = int.Parse(m1_LR9.Text);
                double v = double.Parse(v1_LR9.Text);

                double C = Math.Pow(n, k);
                double t = Math.Round(C / s / 60 / 60 / 24, 1);
                t = Round_LR9(t, 1);
                if (v != 0 || m != 0)
                {
                    double T = t * v;
                    T = Round_LR9(T / m, 2);
                    T -= 0.1;
                    //T = Round_LR9(T / 60, 2);
                    //T = Round_LR9(T / 60, 2);
                    //T = Round_LR9(T / 24, 2);
                    Res1_LR9.Text = (T + t).ToString();
                }
                else
                    Res1_LR9.Text = t.ToString();
            }
            catch (Exception) { }
        }

        private void Apply2_LR9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(n2_LR9.Text);
                int t = int.Parse(t2_LR9.Text);
                int s = int.Parse(s2_LR9.Text);
                BigInteger C = s * t * 365 * 24;
                C *= 60;
                C *= 60;
                double k = BigInteger.Log(C, n);
                Res2_LR9.Text = Math.Round(k).ToString();
            }
            catch (Exception) { }
        }

        private void Apply3_LR9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double k = int.Parse(k3_LR9.Text);
                int t = int.Parse(t3_LR9.Text);
                int s = int.Parse(s3_LR9.Text);
                BigInteger C = s * t * 365 * 24;
                C *= 60;
                C *= 60;
                //double n = (double)BigInteger.Pow(C, (int)(1 / k));
                double n = Math.Pow((double)C, 1 / k);
                Res3_LR9.Text = Math.Round(n).ToString();
            }
            catch (Exception) { }
        }

        private void SixVar_LR9_Click(object sender, RoutedEventArgs e)
        {
            n1_LR9.Text = "118";
            k1_LR9.Text = "9";
            s1_LR9.Text = "50";
            m1_LR9.Text = "7";
            v1_LR9.Text = "12";

            n2_LR9.Text = "118";
            t2_LR9.Text = "90";
            s2_LR9.Text = "50";

            k3_LR9.Text = "11";
            t3_LR9.Text = "90";
            s3_LR9.Text = "50";
        }

        private void ElevenVar_LR9_Click(object sender, RoutedEventArgs e)
        {
            n1_LR9.Text = "33";
            k1_LR9.Text = "15";
            s1_LR9.Text = "30";
            m1_LR9.Text = "0";
            v1_LR9.Text = "0";

            n2_LR9.Text = "45";
            t2_LR9.Text = "50";
            s2_LR9.Text = "30";

            k3_LR9.Text = "6";
            t3_LR9.Text = "90";
            s3_LR9.Text = "100";
        }
        //-------------------------------------------------------------
        //----------------------лаба 10-------------------------------
        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            punkt = 1;
            cl.IsEnabled = false;
            creating_LR9 = true;
            laboratoryWork_6.Visibility = Visibility.Visible;
            TranslateTransform tr1 = new TranslateTransform();
            ShifrGrid2_LR6.RenderTransform = tr1;
            DoubleAnimation animX = new DoubleAnimation();
            animX.From = -800;
            animX.To = 0;
            animX.Duration = TimeSpan.FromSeconds(0.01);
            animX.EasingFunction = new SexticEase();
            tr1.BeginAnimation(TranslateTransform.XProperty, animX);
            ShifrGrid_LR6.Opacity = 0;
            ShifrGrid_LR6_Copy.Opacity = 0;
            if (sts)
            {
                ShifrGrid_LR6_Copy.Visibility = Visibility.Visible;
                ShifrGrid_LR6_Copy.Opacity = 1;
                butKey_LR6_Copy1.Visibility = Visibility.Visible;
            }
            else
            {
                ShifrGrid_LR6_Copy.Visibility = Visibility.Hidden;
                ShifrGrid_LR6_Copy.Opacity = 0;
                butKey_LR6_Copy1.Visibility = Visibility.Hidden;
            }
            if (!sts)
            {
                AnumGridEL4_LR6.Visibility = Visibility.Visible;
                butGen_LR6_Copy.Visibility = Visibility.Visible;
            }
            if (grigshifrlr6)
            {
                ShifrGrid_LR6.Visibility = Visibility.Visible;
                ShifrGrid_LR6.Opacity = 1;
            }
            else
            {
                ShifrGrid_LR6.Visibility = Visibility.Hidden;
                ShifrGrid_LR6.Opacity = 0;
            }

            AnimGrid.Interval = new TimeSpan(0, 0, 0, 0, 50);
            AnimGrid.Tick += new EventHandler(dispatcherTimer_Tick1);

            AnimText1.Interval = new TimeSpan(0, 0, 0, 0, 10);
            AnimText1.Tick += new EventHandler(dispatcherTimer_Tick2);

            OpacityShifr.Interval = new TimeSpan(0, 0, 0, 0, 10);
            OpacityShifr.Tick += new EventHandler(dispatcherTimer_Tick5);

            ShifrGridTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            ShifrGridTimer.Tick += new EventHandler(dispatcherTimer_Tick3);

            ShifrGridTimer2.Interval = new TimeSpan(0, 0, 0, 0, 50);
            ShifrGridTimer2.Tick += new EventHandler(dispatcherTimer_Tick4);

            animationforgrids.Interval = new TimeSpan(0, 0, 0, 0, 50);
            animationforgrids.Tick += new EventHandler(dispatcherTimer_TickForgrids);

            animationforgridsTxt.Interval = new TimeSpan(0, 0, 0, 0, 10);
            animationforgridsTxt.Tick += new EventHandler(dispatcherTimer_TickForgrids2);


            ShifGrid_1.Interval = new TimeSpan(0, 0, 0, 0, 50);
            ShifGrid_1.Tick += new EventHandler(dispatcherTimer_TickOP_);

            OpacityShifr_1.Interval = new TimeSpan(0, 0, 0, 0, 10);
            OpacityShifr_1.Tick += new EventHandler(dispatcherTimer_TickOP);

            timerFor2Shifr_LR6.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timerFor2Shifr_LR6.Tick += new EventHandler(dispatcherTimer_TickShifr2);

            laboratoryWork_6.Visibility = Visibility.Visible;
            Grtemp.IsEnabled = false;
            TranslateTransform tr = new TranslateTransform();
            GridList[5].RenderTransform = tr;
            DoubleAnimation animY = new DoubleAnimation();
            animY.From = 0;
            animY.To = -400;
            animY.Duration = TimeSpan.FromSeconds(speed);
            animY.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.YProperty, animY);
            statusLab[5] = true;
        }
        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            punkt = 2;
            Inp_LR7.Text = ForLR7_LR10.Text;
            creating_LR9 = true;
            laboratory_work7.Visibility = Visibility.Visible;
            Grtemp.IsEnabled = false;
            TranslateTransform tr = new TranslateTransform();
            GridList[6].RenderTransform = tr;
            DoubleAnimation animY = new DoubleAnimation();
            animY.From = 0;
            animY.To = -400;
            animY.Duration = TimeSpan.FromSeconds(speed);
            animY.EasingFunction = new SexticEase();
            tr.BeginAnimation(TranslateTransform.YProperty, animY);
            statusLab[6] = true;
        }
        private void Button_Click_22(object sender, RoutedEventArgs e)// основное
        {
            ststus_LR10.Foreground = Brushes.Gray;
            ststus_LR10.Text = "message is not verified";
            var ECP = new List<BigInteger>();
            try
            {
                for (int i = 0; i < Hesh_LR10.Text.Length; i++)
                    ECP.Add(BigInteger.Pow(Hesh_LR10.Text[i], Convert.ToInt32(key_LR10.Text)) % Convert.ToInt32(keyU2_LR10.Text));
            } catch (Exception) { }
            GMess_LR10.Text = ForLR7_LR10.Text;
            ECP_LR10.Text = string.Join("-", ECP);

            ket_LR10.Text = keyU_LR10.Text + "-" + keyU2_LR10.Text;
        }
        private void Button_Click_23(object sender, RoutedEventArgs e)// проверка подписи
        {
            string TrueECP = "";
            try
            {
                foreach (string key in ECP_LR10.Text.Split('-'))
                    TrueECP += (char)(BigInteger.Pow(Convert.ToInt32(key), Convert.ToInt32(keyU_LR10.Text)) % Convert.ToInt32(keyU2_LR10.Text));

                if (TrueECP == "" || GMess_LR10.Text == "")
                    throw new Exception("Ты шо???");
                Console.WriteLine(TrueECP);
                if (MD5_LR7.Text == TrueECP)
                {
                    ststus_LR10.Text = "verification was successful";
                    ststus_LR10.Foreground = Brushes.Green;
                }
                else
                {
                    ststus_LR10.Text = "verification failed";
                    ststus_LR10.Foreground = Brushes.Red;
                }
            }
            catch (Exception)
            {
                ststus_LR10.Text = "verification failed";
                ststus_LR10.Foreground = Brushes.Red;
            }
        }
        //-------------------------ЛР11-------------------------------
        List<Grid> grlistfor11 = new List<Grid>();
        int idgr = 0;
        private void idpp(object sender, RoutedEventArgs e)
        {
            idgr++;
            if (idgr == 13)
                idgr--;
            grlistfor11[idgr].Visibility = Visibility.Visible;
            grlistfor11[idgr - 1].Visibility = Visibility.Hidden;
        }
        private void idmm(object sender, RoutedEventArgs e)
        {
            idgr--;
            if (idgr == -1)
                idgr++;
            grlistfor11[idgr].Visibility = Visibility.Visible;
            grlistfor11[idgr + 1].Visibility = Visibility.Hidden;

        }
    }
}