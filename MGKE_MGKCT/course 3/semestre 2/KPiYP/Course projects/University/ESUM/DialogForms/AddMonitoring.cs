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
    public partial class AddMonitoring : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddMonitoring()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Название FROM Дисциплины";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0));

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Фамилия, Имя, Отчество, Категория FROM Преподаватели";
            reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox2.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3));

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Фамилия, Имя, Отчество, [Код группы], Группы.Название FROM Студенты, Группы Where [Код группы]=Группы.[Код]";
            reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox3.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3) + " " + reader.GetValue(4));
            conn.Close();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        public AddMonitoring(int mark, string date, string control)
        {
            Text = "Изменить контроль";
            button1.Text = "Изменить";
            numericUpDown1.Value = mark;
            comboBox4.SelectedItem = control;
        }

        private void button1_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}