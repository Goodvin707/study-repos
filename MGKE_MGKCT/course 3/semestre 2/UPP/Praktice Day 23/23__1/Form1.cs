using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23__1
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 newMDIChild = new Form2(this, r.Next(0, 4), trackBar1.Value, trackBar2.Value, trackBar3.Value);
            newMDIChild.Show();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            trackBar1.Width = panel1.Width - 15;
            trackBar2.Width = panel1.Width - 15;
            trackBar3.Width = panel1.Width - 15;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }
    }
}