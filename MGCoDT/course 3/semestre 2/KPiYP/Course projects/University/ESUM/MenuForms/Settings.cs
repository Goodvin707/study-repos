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
    public partial class Settings : Form
    {
        enum AppStyle
        {
            Default,
            Dark,
            VTBBank,
            ExcelVibe
        }
        public Settings(int currentAppStyle)
        {
            InitializeComponent();
            switch (currentAppStyle)
            {
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
                case 4:
                    radioButton4.Checked = true;
                    break;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                ColorPackage.currentAppStyle = 1;
            if (radioButton2.Checked)
                ColorPackage.currentAppStyle = 2;
            if (radioButton3.Checked)
                ColorPackage.currentAppStyle = 3;
            if (radioButton4.Checked)
                ColorPackage.currentAppStyle = 4;
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorPackage.currentAppStyle = 0;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}