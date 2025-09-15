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
    public partial class Priem : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;

        MainMenu main;
        public Priem(MainMenu main)
        {
            InitializeComponent();
            this.main = main;
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NonClientAreaEnabled;

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            string query = $"SELECT Фамилия, Имя, Отчество, Кабинет FROM Врачи ORDER BY Код";

            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = query;
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                listBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + "| каб." + reader.GetValue(3));

            comboBox1.SelectedIndex = 0;
            monthCalendar1.Focus();
        }

        private void Priem_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
            myConnection.Close();
        }

        private void listbox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                monthCalendar1.RemoveAllBoldedDates();
                string query2 = $"SELECT * FROM Врачи";
                OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(query2, connectString);

                DataSet ds2 = new DataSet();
                dataAdapter2.Fill(ds2, "[Врачи]");


                for (int i = 0; i < ds2.Tables["[Врачи]"].Rows.Count; i++)
                {
                    if (listBox1.SelectedItem.ToString() == ds2.Tables["[Врачи]"].Rows[i][2] + " " + ds2.Tables["[Врачи]"].Rows[i][3] + " " + ds2.Tables["[Врачи]"].Rows[i][4] + "| каб." + ds2.Tables["[Врачи]"].Rows[i][5])
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
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = $"SELECT Фамилия, Имя, Отчество, Кабинет FROM Врачи Where {comboBox1.SelectedItem} Like '{textBox1.Text}%' ORDER BY Код";

            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = query;
            OleDbDataReader reader = myCommand.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
                listBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + "| каб." + reader.GetValue(3));
        }
    }
}