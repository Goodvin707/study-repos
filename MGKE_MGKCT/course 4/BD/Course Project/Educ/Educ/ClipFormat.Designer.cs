namespace Educ
{
    partial class ClipFormat
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
            this.addbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(12, 60);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(71, 23);
            this.addbutton.TabIndex = 2;
            this.addbutton.Text = "Принять";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelbutton.Location = new System.Drawing.Point(188, 60);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(71, 23);
            this.cancelbutton.TabIndex = 3;
            this.cancelbutton.Text = "Отмена";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Разделитель\r\nзначений в строке";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(188, 23);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 31);
            this.textBox1.TabIndex = 5;
            // 
            // ClipFormat
            // 
            this.AcceptButton = this.addbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelbutton;
            this.ClientSize = new System.Drawing.Size(271, 91);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.cancelbutton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ClipFormat";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Формат копирования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}