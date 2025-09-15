using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESUM
{
    public partial class AddDiscipline : Form
    {
        public AddDiscipline()
        {
            InitializeComponent();
        }

        public AddDiscipline(string disp) : this()
        {
            Text = "Изменить дисцилину";
            button1.Text = "Изменить";
            textBox1.Text = disp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Поле не заполнено", "!");
        }

        private void button2_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;
    }
}