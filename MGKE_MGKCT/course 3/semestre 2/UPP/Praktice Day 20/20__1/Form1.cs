using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20__1
{
    public partial class Form1 : Form
    {
        Form3 f3;
        Form2 f2;
        Form1 f1;
        Control[] cb;
        public Form1()
        {
            f1 = this;
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.ShowDialog();
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cb = f2.Controls.Find("comboBox1", false);
            if ((cb[0] as ComboBox).SelectedIndex == 0)
                f3 = new Form3(Color.Red);
            if ((cb[0] as ComboBox).SelectedIndex == 1)
                f3 = new Form3(Color.Blue);
            f3.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }
    }
}