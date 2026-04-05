using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Educ
{
    public partial class ClipFormat : Form
    {
        public ClipFormat()
        {
            InitializeComponent();
            textBox1.Text = ClipSettings.Separator.ToString();
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                ClipSettings.Separator = textBox1.Text[0];
                DialogResult = DialogResult.OK;
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}