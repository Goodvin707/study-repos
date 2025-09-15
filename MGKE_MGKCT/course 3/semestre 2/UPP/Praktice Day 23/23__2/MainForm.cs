using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23__2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Primer primer = new Primer();
            primer.Show();
            ChildForm newMDIChild = new ChildForm();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();
        }
    }
}