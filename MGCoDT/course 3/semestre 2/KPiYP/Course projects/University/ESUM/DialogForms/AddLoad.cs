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
    public partial class AddLoad : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddLoad()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Фамилия, Имя, Отчество, Категория FROM Преподаватели";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3));

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Название FROM Дисциплины";
            reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox2.Items.Add(reader.GetValue(0));
            conn.Close();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        public AddLoad(int hours, int semestr) : this()
        {
            Text = "Изменить преподавателя";
            button1.Text = "Изменить";
            numericUpDown1.Value = hours;
            numericUpDown2.Value = semestr;
        }

        private void button1_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}