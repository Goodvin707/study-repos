using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace _24__2
{
    public partial class Form1 : Form
    {
        Color backColor = Color.White;
        Color seriaColor = Color.Blue;
        static int index = 1;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add(0.ToString(), "X");
            dataGridView1.Columns.Add(1.ToString(), "Y");
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 130;
            chart1.Series["Series1"].LegendText = "Y (X)";
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чтобы отобразить таблицу и график, нажмите Создать\nРозрабатчик\nАлексей С. Ю.", "Справка");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                chart1.Series["Series1"].Color = colorDialog.Color;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                chart1.BackColor = colorDialog.Color;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
                dataGridView1.Font = fontDialog.Font;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                dataGridView1.ForeColor = colorDialog.Color;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            chart1.Series["Series1"].Points.Clear();
            double xn = Convert.ToDouble(textBoxXn.Text);
            double xk = Convert.ToDouble(textBoxXk.Text);
            double xh = Convert.ToDouble(textBoxXh.Text);
            double y;

            double max = 0, min = 0;
            for (double x = xn; x <= xk; x += xh)
            {
                if (x <= 0)
                    y = Math.Pow(x, 2) + Math.Sin(7 * x) - 1;
                else if (x > 5)
                    y = Math.Pow((2 * Math.Pow(x, 4) + x * x + 1), 1 / 7);
                else
                    y = Math.Abs(Math.Pow(x, 3) + Math.Pow(10, x));
                chart1.Series["Series1"].Points.AddXY(x, y);
                dataGridView1.Rows.Add(x, y);
                if (y < min)
                    min = y;
                if (y > max)
                    max = y;
            }
            textBox4.Text = max.ToString();
            textBox5.Text = min.ToString();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.ShowDialog();
            StreamWriter sw = new StreamWriter($"{saveFile.FileName}.txt");
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    sw.WriteLine($"{dataGridView1.Rows[i].Cells[0].Value}\t| {dataGridView1.Rows[i].Cells[1].Value:F3}");
            sw.Close();
            index++;
        }
    }
}