using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polyclinic
{
    public partial class PreLoad : Form
    {
        public PreLoad()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            try
            {
                pictureBox1.Image = Image.FromStream(new System.Net.WebClient().OpenRead("https://i.gifer.com/F6iC.gif"));
                ImageAnimator.Animate(pictureBox1.Image, OnFrameChanged);
            }
            catch (Exception) {
                ImageAnimator.StopAnimate(pictureBox1.Image, OnFrameChanged);
                timer1.Enabled = false;
                Autorize autorize = new Autorize();
                autorize.Show();
                this.Hide();
                TopMost = false;
                MessageBox.Show("Невозможно загрузить прелоадер. Проверьте подключение к интернету", "Ошибка подключения");
            }
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => OnFrameChanged(sender, e)));
                return;
            }
            ImageAnimator.UpdateFrames();
            Invalidate(false);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1.0)
            {
                ImageAnimator.StopAnimate(pictureBox1.Image, OnFrameChanged);
                timer1.Enabled = false;
                Autorize autorize = new Autorize();
                autorize.Show();
                this.Hide();
                TopMost = false;
            }
            Opacity += 0.01;
        }
    }
}