using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESUM
{
    public partial class DeleteRow : Form
    {
        public DeleteRow()
        {
            InitializeComponent();
        }

        public DeleteRow(string s)
        {
            InitializeComponent();
            label2.Text = s;
        }

        private void button1_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}