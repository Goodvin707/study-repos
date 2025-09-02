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
    public partial class AddPoruch : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddPoruch()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Название FROM Кафедры";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0));

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Название FROM Дисциплины";
            reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox2.Items.Add(reader.GetValue(0));

            myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Код, Название, Курс FROM Группы";
            reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox3.Items.Add(reader.GetValue(0) + " " + reader.GetValue(1) + " Курс: " + reader.GetValue(2));
            conn.Close();
        }

        public AddPoruch(int semestr) : this()
        {
            Text = "Изменить поручение";
            button1.Text = "Изменить";
            numericUpDown1.Value = semestr;
        }
        
        private void button1_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}