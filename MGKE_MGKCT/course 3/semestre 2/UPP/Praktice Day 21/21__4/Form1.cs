using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21__4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = -10; i <= 10; i++)
            {
                toolStripComboBox1.Items.Add(i);
                toolStripComboBox2.Items.Add(i);
            }
        }

        private void toolStripDropDownButton1_DropDownOpened(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
        }

        private void toolStripDropDownButton1_DropDownClosed(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(toolStripTextBox1.Text);
                double y = Convert.ToDouble(toolStripTextBox2.Text);
                double z = Convert.ToDouble(toolStripTextBox3.Text);
                int a = Convert.ToInt32(toolStripComboBox1.Text);
                int b = Convert.ToInt32(toolStripComboBox2.Text);
                this.Text = (((a * x) / Math.Cos(z)) + (((b * y) + Math.Sin(z)) / (Math.Sqrt(Math.Abs(x - y))))).ToString();
            }
            catch (Exception) { MessageBox.Show("Не все данные введены корректно", "Ошибка вычисления"); }
        }
    }
}