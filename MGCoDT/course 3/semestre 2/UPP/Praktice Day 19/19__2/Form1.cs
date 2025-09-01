using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19__2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int R = 0;
            int r = 0;
            try
            {
                R = Convert.ToInt32(textBox1.Text);
                r = Convert.ToInt32(textBox2.Text);
            }
            catch (Exception) { MessageBox.Show("Не все значения введены"); }
            double V = Math.Round(2  * R * Math.Pow(Math.PI, 2) * Math.Pow(r, 2), 2);
            double S = Math.Round(4 * Math.Pow(Math.PI, 2) * R * r, 2);
            label3.Text = "V = " + V.ToString();
            label4.Text = "Sпов = " + S.ToString();
        }
    }
}