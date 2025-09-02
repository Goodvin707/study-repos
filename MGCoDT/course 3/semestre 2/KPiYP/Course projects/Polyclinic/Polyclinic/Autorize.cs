using Polyclinic.DialogForms;
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
    public partial class Autorize : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";

        Point lastPoint;
        public Autorize()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => Application.Exit();

        private void button2_Click(object sender, EventArgs e) => new HelpForm().Show();

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = $"Select * From Пользователи Where Логин='{textBox1.Text}' AND Пароль='{textBox2.Text}'";
            OleDbDataReader reader = myCommand.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                User.Login = textBox1.Text;

                Hide();
                MainMenu main = new MainMenu();
                main.Show();
            }
            else
                MessageBox.Show("Не найден пользователь с введенными данными", "Ошибка входа");
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration species = new Registration(this);
            species.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                button3.Enabled = false;
            else
                button3.Enabled = true;
        }

        private void Autorize_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);

        private void Autorize_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }
    }
}