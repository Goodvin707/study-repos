using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.Net.Mail;

namespace WpfApp9.Resourses.BugReport
{
    /// <summary>
    /// Логика взаимодействия для BugReport.xaml
    /// </summary>
    public partial class BugReport : Window
    {
        public BugReport()
        {
            InitializeComponent();
        }

        private void SendEmailAsync()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("soft.pul@mail.ru");
            mail.To.Add(new MailAddress("softpul.razrab@mail.ru"));
            mail.Subject = "Сообщение о баге";
            mail.Body = repornA.Text;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.ru";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("soft.pul@mail.ru", "wwceK4dNeRSX7NnvZ48v");
            try { client.Send(mail); } catch (Exception) { Console.WriteLine("Проверьте введенный адрес и подключение к интернету", "Ошибка отправки"); }
        }
        private void Button_ClickA(object sender, RoutedEventArgs e)
        {
            SendEmailAsync();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                imgReport.Source = new BitmapImage(new Uri(filename));
               
            }
        }
        private void MouseMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
               this.DragMove();            
        }

        private void Button_ClickB(object sender, RoutedEventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("soft.pul@mail.ru");
            mail.To.Add(new MailAddress("softpul.razrab@mail.ru"));
            mail.Subject = "Внесение предложения в разработку ПО";
            mail.Body = reportB.Text;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.mail.ru";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("soft.pul@mail.ru", "wwceK4dNeRSX7NnvZ48v");
            try { client.Send(mail); } catch (Exception) { Console.WriteLine("Проверьте введенный адрес и подключение к интернету", "Ошибка отправки"); }
            this.Close();
        }

        private void Button_ClickC(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
