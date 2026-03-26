using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency_DB_GUI.Forms
{
    public partial class InputForm : Form
    {
        public string InputValue { get; private set; }

        public InputForm()
        {
            InitializeComponent();
        }

        public InputForm(string title) : this()
        {
            this.Text = title;
        }

        public InputForm(string title, string defaultValue) : this(title)
        {
            textBox1.Text = defaultValue;
            textBox1.SelectAll();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            InputValue = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
