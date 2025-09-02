using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic
{
    public partial class Zapisatsya : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;
        OleDbDataAdapter dataAdapter2;

        MainMenu mainMenu;
        Dictionary<string, string> species = new Dictionary<string, string>();
        public Zapisatsya(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            string query2 = $"SELECT * FROM Врачи";
            dataAdapter2 = new OleDbDataAdapter(query2, connectString);

            string query = $"SELECT * FROM Специальности";
            OleDbDataAdapter dataAdapter1 = new OleDbDataAdapter(query, connectString);
            DataSet ds1 = new DataSet();

            dataAdapter1.Fill(ds1, "[Специальности]");
            for (int i = 0; i < ds1.Tables["[Специальности]"].Rows.Count; i++)
            {
                species.Add(ds1.Tables["[Специальности]"].Rows[i][0].ToString(), ds1.Tables["[Специальности]"].Rows[i][1].ToString());
                comboBox1.Items.Add(ds1.Tables["[Специальности]"].Rows[i][1]);
            }
            comboBox1.SelectedIndex = 0;
            listBox1.SelectedIndex = 0;
        }

        private void Zapisatsya_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker2.Value.AddHours(3);
            label5.Text = "Выбрано: " + comboBox1.SelectedItem + " " + listBox1.SelectedItem + " " + dateTimePicker1.Text + " " + dateTimePicker2.Text;
        }

        private void Zapisatsya_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainMenu.Show();
            myConnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string key = species.FirstOrDefault(x => x.Value == comboBox1.Items[comboBox1.SelectedIndex].ToString()).Key;

            DataSet ds2 = new DataSet();
            dataAdapter2.Fill(ds2, "[Врачи]");

            for (int i = 0; i < ds2.Tables["[Врачи]"].Rows.Count; i++)
            {
                if (ds2.Tables["[Врачи]"].Rows[i][1].ToString() == key)
                    listBox1.Items.Add(ds2.Tables["[Врачи]"].Rows[i][2] + " " + ds2.Tables["[Врачи]"].Rows[i][3] + " " + ds2.Tables["[Врачи]"].Rows[i][4] + " каб." + ds2.Tables["[Врачи]"].Rows[i][5]);
            }
            if (listBox1.Items.Count == 0)
                btnPriem.Enabled = false;
            else
            {
                listBox1.SelectedIndex = 0;
                btnPriem.Enabled = true;
            }
            label5.Text = "Выбрано: " + comboBox1.SelectedItem + " " + listBox1.SelectedItem + " " + dateTimePicker1.Text + " " + dateTimePicker2.Text;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                monthCalendar1.RemoveAllBoldedDates();

                DataSet ds2 = new DataSet();
                dataAdapter2.Fill(ds2, "[Врачи]");

                for (int i = 0; i < ds2.Tables["[Врачи]"].Rows.Count; i++)
                {
                    if (listBox1.Items[listBox1.SelectedIndex].ToString() == ds2.Tables["[Врачи]"].Rows[i][2] + " " + ds2.Tables["[Врачи]"].Rows[i][3] + " " + ds2.Tables["[Врачи]"].Rows[i][4] + " каб." + ds2.Tables["[Врачи]"].Rows[i][5])
                    {
                        string workDays = ds2.Tables["[Врачи]"].Rows[i][6].ToString();
                        for (int ii = 1; ii <= 12; ii++)
                        {
                            for (int j = 1; j <= 31; j++)
                            {
                                try
                                {
                                    DateTime date = new DateTime(2022, ii, j);
                                    switch (date.DayOfWeek)
                                    {
                                        case DayOfWeek.Monday:
                                            if (workDays.Contains('1'))
                                                monthCalendar1.AddBoldedDate(new DateTime(2022, ii, j));
                                            break;
                                        case DayOfWeek.Tuesday:
                                            if (workDays.Contains('2'))
                                                monthCalendar1.AddBoldedDate(new DateTime(2022, ii, j));
                                            break;
                                        case DayOfWeek.Wednesday:
                                            if (workDays.Contains('3'))
                                                monthCalendar1.AddBoldedDate(new DateTime(2022, ii, j));
                                            break;
                                        case DayOfWeek.Thursday:
                                            if (workDays.Contains('4'))
                                                monthCalendar1.AddBoldedDate(new DateTime(2022, ii, j));
                                            break;
                                        case DayOfWeek.Friday:
                                            if (workDays.Contains('5'))
                                                monthCalendar1.AddBoldedDate(new DateTime(2022, ii, j));
                                            break;
                                    }
                                }
                                catch (ArgumentOutOfRangeException) { }
                            }
                        }
                    }
                }
                monthCalendar1.UpdateBoldedDates();
                label5.Text = "Выбрано: " + comboBox1.SelectedItem + " " + listBox1.SelectedItem + " " + dateTimePicker1.Text + " " + dateTimePicker2.Text;
            }
        }

        private void btnPriem_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Month < DateTime.Now.Month || dateTimePicker1.Value.Day < DateTime.Now.Day)
            {
                MessageBox.Show("Нельзя записаться на прошедшую дату", "Ошибка записи");
                if (dateTimePicker1.Value < DateTime.Now)
                    MessageBox.Show("Нельзя записаться на прошедшее время", "Ошибка записи");
            }
            
            else if (!monthCalendar1.BoldedDates.Contains(dateTimePicker1.Value.Date))
                MessageBox.Show("В этот день врач не работает", "Ошибка записи");
            else
            {
                OleDbConnection conn = new OleDbConnection(connectString);
                conn.Open();
                OleDbCommand myCommand = conn.CreateCommand();
                myCommand.CommandText = $"SELECT Код FROM Специальности WHERE Название Like '{comboBox1.SelectedItem}'";
                OleDbDataReader reader = myCommand.ExecuteReader();
                reader.Read();
                string specKey = reader.GetValue(0).ToString();

                myCommand = conn.CreateCommand();
                myCommand.CommandText = $"SELECT Код FROM Врачи WHERE Фамилия Like '{listBox1.SelectedItem.ToString().Split(' ')[0]}' AND Имя Like '{listBox1.SelectedItem.ToString().Split(' ')[1]}' AND Отчество Like '{listBox1.SelectedItem.ToString().Split(' ')[2]}'";
                OleDbDataReader reader2 = myCommand.ExecuteReader();
                if (reader2.HasRows)
                {
                    reader2.Read();
                    string docKey = reader2.GetValue(0).ToString();
                    string dayPriem = dateTimePicker1.Text + " " + dateTimePicker2.Text;

                    string CommandText = "INSERT INTO [Приемы] ([Логин пользователя], [Код специальности], [Код врача], [Дата и время])"
                    + $" VALUES ('{User.Login}', '{specKey}', '{docKey}', '{dayPriem}')";

                    conn.Close();
                    My_Execute_Non_Query(CommandText);
                }
            }
        }

        public void My_Execute_Non_Query(string CommandText)
        {
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = CommandText;
            myCommand.ExecuteNonQuery();
            conn.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) => label5.Text = "Выбрано: " + comboBox1.SelectedItem + " " + listBox1.SelectedItem + " " + dateTimePicker1.Text + " " + dateTimePicker2.Text;
    }
}