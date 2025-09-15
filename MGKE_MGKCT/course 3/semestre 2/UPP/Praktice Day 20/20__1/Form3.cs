using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20__1
{
    public partial class Form3 : Form
    {
        public Form3(Color color)
        {
            InitializeComponent();
            label1.ForeColor = color;
            label2.ForeColor = color;
            listBox1.ForeColor = color;
            listBox2.ForeColor = color;
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            for (int i = 0; i < Data.Ts.Count; i++)
                listBox1.Items.Add(Data.Ts[i]);
            for (int i = 0; i < Data.Vs.Count; i++)
                listBox2.Items.Add(Data.Vs[i]);
        }
    }
}