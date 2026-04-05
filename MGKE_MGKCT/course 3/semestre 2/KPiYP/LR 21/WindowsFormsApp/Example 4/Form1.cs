using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мы и не сомневались, что Вы так думаете!");
        }

        private void buttonNo_MouseMove(object sender, MouseEventArgs e)
        {
            buttonNo.Top -= e.Y;
            buttonNo.Left += e.X;
            if (buttonNo.Top < -10 || buttonNo.Top > 100)
                buttonNo.Top = 60;
            if (buttonNo.Left < -80 || buttonNo.Left > 250)
                buttonNo.Left = 120;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to close", "SocOpros", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}