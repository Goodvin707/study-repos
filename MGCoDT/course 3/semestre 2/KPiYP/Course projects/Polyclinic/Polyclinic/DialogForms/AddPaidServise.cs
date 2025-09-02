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

namespace Polyclinic.DialogForms
{
    public partial class AddPaidServise : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;
        public AddPaidServise()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = $"SELECT Фамилия, Имя, Отчество, Кабинет FROM Врачи ORDER BY Код";

            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = query;
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3));
            myConnection.Close();

            comboBox1.SelectedIndex = 0;
        }

        public AddPaidServise(string title, double cost)
        {
            InitializeComponent();
            Text = "Изменить платную услугу";
            button1.Text = "Изменить";
            textBox1.Text = title;
            numericUpDown1.Text = cost.ToString();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = $"SELECT Фамилия, Имя, Отчество, Кабинет FROM Врачи ORDER BY Код";

            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = query;
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3));
            myConnection.Close();

            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Название не может быть пустым", "Ошибка ввода");
            else
                DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}