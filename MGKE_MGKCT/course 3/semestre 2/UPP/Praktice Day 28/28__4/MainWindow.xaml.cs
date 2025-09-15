using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Brushes = System.Windows.Media.Brushes;
using Point = System.Windows.Point;

namespace _28__4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();
        string menu = "m1";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Line line = new Line();
                switch (menu)
                {
                    case "m1":
                        switch (ColorChange.SelectedIndex)
                        {
                            case 0: line.Stroke = Brushes.Black; break;
                            case 1: line.Stroke = Brushes.Red; break;
                            case 2: line.Stroke = Brushes.Blue; break;
                            default: line.Stroke = Brushes.Black; break;
                        }
                        line.StrokeThickness = tWidth.Value;
                        break;
                    case "m2":
                        line.Stroke = Brushes.White;
                        line.StrokeThickness = tWidth.Value * 2;
                        break;
                }
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;
                paintSurface.Children.Add(line);

                currentPoint = e.GetPosition(this);
            }
        }

        private void m1_Checked(object sender, RoutedEventArgs e) => menu = (sender as RadioButton).Name;

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            currentPoint = e.GetPosition(this);
            qwe.Content = currentPoint.X + " : " + currentPoint.Y;
        }
    }
}