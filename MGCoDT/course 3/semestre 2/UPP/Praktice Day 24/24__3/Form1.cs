using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24__3
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 15; i++)
                dataGridView1.Columns.Add(i.ToString(), "");
            for (int i = 0; i < 15; i++)
                dataGridView1.Columns[i].Width = 30;
            for (int i = 0; i < 15; i++)
                dataGridView1.Rows.Add();
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    dataGridView1[i, j].Value = r.Next(-100, 101);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int min = 100;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (i + j == 14)
                    {
                        dataGridView1[i, j].Selected = true;
                        if ((int)dataGridView1[i, j].Value < min)
                            min = (int)dataGridView1[i, j].Value;
                    }
                    else
                        dataGridView1[i, j].Selected = false;
                }
            }
            int sum2 = 0;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                sum2 += (int)dataGridView1[i, 1].Value;
            int comp1 = 1;
            for (int j = 0; j < dataGridView1.Rows.Count; j++)
                comp1 *= (int)dataGridView1[0, j].Value;
            textBox1.Text = min + "; " + sum2 + "; " + comp1;
        }
    }
}