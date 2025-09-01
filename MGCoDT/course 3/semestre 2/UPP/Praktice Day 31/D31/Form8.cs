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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            button1.DialogResult = DialogResult.OK;  
            Text = "Минимальные выбросы";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            
        }
    }
}
