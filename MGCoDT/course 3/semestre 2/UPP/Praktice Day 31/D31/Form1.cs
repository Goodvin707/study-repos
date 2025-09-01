using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.SqlClient;
using D31.Models;

namespace D31
{
    public partial class Form1 : Form
    {
        private string ConnStr;
        public Form1()
        {
            InitializeComponent();
            ConnStr = DataContext.getConnectionString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Программа мониторинга загрязнения окружающей среды";
            this.MaximizeBox = false;
            FillSource();
            FillEmission();
        }

        #region FillData
        private void FillSource()
        {
            string SqlText = "SELECT * FROM [Source]";
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Source]");
            dataGridView1.DataSource = ds.Tables["[Source]"].DefaultView;
        }
        private void FillEmission()
        {
            // сформировать строку SQL-запроса 
            string SqlText = "SELECT * FROM [Emission]";
            int index;
            string ID_Source;

            index = dataGridView1.CurrentRow.Index;
            ID_Source = dataGridView1[0, index].Value.ToString();

            SqlText = "SELECT * FROM [Emission],[Source] WHERE (([Emission].ID_Source = ";
            SqlText = SqlText + ID_Source + ") AND ([Source].ID_Source = " + ID_Source + "))";

            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Emission]");
            dataGridView2.DataSource = ds.Tables["[Emission]"].DefaultView;
        }
        #endregion
        public void MyExecuteNonQuery(string SqlText)
        {
            SqlConnection cn; // экземпляр класса типа SqlConnection 
            SqlCommand cmd;

            // выделение памяти с инициализацией строки соединения с базой данных 
            cn = new SqlConnection(ConnStr);
            cn.Open(); // открыть источник данных 
            cmd = cn.CreateCommand(); // задать SQL-команду 
            cmd.CommandText = SqlText; // задать командную строку 
            cmd.ExecuteNonQuery(); // выполнить SQL-команду 
            cn.Close(); // закрыть источник данных 
        }
        #region buttons
        private void button1_Click(object sender, EventArgs e)
        {
            string SqlText = "INSERT INTO [Source] ([ID_Source],[Name],[Address]) VALUES (1, 'Source-01','Address-01') ";
            Form2 f = new Form2(); // создать экземпляр окна 

            if (f.ShowDialog() == DialogResult.OK)
            {
                // сформировать SQL-строку 
                SqlText = "INSERT INTO [Source] ([Name], [Address]) VALUES (";
                SqlText = SqlText + "\'" + f.textBox1.Text + "\', ";
                SqlText = SqlText + "\'" + f.textBox2.Text + "\')";

                // выполнить SQL-команду 
                MyExecuteNonQuery(SqlText);
                // отобразить таблицу Source 
                FillSource();
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            int index, n;
            string ID_Source;
            string name, address;
            string SqlText = "DELETE FROM [Source] WHERE [Source].ID_Source = ";
            // проверка, есть ли вообще записи в таблице Source 
            n = dataGridView1.Rows.Count;
            if (n == 1) return;
            Form5 f = new Form5();
            index = dataGridView1.CurrentRow.Index;
            ID_Source = Convert.ToString(dataGridView1[0, index].Value);
            // сформировать SQL-команду 
            SqlText = SqlText + ID_Source;
            // заполнить информационную справку в окне Form5 
            name = Convert.ToString(dataGridView1[1, index].Value);
            address = Convert.ToString(dataGridView1[2, index].Value);
            f.label2.Text = ID_Source + " - " + name + " - " + address;
            if (f.ShowDialog() == DialogResult.OK) // вывести форму 
            {
                // выполнить SQL-команду 
                MyExecuteNonQuery(SqlText);
                // отобразить таблицу Source 
                FillSource();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index, n;
            string SqlText = "UPDATE [Source] SET ";
            string ID_Source, name, address;
            // проверка, есть ли вообще записи в таблице Source 
            n = dataGridView1.Rows.Count;
            if (n == 1) return;
            Form3 f = new Form3();
            // заполнить форму данными перед открытием 
            index = dataGridView1.CurrentRow.Index;
            ID_Source = dataGridView1[0, index].Value.ToString();
            name = dataGridView1[1, index].Value.ToString();
            address = dataGridView1[2, index].Value.ToString();
            f.textBox1.Text = name;
            f.textBox2.Text = address;
            if (f.ShowDialog() == DialogResult.OK)
            {
                name = f.textBox1.Text;
                address = f.textBox2.Text;
                SqlText += "Name = \'" + name + "\', Address = '" + address + "\' ";
                SqlText += "WHERE [Source].ID_Source = " + ID_Source;
                MyExecuteNonQuery(SqlText);
                FillSource();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string SqlText = "";
            int index; // номер выделенной строки в таблице Source 
            string ID_Source;
            string name;
            Form4 f = new Form4();
            // 1.1. Найти активную строку в Source и взять из нее ID_Source 
            index = dataGridView1.CurrentRow.Index;
            ID_Source = Convert.ToString(dataGridView1[0, index].Value);
            name = Convert.ToString(dataGridView1[1, index].Value);
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Добавить данные в таблицу 
                // Сформировать SQL-строку 
                SqlText = "INSERT INTO [Emission] ([ID_Source], [count], [Text], [date]) VALUES (";
                // Сформировать значения переменной SqlText 
                SqlText = SqlText + ID_Source + ", "; // ID_Source 
                SqlText = SqlText + f.textBox1.Text + ", ";     // count 
                SqlText = SqlText + "\'" + f.textBox2.Text + "\', ";   // Text 
                SqlText = SqlText + "\'" + f.textBox3.Text + "\')";       // date 
                                                                          // выполнить SQL-команду 
                MyExecuteNonQuery(SqlText);
                // вывести таблицу Emission 
                FillEmission();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int index, n;
            string ID_Emission;
            string count, text;
            string SqlText = "DELETE FROM [Emission] WHERE [Emission].ID_Emission = ";

            // проверка, есть ли записи в таблице Emission 
            n = dataGridView2.Rows.Count;
            if (n == 1) return;

            Form6 f = new Form6();

            index = dataGridView2.CurrentRow.Index;
            ID_Emission = Convert.ToString(dataGridView2[0, index].Value);

            // сформировать SQL-команду 
            SqlText += ID_Emission;

            // заполнить информационную справку в окне Form6 
            count = Convert.ToString(dataGridView2[2, index].Value);
            text = Convert.ToString(dataGridView2[3, index].Value);

            f.label2.Text = ID_Emission + " - " + count + " - " + text;

            if (f.ShowDialog() == DialogResult.OK)
            {
                MyExecuteNonQuery(SqlText); // выполнить SQL-команду 
                FillEmission(); // отобразить таблицу Emission 
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index, index_src, n;
            string SqlText = "UPDATE [Emission] SET ";
            string ID_Emission, ID_Source, count, Text, date;
            string Name_Source;
            // проверка, есть ли вообще записи в таблице Emission 
            n = dataGridView2.Rows.Count;
            if (n == 1) return;
            Form7 f = new Form7();
            // заполнить форму данными перед открытием 
            index = dataGridView2.CurrentRow.Index;
            ID_Emission = dataGridView2[0, index].Value.ToString();
            ID_Source = dataGridView2[1, index].Value.ToString();
            count = dataGridView2[2, index].Value.ToString();
            Text = dataGridView2[3, index].Value.ToString();
            date = dataGridView2[4, index].Value.ToString();
            index_src = dataGridView1.CurrentRow.Index;
            Name_Source = dataGridView1[1, index_src].Value.ToString();
            f.label4.Text = Name_Source;
            f.textBox1.Text = count;
            f.textBox2.Text = Text;
            f.textBox3.Text = date;
            if (f.ShowDialog() == DialogResult.OK)
            {
                count = f.textBox1.Text;
                Text = f.textBox2.Text;
                date = f.textBox3.Text;
                SqlText += "count = " + count + ", Text = \'" + Text + "\', date = \'" + date + "\' ";
                SqlText += "WHERE [Emission].ID_Emission = " + ID_Emission;
                MyExecuteNonQuery(SqlText);
                FillEmission();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            string SqlText;
 
            SqlText = "SELECT [Emission].ID_Source, MIN([Emission].count) AS \'Минимальные выбросы\' ";
            SqlText += " FROM [Emission]";
            SqlText += " GROUP BY [Emission].ID_Source";
 
            Form8 f = new Form8();
 
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Emission]");
 
            f.dataGridView1.DataSource = ds.Tables["[Emission]"].DefaultView;
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string SqlText = "SELECT [Emission].ID_Source, MAX([Emission].count) AS \'Максимальные выбросы\' ";
            SqlText += " FROM [Emission]";
            SqlText += " GROUP BY [Emission].ID_Source";
            Form9 f = new Form9();
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Emission]");
            f.dataGridView1.DataSource = ds.Tables["[Emission]"].DefaultView;
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // SQL-запрос - определяет средние выбросы для любого источника 
            string SqlText = "SELECT [Emission].ID_Source, AVG([Emission].count) AS \'Средние выбросы\' ";
            SqlText += " FROM [Emission]";
            SqlText += " GROUP BY [Emission].ID_Source";
            Form10 f = new Form10();
            SqlDataAdapter da = new SqlDataAdapter(SqlText, ConnStr);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Emission]");
            f.dataGridView1.DataSource = ds.Tables["[Emission]"].DefaultView;
            f.ShowDialog();
        }
        #endregion
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // на основе выделенной строки в таблице Source вывести таблицу Emission 
            // определить количество строк в dataGridView1 
            int n = dataGridView1.RowCount;
            int row = dataGridView1.CurrentRow.Index;
            if (n != (row + 1)) // Проверка, был ли клик на последней строке 
                FillEmission();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int n = dataGridView1.RowCount;
            int row = dataGridView1.CurrentRow.Index;
            if (n != (row + 1)) // Проверка, был ли клик на последней строке 
                FillEmission();
        }
    }
}