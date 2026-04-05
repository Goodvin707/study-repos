using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_2
{
    public partial class Form1 : Form
    {
        float x, y; // координаты
        Brush pStdBrush; // кисть
        Graphics poGraphics;
        public Form1()
        {
            InitializeComponent();
            x = 10;
            y = 20;
            pStdBrush = new SolidBrush(Color.Black);
            poGraphics = this.CreateGraphics();
            this.Text = "Программа 2";
            this.Show();
            poGraphics.DrawString("Hello, Window Forms", this.Font, pStdBrush, x, y);
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            poGraphics.DrawString("Hello, Window Forms", this.Font, pStdBrush, x, y);
        }
        private void ShowClick(object pSender, MouseEventArgs e)
        {
            MessageBox.Show("Mouse clicked!");
        }
    }
}