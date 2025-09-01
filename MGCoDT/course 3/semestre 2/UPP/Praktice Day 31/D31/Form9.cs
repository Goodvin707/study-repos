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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            Text = "Максимальные выбросы";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

        }
    }
}
