using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace WpfApp9.Resourses.MessageWinfow
{
    /// <summary>
    /// Логика взаимодействия для SaveWE.xaml
    /// </summary>
    public partial class SaveWE : Window
    {
        DataGrid SelectedDataGried;

        public SaveWE(ref DataGrid SelectedDataGried)
        {
            InitializeComponent();
            this.SelectedDataGried = SelectedDataGried;

        }
        private void ExportToExcel()
        {
            var save = new System.Windows.Forms.SaveFileDialog();
            save.Filter = "Excel File|*.xlsx";
            save.Title = "Save an Excel File";
            save.ShowDialog();
            var excel = new Microsoft.Office.Interop.Excel.Application();    
            var workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            var sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            for (int j = 0; j < SelectedDataGried.Columns.Count; j++)
            {
                var myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true;
                sheet1.Columns[j + 1].ColumnWidth = 15; 
                myRange.Value2 = SelectedDataGried.Columns[j].Header;
            }
            for (int i = 0; i < SelectedDataGried.Columns.Count; i++)
            { 
                for (int j = 0; j < SelectedDataGried.Items.Count; j++)
                {
                    TextBlock b = SelectedDataGried.Columns[i].GetCellContent(SelectedDataGried.Items[j]) as TextBlock;
                    var myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    try
                    {
                        myRange.Value2 = b.Text;
                    }
                    catch { }
                }
            }
            workbook.SaveAs(save.FileName);
            workbook.Close(0);
            excel.Quit();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel();
            this.Close();
        }
        private void ExportToExcelAndCsv()
        {
            SelectedDataGried.SelectAllCells();
            SelectedDataGried.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, SelectedDataGried);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            SelectedDataGried.UnselectAllCells();
            var filesave = new System.Windows.Forms.SaveFileDialog();
            filesave.Filter = "Word document|*.doc";
            filesave.Title = "Save the Word Document";
            filesave.ShowDialog();
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(filesave.FileName);
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();
        }


        private void printButton_Click(object sender, RoutedEventArgs e)
        {


            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(SelectedDataGried, "My First Print Job");
            }
        }
 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ExportToExcelAndCsv();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
