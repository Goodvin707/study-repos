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
    public partial class AddVrach : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;

        public AddVrach()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = $"SELECT Название FROM Специальности ORDER BY Код";

            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = query;
            OleDbDataReader reader = myCommand.ExecuteReader();
                while (reader.Read())
                    comboBox1.Items.Add(reader.GetValue(0));
            myConnection.Close();

            comboBox1.SelectedIndex = 0;
        }

        public AddVrach(string f, string i, string o, string kab, string schedule)
        {
            InitializeComponent();
            Text = "Редактировать врача";
            button1.Text = "Изменить";

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = $"SELECT Название FROM Специальности ORDER BY Код";

            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = query;
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0));
            myConnection.Close();


            comboBox1.SelectedIndex = 0;
            textBox1.Text = f;
            textBox2.Text = i;
            textBox3.Text = o;
            textBox4.Text = kab;
            for (int j = 0; j < schedule.Length; j++)
            {
                switch (schedule[j])
                {
                    case '1': checkBox1.Checked = true; break;
                    case '2': checkBox2.Checked = true; break;
                    case '3': checkBox3.Checked = true; break;
                    case '4': checkBox4.Checked = true; break;
                    case '5': checkBox5.Checked = true; break;
                }
            }
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Фамилия не может быть пустой", "Ошибка ввода");
            else if (textBox2.Text == "")
                MessageBox.Show("Имя не может быть пустым", "Ошибка ввода");
            else if (textBox3.Text == "")
                MessageBox.Show("Отчество не может быть пустым", "Ошибка ввода");
            else if (textBox4.Text == "")
                MessageBox.Show("Кабинет не может быть пустым", "Ошибка ввода");
            else
                DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
    }
}