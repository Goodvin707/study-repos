using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency_DB_GUI.DAL_Utils
{
    internal static class Exporter
    {
        public static void toPDF(DataGridView dataGridView)
        {
            if (dataGridView == null) return;
            if (dataGridView.DataSource == null) return;

            var printDialog = new PrintDialog();
            var printDoc = new PrintDocument();

            printDoc.PrintPage += (senderPrint, args) =>
            {
                //float angle = 90;

                //PointF rotationPoint = new PointF(args.MarginBounds.Right, args.MarginBounds.Top);
                //args.Graphics.TranslateTransform(rotationPoint.X, rotationPoint.Y);
                //args.Graphics.RotateTransform(angle);
                //args.Graphics.TranslateTransform(-rotationPoint.X, -rotationPoint.Y);

                var font = new System.Drawing.Font("Arial", 8);
                var y = 30;
                var x = 30;

                // Заголовок
                args.Graphics.DrawString($"Отчет_{dataGridView.Name}_{DateTime.Now:dd.MM.yyyy}",
                new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                System.Drawing.Brushes.Black, x, y);
                y += 30;

                // Заголовки столбцов
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    var colWidth = args.Graphics.MeasureString(dataGridView.Columns[i].HeaderText, font).Width + 10;
                    args.Graphics.DrawString(dataGridView.Columns[i].HeaderText, font, System.Drawing.Brushes.Teal, x + i * 100, y);
                }
                y += 25;

                // Данные
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        var value = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? "";
                        args.Graphics.DrawString(value, font, System.Drawing.Brushes.Black, x + j * 100, y);
                    }
                    y += 20;
                }

                args.HasMorePages = false;
            };

            printDialog.Document = printDoc;

            if (printDialog.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }
        public static void toWord(DataGridView dataGridView)
        {
            if (dataGridView == null) return;
            if (dataGridView.DataSource == null) return;

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Документ Word (*.docx)|*.docx",
                FileName = $"Отчет_{dataGridView.Name}_{DateTime.Now:yyyyMMdd}.docx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var package = WordprocessingDocument.Create(saveFileDialog.FileName, WordprocessingDocumentType.Document))
                {
                    var mainPart = package.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    var body = mainPart.Document.AppendChild(new Body());

                    // Заголовок — жирный текст
                    var titleRun = new Run(
                        new Bold(),
                        new Text($"Отчет — {DateTime.Now:dd.MM.yyyy}")
                    );
                    var title = new Paragraph(titleRun);
                    body.AppendChild(title);

                    // Таблица
                    var table = new Table();
                    var tableProperties = new TableProperties(
                        new TableWidth { Width = "5000", Type = new EnumValue<TableWidthUnitValues>(TableWidthUnitValues.Dxa) },
                        new TableLook { Val = "04A0" }
                    );
                    table.AppendChild(tableProperties);

                    // Заголовки таблицы
                    var headerRow = new TableRow();
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        var cell = new TableCell(
                        new Paragraph(
                        new Run(
                        new Bold(), // ← Жирный текст в заголовке
                        new Text(dataGridView.Columns[i].HeaderText)
                        )
                        )
                        );
                        headerRow.AppendChild(cell);
                    }
                    table.AppendChild(headerRow);

                    // Данные
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        var row = new TableRow();
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            var cellValue = dataGridView.Rows[i].Cells[j].Value?.ToString() ?? "";
                            var cell = new TableCell(
                            new Paragraph(
                            new Run(new Text(cellValue))
                            )
                            );
                            row.AppendChild(cell);
                        }
                        table.AppendChild(row);
                    }

                    body.AppendChild(table);

                    mainPart.Document.Save();
                }

                MessageBox.Show("Отчет успешно экспортирован в Word!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void toExcel(DataGridView dataGridView)
        {
            if (dataGridView == null) return;
            if (dataGridView.DataSource == null) return;

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel файлы (*.xlsx)|*.xlsx",
                FileName = $"Отчет_{DateTime.Now:yyyyMMdd}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Отчет");

                    // Заголовки
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                    }

                    // Данные
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            var cellValue = dataGridView.Rows[i].Cells[j].Value;
                            worksheet.Cell(i + 2, j + 1).Value = cellValue?.ToString() ?? "";
                        }
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Отчет успешно экспортирован в Excel!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
