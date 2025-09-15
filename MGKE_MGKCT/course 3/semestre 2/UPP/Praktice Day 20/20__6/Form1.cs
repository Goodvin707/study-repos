using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20__6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1.Text = textBox1.Text;
            label2.Text = textBox2.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = (Convert.ToInt32(label2.Text) - 1).ToString();
            if (label1.Text == "0" && label2.Text == "0")
            {
                timer1.Enabled = false;
                MessageBox.Show("Время истекло", "Таймер");
                goto down;
            }
            if ((Convert.ToInt32(label2.Text)) == 0)
            {
                label2.Text = "59";
                label1.Text = (Convert.ToInt32(label1.Text) - 1).ToString();
            }
        down:;
        }
    }
}