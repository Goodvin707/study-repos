using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21__3
{
    public partial class Form1 : Form
    {
        int switcher;
        public Form1()
        {
            InitializeComponent();
            switcher = 0;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            switcher = 0;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            switcher = 1;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            if (switcher == 0)
            {
                toolStripStatusLabel1.Text = "z = " + Convert.ToDouble(Math.Pow(x, 4) / (y + 1)) + " | f = ";
                toolStripStatusLabel1.Text += Convert.ToDouble(Math.Sqrt(Math.Abs(Math.Pow(y, 3) + x)));
            }
            else
                toolStripStatusLabel1.Text = "z = " + Convert.ToDouble(Math.Sqrt(Math.Abs(x - y)));
        }
    }
}