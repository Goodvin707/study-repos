using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22__1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Cortege> teachers = new List<Cortege>();
            List<string> departaments = new List<string>();
            StreamReader sr = new StreamReader("input.txt");
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                string[] items = s.Split('|');
                Cortege cortege = new Cortege()
                {
                    ФИО = items[0].Trim(),
                    Должность = items[1].Trim(),
                    Кафедра = items[2].Trim(),
                    Зарплата = Convert.ToDouble(items[3].Trim())
                };
                if (!departaments.Contains(cortege.Кафедра))
                    departaments.Add(cortege.Кафедра);
                teachers.Add(cortege);
            }
            sr.Close();
            dataGridView1.DataSource = teachers;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Кафедра";
            column1.Width = 100;
            column1.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView2.Columns.Add(column1);

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Зарплата";
            column2.Width = 100;
            column2.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView2.Columns.Add(column2);

            double sum = 0;
            double gsum = 0;
            int count = 0;
            for (int i = 0; i < departaments.Count; ++i)
            {
                for (int j = 0; j < teachers.Count; j++)
                {
                    if (teachers[j].Кафедра == departaments[i])
                    {
                        sum += teachers[j].Зарплата;
                        count++;
                    }
                }
                dataGridView2.Rows.Add(departaments[i], Math.Round(sum / count, 2) + "₽");
                gsum += sum;
                sum = 0;
                count = 0;
            }
            label1.Text += gsum;
        }
    }
}