namespace _25__2
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
            this.btnRun = new System.Windows.Forms.Button();
            this.btnWork = new System.Windows.Forms.Button();
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.txbA = new System.Windows.Forms.TextBox();
            this.txbB = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.helpProvider1.SetHelpString(this.btnRun, "Sum");
            this.btnRun.Location = new System.Drawing.Point(16, 64);
            this.btnRun.Name = "btnRun";
            this.helpProvider1.SetShowHelp(this.btnRun, true);
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Сумма";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnWork
            // 
            this.helpProvider1.SetHelpString(this.btnWork, "Start work");
            this.btnWork.Location = new System.Drawing.Point(16, 93);
            this.btnWork.Name = "btnWork";
            this.helpProvider1.SetShowHelp(this.btnWork, true);
            this.btnWork.Size = new System.Drawing.Size(75, 23);
            this.btnWork.TabIndex = 1;
            this.btnWork.Text = "Работа";
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(8, 24);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(65, 13);
            this.lblA.TabIndex = 2;
            this.lblA.Text = "Значение А";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(216, 24);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(65, 13);
            this.lblB.TabIndex = 3;
            this.lblB.Text = "Значение B";
            // 
            // txbA
            // 
            this.helpProvider1.SetHelpString(this.txbA, "For input integer A");
            this.txbA.Location = new System.Drawing.Point(88, 24);
            this.txbA.Name = "txbA";
            this.helpProvider1.SetShowHelp(this.txbA, true);
            this.txbA.Size = new System.Drawing.Size(100, 20);
            this.txbA.TabIndex = 4;
            // 
            // txbB
            // 
            this.helpProvider1.SetHelpString(this.txbB, "For input integer B");
            this.txbB.Location = new System.Drawing.Point(296, 24);
            this.txbB.Name = "txbB";
            this.helpProvider1.SetShowHelp(this.txbB, true);
            this.txbB.Size = new System.Drawing.Size(100, 20);
            this.txbB.TabIndex = 5;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\minsk\\Desktop\\Work\\3-й курс\\Subjects\\2-й семестр\\УПП\\day_25\\Praktice Day" +
    " 25\\25__3\\Help\\Help.docx";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(322, 126);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Text = "Справка";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 161);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.txbB);
            this.Controls.Add(this.txbA);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.btnWork);
            this.Controls.Add(this.btnRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Асинхронный запуск";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnWork;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txbA;
        private System.Windows.Forms.TextBox txbB;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button btnHelp;
    }
}

