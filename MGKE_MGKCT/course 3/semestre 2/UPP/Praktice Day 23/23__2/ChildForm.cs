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
    public partial class ChildForm : Form
    {
        Rectangle rect1 = new Rectangle(150, 70, 100, 150);
        Rectangle rect2 = new Rectangle(350, 70, 100, 150);
        public ChildForm()
        {
            InitializeComponent();
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(MoveCircle));
            thread1.Name = "First";
            Thread thread2 = new Thread(new ThreadStart(MoveCircle));
            thread2.Name = "Second";
            Thread thread3 = new Thread(new ThreadStart(MoveCircle));
            thread3.Name = "Third";
            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        private void ChildForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            g.FillRectangle(Brushes.Black, rect1);
            g.FillRectangle(Brushes.Black, rect2);
        }

        private void MoveCircle()
        {
            lock (this)
            {
                Graphics g = this.CreateGraphics();
                Brush b1 = Brushes.Red;
                Brush b2 = SystemBrushes.Control;
                int y;
                if (Thread.CurrentThread.Name == "First")
                    y = Height / 2 - 60;
                else if (Thread.CurrentThread.Name == "Second")
                    y = Height / 2 - 20;
                else
                    y = Height / 2 + 20;
                for (int x = 10; x < Width - 40; x += 2)
                {
                    g.FillEllipse(b1, x - 10, y - 10, 20, 20);
                    Thread.Sleep(30);

                    // Если круг или его часть внутри прямоугольника
                    if (x + 10 > rect1.X && x - 10 < rect1.X + rect1.Width)
                        Invalidate(rect1);
                    else if (x + 10 > rect2.X && x - 10 < rect2.X + rect2.Width)
                        Invalidate(rect2);
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