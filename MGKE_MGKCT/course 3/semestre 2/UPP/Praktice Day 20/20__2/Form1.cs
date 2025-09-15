using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20__2
{
    public partial class Form1 : Form
    {
        Button[,] buttons = new Button[3, 3];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int c = 1;
            for (int j = 0; j < buttons.GetLength(1); j++)
            {
                for (int i = 0; i < buttons.GetLength(0); i++)
                {
                    buttons[j, i] = new Button();
                    buttons[j, i].Text = c++.ToString();
                    buttons[j, i].Size = new Size(50, 50);
                    buttons[j, i].Location = new Point(20 + 70 * i, 40 + 70 * j);
                    buttons[j, i].Click += new EventHandler(arraybutton_Click);
                    Controls.Add(buttons[j, i]);
                }
            }
        }

        private void arraybutton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.DarkRed;
            int btnValue = Convert.ToInt32(button.Text);
            button.Text = (btnValue * 10).ToString();
        }
    }
}