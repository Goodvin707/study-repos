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
    public partial class AddGroup : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddGroup()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Название FROM Факультеты";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0));
            conn.Close();
            comboBox1.SelectedIndex = 0;
        }

        public AddGroup(string name, int curs) : this()
        {
            Text = "Изменить научную тему";
            button1.Text = "Изменить";
            textBox1.Text = name;
            numericUpDown1.Value = curs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Поле \"Название\" не заполнено", "!");
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}