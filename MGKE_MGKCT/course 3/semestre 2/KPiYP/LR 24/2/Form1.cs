using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_24
{
    public partial class Form1 : Form
    {
        Point[] points;
        Graphics graphics;
        int i;
        public Form1()
        {
            InitializeComponent();
            points = new Point[Width];
            for (int x = 0; x < Width; x++)
                points[x] = new Point(x, (int)(Math.Sin((double)x / 10) * 100 + 300));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = CreateGraphics();
            graphics.DrawLines(new Pen(Color.Red), points);

            if (i < Width)
            {
                graphics.DrawRectangle(new Pen(Color.Blue), points[i].X - 10, points[i].Y - 10, 20, 20);
                i++;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) => Invalidate();
    }
}