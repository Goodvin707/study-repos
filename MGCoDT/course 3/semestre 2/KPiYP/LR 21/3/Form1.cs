using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_3
{
    public partial class Form1 : Form
    {
        float x, y; // координаты
        Brush pStdBrush; // кисть
        Graphics poGraphics;
        StringBuilder pStr;
        String s;
        public Form1()
        {
            InitializeComponent();
            x = 10;
            y = 20;
            pStdBrush = new SolidBrush(Color.Black);
            poGraphics = this.CreateGraphics();
            this.Text = "Программа 3";
            this.Show();
            pStr = new StringBuilder("Hello, Window Forms"); s = pStr.ToString();
            poGraphics.DrawString(s, this.Font, pStdBrush, x, y);
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                poGraphics.DrawString("Hello, Window Forms", this.Font, pStdBrush, x, y);
            }
            else
                MessageBox.Show("Mouse clicked!");
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            pStr.Append(e.KeyChar);
            s = pStr.ToString();
            poGraphics.DrawString(s, this.Font, pStdBrush, x, y);
        }
    }
}