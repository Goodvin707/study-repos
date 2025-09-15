using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDI
{
    public partial class Form1 : Form
    {
        Random r;
        public Form1()
        {
            r = new Random();
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] arr = new int[Convert.ToInt32(domainUpDown1.Text), Convert.ToInt32(domainUpDown2.Text)];
            int min = Convert.ToInt32(textBox2.Text);
            int max = Convert.ToInt32(textBox3.Text) + 1;
            textBox1.Text = "";
            textBox4.Text = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(min, max);
                    textBox1.Text += arr[i, j] + " ";
                }
                textBox1.Text += "\r\n";
            }
            bool hasEquals = false;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    hasEquals = false;
                    for (int ii = 0; ii < arr.GetLength(0); ii++)
                    {
                        for (int jj = 0; jj < arr.GetLength(1); jj++)
                        {
                            if (i == ii && j == jj)
                                continue;
                            if (arr[i, j] == arr[ii, jj])
                                hasEquals = true;
                        }
                    }
                    if (hasEquals == false)
                        textBox4.Text += arr[i, j] + " ";
                }
            }
        }
    }
}