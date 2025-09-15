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

namespace Polyclinic
{
    public partial class Registration : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;

        Autorize autorize;
        List<string> logins = new List<string>();
        Point lastPoint;
        public Registration(Autorize autorize)
        {
            InitializeComponent();
            this.autorize = autorize;

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "SELECT Логин FROM Пользователи";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while(reader.Read())
                logins.Add(reader.GetValue(0).ToString());
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (logins.Contains(textBox1.Text))
                MessageBox.Show("Пользователь с таким логином уже существует", "Увы");
            else
            {
                string CommandText = $"INSERT INTO Пользователи (Логин, Пароль, [Номер телефона]) VALUES ('{textBox1.Text}', '{textBox2.Text}', '{maskedTextBox1.Text}')";
                My_Execute_Non_Query(CommandText);
                MessageBox.Show("Регистрация прошла успешно", "Ура");
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void Registration_FormClosed(object sender, FormClosedEventArgs e) => autorize.Show();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 4 && textBox2.Text.Length >= 4 && maskedTextBox1.MaskCompleted)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        public void My_Execute_Non_Query(string CommandText)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = CommandText;
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        private void Registration_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Registration_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }
    }
}