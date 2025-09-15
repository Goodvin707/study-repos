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
    public partial class UsersControl : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;

        MainMenu mainMenu;
        public UsersControl(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT * FROM Пользователи";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Пользователи");
            dataGridView1.DataSource = ds.Tables["Пользователи"].DefaultView;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void UsersControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainMenu.Show();
            myConnection.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddUser f = new AddUser();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string CommandText = $"INSERT INTO [Пользователи] (Логин, Пароль, [Номер телефона]) VALUES ('{f.textBox1.Text}', '{f.textBox2.Text}', '{f.maskedTextBox1.Text}')";
                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM Пользователи";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Пользователи");
                dataGridView1.DataSource = ds.Tables["Пользователи"].DefaultView;
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (User.Login != dataGridView1[0,dataGridView1.CurrentRow.Index].Value.ToString())
            {
                DeleleRow f = new DeleleRow();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    string ID = (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString();
                    string CommandText = "DELETE FROM Пользователи WHERE Логин = '" + ID + "'";
                    My_Execute_Non_Query(CommandText);

                    string query = "SELECT * FROM Пользователи";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds, "Пользователи");
                    dataGridView1.DataSource = ds.Tables["Пользователи"].DefaultView;
                }
            }
            else
                MessageBox.Show("Нельзя удалить самого себя", "Ошибка удаления");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM Пользователи WHERE Логин Like '{textBox1.Text}%'";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Пользователи");
            dataGridView1.DataSource = ds.Tables["Пользователи"].DefaultView;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Autorize a = new Autorize();
            a.Show();
            this.Hide();
        }
    }
}