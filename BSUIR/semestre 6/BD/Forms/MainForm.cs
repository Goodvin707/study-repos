using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using TravelAgency_DB_GUI.DAL_Utils;
using TravelAgency_DB_GUI.Utils;

namespace TravelAgency_DB_GUI.Forms
{
    public partial class MainForm : Form
    {
        string mysqlPath = @"C:\ospanel\modules\database\MySQL-8.0-Win10\bin\";
        public MainForm()
        {
            InitializeComponent();
            SearchController.Fields = searchStripComboBox;
            SearchController.Query = searchStripTextBox;
            Logger.loggerTextBox = loggerTextBox;
            treeView1.ExpandAll();

            if (CurrentUser.Login != "root")
            {
                adminToolStripMenuItem.Visible = false;
                mySQLUtilsToolStripMenuItem.Visible = false;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!tabControl1.TabPages.ContainsKey(e.Node.Name))
                tabControl1.TabPages.Add(e.Node.Name, e.Node.Text);

            tabControl1.SelectTab(e.Node.Name);
        }

        private void tabControl1_ControlAdded(object sender, ControlEventArgs e) => TabController.InitNewTab(tabControl1, e);

        private void newSQLQueryToolStripMenuItem_Click(object sender, EventArgs e) => new QuerySender().Show();

        private void addToolStripMenuItem_Click(object sender, EventArgs e) => DatabaseController.BuildInsertQuery(tabControl1);

        private void editToolStripMenuItem_Click(object sender, EventArgs e) => DatabaseController.BuildUpdateQuery(tabControl1);

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = tabControl1.SelectedTab.Controls[0] as DataGridView;

            if (MessageBox.Show(
            $"Точно хотите удалить запись с id {dataGridView.SelectedRows[0].Cells[0].Value}?",
            "Предупреждение",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
            {
                DatabaseController.BuildDeleteQuery(tabControl1);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) => TabController.LoadTable(tabControl1.SelectedTab);

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);

        private async void mysqlToolStripMenuItem_Click(object sender, EventArgs e) => MySQL_UtilityContoller.Exec_mysql(mysqlPath, mysqlToolStripMenuItem);

        private async void mysqlbinlogToolStripMenuItem_Click(object sender, EventArgs e) => MySQL_UtilityContoller.Exec_mysqlbinlog(mysqlPath, mysqlbinlogToolStripMenuItem);

        private async void mysqldumpToolStripMenuItem_Click(object sender, EventArgs e) => MySQL_UtilityContoller.Exec_mysqldump(mysqlPath, mysqldumpToolStripMenuItem);

        private async void mysqlpumpStripMenuItem_Click(object sender, EventArgs e) => MySQL_UtilityContoller.Exec_mysqlpump(mysqlPath, mysqlpumpToolStripMenuItem);

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string logFilePath = @"C:\OSPanel\userdata\logs\MySQL-8.0-Win10_queries.log";
            Process.Start("notepad.exe", logFilePath);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e) => new UsersForm(loggerTextBox).Show();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void clearHistoryWindowToolStripMenuItem_Click(object sender, EventArgs e) => loggerTextBox.Text = "";

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = tabControl1.SelectedTab?.Controls[0] as DataGridView;
            Exporter.toWord(dataGridView);
        }

        private void excelStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = tabControl1.SelectedTab?.Controls[0] as DataGridView;
            Exporter.toExcel(dataGridView);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = tabControl1.SelectedTab?.Controls[0] as DataGridView;
            Exporter.toPDF(dataGridView);
        }

        private void searchToolStripButton_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = tabControl1.SelectedTab?.Controls[0] as DataGridView;
            
            if (dataGridView != null)
            {
                string query = $"Select * from {tabControl1.SelectedTab.Name}_v where `{SearchController.Fields.SelectedItem.ToString()}` like '%{SearchController.Query.Text}%' order by `{SearchController.Fields.SelectedItem.ToString()}`";
                
                using (MySqlDataReader reader = DatabaseController.ExecuteReader(query))
                {
                    if (reader != null)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dataGridView.DataSource = dt;
                    }
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridView dataGridView = tabControl1.SelectedTab?.Controls[0] as DataGridView;
            TabController.LoadSearch(dataGridView);
        }

        private async void createBackupStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку для резервной копии";
                dialog.ShowNewFolderButton = true;
                dialog.SelectedPath = "C:\\backups";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string logPath = $"{dialog.SelectedPath}\\tour_agency_backup_{DateTime.Now.ToString().Replace(".", "_").Replace(":", "-")}.sql\"";

                    string args = $"-u root tour_agency --result-file={logPath}";

                    var result = await ProcessController.RunAsync(mysqlPath + mysqldumpToolStripMenuItem.Text, $"{args}");

                    if (result.Success) {
                        MessageBox.Show("Резервная копия создана!\nПуть: " + logPath, "Резервная копия создана!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        Console.WriteLine(result.Error);
                        MessageBox.Show($"Ошибка:\n{result.Error}");
                    }
                }
            }
        }

        private async void recoveryStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "SQL файлы|*.sql|Все файлы|*.*";
                openFileDialog.Title = "Выберите файл дампа";
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = openFileDialog.FileName;
                    string query = $"mysql -u {CurrentUser.Login} -p tour_agency < {filename}.sql";

                    Logger.LogQuery(query, new MySqlParameter[0]);

                    var result = await ProcessController.RunAsync(mysqlPath + query, "");

                    if (result.Success) {
                        loggerTextBox.Text += "\r\n" + result.Output;
                        loggerTextBox.Text += "\r\n" + "Резервная копия создана";
                    }
                    else {
                        MessageBox.Show($"Ошибка:\n{result.Error}");
                    }
                }
            }
        }
    }
}
