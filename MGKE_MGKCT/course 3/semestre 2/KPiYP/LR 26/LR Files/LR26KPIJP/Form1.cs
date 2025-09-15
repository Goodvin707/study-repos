using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR26KPIJP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "employeeDataSet1.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter1.Fill(this.employeeDataSet1.Employee);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "employeeDataSet.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.employeeDataSet.Employee);
            textBox1.DataBindings.Add("Text", employeeDataSet1, "Employee.Surname");
            textBox2.DataBindings.Add("Text", employeeDataSet1, "Employee.Name");
            textBox3.DataBindings.Add("Text", employeeDataSet1, "Employee.Patronymic");
            textBox7.DataBindings.Add("Text", employeeDataSet1, "Employee.NatName");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}