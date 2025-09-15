using System;
using System.Drawing;
using System.Windows.Forms;

namespace ESUM
{
    public partial class Preload : Form
    {
        int sec = 0;
        public Preload()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromStream(new System.Net.WebClient().OpenRead("https://i.pinimg.com/originals/d9/79/66/d979668d4066d9b4bd07800cca931aeb.gif"));
            ImageAnimator.Animate(pictureBox1.Image, OnFrameChanged);
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
            sec++;
            if (sec == 5)
            {
                ImageAnimator.StopAnimate(pictureBox1.Image, OnFrameChanged);
                timer1.Enabled = false;
                Autorise autorize = new Autorise();
                autorize.Show();
                Hide();
            }
        }
    }
}