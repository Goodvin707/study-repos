using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19__4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите выйти?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || !radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Не все данные указаны", "Ошибка регистрации");
                goto down;
            }
            string section = "";
            if (radioButton1.Checked)
                section = "Компьютерная графика";
            if (radioButton2.Checked)
                section = "WEB-дизайн";
            if (radioButton3.Checked)
                section = "Машинное обучение";
            comboBox1.Items.Add(textBox1.Text + " | " + section);
        down:;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            foreach (string item in listBox1.Items)
            {
                if ('"' + textBox2.Text + '"' == item)
                {
                    MessageBox.Show("Такая тема уже есть в списке", "Хмм...");
                    flag = false;
                    break;
                }
                    
            }
            if (flag == true)
                listBox1.Items.Add('"' + textBox2.Text + '"');
        }
    }
}