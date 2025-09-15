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
    public partial class AddScienceTema : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddScienceTema()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Фамилия, Имя, Отчество, Категория FROM Преподаватели";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3));
            conn.Close();
            comboBox1.SelectedIndex = 0;
        }

        public AddScienceTema(string tema) : this()
        {
            Text = "Изменить научную тему";
            button1.Text = "Изменить";
            textBox1.Text = tema;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Поле не заполнено", "!");
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}