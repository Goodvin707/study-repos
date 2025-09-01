using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D31
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.No;
            Text = "Удалить источник заражения";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
    }
}
