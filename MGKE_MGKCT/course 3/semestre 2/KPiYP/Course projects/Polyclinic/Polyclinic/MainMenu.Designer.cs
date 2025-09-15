
namespace Polyclinic
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSpecies = new System.Windows.Forms.Button();
            this.btnVrachy = new System.Windows.Forms.Button();
            this.btnUslugy = new System.Windows.Forms.Button();
            this.btnPriem = new System.Windows.Forms.Button();
            this.btnPaidServices = new System.Windows.Forms.Button();
            this.btnZap = new System.Windows.Forms.Button();
            this.btnMyZapisy = new System.Windows.Forms.Button();
            this.btnUsersControl = new System.Windows.Forms.Button();
            this.btnChangeUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(308, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(190, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnSpecies
            // 
            this.btnSpecies.BackColor = System.Drawing.Color.White;
            this.btnSpecies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpecies.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSpecies.Location = new System.Drawing.Point(12, 75);
            this.btnSpecies.Name = "btnSpecies";
            this.btnSpecies.Size = new System.Drawing.Size(218, 52);
            this.btnSpecies.TabIndex = 1;
            this.btnSpecies.Text = "Специальности";
            this.btnSpecies.UseVisualStyleBackColor = false;
            this.btnSpecies.Click += new System.EventHandler(this.btnSpecies_Click);
            // 
            // btnVrachy
            // 
            this.btnVrachy.BackColor = System.Drawing.Color.White;
            this.btnVrachy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVrachy.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVrachy.Location = new System.Drawing.Point(12, 183);
            this.btnVrachy.Name = "btnVrachy";
            this.btnVrachy.Size = new System.Drawing.Size(218, 52);
            this.btnVrachy.TabIndex = 2;
            this.btnVrachy.Text = "Врачи";
            this.btnVrachy.UseVisualStyleBackColor = false;
            this.btnVrachy.Click += new System.EventHandler(this.btnVrachy_Click);
            // 
            // btnUslugy
            // 
            this.btnUslugy.BackColor = System.Drawing.Color.White;
            this.btnUslugy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUslugy.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUslugy.Location = new System.Drawing.Point(570, 75);
            this.btnUslugy.Name = "btnUslugy";
            this.btnUslugy.Size = new System.Drawing.Size(218, 52);
            this.btnUslugy.TabIndex = 7;
            this.btnUslugy.Text = "Услуги";
            this.btnUslugy.UseVisualStyleBackColor = false;
            this.btnUslugy.Click += new System.EventHandler(this.btnUslugy_Click);
            // 
            // btnPriem
            // 
            this.btnPriem.BackColor = System.Drawing.Color.White;
            this.btnPriem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPriem.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPriem.Location = new System.Drawing.Point(12, 284);
            this.btnPriem.Name = "btnPriem";
            this.btnPriem.Size = new System.Drawing.Size(218, 52);
            this.btnPriem.TabIndex = 3;
            this.btnPriem.Text = "Прием";
            this.btnPriem.UseVisualStyleBackColor = false;
            this.btnPriem.Click += new System.EventHandler(this.btnPriem_Click);
            // 
            // btnPaidServices
            // 
            this.btnPaidServices.BackColor = System.Drawing.Color.White;
            this.btnPaidServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaidServices.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPaidServices.Location = new System.Drawing.Point(570, 183);
            this.btnPaidServices.Name = "btnPaidServices";
            this.btnPaidServices.Size = new System.Drawing.Size(218, 52);
            this.btnPaidServices.TabIndex = 8;
            this.btnPaidServices.Text = "Платные услуги";
            this.btnPaidServices.UseVisualStyleBackColor = false;
            this.btnPaidServices.Click += new System.EventHandler(this.btnPaidServices_Click);
            // 
            // btnZap
            // 
            this.btnZap.BackColor = System.Drawing.Color.White;
            this.btnZap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZap.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnZap.Location = new System.Drawing.Point(570, 284);
            this.btnZap.Name = "btnZap";
            this.btnZap.Size = new System.Drawing.Size(218, 52);
            this.btnZap.TabIndex = 9;
            this.btnZap.Text = "Записаться";
            this.btnZap.UseVisualStyleBackColor = false;
            this.btnZap.Click += new System.EventHandler(this.bntZap_Click);
            // 
            // btnMyZapisy
            // 
            this.btnMyZapisy.BackColor = System.Drawing.Color.White;
            this.btnMyZapisy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyZapisy.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMyZapisy.Location = new System.Drawing.Point(293, 219);
            this.btnMyZapisy.Name = "btnMyZapisy";
            this.btnMyZapisy.Size = new System.Drawing.Size(218, 52);
            this.btnMyZapisy.TabIndex = 4;
            this.btnMyZapisy.Text = "Мои записи";
            this.btnMyZapisy.UseVisualStyleBackColor = false;
            this.btnMyZapisy.Click += new System.EventHandler(this.btnMyZapisy_Click);
            // 
            // btnUsersControl
            // 
            this.btnUsersControl.BackColor = System.Drawing.Color.White;
            this.btnUsersControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsersControl.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUsersControl.Location = new System.Drawing.Point(293, 284);
            this.btnUsersControl.Name = "btnUsersControl";
            this.btnUsersControl.Size = new System.Drawing.Size(218, 52);
            this.btnUsersControl.TabIndex = 5;
            this.btnUsersControl.Text = "Пользователи";
            this.btnUsersControl.UseVisualStyleBackColor = false;
            this.btnUsersControl.Click += new System.EventHandler(this.btnUsersControl_Click);
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.BackColor = System.Drawing.Color.White;
            this.btnChangeUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeUser.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChangeUser.Location = new System.Drawing.Point(293, 284);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(218, 68);
            this.btnChangeUser.TabIndex = 6;
            this.btnChangeUser.Text = "Сменить пользователя";
            this.btnChangeUser.UseVisualStyleBackColor = false;
            this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(799, 386);
            this.Controls.Add(this.btnUsersControl);
            this.Controls.Add(this.btnMyZapisy);
            this.Controls.Add(this.btnZap);
            this.Controls.Add(this.btnPaidServices);
            this.Controls.Add(this.btnPriem);
            this.Controls.Add(this.btnUslugy);
            this.Controls.Add(this.btnVrachy);
            this.Controls.Add(this.btnSpecies);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnChangeUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainMenu_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSpecies;
        private System.Windows.Forms.Button btnVrachy;
        private System.Windows.Forms.Button btnUslugy;
        private System.Windows.Forms.Button btnPriem;
        private System.Windows.Forms.Button btnPaidServices;
        private System.Windows.Forms.Button btnZap;
        private System.Windows.Forms.Button btnMyZapisy;
        private System.Windows.Forms.Button btnUsersControl;
        private System.Windows.Forms.Button btnChangeUser;
    }
}