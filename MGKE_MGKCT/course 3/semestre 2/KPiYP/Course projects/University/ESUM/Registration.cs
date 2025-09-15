using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESUM
{
    public partial class Registration : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        private OleDbConnection myConnection;

        Autorise autorize;
        List<string> logins = new List<string>();
        public Registration(Autorise autorize)
        {
            InitializeComponent();
            this.autorize = autorize;

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "SELECT Логин FROM Пользователи";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                logins.Add(reader.GetValue(0).ToString());
            myConnection.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e) => button1.BackColor = Color.LightGreen;

        private void button1_MouseLeave(object sender, EventArgs e) => button1.BackColor = Color.CornflowerBlue;

        private void button2_MouseEnter(object sender, EventArgs e) => button2.BackColor = Color.LightGreen;

        private void button2_MouseLeave(object sender, EventArgs e) => button2.BackColor = Color.CornflowerBlue;

        private void button1_Click(object sender, EventArgs e)
        {
            if (logins.Contains(textBox1.Text))
                MessageBox.Show("Пользователь с таким логином уже существует", "Увы");
            else
            {
                if (!string.IsNullOrEmpty(textBox3.Text?.Trim()))
                {
                    const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    var email = textBox3.Text.Trim().ToLowerInvariant();

                    if (Regex.Match(email, pattern).Success)
                    {
                        string CommandText = $"INSERT INTO Пользователи (Логин, Пароль, Почта) VALUES ('{textBox1.Text}', '{User.GetHash(textBox2.Text)}', '{textBox3.Text}')";
                        My_Execute_Non_Query(CommandText);
                        MessageBox.Show("Регистрация прошла успешно", "Ура");
                        Close();
                    }
                    else
                        MessageBox.Show("Почта введена некорректно", "Увы");
                }
                else
                    MessageBox.Show("Почта не указана", "Увы");
            }
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void Registration_FormClosed(object sender, FormClosedEventArgs e) => autorize.Show();

        public void My_Execute_Non_Query(string CommandText)
        {
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = CommandText;
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 4 && textBox2.Text.Length >= 4)
                button1.Enabled = true;
            else
                button1.Enabled = false;
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