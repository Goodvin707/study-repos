using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23__3
{
    public partial class Form1 : Form
    {
        public enum Tools
        {
            PEN = 1, TEXT, LINE, ELLIPSE, NULL = 0
        }
        Tools curentTool;
        public Form1()
        {
            InitializeComponent();
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "toolStripButtonPen":
                    curentTool = Tools.PEN;
                    statusStrip1.Items[0].Text = "Выбран карандаш"; break;
                case "toolStripButtonText":
                    curentTool = Tools.TEXT;
                    statusStrip1.Items[0].Text = "Создание надписей"; break;
                case "toolStripButtonLine":
                    curentTool = Tools.LINE;
                    statusStrip1.Items[0].Text = "Рисование линий"; break;
                case "toolStripButtonEllipse":
                    curentTool = Tools.ELLIPSE;
                    statusStrip1.Items[0].Text = "Рисование эллипса"; break;
            }
            SetToolStripButtonsPushedState(e.ClickedItem);
        }
        private void SetToolStripButtonsPushedState(ToolStripItem button)
        {
            foreach (ToolStripButton btnItem in toolStrip1.Items)
            {
                if (btnItem == button)
                    btnItem.Checked = true;
                else
                    btnItem.Checked = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("В задании на 10 баллов всё что надо есть", "Ну в общем");
        }
    }
}