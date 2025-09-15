using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23__2
{
    public partial class Primer : Form
    {
        Rectangle rect = new Rectangle(180, 110, 150, 100);
        public Primer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(MoveCircle));
            thread1.Name = "First";
            Thread thread2 = new Thread(new ThreadStart(MoveCircle));
            thread2.Name = "Second";
            thread1.Start();
            thread2.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            g.FillRectangle(Brushes.Black, rect);
        }

        private void MoveCircle()
        {
            lock (this)
            {
                Graphics g = this.CreateGraphics();
                Brush b1 = Brushes.Red;
                Brush b2 = SystemBrushes.Control;
                int x;
                if (Thread.CurrentThread.Name == "First")
                    x = Width / 2 - 30;
                else
                    x = Width / 2 + 30;
                for (int y = 10; y < Height - 40; y++)
                {
                    g.FillEllipse(b1, x - 10, y - 10, 20, 20);
                    Thread.Sleep(30);
                    if (y + 10 > rect.Y && y - 10 < rect.Y + rect.Height)
                        Invalidate(rect);
                    else
                    {
                        Monitor.Pulse(this);
                        Monitor.Wait(this);
                    }
                    g.FillEllipse(b2, x - 10, y - 10, 20, 20);
                }
                Monitor.Pulse(this);
            }
            MessageBox.Show("Поток " + Thread.CurrentThread.Name + " завершен!");
        }
    }
}