using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int X = Convert.ToInt32(XTextBox1.Text);
                int Y = Convert.ToInt32(YTextBox2.Text);
                int N = Convert.ToInt32(NTextBox3.Text);
                int R = Convert.ToInt32(RListBox1.Text);
                double a = 0;
                double Z = 0;
                if (radioButton1.Checked)
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (i % 2 == 0)
                            Z += (Math.Pow(Y, i)) / 2 * i;
                        else
                            Z += -1 * ((Math.Pow(X, i)) / 2 * i);
                    }
                }
                else
                {
                    for (int i = 0; i < N; i++)
                        for (int j = 0; j < R; j++)
                            Z += (i * i + j) / Math.Pow(a, j);
                }
                ZTextBox4.Text = Math.Round(Z, 2).ToString();
            } catch (Exception) { }
        }
    }
}