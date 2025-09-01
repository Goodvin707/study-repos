using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20__5
{
    public partial class Form1 : Form
    {
        string s = "Быть?";
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add(s);
            if (s == "Быть?")
                s = "Или не быть?";
            else if (s == "Или не быть?")
                s = "Быть?";
        }
    }
}