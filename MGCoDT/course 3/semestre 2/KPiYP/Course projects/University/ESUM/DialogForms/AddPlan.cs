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
    public partial class AddPlan : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public AddPlan()
        {
            InitializeComponent();
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = "SELECT Название FROM Дисциплины";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                comboBox1.Items.Add(reader.GetValue(0));
            conn.Close();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
        }

        public AddPlan(string kurs, string semestr, string vidZanatia, string formControl, int hours) : this()
        {
            Text = "Изменить учебный план";
            button1.Text = "Изменить";
            comboBox2.SelectedItem = kurs;
            comboBox3.SelectedItem = semestr;
            comboBox4.SelectedItem = vidZanatia;
            comboBox5.SelectedItem = formControl;
            numericUpDown1.Value = hours;
        }

        private void button1_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}