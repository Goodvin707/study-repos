using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Educ
{
    public partial class Journals : Form
    {
        string selectedGroup = "0";
        public Journals()
        {
            InitializeComponent();
            
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
            dataGridView1.AutoResizeColumns();
        }

        private void SessionJournal_Load(object sender, EventArgs e)
        {
            SelectGroup f = new SelectGroup();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Text += " группы \"" + f.listBox1.SelectedItem.ToString() + "\"";
                f.Close();
                selectedGroup = f.listBox1.SelectedItem.ToString();

                DataTransfer.connection.Open();

                MySqlDataReader rdr = new MySqlCommand($"Use university;Call journal_disc({selectedGroup.Split(' ')[0]});", DataTransfer.connection).ExecuteReader(); // {selectedGroup.Split(' ')[0]}
                List<string> values = new List<string>();
                while (rdr.Read())
                    values.Add(rdr.GetString(0));
                rdr.Close();
                listBox1.DataSource = values.ToArray();
                
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;

                    rdr = new MySqlCommand($"Use university;Call journal_dates({selectedGroup.Split(' ')[0]}, {Functional.FindTheKeyByValue(listBox1.SelectedItem.ToString(), "title", "disciplines", DataTransfer.connection)});", DataTransfer.connection).ExecuteReader(); // {selectedGroup.Split(' ')[0]} || {Functional.FindTheKeyByValue(listBox1.SelectedItem.ToString(), "title", "disciplines", DataTransfer.connection)}
                    while (rdr.Read())
                    {
                        string s = rdr.GetString(0).Remove(10);
                        dataGridView1.Columns.Add("event_date", s);
                    }
                    rdr.Close();

                    rdr = new MySqlCommand($"Use university;Call journal_studfio({selectedGroup.Split(' ')[0]}, {Functional.FindTheKeyByValue(listBox1.SelectedItem.ToString(), "title", "disciplines", DataTransfer.connection)});", DataTransfer.connection).ExecuteReader();
                    int i = 0;
                    while (rdr.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].HeaderCell.Value = rdr.GetString(0);
                        i++;
                    }
                    rdr.Close();

                    rdr = new MySqlCommand($"Use university;Select Оценка, `Дата проведения`, Писал from monitoring_view", DataTransfer.connection).ExecuteReader();
                    while (rdr.Read())
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            for (int k = 0; k < dataGridView1.Columns.Count; k++)
                            {
                                string r = rdr.GetString(1).Remove(10);
                                string c = rdr.GetString(2);
                                if (r == dataGridView1.Columns[k].HeaderText && c == dataGridView1.Rows[j].HeaderCell.Value.ToString())
                                    dataGridView1[k, j].Value = rdr.GetValue(0);
                            }
                        }
                    }
                    rdr.Close();

                    dataGridView1.AutoResizeRows();
                    dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
                }
                DataTransfer.connection.Close();
            }
            else
                this.Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataTransfer.connection.Open();

            MySqlDataReader rdr = new MySqlCommand($"Use university;Call journal_dates({selectedGroup.Split(' ')[0]}, {Functional.FindTheKeyByValue(listBox1.SelectedItem.ToString(), "title", "disciplines", DataTransfer.connection)});", DataTransfer.connection).ExecuteReader();
            while (rdr.Read())
            {
                string s = rdr.GetString(0).Remove(10);
                dataGridView1.Columns.Add("event_date", s);
            }
            rdr.Close();

            rdr = new MySqlCommand($"Use university;Call journal_studfio({selectedGroup.Split(' ')[0]}, {Functional.FindTheKeyByValue(listBox1.SelectedItem.ToString(), "title", "disciplines", DataTransfer.connection)});", DataTransfer.connection).ExecuteReader();
            int i = 0;
            while (rdr.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value = rdr.GetString(0);
                i++;
            }
            rdr.Close();

            rdr = new MySqlCommand($"Use university;Select Оценка, `Дата проведения`, Писал from monitoring_view", DataTransfer.connection).ExecuteReader();
            while (rdr.Read())
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    for (int k = 0; k < dataGridView1.Columns.Count; k++)
                    {
                        string r = rdr.GetString(1).Remove(10);
                        string c = rdr.GetString(2);
                        if (r == dataGridView1.Columns[k].HeaderText && c == dataGridView1.Rows[j].HeaderCell.Value.ToString())
                            dataGridView1[k, j].Value = rdr.GetValue(0);
                    }
                }
            }
            rdr.Close();


            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            DataTransfer.connection.Close();
        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                Rectangle rect = dataGridView1.GetColumnDisplayRectangle(e.ColumnIndex, true);
                Size titleSize = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font);
                if (dataGridView1.ColumnHeadersHeight < titleSize.Width)
                    dataGridView1.ColumnHeadersHeight = titleSize.Width;
                e.Graphics.TranslateTransform(0, titleSize.Width);
                e.Graphics.RotateTransform(-90.0F);
                e.Graphics.DrawString(e.Value.ToString(), Font, Brushes.Black, new PointF(rect.Y - (dataGridView1.ColumnHeadersHeight - titleSize.Width), rect.X + 5));
                // e.Graphics.DrawString(e.Value.ToString(), this.Font, Brushes.Black, new PointF(rect.Y, rect.X));

                e.Graphics.RotateTransform(90.0F);
                e.Graphics.TranslateTransform(0, -titleSize.Width);
                e.Handled = true;
            }
        }

        private void shhLeftPannel_Click(object sender, EventArgs e) => splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;

        private void toolStripButton1_Click(object sender, EventArgs e) => toolStrip1.Visible = !toolStrip1.Visible;
    }
}