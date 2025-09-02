using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic.DialogForms
{
    public partial class HelpForm : Form
    {
        Point lastPoint;
        public HelpForm()
        {
            InitializeComponent();
            textBox1.SelectionStart = 0;
        }

        private void button1_Click(object sender, EventArgs e) => Close();

        private void HelpForm_MouseDown(object sender, MouseEventArgs e) => lastPoint = new Point(e.X, e.Y);

        private void HelpForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }
    }
}