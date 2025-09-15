using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic.DialogForms
{
    public partial class AddSpec : Form
    {
        public AddSpec()
        {
            InitializeComponent();
        }
        public AddSpec(string title)
        {
            InitializeComponent();
            textBox1.Text = title;
            Text = "Изменить специальность";
            button1.Text = "Изменить";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Название не может быть пустым", "Ошибка ввода");
            else
                DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}