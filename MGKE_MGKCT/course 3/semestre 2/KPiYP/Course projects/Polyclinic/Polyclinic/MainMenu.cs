using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic
{
    public partial class MainMenu : Form
    {
        
        public MainMenu()
        {
            InitializeComponent();
            if (User.Login != "admin") // если обычный пользователь
            {
                btnUsersControl.Visible = false;
            }
            else // если админ
            {
                btnChangeUser.Visible = false;
            }
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void btnSpecies_Click(object sender, EventArgs e)
        {
            this.Hide();
            Species species = new Species(this);
            species.Show();
        }

        private void btnVrachy_Click(object sender, EventArgs e)
        {
            this.Hide();
            Vrachi species = new Vrachi(this);
            species.Show();
        }

        private void btnUslugy_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uslugy species = new Uslugy(this);
            species.Show();
        }

        private void btnPriem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Priem species = new Priem(this);
            species.Show();
        }

        private void btnPaidServices_Click(object sender, EventArgs e)
        {
            this.Hide();
            PaidServices species = new PaidServices(this);
            species.Show();
        }

        private void bntZap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Zapisatsya zapisatsya = new Zapisatsya(this);
            zapisatsya.Show();
        }

        private void btnMyZapisy_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyZapisy zapisatsya = new MyZapisy(this);
            zapisatsya.Show();
        }

        private void btnUsersControl_Click(object sender, EventArgs e)
        {
            this.Hide();
            UsersControl zapisatsya = new UsersControl(this);
            zapisatsya.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                Autorize a = new Autorize();
                a.Show();
                this.Hide();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            Autorize a = new Autorize();
            a.Show();
            this.Hide();
        }
    }
}