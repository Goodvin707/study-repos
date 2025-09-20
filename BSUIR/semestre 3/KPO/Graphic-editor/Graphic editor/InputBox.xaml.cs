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
    public partial class InputBox : Window
    {
        public string InputValue { get; private set; }
        
        public InputBox(string title, string prompt)
        {
            InitializeComponent();
            Title = title;
            txtPrmt.Text = prompt;
            inputTextBox.Focus();
            inputTextBox.SelectAll();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            inputTextBox.Text = inputTextBox.Text.Replace(".",",");
            try
            {
                int val = (int)(double.Parse(inputTextBox.Text));
                InputValue = val.ToString();
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}