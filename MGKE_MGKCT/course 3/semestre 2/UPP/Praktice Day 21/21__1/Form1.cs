using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21__1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int v = e.X;
            int t = e.Y;
            vTextBox4.Text = v.ToString();
            tTextBox5.Text = t.ToString();
            double e_2 = 0;
            double arg3 = 0;
            double a_del = 0;
            this.Text = "ERROR COMPUTING";
            try
            {
                e_2 = Convert.ToDouble(e_2TextBox1.Text);
                arg3 = Convert.ToDouble(arg3TextBox2.Text);
                a_del = Convert.ToDouble(a_delTextBox3.Text);
            } catch (Exception) { this.Text = "ERROR COMPUTING"; }
            double U = (v - e_2 + Math.Abs(Math.Cos(arg3) + Math.Sqrt(Math.Sqrt(t)))) / (a_del * Math.Tan(t));
            this.Text = Math.Round(U, 2).ToString();
        }
    }
}