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
using System.Xml.Linq;

namespace ESUM
{
    public partial class UserControl : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        OleDbConnection myConnection;

        Stack<string> rows1 = new Stack<string>();
        Stack<string> rows2 = new Stack<string>();
        public UserControl()
        {
            InitializeComponent();

            string query = $"SELECT * FROM Пользователи order by Логин";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, $"[Пользователи]");
            dataGridView1.DataSource = ds.Tables[$"[Пользователи]"].DefaultView;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            comboBox1.SelectedIndex = 0;
        }

        private void UserControl_SizeChanged(object sender, EventArgs e) => dataGridView1.Size = new Size(dataGridView1.Size.Width, Height - 300);

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TopMost = false;
            AddUser f = new AddUser();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string CommandText = $"INSERT INTO [Пользователи] (Логин, Пароль, Почта) VALUES ('{f.textBox1.Text}', '{User.GetHash(f.textBox2.Text)}', '{f.textBox3.Text}')";
                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM Пользователи";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Пользователи");
                dataGridView1.DataSource = ds.Tables["Пользователи"].DefaultView;
                TopMost = true;

                rows1.Push($"D;{f.textBox1.Text};{f.textBox2.Text};{f.textBox3.Text}");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            TopMost = false;
            if (User.Login != dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString())
            {
                DeleteRow f = new DeleteRow("После удаления учетной записи войти в\nнее будет невозможно");
                if (f.ShowDialog() == DialogResult.OK)
                {
                    rows1.Push($"I;{(dataGridView1[0, dataGridView1.CurrentRow.Index].Value)};" +
                        $"{(dataGridView1[1, dataGridView1.CurrentRow.Index].Value)};" +
                        $"{(dataGridView1[2, dataGridView1.CurrentRow.Index].Value)}");

                    string ID = (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString();
                    string CommandText = "DELETE FROM Пользователи WHERE Логин = '" + ID + "'";
                    My_Execute_Non_Query(CommandText);

                    string query = "SELECT * FROM Пользователи";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds, "Пользователи");
                    dataGridView1.DataSource = ds.Tables["Пользователи"].DefaultView;
                    TopMost = true;
                }
            }
            else
                MessageBox.Show("Нельзя удалить самого себя", "Ошибка удаления");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                btnFind.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                btnFind.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string query = "";
            if (radioButton1.Checked)
                query = $"SELECT * FROM Пользователи WHERE {comboBox1.SelectedItem} Like '{textBox1.Text}%'";
            if (radioButton2.Checked)
                query = $"SELECT * FROM Пользователи WHERE {comboBox1.SelectedItem} Like '%{textBox1.Text}'";
            if (radioButton3.Checked)
                query = $"SELECT * FROM Пользователи WHERE {comboBox1.SelectedItem} Like '%{textBox1.Text}%'";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Пользователи");
            dataGridView1.DataSource = ds.Tables["Пользователи"].DefaultView;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string query = $"SELECT * FROM Пользователи";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();

            dataAdapter.Fill(ds, $"[Пользователи]");
            dataGridView1.DataSource = ds.Tables[$"[Пользователи]"].DefaultView;
        }

        private void btnVernyt_Click(object sender, EventArgs e)
        {
            // Назад в будущее
            if (rows2.Count > 0)
            {
                btnVernyt.Enabled = false;
                btnCancel.Enabled = false;

                string s;
                if (rows2.Peek().Split(';')[0] == "I")
                {
                    My_Execute_Non_Query($"INSERT INTO [Пользователи] (Логин, Пароль, Почта) " +
                        $"VALUES ('{rows2.Peek().Split(';')[1]}', '{rows2.Peek().Split(';')[2]}', '{rows2.Peek().Split(';')[3]}')");
                    s = "D;" + rows2.Peek().Split(';')[1] + ";" + rows2.Peek().Split(';')[2] + ";" + rows2.Peek().Split(';')[3];
                }
                else
                {
                    My_Execute_Non_Query($"DELETE FROM Пользователи WHERE Логин = '{rows2.Peek().Split(';')[1]}'");
                    s = "I;" + rows2.Peek().Split(';')[1] + ";" + rows2.Peek().Split(';')[2] + ";" + rows2.Peek().Split(';')[3];
                }

                textBox1.Text = "";

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Пользователи", connectString);
                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, $"[Пользователи]");
                dataGridView1.DataSource = ds.Tables[$"[Пользователи]"].DefaultView;
                rows1.Push(s);
                rows2.Pop();

                btnVernyt.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // В прошлое
            if (rows1.Count > 0)
            {
                btnVernyt.Enabled = false;
                btnCancel.Enabled = false;

                string s;
                if (rows1.Peek().Split(';')[0] == "I")
                {
                    My_Execute_Non_Query($"INSERT INTO [Пользователи] (Логин, Пароль, Почта) " +
                        $"VALUES ('{rows1.Peek().Split(';')[1]}', '{rows1.Peek().Split(';')[2]}', '{rows1.Peek().Split(';')[3]}')");
                    s = "D;" + rows1.Peek().Split(';')[1] + ";" + rows1.Peek().Split(';')[2] + ";" + rows1.Peek().Split(';')[3];
                }
                else
                {
                    My_Execute_Non_Query($"DELETE FROM Пользователи WHERE Логин = '{rows1.Peek().Split(';')[1]}'");
                    s = "I;" + rows1.Peek().Split(';')[1] + ";" + rows1.Peek().Split(';')[2] + ";" + rows1.Peek().Split(';')[3];
                }

                textBox1.Text = "";

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Пользователи", connectString);
                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, $"[Пользователи]");
                dataGridView1.DataSource = ds.Tables[$"[Пользователи]"].DefaultView;
                rows2.Push(s);
                rows1.Pop();

                btnVernyt.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void btnToXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                Exporter.ExportToXML(saveFileDialog, connectString);
        }
    }
}