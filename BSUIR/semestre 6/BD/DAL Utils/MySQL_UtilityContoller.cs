using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_DB_GUI.Forms;
using TravelAgency_DB_GUI.Utils;

namespace TravelAgency_DB_GUI.DAL_Utils
{
    internal static class MySQL_UtilityContoller
    {
        public static async void Exec_mysql(string mysqlPath, ToolStripMenuItem mysqlToolStripMenuItem)
        {
            using (var input = new InputForm("Команда для mysql", "show variables like \'%version%\';"))
            {
                if (input.ShowDialog() == DialogResult.OK)
                {
                    string query = input.InputValue;

                    string args = $"-u root tour_agency -e \"{query}\"";

                    Logger.LogQuery(input.InputValue, new MySqlParameter[0]);

                    var result = await ProcessController.RunAsync(mysqlPath + mysqlToolStripMenuItem.Text, args);

                    if (result.Success)
                    {
                        Logger.loggerTextBox.Text += "\r\n" + result.Output;
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка:\n{result.Error}");
                    }
                }
            }
        }

        public static async void Exec_mysqlbinlog(string mysqlPath, ToolStripMenuItem mysqlbinlogToolStripMenuItem)
        {
            using (var input = new InputForm("Команда для mysqlbinlog", "--verbose --base64-output=DECODE-ROWS C:\\OSPanel\\userdata\\MySQL-8.0-Win10\\mysql-bin.000001"))
            {
                if (input.ShowDialog() == DialogResult.OK)
                {
                    string query = input.InputValue;

                    string args = $" {query}";

                    Logger.LogQuery(input.InputValue, new MySqlParameter[0]);

                    var result = await ProcessController.RunAsync(mysqlPath + mysqlbinlogToolStripMenuItem.Text, args);

                    if (result.Success)
                    {
                        Logger.loggerTextBox.Text += "\r\n" + result.Output;
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка:\n{result.Error}\n\nКоманда: {mysqlPath + mysqlbinlogToolStripMenuItem.Text + args}");
                    }
                }
            }
        }

        public static async void Exec_mysqldump(string mysqlPath, ToolStripMenuItem mysqldumpToolStripMenuItem)
        {
            using (var input = new InputForm("Команда для mysqldump", "-u root --help"))
            {
                if (input.ShowDialog() == DialogResult.OK)
                {
                    string query = input.InputValue;

                    string args = $" {query}";

                    Logger.LogQuery(input.InputValue, new MySqlParameter[0]);

                    var result = await ProcessController.RunAsync(mysqlPath + mysqldumpToolStripMenuItem.Text, args);

                    if (result.Success)
                    {
                        Logger.loggerTextBox.Text += "\r\n" + result.Output;
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка:\n{result.Error}\n\nКоманда: {mysqlPath + mysqldumpToolStripMenuItem.Text + args}");
                    }
                }
            }
        }

        public static async void Exec_mysqlpump(string mysqlPath, ToolStripMenuItem mysqlpumpToolStripMenuItem)
        {
            using (var input = new InputForm("Команда для mysqlpump", "-u root --help"))
            {
                if (input.ShowDialog() == DialogResult.OK)
                {
                    string query = input.InputValue;

                    string args = $" {query}";

                    Logger.LogQuery(input.InputValue, new MySqlParameter[0]);

                    var result = await ProcessController.RunAsync(mysqlPath + mysqlpumpToolStripMenuItem.Text, args);

                    if (result.Success)
                    {
                        Logger.loggerTextBox.Text += "\r\n" + result.Output;
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка:\n{result.Error}\n\nКоманда: {mysqlPath + mysqlpumpToolStripMenuItem.Text + args}");
                    }
                }
            }
        }
    }
}
