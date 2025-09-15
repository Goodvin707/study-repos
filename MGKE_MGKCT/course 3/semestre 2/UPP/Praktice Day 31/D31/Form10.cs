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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;
            Text = "Средние выбросы";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }
    }
}
