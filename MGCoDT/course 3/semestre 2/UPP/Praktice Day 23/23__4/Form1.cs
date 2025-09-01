using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _23__4
{
    public partial class Form1 : Form
    {
        public enum Tools { PEN = 1, TEXT, LINE, ELLIPSE, NULL = 0 }
        Tools curentTool;
        Point lastpoint;
        Pen pen;
        int si = 0;
        int angle = 0;
        int linearMode = 0;
        float textureScale;
        Color color1 = Color.Blue;
        Color color2 = Color.Green;
        Graphics graphics;
        bool firstSave = true;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
            for (float i = 1.0f; i < 5; i += 0.5f)
                toolStripComboBox1.Items.Add(Math.Round(i, 1));
            for (int i = 0; i <= 365; i++)
                toolStripComboBox2.Items.Add(i);
            for (float i = 0.1f; i <= 5; i += 0.1f)
                toolStripComboBox3.Items.Add(Math.Round(i, 1));
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();

            if (e.Button == MouseButtons.Left)
            {
                switch (curentTool)
                {
                    case (Tools)1:
                        graphics.DrawRectangle(pen, e.X, e.Y, 1, 1);
                        break;
                    case (Tools)2:
                        // Артем памаги
                        break;
                    case (Tools)5:
                        break;
                    case 0: break;
                }
            }
            toolStripStatusLabel1.Text = "Курсор(X; Y): " + e.X + "; " + e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            graphics = panel1.CreateGraphics();
            LinearGradientBrush gradBrush;
            try
            {
                gradBrush = new LinearGradientBrush(new Rectangle(lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y), color1, color2, (LinearGradientMode)linearMode);
            }
            catch (Exception) { goto down; }
            switch (curentTool)
            {
                case (Tools)3:
                    if (!checkBox1.Checked)
                        graphics.DrawRectangle(pen, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y);
                    else
                    {
                        switch (si)
                        {
                            case 1:
                                graphics.FillRectangle(new SolidBrush(pen.Color), lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y);
                                break;
                            case 2:
                                graphics.FillRectangle(gradBrush, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y);
                                break;
                            case 3:
                                OpenFileDialog fileDialog = new OpenFileDialog();
                                if (fileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    TextureBrush textureBrush = new TextureBrush(Image.FromFile(fileDialog.FileName));
                                    textureBrush.ScaleTransform(textureScale, textureScale);
                                    textureBrush.RotateTransform(angle);
                                    graphics.FillRectangle(textureBrush, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y);
                                }
                                break;
                        }
                    }
                    break;
                case (Tools)4:
                    if (!checkBox1.Checked)
                        graphics.DrawEllipse(pen, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y);
                    else
                    {
                        switch (si)
                        {
                            case 1:
                                graphics.FillEllipse(new SolidBrush(pen.Color), lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y);
                                break;
                            case 2:
                                graphics.FillEllipse(gradBrush, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y);
                                break;
                            case 3:
                                OpenFileDialog fileDialog = new OpenFileDialog();
                                if (fileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    TextureBrush textureBrush = new TextureBrush(Image.FromFile(fileDialog.FileName));
                                    textureBrush.ScaleTransform(textureScale, textureScale);
                                    textureBrush.RotateTransform(angle);
                                    graphics.FillEllipse(textureBrush, lastpoint.X, lastpoint.Y, e.X - lastpoint.X, e.Y - lastpoint.Y);
                                }
                                break;
                        }
                    }
                    break;
                case 0: break;
            }
        down:;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton1":
                    curentTool = Tools.PEN;
                    statusStrip1.Items[1].Text = "Выбрано: Карандаш"; break;
                case "toolStripButton2":
                    curentTool = Tools.TEXT;
                    statusStrip1.Items[1].Text = "Выбрано: Надпись"; break;
                case "toolStripButton3":
                    curentTool = Tools.LINE;
                    statusStrip1.Items[1].Text = "Выбрано: Прямоугольник"; break;
                case "toolStripButton4":
                    curentTool = Tools.ELLIPSE;
                    statusStrip1.Items[1].Text = "Выбрано: Эллипс"; break;
            }
            SetToolStripButtonsPushedState(e.ClickedItem);
        }

        private void SetToolStripButtonsPushedState(ToolStripItem button)
        {
            foreach (ToolStripButton btnItem in toolStrip1.Items)
            {
                if (btnItem == button)
                    btnItem.Checked = true;
                else
                    btnItem.Checked = false;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                pen.Color = colorDialog.Color;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox toolStrip = (ToolStripComboBox)sender;
            pen.Width = (float)Convert.ToDouble(toolStrip.Text);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            si = Convert.ToInt32(item.Name[item.Name.Length - 1].ToString());
            switch (si)
            {
                case 1:
                    toolStripMenuItem1.Checked = true;
                    toolStripMenuItem2.Checked = false;
                    toolStripMenuItem3.Checked = false;
                    break;
                case 2:
                    toolStripMenuItem1.Checked = false;
                    toolStripMenuItem2.Checked = true;
                    toolStripMenuItem3.Checked = false;
                    break;
                case 3:
                    toolStripMenuItem1.Checked = false;
                    toolStripMenuItem2.Checked = false;
                    toolStripMenuItem3.Checked = true;
                    break;
            }
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox toolStrip = (ToolStripComboBox)sender;
            angle = Convert.ToInt32(toolStrip.Text);
        }

        private void toolStripComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox toolStrip = (ToolStripComboBox)sender;
            textureScale = (float)Convert.ToDouble(toolStrip.Text);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                color1 = colorDialog.Color;
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                color2 = colorDialog.Color;
        }

        private void toolStripComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox toolStrip = (ToolStripComboBox)sender;
            switch (toolStrip.SelectedIndex)
            {
                case 0:
                    linearMode = 0;
                    break;
                case 1:
                    linearMode = 1;
                    break;
                case 2:
                    linearMode = 2;
                    break;
                case 3:
                    linearMode = 3;
                    break;
            }
        }

        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Если в задании на 8 баллов не хватило функционала,\n" +
                            "то здесь этот функционал присутствует.\n\n" +
                            "Вроде все некорректные сценарии я предусмотрел,\n" +
                            "так что если фигура, которая ожидалась не нарисовалась,\n" +
                            "значит не все настройки были заданы или\n" +
                            "немного не так мышь была двинута.\n\n" +
                            "Выглядит всё на первый взгляд простовато,\n" +
                            "но в настройках есть очень много пунктов для покраски.\n" +
                            "Этим не очень удобно пользоваться, возможно, но зато приложение " +
                            "выглядит нормально как в полноэкранном, так и в оконном режиме.\n\n" +
                            "Ну и вообще это Pre-Alpha, какие могут быть претензии?","Справочка (не медицинская)");
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) => lastpoint = new Point(e.X, e.Y);

        private void toolStripButton5_Click(object sender, EventArgs e) => checkBox1.Checked = checkBox1.Checked ? false : true;

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e) => panel1.CreateGraphics().Clear(SystemColors.Control);

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (firstSave)
            {
                MessageBox.Show("Сохранение производится 2 секунды." +
                                "Перед сохранением уберите с панели рисования лишние элементы." +
                                "Они могут повредить изображение", "Важная информация");
                firstSave = false;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "* .jpg | .jpg | * .png | .png | * .bmp | * .bmp | * .tiff | * .tiff";
            if (save.ShowDialog() == DialogResult.OK)
            {
                Thread.Sleep(2000);
                Size BorderSize = new Size(5 + this.Width - this.panel1.Width,  5 + this.Height - this.panel1.Height - 22);
                Bitmap screenshot = new Bitmap(this.panel1.Width, this.panel1.Height);
                Graphics gr = Graphics.FromImage(screenshot);
                gr.CopyFromScreen(this.Location.X + (BorderSize.Width / 2), this.Location.Y + (BorderSize.Height) - 8, 0, 0, new Size(this.Width - BorderSize.Width, this.Height - BorderSize.Height));
                screenshot.Save(save.FileName);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string empUpLoadPictureRealPos = open.FileName;
                        String[] empImageData = empUpLoadPictureRealPos.Split('.');
                        graphics = panel1.CreateGraphics();
                        graphics.DrawImage(Image.FromFile(empUpLoadPictureRealPos), 0, 0);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно прочитать выбранную картинку или неверный тип файла!", "Сообщение об ошибке");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке фотографии: " + ex.Message);
            }
        }
    }
}