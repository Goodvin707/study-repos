using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _22__4
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        GraphicsPath pathOfUpperMiniCircle;
        GraphicsPath pathOfMiniCircle;
        GraphicsPath pathOfPolygon;

        List<Point> pointsOfMiniCircle = new List<Point>();

        Point curs;
        Point[] pointsOfPolygon = new Point[10];

        int R = 200;

        bool Enter1 = false;
        bool Enter2 = false;
        
        Random r = new Random();
        Color[] labelColors = new Color[10];
        Color fillColor = Color.Red;
        Pen pen = new Pen(Color.Black);
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 5;
            pathOfUpperMiniCircle = new GraphicsPath();
            pathOfMiniCircle = new GraphicsPath();
            pathOfPolygon = new GraphicsPath();
            labelColors[0] = Color.Black;
            labelColors[1] = Color.Purple;
            labelColors[2] = Color.Peru;
            labelColors[3] = Color.LightPink;
            labelColors[4] = Color.Magenta;
            labelColors[5] = Color.SpringGreen;
            labelColors[6] = Color.Chocolate;
            labelColors[7] = Color.DarkRed;
            labelColors[8] = Color.MidnightBlue;
            labelColors[9] = Color.Violet;

            pointsOfPolygon[0] = new Point(221, 80);
            pointsOfPolygon[1] = new Point(201, 100);
            pointsOfPolygon[2] = new Point(200, 111);
            pointsOfPolygon[3] = new Point(195, 125);
            pointsOfPolygon[4] = new Point(199, 136);
            pointsOfPolygon[5] = new Point(201, 150);
            pointsOfPolygon[6] = new Point(250, 150);
            pointsOfPolygon[7] = new Point(245, 121);
            pointsOfPolygon[8] = new Point(240, 106);
            pointsOfPolygon[9] = new Point(230, 90);

            label2.MouseMove += label1_MouseMove;
            label3.MouseMove += label1_MouseMove;
            label4.MouseMove += label1_MouseMove;
            label5.MouseMove += label1_MouseMove;
            label6.MouseMove += label1_MouseMove;
            label7.MouseMove += label1_MouseMove;
            label8.MouseMove += label1_MouseMove;
            label9.MouseMove += label1_MouseMove;


            pathOfPolygon.StartFigure();
            pathOfPolygon.AddPolygon(pointsOfPolygon);
            pathOfPolygon.CloseFigure();

            pathOfMiniCircle.StartFigure();
            pathOfMiniCircle.AddEllipse(150 - R / 2 + R / 4, 150 - R / 2 + R / 4, R / 2, R / 2);
            pathOfMiniCircle.CloseFigure();

            pathOfUpperMiniCircle.StartFigure();
            pathOfUpperMiniCircle.AddEllipse(150 - R / 2 + R / 4, 150 - R / 4 - R / 4, R / 2, R / 2);
            pathOfUpperMiniCircle.CloseFigure();

            for (int x = 150 - R / 4; x < 150; x++)
                for (int y = 150 - R / 2; y < 150; y++)
                    if (pathOfUpperMiniCircle.IsVisible(x, y) && !pathOfMiniCircle.IsVisible(x, y))
                        pointsOfMiniCircle.Add(new Point(x, y));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            graphics.DrawLine(pen, 0, 150, 300, 150);
            graphics.DrawLine(pen, 150, 0, 150, 300);
            graphics.DrawLine(pen, 150 - R / 2, 150 + R / 2, 150 + R / 2, 150 - R / 2);

            pen.DashStyle = DashStyle.Dot;
            graphics.DrawLine(pen, 150, 150 - R / 2, 150 + R / 2, 150 - R / 2);
            graphics.DrawLine(pen, 150 + R / 2, 150, 150 + R / 2, 150 - R / 2);
            pen.DashStyle = DashStyle.Solid;

            graphics.DrawEllipse(pen, 150 - R + R / 2, 150 - R + R / 2, R, R);
            graphics.DrawEllipse(pen, 150 - R / 2 + R / 4, 150 - R / 2 + R / 4, R / 2, R / 2);
            graphics.DrawEllipse(pen, 150 - R / 2 + R / 4, 150 - R / 4 - R / 4, R / 2, R / 2);

            

            if (Enter2)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0: graphics.FillPolygon(Brushes.Black, pointsOfPolygon); break;
                    case 1: graphics.FillPolygon(Brushes.Purple, pointsOfPolygon); break;
                    case 2: graphics.FillPolygon(Brushes.Peru, pointsOfPolygon); break;
                    case 3: graphics.FillPolygon(Brushes.LightPink, pointsOfPolygon); break;
                    case 4: graphics.FillPolygon(Brushes.Magenta, pointsOfPolygon); break;
                    case 5: graphics.FillPolygon(Brushes.SpringGreen, pointsOfPolygon); break;
                    case 6: graphics.FillPolygon(Brushes.Chocolate, pointsOfPolygon); break;
                    case 7: graphics.FillPolygon(Brushes.DarkRed, pointsOfPolygon); break;
                    case 8: graphics.FillPolygon(Brushes.MidnightBlue, pointsOfPolygon); break;
                    case 9: graphics.FillPolygon(Brushes.Violet, pointsOfPolygon); break;
                }
            }
            else
                graphics.FillPolygon(Brushes.Gray, pointsOfPolygon);

            if (Enter1)
                graphics.DrawPolygon(new Pen(fillColor), pointsOfMiniCircle.ToArray());
            else
                graphics.DrawPolygon(new Pen(Color.Gray), pointsOfMiniCircle.ToArray());
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            int curX = e.X;
            int curY = e.Y;
            if (curX < 150 && curY < 150 && pathOfUpperMiniCircle.IsVisible(curX, curY) && !pathOfMiniCircle.IsVisible(curX, curY))
            {
                if (!Enter1)
                {
                    panel1.Invalidate();
                    Enter1 = true;
                }
            }
            else
            {
                if (Enter1)
                {
                    panel1.Invalidate();
                    Enter1 = false;
                }
            }

            if (pathOfPolygon.IsVisible(curX, curY))
            {
                if (!Enter2)
                {
                    panel1.Invalidate();
                    Enter2 = true;
                }
            }
            else
            {
                if (Enter2)
                {
                    panel1.Invalidate();
                    Enter2 = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = fillColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                fillColor = colorDialog.Color;
                panel1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                button2.Text = "Ну ладно уже";
                timer1.Enabled = false;
            }    
            else
            {
                button2.Text = "Харе красить";
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.ForeColor = labelColors[r.Next(0, labelColors.Length)];
            label2.ForeColor = labelColors[r.Next(0, labelColors.Length)];
            label3.ForeColor = labelColors[r.Next(0, labelColors.Length)];
            label4.ForeColor = labelColors[r.Next(0, labelColors.Length)];
            label5.ForeColor = labelColors[r.Next(0, labelColors.Length)];
            label6.ForeColor = labelColors[r.Next(0, labelColors.Length)];
            label7.ForeColor = labelColors[r.Next(0, labelColors.Length)];
            label8.ForeColor = labelColors[r.Next(0, labelColors.Length)];
            label9.ForeColor = labelColors[r.Next(0, labelColors.Length)];
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label label = (Label)sender;
                label.Left += e.X - curs.X - 10;
                label.Top += e.Y - curs.Y - 10;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e) => curs = new Point(e.X, e.Y);
    }
}