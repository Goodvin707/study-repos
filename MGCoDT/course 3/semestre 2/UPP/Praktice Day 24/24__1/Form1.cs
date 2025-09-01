using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _24__1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.MouseDown += textBox1_MouseDown;
            textBox2.MouseDown += textBox1_MouseDown;
            textBox3.MouseDown += textBox1_MouseDown;
            textBox4.MouseDown += textBox1_MouseDown;
            textBox5.MouseDown += textBox1_MouseDown;
            textBox6.MouseDown += textBox1_MouseDown;
            textBox7.MouseDown += textBox1_MouseDown;
            textBox8.MouseDown += textBox1_MouseDown;
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Name[textBox.Name.Length - 1].ToString();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }
    }
}