using Polyclinic.DialogForms;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using exportWord = Microsoft.Office.Interop.Word;

namespace Polyclinic
{
    public partial class PaidServices : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Polyclinic.accdb;";
        private OleDbConnection myConnection;

        MainMenu main;
        string result = "";
        public PaidServices(MainMenu main)
        {
            InitializeComponent();
            this.main = main;
            if (User.Login != "admin")
            {
                addBtn.Visible = false;
                editBtn.Visible = false;
                delBtn.Visible = false;
            }

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            string query = "SELECT * FROM [Платные услуги] ORDER BY Код";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Платные услуги]");
            dataGridView1.DataSource = ds.Tables["[Платные услуги]"].DefaultView;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            comboBox1.SelectedIndex = 0;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddPaidServise f = new AddPaidServise();
            if (f.ShowDialog() == DialogResult.OK)
            {
                OleDbConnection conn = new OleDbConnection(connectString);
                conn.Open();
                OleDbCommand myCommand = conn.CreateCommand();
                myCommand.CommandText = $"SELECT Код FROM Врачи WHERE " +
                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                    $"AND Кабинет Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                OleDbDataReader reader = myCommand.ExecuteReader();
                reader.Read();
                string CommandText = $"INSERT INTO [Платные услуги] ([Код врача], Название, Стоимость) VALUES ({reader.GetValue(0)}, '{f.textBox1.Text}', {f.numericUpDown1.Text})";
                conn.Close();

                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM [Платные услуги] ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "[Платные услуги]");
                dataGridView1.DataSource = ds.Tables["[Платные услуги]"].DefaultView;
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            AddPaidServise f = new AddPaidServise((dataGridView1[2, dataGridView1.CurrentRow.Index].Value).ToString(), Convert.ToDouble(dataGridView1[3, dataGridView1.CurrentRow.Index].Value));
            if (f.ShowDialog() == DialogResult.OK)
            {
                string ID = (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString();

                OleDbConnection conn = new OleDbConnection(connectString);
                conn.Open();
                OleDbCommand myCommand = conn.CreateCommand();
                myCommand.CommandText = $"SELECT Код FROM Врачи WHERE " +
                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                    $"AND Кабинет Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                OleDbDataReader reader = myCommand.ExecuteReader();
                reader.Read();
                string CommandText = $"UPDATE [Платные услуги] SET [Код врача]='{reader.GetValue(0)}', Название='{f.textBox1.Text}', Стоимость={f.numericUpDown1.Text} WHERE Код = {ID}";
                conn.Close();

                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM [Платные услуги] ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "[Платные услуги]");
                dataGridView1.DataSource = ds.Tables["[Платные услуги]"].DefaultView;
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DeleleRow f = new DeleleRow();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string ID = (dataGridView1[0, dataGridView1.CurrentRow.Index].Value).ToString();
                string CommandText = "DELETE FROM [Платные услуги] WHERE Код = " + ID;
                My_Execute_Non_Query(CommandText);

                string query = "SELECT * FROM [Платные услуги] ORDER BY Код";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "[Платные услуги]");
                dataGridView1.DataSource = ds.Tables["[Платные услуги]"].DefaultView;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = $"SELECT * FROM [Платные услуги] WHERE {comboBox1.SelectedItem} Like '{textBox1.Text}%' ORDER BY Код";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "[Платные услуги]");
            dataGridView1.DataSource = ds.Tables["[Платные услуги]"].DefaultView;
        }

        private void PaidServices_FormClosed(object sender, FormClosedEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            string s = "";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = $"Select * FROM [Платные услуги]";
            OleDbDataReader reader = myCommand.ExecuteReader();
            s += "[" + reader.GetName(0) + "]    [" + reader.GetName(1) + "]    [" + reader.GetName(2) + "]\n";
            while (reader.Read())
            {
                s += reader.GetValue(0) + "\t" + reader.GetValue(1) + "\t" + reader.GetValue(2) + "\n";
            }

            exportWord.Application wordapp = new exportWord.Application();
            wordapp.Visible = true;
            exportWord.Document worddoc;
            object wordobj = System.Reflection.Missing.Value;
            worddoc = wordapp.Documents.Add(ref wordobj);
            wordapp.Selection.TypeText(s);
            wordapp = null;
            myConnection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) => toolStripStatusLabel1.Text = "Выбрано: " + (dataGridView1.CurrentRow.Index + 1) + " из " + dataGridView1.RowCount;

        private void toolStripMenuItem1_Click(object sender, EventArgs e) => addBtn_Click(sender, e);

        private void toolStripMenuItem2_Click(object sender, EventArgs e) => editBtn_Click(sender, e);

        private void toolStripMenuItem3_Click(object sender, EventArgs e) => delBtn_Click(sender, e);
    }
}