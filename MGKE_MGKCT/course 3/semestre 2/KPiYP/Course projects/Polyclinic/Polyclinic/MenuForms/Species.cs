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
    public partial class Species : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;

        MainMenu mainMenu;
        string result;
        public Species(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            if (User.Login != "admin")
            {
                addBtn.Visible = false;
                editBtn.Visible = false;
                delBtn.Visible = false;
            }

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT * FROM Специальности ORDER BY Код";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Специальности");
            dataGridView1.DataSource = ds.Tables["Специальности"].DefaultView;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Species_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainMenu.Show();
            myConnection.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddSpec f = new AddSpec();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string CommandText = $"INSERT INTO [Специальности] (Название) VALUES ('{f.textBox1.Text}')";
                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM Специальности ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Специальности");
                dataGridView1.DataSource = ds.Tables["Специальности"].DefaultView;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            AddSpec f = new AddSpec((dataGridView1[1, dataGridView1.CurrentRow.Index].Value).ToString());
            if (f.ShowDialog() == DialogResult.OK)
            {
                string ID = (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString();
                string CommandText = $"UPDATE Специальности SET Название='{f.textBox1.Text}' WHERE Код = {ID}";
                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM Специальности ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Специальности");
                dataGridView1.DataSource = ds.Tables["Специальности"].DefaultView;
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DeleleRow f = new DeleleRow();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string ID = (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString();
                string CommandText = "DELETE FROM Специальности WHERE Код = " + ID;
                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM Специальности ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Специальности");
                dataGridView1.DataSource = ds.Tables["Специальности"].DefaultView;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM Специальности WHERE Название Like '{textBox1.Text}%' ORDER BY Код";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Специальности");
            dataGridView1.DataSource = ds.Tables["Специальности"].DefaultView;
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
    }
}