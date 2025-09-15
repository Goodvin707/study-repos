using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20__4
{
    public partial class Form1 : Form
    {
        int sec = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = (sec++).ToString();
            if (sec == 60)
            {
                sec = 1;
                label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false;
                button1.Text = "Пуск";
            }
            else if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                button1.Text = "Стоп";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "00";
            label2.Text = "00";
        }
    }
}