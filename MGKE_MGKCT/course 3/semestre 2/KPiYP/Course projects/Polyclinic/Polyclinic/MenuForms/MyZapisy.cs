using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Polyclinic.DialogForms;
using exportWord = Microsoft.Office.Interop.Word;

namespace Polyclinic
{
    public partial class MyZapisy : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;

        MainMenu mainMenu;
        List<DateTime> dates = new List<DateTime>();
        List<int> vrachKeys = new List<int>(); 
        public MyZapisy(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NonClientAreaEnabled;

            label5.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            label1.Text = "Логин: " + User.Login;

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = $"Select [Дата и время], [Код врача] FROM Приемы WHERE [Логин пользователя]='{User.Login}'";
            OleDbDataReader reader = myCommand.ExecuteReader();

            string date;
            while(reader.Read())
            {
                date = reader.GetValue(0).ToString();
                monthCalendar1.AddBoldedDate(new DateTime(Convert.ToInt32(date.Split('.')[2].Remove(date.Split('.')[2].IndexOf(' '), date.Split('.')[2].Length - date.Split('.')[2].IndexOf(' '))), Convert.ToInt32(date.Split('.')[1]), Convert.ToInt32(date.Split('.')[0])));
                dates.Add(DateTime.Parse(date));
                vrachKeys.Add(reader.GetInt32(1));
            }

            myCommand = myConnection.CreateCommand();
            myCommand.CommandText = $"SELECT [Номер телефона] FROM Пользователи WHERE [Логин]='{User.Login}'";
            OleDbDataReader reader2 = myCommand.ExecuteReader();
            reader2.Read();
            label3.Text = "Номер телефона: " + reader2.GetValue(0).ToString();
        }

        private void MyZapisy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            mainMenu.Show();
            myConnection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e) => label5.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;

        private void exportToWord(object sender, EventArgs e)
        {
            string s = "";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = $"Select * FROM Приемы WHERE [Логин пользователя]='{User.Login}'";
            OleDbDataReader reader = myCommand.ExecuteReader();
            s += "[" + reader.GetName(1) + "]    [" + reader.GetName(2) + "]    [" + reader.GetName(3) + "]    [" + reader.GetName(4) + "]\n";
            while (reader.Read())
            {
                s += reader.GetValue(1) + "\t\t\t" + reader.GetValue(2) + "\t\t\t" + reader.GetValue(3) + "\t\t" + reader.GetValue(4) + "\n";
            }

            exportWord.Application wordapp = new exportWord.Application();
            wordapp.Visible = true;
            exportWord.Document worddoc;
            object wordobj = System.Reflection.Missing.Value;
            worddoc = wordapp.Documents.Add(ref wordobj);
            wordapp.Selection.TypeText(s);
            wordapp = null;
            myConnection.Close();
        }

        private void exportToEmail(object sender, EventArgs e)
        {
        zxc:
            SendOnEmail onEmail = new SendOnEmail();
            if (onEmail.ShowDialog() == DialogResult.OK)
            {
                string email = onEmail.textBox1.Text;
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("albert.gonchiy@bk.ru");
                    mail.To.Add(new MailAddress(email));
                    mail.Subject = $"Мои записи";
                    mail.Body = $"<h2><center><font face=\"Segoe Print\">Список моих записей</center></h2><br>";
                    mail.Body += "<h4><font face=\"Arial\">";
                    
                    myConnection = new OleDbConnection(connectString);
                    myConnection.Open();
                    OleDbCommand myCommand = myConnection.CreateCommand();
                    myCommand.CommandText = $"Select * FROM Приемы WHERE [Логин пользователя]='{User.Login}'";
                    OleDbDataReader reader = myCommand.ExecuteReader();
                    mail.Body += "[" + reader.GetName(1) + "]    [" + reader.GetName(2) + "]    [" + reader.GetName(3) + "]    [" + reader.GetName(4) + "]<br>";
                    while (reader.Read())
                    {
                        mail.Body += reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3) + " " + reader.GetValue(4) + "<br>";
                    }
                    mail.Body += "</h4>";
                    mail.IsBodyHtml = true;
                    
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.mail.ru";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("albert.gonchiy@bk.ru", "5cJxkxNeaBuBU21qkqbS");
                    client.Send(mail);
                } catch (Exception) { MessageBox.Show("Проверьте введенный адрес и подключение к интернету", "Ошибка отправки"); goto zxc; }

                MessageBox.Show("Письмо отправлено на " + email, "Отправка данных на электронный ящик");
                onEmail.Close();
                myConnection.Close();
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (monthCalendar1.BoldedDates.Contains(monthCalendar1.SelectionStart.Date))
            {
                for (int i = 0; i < dates.Count; i++)
                {
                    if (dates[i].Date == monthCalendar1.SelectionStart.Date)
                    {
                        OleDbCommand myCommand = myConnection.CreateCommand();
                        myCommand.CommandText = $"SELECT [Код врача] FROM Приемы WHERE [Дата и время]=#{dates[i].Date.Month}/{dates[i].Date.Day}/{dates[i].Date.Year} {dates[i].Hour}:{dates[i].Minute}:{dates[i].Second}#";
                        OleDbDataReader reader2 = myCommand.ExecuteReader();
                        reader2.Read();
                        for (int j = 0; j < vrachKeys.Count; j++)
                        {
                            if (vrachKeys[j] == reader2.GetInt32(0))
                            {
                                myCommand = myConnection.CreateCommand();
                                myCommand.CommandText = $"SELECT Фамилия, Имя, Отчество FROM Врачи WHERE [Код]={vrachKeys[j]}";
                                reader2 = myCommand.ExecuteReader();
                                reader2.Read();

                                toolTip1.SetToolTip(monthCalendar1, "Вы записаны к " + reader2.GetValue(0) + " " + reader2.GetValue(1) + " " + reader2.GetValue(2) + "\nна " + dates[i].ToString());
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}