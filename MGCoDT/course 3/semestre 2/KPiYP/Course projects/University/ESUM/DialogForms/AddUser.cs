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
    public partial class AddUser : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        private OleDbConnection myConnection;

        List<string> logins = new List<string>();
        public AddUser()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "SELECT Логин FROM Пользователи";
            OleDbDataReader reader = myCommand.ExecuteReader();
            while (reader.Read())
                logins.Add(reader.GetValue(0).ToString());
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 4)
                MessageBox.Show("Логин не может состоять из 3-х и менее символов", "Ошибка ввода");
            else if (textBox2.Text.Length <= 4)
                MessageBox.Show("Пароль не может состоять из 3-х и менее символов", "Ошибка ввода");
            else if (logins.Contains(textBox1.Text))
                MessageBox.Show("Пользователь с таким логином уже существует", "Увы");
            else
            {
                if (!string.IsNullOrEmpty(textBox3.Text?.Trim()))
                {
                    const string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                    var email = textBox3.Text.Trim().ToLowerInvariant();

                    if (Regex.Match(email, pattern).Success)
                        DialogResult = DialogResult.OK;
                    else
                        MessageBox.Show("Почта введена некорректно", "Увы");
                }
                else
                    MessageBox.Show("Почта не указана", "Увы");
            }
            if (DialogResult != DialogResult.OK)
                DialogResult = DialogResult.None;
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}