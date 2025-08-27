using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppForLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuItemNone_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string text = item.Text;
            switch (text)
            {
                case "Пусто":
                    trackBar1.TickStyle = TickStyle.None;
                    break;
                case "Сверху-слева":
                    trackBar1.TickStyle = TickStyle.TopLeft;
                    break;
                case "Снизу-справа":
                    trackBar1.TickStyle = TickStyle.BottomRight;
                    break;
                case "С обеих сторон":
                    trackBar1.TickStyle = TickStyle.Both;
                    break;
            }
            foreach (ToolStripMenuItem item1 in menuItemTrackBar.DropDownItems)
            {
                if (item1.Text == text)
                    item1.Checked = true;
                else
                    item1.Checked = false;
            }
            foreach (ToolStripMenuItem item1 in contextMenuStrip2.Items)
            {
                if (item1.Text == text)
                    item1.Checked = true;
                else
                    item1.Checked = false;
            }
        }

        private void toolStripMenuItemH_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string text = item.Text;
            switch (text)
            {
                case "Горизонтальная":
                    trackBar1.Orientation = Orientation.Horizontal;
                    break;
                case "Вертикальная":
                    trackBar1.Orientation = Orientation.Vertical;
                    break;
            }
            foreach (ToolStripMenuItem item1 in toolStripMenuItemOrientation.DropDownItems)
            {
                if (item1.Text == text)
                    item1.Checked = true;
                else
                    item1.Checked = false;
            }
        }
    }
}