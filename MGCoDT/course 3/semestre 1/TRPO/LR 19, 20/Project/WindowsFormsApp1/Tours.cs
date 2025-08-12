using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Tours : Form
    {
        struct Tour
        {
            public string from;
            public string to;
            public string flyFrom;
            public string flyTo;
            public int nights;
            public string hotel;
            public int older;
            public int young;
            public int minCost;
            public int maxCost;
            public Tour(string from, string to, string flyFrom, string flyTo, int nights, string hotel, int older, int young, int minCost, int maxCost)
            {
                this.from = from;
                this.to = to;
                this.flyFrom = flyFrom;
                this.flyTo = flyTo;
                this.nights = nights;
                this.hotel = hotel;
                this.older = older;
                this.young = young;
                this.minCost = minCost;
                this.maxCost = maxCost;
            }
        }
        public Tours()
        {
            InitializeComponent();
            Random r = new Random();
            StreamReader f = new StreamReader("tour.txt");
            string from = f.ReadLine();
            string to = f.ReadLine();
            string flyFrom = f.ReadLine();
            string flyTo = f.ReadLine();
            int nights = Convert.ToInt16(f.ReadLine());
            string hotel = f.ReadLine();
            int older = Convert.ToInt16(f.ReadLine());
            int young = Convert.ToInt16(f.ReadLine());
            int minCost = Convert.ToInt16(f.ReadLine());
            int maxCost = Convert.ToInt16(f.ReadLine());
            f.Close();
            Tour tour = new Tour(from, to, flyFrom, flyTo, nights, hotel, older, young, minCost, maxCost);
            if (minCost >= 1000 && minCost < 3500)
            {
                label2.Visible = true;
                textBox1.Visible = true;
                textBox1.Text = "Ночей: " + tour.nights;
                textBox1.Text += "\r\nОтель: " + tour.hotel;
                textBox1.Text += "\r\nЦена: " + (tour.maxCost - tour.minCost + r.Next(0, 1001));
                pictureBox4.Visible = true;
            }
            if (minCost >= 3500 && minCost < 6000)
            {
                label3.Visible = true;
                textBox2.Visible = true;
                textBox2.Text = "Ночей: " + tour.nights;
                textBox2.Text += "\r\nОтель: " + tour.hotel;
                textBox2.Text += "\r\nЦена: " + (tour.maxCost - tour.minCost + r.Next(1001, 3501));
                pictureBox1.Visible = true;
            }
            if (minCost >= 6000 && minCost < 7500)
            {
                label4.Visible = true;
                textBox3.Visible = true;
                textBox3.Text = "Ночей: " + tour.nights;
                textBox3.Text += "\r\nОтель: " + tour.hotel;
                textBox3.Text += "\r\nЦена: " + (tour.maxCost - tour.minCost + r.Next(3501, 6001));
                pictureBox3.Visible = true;
            }
            if (minCost >= 7500 && minCost < 10000)
            {
                label5.Visible = true;
                textBox4.Visible = true;
                textBox4.Text = "Ночей: " + tour.nights;
                textBox4.Text += "\r\nОтель: " + tour.hotel;
                textBox4.Text += "\r\nЦена: " + (tour.maxCost - tour.minCost + r.Next(6001, 10001));
                pictureBox2.Visible = true;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Thistle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.PaleVioletRed;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Thistle;
        }
    }
}