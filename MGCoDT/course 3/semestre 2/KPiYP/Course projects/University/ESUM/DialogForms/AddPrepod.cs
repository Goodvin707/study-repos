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
    public partial class AddPrepod : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddPrepod()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Название FROM Кафедры";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0));
            conn.Close();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public AddPrepod(string f, string i, string o, string kategory, string date, int chidCount, int zp, string sex) : this()
        {
            Text = "Изменить преподавателя";
            button1.Text = "Изменить";
            textBox1.Text = f;
            textBox2.Text = i;
            textBox3.Text = o;
            comboBox2.SelectedItem = kategory;
            dateTimePicker1.Text = date;
            numericUpDown1.Value = chidCount;
            numericUpDown2.Value = zp;
            if (sex == "ж")
                radioButton2.Checked = true;
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