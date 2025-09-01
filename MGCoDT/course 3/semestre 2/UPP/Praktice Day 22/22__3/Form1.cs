using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22__3
{
    public partial class Form1 : Form
    {
        double v = 5;
        double e_2 = 2;
        double a_del = 4;
        double arg3 = 3;
        int t;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = v.ToString();
            textBox2.Text = e_2.ToString();
            textBox3.Text = a_del.ToString();
            textBox4.Text = arg3.ToString();
            t = panel1.Width;
            textBox5.Text = t.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            Point[] points = new Point[panel1.Width];
            for (int i = t; i < points.Length; i++)
                points[i] = new Point(i, (int)U(i) + 200);
            graphics.DrawLines(new Pen(Color.Red, 1.5f), points);
        }

        private double U(double t)
        {
            double y = (v - e_2 + Math.Abs(Math.Cos(arg3) + Math.Sqrt(Math.Abs(t)))) / (a_del * Math.Tan(t));
            if (double.IsInfinity(y))
                return 0;
            return y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v = Convert.ToDouble(textBox1.Text);
            e_2 = Convert.ToDouble(textBox2.Text);
            a_del = Convert.ToDouble(textBox3.Text);
            arg3 = Convert.ToDouble(textBox4.Text);
            panel1.Invalidate();
            t = Convert.ToInt32(textBox5.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int step = 1;
            t -= step;
            textBox5.Text = t.ToString();
            panel1.Invalidate();
            if (t - step < 0)
            {
                timer1.Stop();
                textBox5.Enabled = true;
            }
        }
    }
}