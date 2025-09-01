using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22__2
{
    public partial class Form1 : Form
    {
        Color color = Color.Red;
        Point[] points;
        Rectangle[] rectangles;
        Graphics graphics;
        int mode = 1;
        int dx = 5;
        int x0 = 0, xn = 400;
        double a = 5, b = 400, p = -0.5;
        double k = 6.4;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = mode;
            textBox1.Text = a.ToString();
            textBox2.Text = b.ToString();
            textBox3.Text = k.ToString();
            textBox4.Text = p.ToString();
            points = new Point[xn];
            rectangles = new Rectangle[xn];
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            graphics = panel1.CreateGraphics();
            switch (mode)
            {
                case 0:
                    for (int i = 0; i < xn; i++)
                        rectangles[i] = new Rectangle(i, (int)Y(i) + 200, 1, 1);
                    graphics.DrawRectangles(new Pen(color), rectangles);
                    break;
                case 1:
                    for (int i = 0; i < points.Length; i++)
                        points[i] = new Point(i, (int)(Y(i)) + 200);
                    graphics.DrawLines(new Pen(color, 1.5f), points);
                    break;
                default:
                    break;
            }
        }

        double Y(double x)
        {
            if (x == 0)
                return 0;
            else
                return a * Math.Pow(x, -p) * Math.Sin(k * x + b);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            k = Convert.ToDouble(textBox3.Text);
            p = Convert.ToDouble(textBox4.Text);
            panel1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog.Color;
                panel1.Invalidate();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = ((ComboBox)sender).SelectedIndex;
            panel1.Invalidate();
        }
    }
}