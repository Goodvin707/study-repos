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
    public partial class frmChild : Form
    {
        public frmChild()
        {
            InitializeComponent();
        }
        public frmChild(frmContainer parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void MenuItemBold_Click(object sender, EventArgs e)
        {
            Font newFont = new Font(
                rtfText.SelectionFont,
                rtfText.SelectionFont.Bold ? rtfText.SelectionFont.Style & ~FontStyle.Bold : rtfText.SelectionFont.Style | FontStyle.Bold);
            rtfText.SelectionFont = newFont;
        }

        private void MenuItemItalic_Click(object sender, EventArgs e)
        {
            Font newFont = new Font(
                rtfText.SelectionFont,
                rtfText.SelectionFont.Italic ? rtfText.SelectionFont.Style & ~FontStyle.Italic : rtfText.SelectionFont.Style | FontStyle.Italic);
            rtfText.SelectionFont = newFont;
        }

        private void MenuItemUnderline_Click(object sender, EventArgs e)
        {
            Font newFont = new Font(
                rtfText.SelectionFont,
                rtfText.SelectionFont.Underline ? rtfText.SelectionFont.Style & ~FontStyle.Underline : rtfText.SelectionFont.Style | FontStyle.Underline);
            rtfText.SelectionFont = newFont;
        }

        private void MenuItemPaste_Click(object sender, EventArgs e) => rtfText.Paste();

        private void MenuItemCut_Click(object sender, EventArgs e) => rtfText.Cut();

        private void MenuItemCopy_Click(object sender, EventArgs e) => rtfText.Copy();

        private void MenuItemRedo_Click(object sender, EventArgs e) => rtfText.Redo();

        private void MenuItemUndo_Click(object sender, EventArgs e) => rtfText.Undo();

        private void toolStripSplitButton2_MouseEnter(object sender, EventArgs e)
        {
            MenuItemCut.Enabled = rtfText.SelectedText.Length > 0 ? true : false;
            MenuItemPaste.Enabled = Clipboard.ContainsText() ? true : false;
        }
    }
}