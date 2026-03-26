using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_DB_GUI.Utils;

namespace TravelAgency_DB_GUI.Forms
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DatabaseController.TestConnection(textBox1.Text, maskedTextBox1.Text))
            {
                CurrentUser.Login = textBox1.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Auth_Load(object sender, EventArgs e) => button1.PerformClick();
    }
}
