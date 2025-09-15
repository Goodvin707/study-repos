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
    public partial class AddDipl : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddDipl()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Фамилия, Имя, Отчество, [Код группы] FROM Студенты";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3));

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Фамилия, Имя, Отчество, Категория FROM Преподаватели";
            reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox2.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3));
            conn.Close();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public AddDipl(string tema)
        {
            Text = "Изменить дипломную работу";
            button1.Text = "Изменить";
            textBox1.Text = tema;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Поле \"Тема\" не заполнено", "!");
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}