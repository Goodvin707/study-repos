
namespace WindowsFormsAppForLab
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMove = new System.Windows.Forms.ToolStripMenuItem();
            this.уведомитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сообщение1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сообщение2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сообщение3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTrackBar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNone = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTopLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBottomRight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrientation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemH = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCommand,
            this.menuItemTrackBar,
            this.menuItemAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(316, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemCommand
            // 
            this.menuItemCommand.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAdd,
            this.menuItemDel,
            this.menuItemMove,
            this.уведомитьToolStripMenuItem});
            this.menuItemCommand.Name = "menuItemCommand";
            this.menuItemCommand.Size = new System.Drawing.Size(102, 20);
            this.menuItemCommand.Text = "Команда меню";
            // 
            // menuItemAdd
            // 
            this.menuItemAdd.Name = "menuItemAdd";
            this.menuItemAdd.Size = new System.Drawing.Size(146, 22);
            this.menuItemAdd.Text = "Добавить";
            // 
            // menuItemDel
            // 
            this.menuItemDel.Name = "menuItemDel";
            this.menuItemDel.Size = new System.Drawing.Size(146, 22);
            this.menuItemDel.Text = "Удалить";
            // 
            // menuItemMove
            // 
            this.menuItemMove.Name = "menuItemMove";
            this.menuItemMove.Size = new System.Drawing.Size(146, 22);
            this.menuItemMove.Text = "Переместить";
            // 
            // уведомитьToolStripMenuItem
            // 
            this.уведомитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сообщение1ToolStripMenuItem,
            this.сообщение2ToolStripMenuItem,
            this.сообщение3ToolStripMenuItem});
            this.уведомитьToolStripMenuItem.Name = "уведомитьToolStripMenuItem";
            this.уведомитьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.уведомитьToolStripMenuItem.Text = "Уведомить";
            // 
            // сообщение1ToolStripMenuItem
            // 
            this.сообщение1ToolStripMenuItem.Name = "сообщение1ToolStripMenuItem";
            this.сообщение1ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.сообщение1ToolStripMenuItem.Text = "Сообщение 1";
            // 
            // сообщение2ToolStripMenuItem
            // 
            this.сообщение2ToolStripMenuItem.Name = "сообщение2ToolStripMenuItem";
            this.сообщение2ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.сообщение2ToolStripMenuItem.Text = "Сообщение 2";
            // 
            // сообщение3ToolStripMenuItem
            // 
            this.сообщение3ToolStripMenuItem.Name = "сообщение3ToolStripMenuItem";
            this.сообщение3ToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.сообщение3ToolStripMenuItem.Text = "Сообщение 3";
            // 
            // menuItemTrackBar
            // 
            this.menuItemTrackBar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNone,
            this.menuItemTopLeft,
            this.menuItemBottomRight,
            this.menuItemBoth,
            this.toolStripMenuItemOrientation});
            this.menuItemTrackBar.Name = "menuItemTrackBar";
            this.menuItemTrackBar.Size = new System.Drawing.Size(98, 20);
            this.menuItemTrackBar.Text = "Стиль бегунка";
            this.menuItemTrackBar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuItemNone
            // 
            this.menuItemNone.Name = "menuItemNone";
            this.menuItemNone.Size = new System.Drawing.Size(180, 22);
            this.menuItemNone.Text = "Пусто";
            this.menuItemNone.Click += new System.EventHandler(this.menuItemNone_Click);
            // 
            // menuItemTopLeft
            // 
            this.menuItemTopLeft.Name = "menuItemTopLeft";
            this.menuItemTopLeft.Size = new System.Drawing.Size(180, 22);
            this.menuItemTopLeft.Text = "Сверху-слева";
            this.menuItemTopLeft.Click += new System.EventHandler(this.menuItemNone_Click);
            // 
            // menuItemBottomRight
            // 
            this.menuItemBottomRight.Checked = true;
            this.menuItemBottomRight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemBottomRight.Name = "menuItemBottomRight";
            this.menuItemBottomRight.Size = new System.Drawing.Size(180, 22);
            this.menuItemBottomRight.Text = "Снизу-справа";
            this.menuItemBottomRight.Click += new System.EventHandler(this.menuItemNone_Click);
            // 
            // menuItemBoth
            // 
            this.menuItemBoth.Name = "menuItemBoth";
            this.menuItemBoth.Size = new System.Drawing.Size(180, 22);
            this.menuItemBoth.Text = "С обеих сторон";
            this.menuItemBoth.Click += new System.EventHandler(this.menuItemNone_Click);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(94, 20);
            this.menuItemAbout.Text = "О программе";
            // 
            // trackBar1
            // 
            this.trackBar1.ContextMenuStrip = this.contextMenuStrip2;
            this.trackBar1.Location = new System.Drawing.Point(12, 43);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(276, 45);
            this.trackBar1.TabIndex = 1;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(161, 92);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem4.Text = "Пусто";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.menuItemNone_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem5.Text = "Сверху-слева";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.menuItemNone_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Checked = true;
            this.toolStripMenuItem6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem6.Text = "Снизу-справа";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.menuItemNone_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem7.Text = "С обеих сторон";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.menuItemNone_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem1.Text = "Добавить";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem2.Text = "Удалить";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem3.Text = "Переместить";
            // 
            // toolStripMenuItemOrientation
            // 
            this.toolStripMenuItemOrientation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemH,
            this.toolStripMenuItemV});
            this.toolStripMenuItemOrientation.Name = "toolStripMenuItemOrientation";
            this.toolStripMenuItemOrientation.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemOrientation.Text = "Ориентация";
            // 
            // toolStripMenuItemH
            // 
            this.toolStripMenuItemH.Name = "toolStripMenuItemH";
            this.toolStripMenuItemH.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemH.Text = "Горизонтальная";
            this.toolStripMenuItemH.Click += new System.EventHandler(this.toolStripMenuItemH_Click);
            // 
            // toolStripMenuItemV
            // 
            this.toolStripMenuItemV.Name = "toolStripMenuItemV";
            this.toolStripMenuItemV.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemV.Text = "Вертикальная";
            this.toolStripMenuItemV.Click += new System.EventHandler(this.toolStripMenuItemH_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 326);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemCommand;
        private System.Windows.Forms.ToolStripMenuItem menuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem menuItemDel;
        private System.Windows.Forms.ToolStripMenuItem menuItemMove;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem уведомитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сообщение1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сообщение2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сообщение3ToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolStripMenuItem menuItemTrackBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemNone;
        private System.Windows.Forms.ToolStripMenuItem menuItemTopLeft;
        private System.Windows.Forms.ToolStripMenuItem menuItemBottomRight;
        private System.Windows.Forms.ToolStripMenuItem menuItemBoth;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrientation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemH;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemV;
    }
}

