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

namespace ESUM
{
    public partial class Chart : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        OleDbConnection myConnection;
        public Chart()
        {
            InitializeComponent();

            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Код, Название FROM Дисциплины";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1));

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Код, Фамилия, Имя, Отчество, Категория FROM Преподаватели";
            reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox2.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3) + " " + reader.GetValue(4));

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Студенты.Код, Фамилия, Имя, Отчество, [Код группы], Группы.Название FROM Студенты, Группы Where [Код группы]=Группы.[Код]";
            reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox3.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3) + " " + reader.GetValue(4) + " " + reader.GetValue(5));
            conn.Close();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;


            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adapt = new OleDbDataAdapter("Select Фамилия + ' ' + Имя + ' ' + Отчество as ФИО, Оценка from Контроль, Студенты where Студенты.Код=Контроль.[Код студента]", myConnection);
            adapt.Fill(ds);
            chart1.DataSource = ds;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.Titles.Add("Успеваемость");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select Фамилия + ' ' + Имя + ' ' + Отчество as ФИО, Оценка from Контроль, Студенты where Студенты.Код=Контроль.[Код студента]";

            if (checkBox1.Checked)
                query += $" and Контроль.[Код дисциплины]={comboBox1.SelectedItem.ToString().Split(' ')[0]}";
            if (checkBox2.Checked)
                query += $" and Контроль.[Код преподавателя]={comboBox2.SelectedItem.ToString().Split(' ')[0]}";
            if (checkBox3.Checked)
                query += $" and Контроль.[Код студента]={comboBox3.SelectedItem.ToString().Split(' ')[0]}";
            if (checkBox4.Checked)
                query += $" and Контроль.[Форма контроля]='{comboBox4.SelectedItem}'";

            chart1.Series[0].Points.Clear();
            DataSet ds = new DataSet();
            OleDbDataAdapter adapt = new OleDbDataAdapter(query, myConnection);
            adapt.Fill(ds);
            chart1.DataSource = ds;
            myConnection.Close();
        }

        private void Chart_FormClosed(object sender, FormClosedEventArgs e) => myConnection.Close();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                comboBox1.Enabled = true;
            else
                comboBox1.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                comboBox2.Enabled = true;
            else
                comboBox2.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                comboBox3.Enabled = true;
            else
                comboBox3.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
                comboBox4.Enabled = true;
            else
                comboBox4.Enabled = false;
        }
    }
}