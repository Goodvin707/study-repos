using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23__1
{
    public partial class Form2 : Form
    {
        int figureType;
        int r;
        int g;
        int b;
        public Form2()
        {
            InitializeComponent();
            this.Paint += Form2_Paint;
        }

        public Form2(Form parent, int figureType, int r, int g, int b)
        {
            InitializeComponent();
            this.figureType = figureType;
            this.r = r;
            this.g = g;
            this.b = b;
            this.MdiParent = parent;
            this.Paint += Form2_Paint;
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            int w = this.ClientSize.Width, h = this.ClientSize.Height;
            switch (figureType)
            {
                case 0:
                    e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(r, g, b)), new Point[3]
                    {
                        new Point(w / 2, 0),
                        new Point(w, h),
                        new Point(0, h)
                    });
                    break;
                case 1:
                    e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(r, g, b)), new Rectangle(0, 0, Math.Min(w, h), Math.Min(w, h)));
                    break;
                case 2:
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(r, g, b)), new Rectangle(0, h / 5, w, 3 * h / 5));
                    break;
                case 3:
                    e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(r, g, b)), new Point[4]
                    {
                        new Point(w, 0),
                        new Point(4 * w / 5, h),
                        new Point(0, h),
                        new Point(w / 5, 0)
                    });
                    break;
            }
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}