namespace Educ
{
    partial class AddEditDelRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditDelRecord));
            this.cancelbutton = new System.Windows.Forms.Button();
            this.addbutton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.вставитьtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вБуферToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelbutton
            // 
            this.cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelbutton.Location = new System.Drawing.Point(84, 3);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 1;
            this.cancelbutton.Text = "Отмена";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(3, 3);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(75, 23);
            this.addbutton.TabIndex = 0;
            this.addbutton.Text = "Добавить";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel2.Controls.Add(this.addbutton);
            this.flowLayoutPanel2.Controls.Add(this.cancelbutton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 184);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(361, 37);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(361, 160);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вставитьtoolStripMenuItem,
            this.вБуферToolStripMenuItem,
            this.очиститьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(361, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // вставитьtoolStripMenuItem
            // 
            this.вставитьtoolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.вставитьtoolStripMenuItem.Name = "вставитьtoolStripMenuItem";
            this.вставитьtoolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.вставитьtoolStripMenuItem.Text = "Вставить из буфера";
            this.вставитьtoolStripMenuItem.Click += new System.EventHandler(this.вставитьtoolStripMenuItem_Click);
            // 
            // вБуферToolStripMenuItem
            // 
            this.вБуферToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.вБуферToolStripMenuItem.Name = "вБуферToolStripMenuItem";
            this.вБуферToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.вБуферToolStripMenuItem.Text = "Копировать в буфер";
            this.вБуферToolStripMenuItem.Click += new System.EventHandler(this.вБуферToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // AddEditDelRecord
            // 
            this.AcceptButton = this.addbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.cancelbutton;
            this.ClientSize = new System.Drawing.Size(361, 221);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(377, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(377, 260);
            this.Name = "AddEditDelRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить запись";
            this.Load += new System.EventHandler(this.AddEditDelRecord_Load);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem вБуферToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставитьtoolStripMenuItem;
    }
}