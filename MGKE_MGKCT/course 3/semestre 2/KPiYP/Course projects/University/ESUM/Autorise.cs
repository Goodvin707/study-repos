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
    public partial class Autorise : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        public Autorise()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e) => button1.BackColor = Color.LightGreen;

        private void button1_MouseLeave(object sender, EventArgs e) => button1.BackColor = Color.CornflowerBlue;

        private void button2_MouseEnter(object sender, EventArgs e) => button2.BackColor = Color.LightGreen;

        private void button2_MouseLeave(object sender, EventArgs e) => button2.BackColor = Color.CornflowerBlue;

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = $"Select * From Пользователи Where Логин='{textBox1.Text}' AND Пароль='{User.GetHash(textBox2.Text)}'";
            OleDbDataReader reader = myCommand.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                User.Login = textBox1.Text;
                User.Password = textBox2.Text;
                User.Email = reader.GetValue(2).ToString();
                Hide();
                MainWindow main = new MainWindow();
                main.Show();
            }
            else
                MessageBox.Show("Не найден пользователь с введенными данными", "Ошибка входа");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Registration registration = new Registration(this);
            registration.Show();
        }

        private void Autorise_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }
    }
}