using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox10.Text != "")
            {
                StreamWriter f = new StreamWriter("tour.txt");
                f.WriteLine(textBox1.Text);
                f.WriteLine(textBox2.Text);
                f.WriteLine(textBox3.Text);
                f.WriteLine(textBox8.Text);
                f.WriteLine(Convert.ToInt16(textBox4.Text));
                f.WriteLine(textBox9.Text);
                f.WriteLine(Convert.ToInt16(textBox5.Text));
                f.WriteLine(Convert.ToInt16(textBox10.Text));
                if (trackBar1.Value == 0)
                    f.WriteLine(1000);
                else
                    f.WriteLine(trackBar1.Value * 1000);
                f.WriteLine(trackBar2.Value * 1000);
                f.Close();
                this.Hide();
                Tours tours = new Tours();
                tours.Show();
            }
            else
            {
                button11.Text = "Все поля должны быть заполнены";
            }
        }

        private void button12_MouseEnter(object sender, EventArgs e)
        {
            button12.BackColor = Color.Red;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.WindowState = (FormWindowState)1;
        }

        private void button12_MouseLeave_1(object sender, EventArgs e)
        {
            button12.BackColor = Color.Thistle;
        }

        private void button13_MouseEnter(object sender, EventArgs e)
        {
            button13.BackColor = Color.PaleVioletRed;
        }

        private void button13_MouseLeave(object sender, EventArgs e)
        {
            button13.BackColor = Color.Thistle;
        }
    }
}