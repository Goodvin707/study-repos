using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.DrawArc(new Pen(Color.Aqua), 10, 10, 70, 70, 30, 90);
            graphics.FillRectangle(Brushes.BlanchedAlmond, 80, 20, 50, 50);
            graphics.DrawEllipse(new Pen(Color.BlueViolet), 83, 23, 45, 45);
            graphics.FillPolygon(Brushes.LightGreen, new Point[] { new Point(20, 80), new Point(100, 120), new Point(150, 90), new Point(200, 90), new Point(450, 190) });
        }
    }
}