using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using exportWord = Microsoft.Office.Interop.Word;

namespace ESUM
{
    class Exporter
    {
        static public void ExportToExcel(TabControl tabControl1, DataGridView dataGrid)
        {
            if (tabControl1.SelectedTab != null)
            {
                dataGrid = (tabControl1.SelectedTab.Controls.Find(tabControl1.SelectedTab.Text.Replace(" ", ""), false)[0] as DoubleBufferedDataGridView);

                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Application.Workbooks.Add(Type.Missing);

                ExcelApp.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ExcelApp.Columns.ColumnWidth = 30;

                for (int i = 0; i < dataGrid.ColumnCount; i++)
                    ExcelApp.Cells[1, i + 1] = dataGrid.Columns[i].HeaderText;

                ExcelApp.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                string value;
                for (int i = 0; i < dataGrid.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGrid.RowCount - 1; j++)
                    {
                        value = (dataGrid[i, j].Value).ToString();
                        ExcelApp.Cells[j + 2, i + 1] = value;
                    }
                }
                ExcelApp.Visible = true;
                ExcelApp.Quit();
            }
        }

        static public void ExportToWord(TabControl tabControl1, DataGridView dataGrid)
        {
            if (tabControl1.SelectedTab != null)
            {
                dataGrid = (tabControl1.SelectedTab.Controls.Find(tabControl1.SelectedTab.Text.Replace(" ", ""), false)[0] as DoubleBufferedDataGridView);
                string s = "";
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    for (int j = 0; j < dataGrid.ColumnCount; j++)
                        s += dataGrid.Rows[i].Cells[j].Value + " ";
                    s += "\n";
                }

                exportWord.Application wordapp = new exportWord.Application();
                wordapp.Visible = true;
                exportWord.Document worddoc;
                object wordobj = System.Reflection.Missing.Value;
                worddoc = wordapp.Documents.Add(ref wordobj);
                wordapp.Selection.TypeText(s);
                wordapp = null;
            }
        }

        static public void ExportToTXT(TabControl tabControl1, DataGridView dataGrid)
        {
            if (tabControl1.SelectedTab != null)
            {
                dataGrid = (tabControl1.SelectedTab.Controls.Find(tabControl1.SelectedTab.Text.Replace(" ", ""), false)[0] as DoubleBufferedDataGridView);
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = tabControl1.SelectedTab.Text;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName + ".txt", false, Encoding.GetEncoding("utf-8"));
                    for (int i = 0; i < dataGrid.ColumnCount; i++)
                        sw.Write(dataGrid.Columns[i].HeaderText + " |\t");
                    sw.WriteLine();
                    for (int i = 0; i < dataGrid.RowCount; i++)
                    {
                        for (int j = 0; j < dataGrid.ColumnCount; j++)
                            sw.Write(dataGrid.Rows[i].Cells[j].Value + "\t");
                        sw.WriteLine();
                    }
                    sw.Close();
                    System.Diagnostics.Process.Start(saveFileDialog.FileName + ".txt");
                }
            }
        }

        static public void ExportToXML(SaveFileDialog save, string connectString)
        {
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM Пользователи", connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, $"[Пользователи]");

            List<Users> users = new List<Users>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                users.Add(new Users(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString()));

            XDocument xdoc = new XDocument();
            XElement xElementRoot = new XElement("Users");
            for (int i = 0; i < users.Count; i++)
            {
                XElement xElement = new XElement("user");
                XAttribute xAttributeLogin = new XAttribute("Login", users[i].Login);
                XAttribute xAttributePassword = new XAttribute("Password", users[i].Password);
                XAttribute xAttributeEmail = new XAttribute("Email", users[i].Email);
                xElement.Add(xAttributeLogin);
                xElement.Add(xAttributePassword);
                xElement.Add(xAttributeEmail);
                xElementRoot.Add(xElement);
            }
            xdoc.Add(xElementRoot);

            xdoc.Save(save.FileName + ".xml");
            System.Diagnostics.Process.Start(save.FileName + ".xml");
        }

        static public void SendOnMail(TabControl tabControl1, DataGridView dataGrid)
        {
            if (tabControl1.SelectedTab != null)
            {
                dataGrid = (tabControl1.SelectedTab.Controls.Find(tabControl1.SelectedTab.Text.Replace(" ", ""), false)[0] as DoubleBufferedDataGridView);
                SendOnEmail onEmail = new SendOnEmail();
                if (onEmail.ShowDialog() == DialogResult.OK)
                {
                    string email = onEmail.textBox1.Text;
                    try
                    {
                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(User.Email);
                        mail.To.Add(new MailAddress(email));
                        mail.Subject = $"{tabControl1.SelectedTab.Text}";
                        mail.Body = $"<h2><center><font face=\"Segoe Print\">Данные о {tabControl1.SelectedTab.Text}</center></h2><br>";
                        mail.Body += "<h4><font face=\"Arial\">";
                        for (int i = 0; i < dataGrid.ColumnCount; i++)
                            mail.Body += $"[{dataGrid.Columns[i].HeaderText}]  ";
                        mail.Body += "<br>";
                        for (int i = 0; i < dataGrid.RowCount; i++)
                        {
                            for (int j = 0; j < dataGrid.ColumnCount; j++)
                                mail.Body += dataGrid.Rows[i].Cells[j].Value + " ";
                            mail.Body += "<br>";
                        }
                        mail.Body += "</h4>";
                        mail.IsBodyHtml = true;

                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.mail.ru";
                        client.Port = 587;
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential("a_susamogushko@mail.ru", "qHqdWtxPtCkD6TSVGbRu");
                        client.Send(mail);

                        MessageBox.Show("Письмо отправлено на " + email, "Отправка данных на электронный ящик");
                    }
                    catch (Exception) { MessageBox.Show("Проверьте введенный адрес и подключение к интернету", "Ошибка отправки"); }
                }
            }
        }

        static public void clearEXTask()
        {
            foreach (Process proc in Process.GetProcessesByName("EXCEL"))
                proc.Kill();
        }
    }
}