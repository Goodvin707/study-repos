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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] words = textBox1.Text.Split(' ');
            if (checkBox1.Checked)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i][0] != textBox2.Text.ToUpper()[0] && words[i][0] != textBox2.Text.ToLower()[0])
                        Data.Ts.Add(words[i]);
                }
            }
            if (checkBox2.Checked)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i][words[i].Length - 1] != textBox2.Text.ToUpper()[0] && words[i][words[i].Length - 1] != textBox2.Text.ToLower()[0])
                        Data.Vs.Add(words[i]);
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
                e.Handled = true;
        }
    }
}