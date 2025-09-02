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
    public partial class DeleleRow : Form
    {
        public DeleleRow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}