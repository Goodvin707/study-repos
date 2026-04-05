
namespace WindowsFormsAppForLab
{
    partial class frmChild
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChild));
            this.rtfText = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemBold = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemItalic = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUnderline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.MenuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtfText
            // 
            this.rtfText.ContextMenuStrip = this.contextMenuStrip1;
            this.rtfText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfText.Location = new System.Drawing.Point(0, 0);
            this.rtfText.Name = "rtfText";
            this.rtfText.Size = new System.Drawing.Size(323, 220);
            this.rtfText.TabIndex = 0;
            this.rtfText.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemBold,
            this.MenuItemItalic,
            this.MenuItemUnderline});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 70);
            // 
            // MenuItemBold
            // 
            this.MenuItemBold.Name = "MenuItemBold";
            this.MenuItemBold.Size = new System.Drawing.Size(156, 22);
            this.MenuItemBold.Text = "Полужирный";
            this.MenuItemBold.Click += new System.EventHandler(this.MenuItemBold_Click);
            // 
            // MenuItemItalic
            // 
            this.MenuItemItalic.Name = "MenuItemItalic";
            this.MenuItemItalic.Size = new System.Drawing.Size(156, 22);
            this.MenuItemItalic.Text = "Курсив";
            this.MenuItemItalic.Click += new System.EventHandler(this.MenuItemItalic_Click);
            // 
            // MenuItemUnderline
            // 
            this.MenuItemUnderline.Name = "MenuItemUnderline";
            this.MenuItemUnderline.Size = new System.Drawing.Size(156, 22);
            this.MenuItemUnderline.Text = "Подчеркнутый";
            this.MenuItemUnderline.Click += new System.EventHandler(this.MenuItemUnderline_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripSplitButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 195);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(323, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripSplitButton1.Text = "Шрифт";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem1.Text = "Полужирный";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.MenuItemBold_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem2.Text = "Курсив";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.MenuItemItalic_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuItem3.Text = "Подчеркнутый";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.MenuItemUnderline_Click);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUndo,
            this.MenuItemRedo,
            this.MenuItemCopy,
            this.MenuItemCut,
            this.MenuItemPaste});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(63, 22);
            this.toolStripSplitButton2.Text = "Правка";
            this.toolStripSplitButton2.MouseEnter += new System.EventHandler(this.toolStripSplitButton2_MouseEnter);
            // 
            // MenuItemUndo
            // 
            this.MenuItemUndo.Name = "MenuItemUndo";
            this.MenuItemUndo.Size = new System.Drawing.Size(180, 22);
            this.MenuItemUndo.Text = "Отменить";
            this.MenuItemUndo.Click += new System.EventHandler(this.MenuItemUndo_Click);
            // 
            // MenuItemRedo
            // 
            this.MenuItemRedo.Name = "MenuItemRedo";
            this.MenuItemRedo.Size = new System.Drawing.Size(180, 22);
            this.MenuItemRedo.Text = "Повторить";
            this.MenuItemRedo.Click += new System.EventHandler(this.MenuItemRedo_Click);
            // 
            // MenuItemCopy
            // 
            this.MenuItemCopy.Name = "MenuItemCopy";
            this.MenuItemCopy.Size = new System.Drawing.Size(180, 22);
            this.MenuItemCopy.Text = "Копировать";
            this.MenuItemCopy.Click += new System.EventHandler(this.MenuItemCopy_Click);
            // 
            // MenuItemCut
            // 
            this.MenuItemCut.Name = "MenuItemCut";
            this.MenuItemCut.Size = new System.Drawing.Size(180, 22);
            this.MenuItemCut.Text = "Вырезать";
            this.MenuItemCut.Click += new System.EventHandler(this.MenuItemCut_Click);
            // 
            // MenuItemPaste
            // 
            this.MenuItemPaste.Name = "MenuItemPaste";
            this.MenuItemPaste.Size = new System.Drawing.Size(180, 22);
            this.MenuItemPaste.Text = "Вставить";
            this.MenuItemPaste.Click += new System.EventHandler(this.MenuItemPaste_Click);
            // 
            // frmChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 220);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.rtfText);
            this.Name = "frmChild";
            this.Text = "frmChild";
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBold;
        private System.Windows.Forms.ToolStripMenuItem MenuItemItalic;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUnderline;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRedo;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCut;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPaste;
    }
}