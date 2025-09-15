using Polyclinic.DialogForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic
{
    public partial class Vrachi : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;

        MainMenu main;
        string result = "";
        public Vrachi(MainMenu main)
        {
            InitializeComponent();
            this.main = main;
            comboBox1.SelectedIndex = 0;
            if (User.Login != "admin")
            {
                addBtn.Visible = false;
                editBtn.Visible = false;
                delBtn.Visible = false;
            }

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = $"SELECT * FROM Врачи ORDER BY Код";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Врачи");
            dataGridView1.DataSource = ds.Tables["Врачи"].DefaultView;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddVrach f = new AddVrach();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string schedule = "";
                if (f.checkBox1.Checked)
                    schedule += "1";
                if (f.checkBox2.Checked)
                    schedule += "2";
                if (f.checkBox3.Checked)
                    schedule += "3";
                if (f.checkBox4.Checked)
                    schedule += "4";
                if (f.checkBox5.Checked)
                    schedule += "5";
                
                OleDbConnection conn = new OleDbConnection(connectString);
                conn.Open();
                OleDbCommand myCommand = conn.CreateCommand();
                myCommand.CommandText = $"SELECT Код FROM Специальности WHERE Название Like '{f.comboBox1.SelectedItem}'";
                OleDbDataReader reader = myCommand.ExecuteReader();
                reader.Read();

                string CommandText = "INSERT INTO [Врачи] ([Код специальности], [Фамилия], [Имя], [Отчество], [Кабинет],[Расписание]) VALUES " +
                    $"('{reader.GetValue(0)}', '{f.textBox1.Text}', '{f.textBox2.Text}', '{f.textBox3.Text}', '{f.textBox4.Text}', '{schedule}')";
                conn.Close();

                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM Врачи ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Врачи");
                dataGridView1.DataSource = ds.Tables["Врачи"].DefaultView;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            AddVrach f = new AddVrach((dataGridView1[2, dataGridView1.CurrentRow.Index].Value).ToString(),
                (dataGridView1[3, dataGridView1.CurrentRow.Index].Value).ToString(),
                (dataGridView1[4, dataGridView1.CurrentRow.Index].Value).ToString(),
                (dataGridView1[5, dataGridView1.CurrentRow.Index].Value).ToString(),
                (dataGridView1[6, dataGridView1.CurrentRow.Index].Value).ToString());
            if (f.ShowDialog() == DialogResult.OK)
            {
                string schedule = "";
                if (f.checkBox1.Checked)
                    schedule += "1";
                if (f.checkBox2.Checked)
                    schedule += "2";
                if (f.checkBox3.Checked)
                    schedule += "3";
                if (f.checkBox4.Checked)
                    schedule += "4";
                if (f.checkBox5.Checked)
                    schedule += "5";

                OleDbConnection conn = new OleDbConnection(connectString);
                conn.Open();
                OleDbCommand myCommand = conn.CreateCommand();
                myCommand.CommandText = $"SELECT Код FROM Специальности WHERE Название Like '{f.comboBox1.SelectedItem}'";
                OleDbDataReader reader = myCommand.ExecuteReader();
                reader.Read();

                string ID = (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString();
                string CommandText = $"UPDATE Врачи SET [Код специальности]='{reader.GetValue(0)}', Фамилия='{f.textBox1.Text}', Имя='{f.textBox2.Text}', Отчество='{f.textBox3.Text}', Кабинет='{f.textBox4.Text}', Расписание='{schedule}' WHERE Код = {ID}";
                conn.Close();

                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM Врачи ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Врачи");
                dataGridView1.DataSource = ds.Tables["Врачи"].DefaultView;
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DeleleRow f = new DeleleRow();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string ID = (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString();
                string CommandText = "DELETE FROM Врачи WHERE Код = " + ID;
                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM Врачи ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Врачи");
                dataGridView1.DataSource = ds.Tables["Врачи"].DefaultView;
            }
        }

        private void Vrachi_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
            myConnection.Close();
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
            string query = $"SELECT * FROM Врачи WHERE {comboBox1.SelectedItem} Like '{textBox1.Text}%' ORDER BY Код";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Врачи");
            dataGridView1.DataSource = ds.Tables["Врачи"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = "";
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                result += dataGridView1.Columns[i].HeaderText + " |\t";
            result += "\n";
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    result += dataGridView1.Rows[i].Cells[j].Value + "\t";
                result += "\n";
            }

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e) => e.Graphics.DrawString(result, new System.Drawing.Font("Arial", 14), Brushes.Black, 0, 0);

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) => toolStripStatusLabel1.Text = "Выбрано: " + (dataGridView1.CurrentRow.Index + 1) + " из " + dataGridView1.RowCount;

        private void toolStripMenuItem1_Click(object sender, EventArgs e) => addBtn_Click(sender, e);

        private void toolStripMenuItem2_Click(object sender, EventArgs e) => editBtn_Click(sender, e);

        private void toolStripMenuItem3_Click(object sender, EventArgs e) => delBtn_Click(sender, e);
    }
}