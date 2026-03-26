using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graphic_editor
{
    public partial class ImageProperty : Window
    {
        public ImageProperty(double width,double height)
        {
            InitializeComponent();
            tbWidth.Text = width.ToString();
            tbHeight.Text = height.ToString();
        }

        public double FieldWidth { get; set; }
        public double FieldHeight { get; set; }

        //Метод проверяющий, что в текстовое поле введено число
        private bool CheckSize(string s)
        {    
            for (int i=0;i<s.Length;i++)
            {
                if (s[0]==',' || s.LastIndexOf(',')!=s.IndexOf(',') || (s[i]!=',' && !(s[i] >= '0' && s[i] <= '9')))
                {
                    MessageBox.Show("Enter the correct size!");
                    return false;
                }
            }
            return true;
        }

        //Обработчик события изменения текстового поля для ширины холста
        private void Width_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CheckSize(tbWidth.Text))
            {
                tbWidth.Focus();
                return;
            }
        }

        //Обработчик события изменения текстового поля для высоты холста
        private void Height_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!CheckSize(tbHeight.Text))
            {
                tbHeight.Focus();
                return;
            }
        }

        //Обаботчик события клика на кнопку сохранить изменения
        private void BtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (tbWidth.Text == "" || tbHeight.Text == "")
            {
                MessageBox.Show("Enter a positive number!");
                return;
            }
            FieldWidth = double.Parse(tbWidth.Text);
            FieldHeight = double.Parse(tbHeight.Text);
            MainWindow mainWindow = this.Owner as MainWindow;
            mainWindow.cnvPaint.Width = FieldWidth;
            mainWindow.cnvPaint.Height = FieldHeight;
            Close();
        }
    }
}