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
    public partial class AddStud : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddStud()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Код, Название, Курс FROM Группы";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " Курс: " + reader.GetValue(2));
            conn.Close();
            comboBox1.SelectedIndex = 0;
        }

        public AddStud(string f, string i, string o, string sex, string date, int year, string children,  int stip) : this()
        {
            Text = "Изменить студента";
            button1.Text = "Изменить";
            textBox1.Text = f;
            textBox2.Text = i;
            textBox3.Text = o;
            if (sex == "ж")
                radioButton2.Checked = true;
            dateTimePicker1.Text = date;
            numericUpDown1.Value = year;
            if (children == "True")
                checkBox1.Checked = true;
            numericUpDown2.Value = stip;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Поле \"Фамилия\" не заполнено", "!");
            else if (textBox2.Text == "")
                MessageBox.Show("Поле \"Имя\" не заполнено", "!");
            else if (textBox3.Text == "")
                MessageBox.Show("Поле \"Отчество\" не заполнено", "!");
            else
                DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}