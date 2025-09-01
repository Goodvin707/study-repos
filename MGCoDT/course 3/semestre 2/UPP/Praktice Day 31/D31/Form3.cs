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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            button2.DialogResult = DialogResult.No;
            Text = "Редактировать источник";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
    }
}
