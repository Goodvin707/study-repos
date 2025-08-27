using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppForLab
{
    public partial class frmContainer : Form
    {
        public frmContainer()
        {
            InitializeComponent();
            frmChild child = new frmChild(this);
            child.Show();
        }

        private void MenuItemNewWindow_Click(object sender, EventArgs e)
        {
            frmChild newChild = new frmChild(this);
            newChild.Show();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}