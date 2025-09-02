using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ESUM
{
    public partial class MainWindow : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=University.accdb;";
        OleDbConnection myConnection;

        int fieldIndex;
        DoubleBufferedDataGridView dataGrid;
        string resultForPrint = "";
        List<string> tabNames = new List<string>();
        List<TreeNode> nodes = new List<TreeNode>();
        bool nodesExpanded = false;
        ColorPackage colorPackage;
        public MainWindow()
        {
            InitializeComponent();
            if (User.Login != "admin")
            {
                addMenu.Visible = false;
                editMenu.Visible = false;
                deleteMenu.Visible = false;
                usersMenu.Visible = false;
                AddToolStripBtn.Visible = false;
                EditToolStripBtn.Visible = false;
                DeleteToolStripBtn.Visible = false;
                toolStripSeparator6.Visible = false;
                contextMenuStrip1.Items.RemoveAt(contextMenuStrip1.Items.Count - 1);
                contextMenuStrip1.Items.RemoveAt(contextMenuStrip1.Items.Count - 1);
                contextMenuStrip1.Items.RemoveAt(contextMenuStrip1.Items.Count - 1);
            }

            nodes.Add(treeView1.Nodes[0]);
            nodes.Add(treeView1.Nodes[1]);

            nodes.Add(treeView1.Nodes[0].Nodes[0]);
            nodes.Add(treeView1.Nodes[0].Nodes[1]);

            nodes.Add(treeView1.Nodes[0].Nodes[0].Nodes[0]);
            nodes.Add(treeView1.Nodes[0].Nodes[0].Nodes[1]);

            nodes.Add(treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[0]);
            nodes.Add(treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[1]);
            nodes.Add(treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[2]);
            nodes.Add(treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[3]);
            nodes.Add(treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[4]);
            nodes.Add(treeView1.Nodes[0].Nodes[0].Nodes[0].Nodes[5]);

            nodes.Add(treeView1.Nodes[0].Nodes[1].Nodes[0]);

            nodes.Add(treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes[0]);
            nodes.Add(treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes[1]);

            nodes.Add(treeView1.Nodes[1].Nodes[0]);

            if (File.Exists("appstyle.txt"))
            {
                StreamReader sr = new StreamReader("appstyle.txt");
                ColorPackage.currentAppStyle = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
            InintializeAppStyle();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void openNewTab(object sender, TreeNodeMouseClickEventArgs e)
        {
            tabNames.Clear();
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
                tabNames.Add(tabControl1.TabPages[i].Name);

            if (!tabNames.Contains(treeView1.SelectedNode.Name))
            {
                string query = $"SELECT * FROM {treeView1.SelectedNode.Name}";

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
                DataSet ds = new DataSet();

                dataAdapter.Fill(ds, $"[{treeView1.SelectedNode.Name}]");

                dataGrid = new DoubleBufferedDataGridView();
                dataGrid.AllowUserToOrderColumns = false;
                dataGrid.AllowUserToAddRows = false;
                dataGrid.AllowUserToDeleteRows = false;
                dataGrid.ReadOnly = true;
                dataGrid.BackgroundColor = colorPackage.dg;
                dataGrid.BorderStyle = BorderStyle.Fixed3D;
                dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGrid.SelectionChanged += dataGridView1_SelectionChanged;
                dataGrid.Sorted += DataSorted;
                dataGrid.DataSource = ds.Tables[$"[{treeView1.SelectedNode.Name}]"].DefaultView;

                TabPage tabPage = new TabPage();
                tabPage.Text = treeView1.SelectedNode.Text;
                tabPage.Name = treeView1.SelectedNode.Name;
                tabPage.ContextMenuStrip = contextMenuStrip1;
                tabPage.BackColor = colorPackage.tp;
                tabPage.Controls.Add(dataGrid);

                tabControl1.TabPages.Add(tabPage);

                dataGrid.AutoResizeColumns();
                dataGrid.Name = treeView1.SelectedNode.Name;
                dataGrid.Dock = DockStyle.Fill;
                if (dataGrid.RowCount > 0)
                {
                    dataGrid.Rows[0].Selected = false;
                    dataGrid.Rows[0].Selected = true;
                }
                else
                    statSelected.Text = "";

                ColorizingRows();

                tabControl1.SelectedTab = tabPage;

                InitializeSearch();
                InitializeStatus();
            }
            else
            {
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    if (tabControl1.TabPages[i].Name == treeView1.SelectedNode.Name)
                        tabControl1.SelectedTab = tabControl1.TabPages[i];
                }
            }
        }

        public void ADD()
        {
            if (tabControl1.SelectedTab != null)
            {
                string CommandText;
                switch (tabControl1.SelectedTab.Text)
                {
                    case "Факультеты":
                        {
                            AddFacult f = new AddFacult();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                CommandText = $"INSERT INTO [Факультеты] (Название) VALUES ('{f.textBox1.Text}')";
                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Кафедры":
                        {
                            AddKafedra f = new AddKafedra();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Факультеты WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO [Кафедры] ([Код факультета], Название) VALUES ({reader.GetValue(0)}, '{f.textBox1.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Дисциплины":
                        {
                            AddDiscipline f = new AddDiscipline();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                CommandText = $"INSERT INTO [Дисциплины] (Название) VALUES ('{f.textBox1.Text}')";
                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Докторские":
                        {
                            AddDocskayaOrKandskaya f = new AddDocskayaOrKandskaya("Докторская");
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO [Докторские] (Преподаватель, Название, Дата) VALUES ('{reader.GetValue(0)}', '{f.textBox1.Text}', '{f.dateTimePicker1.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Кандидатские":
                        {
                            AddDocskayaOrKandskaya f = new AddDocskayaOrKandskaya("Кандидатская");
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO [Кандидатские] (Преподаватель, Название, Дата) VALUES ('{reader.GetValue(0)}', '{f.textBox1.Text}', '{f.dateTimePicker1.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Аспирантура":
                        {
                            AddAspra f = new AddAspra();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO [Аспирантура] (Преподаватель, Дата) VALUES ('{reader.GetValue(0)}', '{f.dateTimePicker1.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Научные темы":
                        {
                            AddScienceTema f = new AddScienceTema();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO НаучныеТемы (Преподаватель, Тема) VALUES ('{reader.GetValue(0)}', '{f.textBox1.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Научные направления":
                        {
                            AddSciDirection f = new AddSciDirection();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO НаучныеНаправления (Преподаватель) VALUES ('{reader.GetValue(0)}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Группы":
                        {
                            AddGroup f = new AddGroup();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Факультеты WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO [Группы] ([Код факультета], Название, Курс) VALUES ({reader.GetValue(0)}, '{f.textBox1.Text}', '{f.numericUpDown1.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Преподаватели":
                        {
                            AddPrepod f = new AddPrepod();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                string sex = "";
                                if (f.radioButton1.Checked)
                                    sex = "м";
                                if (f.radioButton2.Checked)
                                    sex = "ж";
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Кафедры WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = "INSERT INTO [Преподаватели] ([Код кафедры], Фамилия, Имя, Отчество, Категория, [Дата рождения], Дети, ЗП, Пол) VALUES " +
                                    $"({reader.GetValue(0)}, '{f.textBox1.Text}', '{f.textBox2.Text}', '{f.textBox3.Text}', '{f.comboBox2.SelectedItem}', '{f.dateTimePicker1.Text}', '{f.numericUpDown1.Text}', '{f.numericUpDown2.Text}', '{sex}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Нагрузки":
                        {
                            AddLoad f = new AddLoad();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                string prepKey = reader.GetValue(0).ToString();

                                myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Дисциплины WHERE Название Like '{f.comboBox2.SelectedItem}'";
                                reader = myCommand.ExecuteReader();
                                reader.Read();
                                string dispKey = reader.GetValue(0).ToString();

                                CommandText = "INSERT INTO Нагрузки ([Код преподавателя], [Код дисциплины], [Вид занятия], [Количество часов], [Семестр]) VALUES " +
                                    $"('{prepKey}', '{dispKey}', '{f.comboBox3.SelectedItem}', '{f.numericUpDown1.Text}', '{f.numericUpDown2.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Дипломные работы":
                        {
                            AddDipl f = new AddDipl();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                    $"Фамилия Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND Категория Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[3]}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                string prepKey = reader.GetValue(0).ToString();

                                myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Студенты WHERE " +
                                    $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND [Код группы] Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}' ";
                                reader = myCommand.ExecuteReader();
                                reader.Read();
                                string studKey = reader.GetValue(0).ToString();

                                CommandText = "INSERT INTO ДипломныеРаботы ([Код студента], [Код преподавателя], Тема) VALUES " +
                                    $"('{studKey}', '{prepKey}', '{f.textBox1.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Студенты":
                        {
                            AddStud f = new AddStud();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                string sex = "";
                                if (f.radioButton1.Checked)
                                    sex = "м";
                                if (f.radioButton2.Checked)
                                    sex = "ж";
                                byte child = 0;
                                if (f.checkBox1.Checked)
                                    child = 1;
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Группы WHERE " +
                                    $"Название Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}'" +
                                    $"AND Курс Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO Студенты ([Код группы], Фамилия, Имя, Отчество, Пол, [Дата рождения], [Год поступления], Дети, Стипендия) VALUES " +
                                    $"({reader.GetValue(0)}, '{f.textBox1.Text}', '{f.textBox2.Text}', '{f.textBox3.Text}', '{sex}', '{f.dateTimePicker1.Text}', '{f.numericUpDown1.Value}', {child}, '{f.numericUpDown2.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Контроль":
                        {
                            AddMonitoring f = new AddMonitoring();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Дисциплины WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                string dispKey = reader.GetValue(0).ToString();

                                myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                    $"Фамилия Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND Категория Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[3]}'";
                                reader = myCommand.ExecuteReader();
                                reader.Read();
                                string prepKey = reader.GetValue(0).ToString();

                                myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Студенты WHERE " +
                                    $"Фамилия Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[0]}' " +
                                    $"AND Имя Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[1]}' " +
                                    $"AND Отчество Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[2]}' " +
                                    $"AND [Код группы] Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[3]}' ";
                                reader = myCommand.ExecuteReader();
                                reader.Read();
                                string studKey = reader.GetValue(0).ToString();

                                CommandText = $"INSERT INTO Контроль ([Код дисциплины], [Код преподавателя], [Код студента], Оценка, Дата, [Форма контроля]) VALUES " +
                                    $"({dispKey}, {prepKey}, {studKey}, '{f.numericUpDown1.Value}', '{f.dateTimePicker1.Text}', '{f.comboBox4.SelectedItem}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Учебные планы":
                        {
                            AddPlan f = new AddPlan();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Дисциплины WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                CommandText = $"INSERT INTO УчебныеПланы ([Код дисциплины], Курс, Семестр, [Вид занятия], [Форма контроля], [Количество часов]) VALUES " +
                                    $"({reader.GetValue(0)}, '{f.comboBox2.SelectedItem}', '{f.comboBox3.SelectedItem}', '{f.comboBox4.SelectedItem}', '{f.comboBox5.SelectedItem}', '{f.numericUpDown1.Text}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                    case "Учебные поручения":
                        {
                            AddPoruch f = new AddPoruch();
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                OleDbConnection conn = new OleDbConnection(connectString);
                                conn.Open();
                                OleDbCommand myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Кафедры WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                OleDbDataReader reader = myCommand.ExecuteReader();
                                reader.Read();
                                string kafKey = reader.GetValue(0).ToString();

                                myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Дисциплины WHERE Название Like '{f.comboBox2.SelectedItem}'";
                                reader = myCommand.ExecuteReader();
                                reader.Read();
                                string dispKey = reader.GetValue(0).ToString();

                                myCommand = conn.CreateCommand();
                                myCommand.CommandText = $"SELECT Код FROM Группы WHERE " +
                                    $"Название Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[1]}'" +
                                    $"AND Курс Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[3]}'";
                                reader = myCommand.ExecuteReader();
                                reader.Read();
                                string groupKey = reader.GetValue(0).ToString();

                                CommandText = $"INSERT INTO УчебныеПоручения ([Код кафедры], [Код дисциплины], [Код группы], Семестр) VALUES " +
                                    $"({kafKey}, {dispKey}, {groupKey}, '{f.numericUpDown1.Value}')";
                                conn.Close();

                                My_Execute_Non_Query(CommandText);
                                UpdateTable();
                            }
                            break;
                        }
                }
            }
        }

        public void EDIT()
        {
            if (tabControl1.SelectedTab != null)
            {
                dataGrid = (tabControl1.SelectedTab.Controls.Find(tabControl1.SelectedTab.Text.Replace(" ", ""), false)[0] as DoubleBufferedDataGridView);
                if (dataGrid.CurrentRow != null)
                {
                    string ID = dataGrid[0, dataGrid.CurrentRow.Index].Value.ToString();
                    string CommandText;
                    switch (tabControl1.SelectedTab.Text)
                    {
                        case "Факультеты":
                            {
                                AddFacult f = new AddFacult(dataGrid[1, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    CommandText = $"UPDATE [Факультеты] SET Название='{f.textBox1.Text}' WHERE Код = {ID}";
                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Кафедры":
                            {
                                AddKafedra f = new AddKafedra(dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Факультеты WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE [Кафедры] SET [Код факультета]={reader.GetValue(0)}, Название='{f.textBox1.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Дисциплины":
                            {
                                AddDiscipline f = new AddDiscipline(dataGrid[1, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    CommandText = $"UPDATE [Дисциплины] SET Название='{f.textBox1.Text}' WHERE Код = {ID}";
                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Докторские":
                            {
                                AddDocskayaOrKandskaya f = new AddDocskayaOrKandskaya("Докторская", dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString(), dataGrid[3, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                        $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE [Докторские] SET Преподаватель='{reader.GetValue(0)}', Название='{f.textBox1.Text}', Дата='{f.dateTimePicker1.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Кандидатские":
                            {
                                AddDocskayaOrKandskaya f = new AddDocskayaOrKandskaya("Кандидатская", dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString(), dataGrid[3, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                        $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE [Кандидатские] SET Преподаватель='{reader.GetValue(0)}', Название='{f.textBox1.Text}', Дата='{f.dateTimePicker1.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Аспирантура":
                            {
                                AddAspra f = new AddAspra(dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                        $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE [Аспирантура] SET Преподаватель='{reader.GetValue(0)}', Дата='{f.dateTimePicker1.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Научные темы":
                            {
                                AddScienceTema f = new AddScienceTema(dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                        $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE НаучныеТемы SET Преподаватель='{reader.GetValue(0)}', Тема='{f.textBox1.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Научные направления":
                            {
                                AddSciDirection f = new AddSciDirection();
                                f.Text = "Изменить научную тему";
                                f.button1.Text = "Изменить";
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                        $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE НаучныеНаправления SET Преподаватель='{reader.GetValue(0)}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Группы":
                            {
                                AddGroup f = new AddGroup(dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString(), Convert.ToInt32(dataGrid[3, dataGrid.CurrentRow.Index].Value));
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Факультеты WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE [Группы] SET [Код факультета]={reader.GetValue(0)}, Название='{f.textBox1.Text}', Курс='{f.numericUpDown1.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Преподаватели":
                            {
                                AddPrepod f = new AddPrepod(dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[3, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[4, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[5, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[6, dataGrid.CurrentRow.Index].Value.ToString(),
                                    Convert.ToInt32(dataGrid[7, dataGrid.CurrentRow.Index].Value.ToString()),
                                    Convert.ToInt32(dataGrid[8, dataGrid.CurrentRow.Index].Value.ToString()),
                                    dataGrid[9, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    string sex = "";
                                    if (f.radioButton1.Checked)
                                        sex = "м";
                                    if (f.radioButton2.Checked)
                                        sex = "ж";
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Кафедры WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE [Преподаватели] SET [Код кафедры]={reader.GetValue(0)}, Фамилия='{f.textBox1.Text}', Имя='{f.textBox2.Text}', Отчество='{f.textBox3.Text}', " +
                                        $"Категория='{f.comboBox2.SelectedItem}', [Дата рождения]='{f.dateTimePicker1.Text}', Дети='{f.numericUpDown1.Text}', ЗП='{f.numericUpDown2.Text}', Пол='{sex}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Нагрузки":
                            {
                                AddLoad f = new AddLoad(Convert.ToInt32(dataGrid[4, dataGrid.CurrentRow.Index].Value.ToString()), Convert.ToInt32(dataGrid[5, dataGrid.CurrentRow.Index].Value.ToString()));
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                        $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string prepKey = reader.GetValue(0).ToString();

                                    myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Дисциплины WHERE Название Like '{f.comboBox2.SelectedItem}'";
                                    reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string dispKey = reader.GetValue(0).ToString();

                                    CommandText = $"UPDATE Нагрузки SET [Код преподавателя]='{prepKey}', [Код дисциплины]='{dispKey}', [Вид занятия]='{f.comboBox3.SelectedItem}', [Количество часов]='{f.numericUpDown1.Text}', [Семестр]='{f.numericUpDown2.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Дипломные работы":
                            {
                                AddDipl f = new AddDipl(dataGrid[3, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                        $"Фамилия Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND Категория Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string prepKey = reader.GetValue(0).ToString();

                                    myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Студенты WHERE" +
                                        $"Фамилия Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND [Код группы] Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[3]}' ";
                                    reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string studKey = reader.GetValue(0).ToString();

                                    CommandText = $"UPDATE ДипломныеРаботы SET [Код студента]='{studKey}', [Код преподавателя]='{prepKey}', Тема='{f.textBox1.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Студенты":
                            {
                                AddStud f = new AddStud(dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[3, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[4, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[5, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[6, dataGrid.CurrentRow.Index].Value.ToString(),
                                    Convert.ToInt32(dataGrid[7, dataGrid.CurrentRow.Index].Value.ToString()),
                                    dataGrid[8, dataGrid.CurrentRow.Index].Value.ToString(),
                                    Convert.ToInt32(dataGrid[9, dataGrid.CurrentRow.Index].Value.ToString()));
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    string sex = "";
                                    if (f.radioButton1.Checked)
                                        sex = "м";
                                    if (f.radioButton2.Checked)
                                        sex = "ж";
                                    byte child = 0;
                                    if (f.checkBox1.Checked)
                                        child = 1;
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Группы WHERE " +
                                        $"Название Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[1]}'" +
                                        $"AND Курс Like '{f.comboBox1.SelectedItem.ToString().Split(' ')[3]}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE Студенты SET [Код группы]={reader.GetValue(0)}, Фамилия='{f.textBox1.Text}', Имя='{f.textBox2.Text}', Отчество='{f.textBox3.Text}', Пол='{sex}', " +
                                        $"[Дата рождения]='{f.dateTimePicker1.Text}', [Год поступления]='{f.numericUpDown1.Value}', Дети={child}, Стипендия='{f.numericUpDown2.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Контроль":
                            {
                                AddMonitoring f = new AddMonitoring(Convert.ToInt32(dataGrid[4, dataGrid.CurrentRow.Index].Value.ToString()),
                                    dataGrid[5, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[6, dataGrid.CurrentRow.Index].Value.ToString());
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Дисциплины WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string dispKey = reader.GetValue(0).ToString();

                                    myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Преподаватели WHERE " +
                                        $"Фамилия Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND Категория Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[3]}'";
                                    reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string prepKey = reader.GetValue(0).ToString();

                                    myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Студенты WHERE" +
                                        $"Фамилия Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[0]}' " +
                                        $"AND Имя Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[1]}' " +
                                        $"AND Отчество Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[2]}' " +
                                        $"AND [Код группы] Like '{f.comboBox3.SelectedItem.ToString().Split(' ')[3]}' ";
                                    reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string studKey = reader.GetValue(0).ToString();

                                    CommandText = $"UPDATE Контроль SET [Код дисциплины]={dispKey}, [Код преподавателя]={prepKey}, [Код студента]={studKey}, Оценка='{f.numericUpDown1.Value}', Дата='{f.dateTimePicker1.Text}', [Форма контроля]='{f.comboBox4.SelectedItem}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Учебные планы":
                            {
                                AddPlan f = new AddPlan(dataGrid[2, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[3, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[4, dataGrid.CurrentRow.Index].Value.ToString(),
                                    dataGrid[5, dataGrid.CurrentRow.Index].Value.ToString(),
                                    Convert.ToInt32(dataGrid[6, dataGrid.CurrentRow.Index].Value.ToString()));
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Дисциплины WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    CommandText = $"UPDATE УчебныеПланы SET [Код дисциплины]={reader.GetValue(0)}, Курс='{f.comboBox2.SelectedItem}', Семестр='{f.comboBox3.SelectedItem}', [Вид занятия]='{f.comboBox4.SelectedItem}', [Форма контроля]='{f.comboBox5.SelectedItem}', [Количество часов]='{f.numericUpDown1.Text}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                        case "Учебные поручения":
                            {
                                AddPoruch f = new AddPoruch(Convert.ToInt32(dataGrid[4, dataGrid.CurrentRow.Index].Value.ToString()));
                                if (f.ShowDialog() == DialogResult.OK)
                                {
                                    OleDbConnection conn = new OleDbConnection(connectString);
                                    conn.Open();
                                    OleDbCommand myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Кафедра WHERE Название Like '{f.comboBox1.SelectedItem}'";
                                    OleDbDataReader reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string kafKey = reader.GetValue(0).ToString();

                                    myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Дисциплины WHERE Название Like '{f.comboBox2.SelectedItem}'";
                                    reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string dispKey = reader.GetValue(0).ToString();

                                    myCommand = conn.CreateCommand();
                                    myCommand.CommandText = $"SELECT Код FROM Группы WHERE " +
                                        $"Название Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[1]}'" +
                                        $"AND Курс Like '{f.comboBox2.SelectedItem.ToString().Split(' ')[3]}'";
                                    reader = myCommand.ExecuteReader();
                                    reader.Read();
                                    string groupKey = reader.GetValue(0).ToString();

                                    CommandText = $"UPDATE УчебныеПоручения SET [Код кафедры]={kafKey}, [Код дисциплины]={dispKey}, [Код группы]={groupKey}, Семестр='{f.numericUpDown1.Value}' WHERE Код = {ID}";
                                    conn.Close();

                                    My_Execute_Non_Query(CommandText);
                                    UpdateTable();
                                }
                                break;
                            }
                    }
                }
            }
        }

        public void DEL()
        {
            if (tabControl1.SelectedTab != null && dataGrid.CurrentRow != null)
            {
                if (new DeleteRow().ShowDialog() == DialogResult.OK)
                {
                    int index = dataGrid.CurrentRow.Index;
                    string ID = Convert.ToString(dataGrid[0, index].Value);
                    string CommandText = $"DELETE FROM {tabControl1.SelectedTab.Text} WHERE Код = " + ID;
                    My_Execute_Non_Query(CommandText);
                    UpdateTable();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int tabInd = 0;
            if (tabControl1.SelectedIndex > 1)
                tabInd = tabControl1.SelectedIndex - 1;
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            if (tabControl1.TabPages.Count > 0)
                tabControl1.SelectedTab = tabControl1.TabPages[tabInd];
            else
            {
                textBox1.Text = "";
                label1.Text = "Ничего не выбрано";
                label2.Text = "Поиск по...";
                statSelected.Text = "";
                comboBox1.Items.Clear();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) => ADD();

        private void toolStripMenuItem3_Click(object sender, EventArgs e) => EDIT();

        private void toolStripMenuItem4_Click(object sender, EventArgs e) => DEL();

        private void AddToolStripBtn_Click(object sender, EventArgs e) => ADD();

        private void EditToolStripBtn_Click(object sender, EventArgs e) => EDIT();

        private void DeleteToolStripBtn_Click(object sender, EventArgs e) => DEL();

        private void closeAllTabs(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            textBox1.Text = "";
            label1.Text = "Ничего не выбрано";
            label2.Text = "Поиск по...";
            statSelected.Text = "";
            comboBox1.Items.Clear();
        }

        private void printTable(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                dataGrid = (tabControl1.SelectedTab.Controls.Find(tabControl1.SelectedTab.Text.Replace(" ", ""), false)[0] as DoubleBufferedDataGridView);
                for (int i = 0; i < dataGrid.ColumnCount; i++)
                    resultForPrint += dataGrid.Columns[i].HeaderText + " |\t";
                resultForPrint += "\n";
                for (int i = 0; i < dataGrid.RowCount; i++)
                {
                    for (int j = 0; j < dataGrid.ColumnCount; j++)
                        resultForPrint += dataGrid.Rows[i].Cells[j].Value + "\t";
                    resultForPrint += "\n";
                }

                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintPageHandler;

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                    printDialog.Document.Print();
            }
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e) => e.Graphics.DrawString(resultForPrint, new System.Drawing.Font("Arial", 14), Brushes.Black, 0, 0);

        private void exportToExcel(object sender, EventArgs e) => Exporter.ExportToExcel(tabControl1, dataGrid);

        private void exportToWord(object sender, EventArgs e) => Exporter.ExportToWord(tabControl1, dataGrid);

        private void exportToTXT(object sender, EventArgs e) => Exporter.ExportToTXT(tabControl1, dataGrid);

        private void sendOnEmail(object sender, EventArgs e) => Exporter.SendOnMail(tabControl1, dataGrid);

        public void My_Execute_Non_Query(string CommandText)
        {
            OleDbConnection conn = new OleDbConnection(connectString);
            conn.Open();
            OleDbCommand myCommand = conn.CreateCommand();
            myCommand.CommandText = CommandText;
            myCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateTable()
        {
            dataGrid = (tabControl1.SelectedTab.Controls.Find(tabControl1.SelectedTab.Name, false)[0] as DoubleBufferedDataGridView);
            string CommandText = $"SELECT * FROM {tabControl1.SelectedTab.Name} ORDER BY Код";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(CommandText, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, $"{tabControl1.SelectedTab.Name}");
            dataGrid.DataSource = ds.Tables[0].DefaultView;
            ColorizingRows();
            dataGrid.Rows[0].Selected = false;
            dataGrid.Rows[0].Selected = true;
            if (checkBox1.Checked)
                dataGrid.Columns[0].Visible = true;
            else
                dataGrid.Columns[0].Visible = false;
        }

        public void SearchBy(string tabTitle, string pole)
        {
            string query = $"SELECT * FROM {tabTitle} where [{pole}] Like '{textBox1.Text}%'";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connectString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, tabTitle);

            dataGrid = (tabControl1.SelectedTab.Controls.Find(tabControl1.SelectedTab.Text.Replace(" ", ""), false)[0] as DoubleBufferedDataGridView);
            dataGrid.DataSource = ds.Tables[tabTitle].DefaultView;
            ColorizingRows();

            textBox1.Focus();
        }

        public void InitializeSearch()
        {
            label1.Text = tabControl1.SelectedTab.Text;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Код");
            switch (tabControl1.SelectedTab.Text)
            {
                case "Факультеты":
                    comboBox1.Items.Add("Название");
                    break;
                case "Кафедры":
                    comboBox1.Items.Add("Код факультета");
                    comboBox1.Items.Add("Название");
                    break;
                case "Дисциплины":
                    comboBox1.Items.Add("Название");
                    break;
                case "Докторские":
                    comboBox1.Items.Add("Преподаватель");
                    comboBox1.Items.Add("Название");
                    comboBox1.Items.Add("Дата");
                    break;
                case "Кандидатские":
                    comboBox1.Items.Add("Преподаватель");
                    comboBox1.Items.Add("Название");
                    comboBox1.Items.Add("Дата");
                    break;
                case "Аспирантура":
                    comboBox1.Items.Add("Преподаватель");
                    comboBox1.Items.Add("Дата");
                    break;
                case "Научные темы":
                    comboBox1.Items.Add("Преподаватель");
                    comboBox1.Items.Add("Тема");
                    break;
                case "Научные направления":
                    comboBox1.Items.Add("Преподаватель");
                    break;
                case "Группы":
                    comboBox1.Items.Add("Код факультета");
                    comboBox1.Items.Add("Название");
                    comboBox1.Items.Add("Курс");
                    break;
                case "Преподаватели":
                    comboBox1.Items.Add("Код кафедры");
                    comboBox1.Items.Add("Фамилия");
                    comboBox1.Items.Add("Имя");
                    comboBox1.Items.Add("Отчество");
                    comboBox1.Items.Add("Категория");
                    comboBox1.Items.Add("Дата рождения");
                    comboBox1.Items.Add("Дети");
                    comboBox1.Items.Add("Пол");
                    break;
                case "Учебные поручения":
                    comboBox1.Items.Add("Код кафедры");
                    comboBox1.Items.Add("Код дисциплины");
                    comboBox1.Items.Add("Код группы");
                    comboBox1.Items.Add("Семестр");
                    break;
                case "Студенты":
                    comboBox1.Items.Add("Код группы");
                    comboBox1.Items.Add("Фамилия");
                    comboBox1.Items.Add("Имя");
                    comboBox1.Items.Add("Отчество");
                    comboBox1.Items.Add("Пол");
                    comboBox1.Items.Add("Дата рождения");
                    comboBox1.Items.Add("Год поступления");
                    comboBox1.Items.Add("Стипендия");
                    break;
                case "Нагрузки":
                    comboBox1.Items.Add("Код преподавателя");
                    comboBox1.Items.Add("Код дисциплины");
                    comboBox1.Items.Add("Вид занятия");
                    comboBox1.Items.Add("Количество часов");
                    comboBox1.Items.Add("Семестр");
                    break;
                case "Дипломные работы":
                    comboBox1.Items.Add("Код студента");
                    comboBox1.Items.Add("Код преподавателя");
                    comboBox1.Items.Add("Тема");
                    break;
                case "Контроль":
                    comboBox1.Items.Add("Код дисциплины");
                    comboBox1.Items.Add("Код преподавателя");
                    comboBox1.Items.Add("Код студента");
                    comboBox1.Items.Add("Дата");
                    comboBox1.Items.Add("Форма контроля");
                    break;
                case "Учебные планы":
                    comboBox1.Items.Add("Код дисциплины");
                    comboBox1.Items.Add("Курс");
                    comboBox1.Items.Add("Семестр");
                    comboBox1.Items.Add("Вид занятия");
                    comboBox1.Items.Add("Форма контроля");
                    comboBox1.Items.Add("Количество часов");
                    break;
            }
            try { comboBox1.SelectedIndex = fieldIndex; } catch { }
        }

        public void InitializeStatus()
        {
            for (int i = 0; i < nodes.Count; i++)
                if (nodes[i].Name == tabControl1.SelectedTab.Name)
                    statNodePath.Text = nodes[i].FullPath;
        }

        public void InintializeAppStyle()
        {
            colorPackage = new ColorPackage(ColorPackage.currentAppStyle);
            menuStrip1.BackColor = colorPackage.menuStrip;
            toolStrip1.BackColor = colorPackage.toolStrip;
            statusStrip1.BackColor = colorPackage.statusStrip;
            splitContainer1.BackColor = colorPackage.splitContainer1;
            splitContainer2.BackColor = colorPackage.splitContainer2;
            treeView1.BackColor = colorPackage.tree;
            PropertyPanel.BackColor = colorPackage.propertyPanel;
            if (ColorPackage.currentAppStyle == 2)
            {
                for (int i = 0; i < menuStrip1.Items.Count; i++)
                    menuStrip1.Items[i].ForeColor = Color.White;
                treeView1.ForeColor = Color.White;
                treeView1.LineColor = Color.White;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                checkBox1.ForeColor = Color.White;
                statNodePath.ForeColor = Color.White;
                statSelected.ForeColor = Color.White;
                if (dataGrid != null)
                    dataGrid.BackgroundColor = colorPackage.dg;
            }
            else
            {
                for (int i = 0; i < menuStrip1.Items.Count; i++)
                    menuStrip1.Items[i].ForeColor = SystemColors.ControlText;
                treeView1.ForeColor = SystemColors.ControlText;
                treeView1.LineColor = SystemColors.ControlText;
                label1.ForeColor = SystemColors.ControlText;
                label2.ForeColor = SystemColors.ControlText;
                checkBox1.ForeColor = SystemColors.ControlText;
                statNodePath.ForeColor = SystemColors.ControlText;
                statSelected.ForeColor = SystemColors.ControlText;
                if (dataGrid != null)
                    dataGrid.BackgroundColor = Color.White;
            }
        }

        public void ColorizingRows()
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                {
                    if (i % 2 == 0)
                        dataGrid.Rows[i].Cells[j].Style.BackColor = colorPackage.dgCells;
                    else
                        dataGrid.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
            if (ColorPackage.currentAppStyle == 2)
            {
                for (int i = 0; i < dataGrid.RowCount; i++)
                    for (int j = 0; j < dataGrid.ColumnCount; j++)
                        if (i % 2 != 0)
                            dataGrid.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(190, 145, 221);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count > 0)
            {
                if (checkBox1.Checked)
                    dataGrid.Columns[0].Visible = true;
                else
                    dataGrid.Columns[0].Visible = false;
            }
        }

        private void usersMenu_Click(object sender, EventArgs e)
        {
            UserControl control = new UserControl();
            control.ShowDialog();
        }

        private void DataSorted(object sender, EventArgs e) => ColorizingRows();

        private void HotKeys(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T)
            {
                if (nodesExpanded)
                {
                    treeView1.CollapseAll();
                    nodesExpanded = false;
                }
                else
                {
                    treeView1.ExpandAll();
                    nodesExpanded = true;
                }
            }
            if (e.Control && e.KeyCode == Keys.Add)
                ADD();
            if (e.Control && e.KeyCode == Keys.Multiply)
                EDIT();
            if (e.Control && e.KeyCode == Keys.Subtract)
                DEL();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrid.CurrentRow != null && dataGrid.CurrentRow.Index != -1)
                statSelected.Text = "Выбрано: " + (dataGrid.CurrentRow.Index + 1) + " из " + dataGrid.RowCount;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exporter.clearEXTask();
            myConnection.Close();

            StreamWriter sw = new StreamWriter("appstyle.txt", false);
            sw.WriteLine(ColorPackage.currentAppStyle);
            sw.Close();

            System.Windows.Forms.Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
                SearchBy(tabControl1.SelectedTab.Name, comboBox1.SelectedItem.ToString());
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                InitializeSearch();
                InitializeStatus();
                UpdateTable();
                if (ColorPackage.currentAppStyle == 2)
                    dataGrid.BackgroundColor = colorPackage.dg;
                else
                    dataGrid.BackgroundColor = Color.White;
            }
            else
            {
                statNodePath.Text = "Готово";
                checkBox1.Checked = true;
            }
            textBox1.Text = "";
            if (dataGrid.RowCount > 0)
            {
                dataGrid.Rows[0].Selected = false;
                dataGrid.Rows[0].Selected = true;
            }
            else
                statSelected.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                label2.Text = $"Поиск по {comboBox1.SelectedItem}";
                fieldIndex = comboBox1.SelectedIndex;
            }
        }

        private void panelFacult_SizeChanged(object sender, EventArgs e) => textBox1.Width = PropertyPanel.Width - 40;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exporter.clearEXTask();
            myConnection.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void settingsMenu_Click(object sender, EventArgs e)
        {
            Settings control = new Settings(ColorPackage.currentAppStyle);
            control.ShowDialog();
            InintializeAppStyle();
            if (tabControl1.TabPages.Count > 0)
                ColorizingRows();
        }

        private void myProfileMenu_Click(object sender, EventArgs e)
        {
            MyProfile profile = new MyProfile();
            if (profile.ShowDialog() == DialogResult.OK)
            {
                string CommandText = $"UPDATE [Пользователи] SET Логин='{profile.textBox1.Text}', Пароль='{User.GetHash(profile.textBox2.Text)}', Почта='{profile.textBox3.Text}' WHERE Логин = '{User.Login}'";
                My_Execute_Non_Query(CommandText);
                User.Login = profile.textBox1.Text;
                User.Password = profile.textBox2.Text;
                User.Email = profile.textBox3.Text;
            }
        }

        private void changeUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите выйти из аккаунта?", "Смена пользователя", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Hide();
                new Autorise().Show();
            }
        }

        private void abouMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                                       Название проекта: «ESUM»\n" +
                "Разработчик проекта: учащийся группы 45 ТП, Сушко Алексей Юльевич.\n" +
                "Приложение разрабатывалось в среде разработки Visual Studio 2022 с использованием языка программирования C# и технологии Windows Forms.\n\n" +
                "Результатом работы стало приложение с возможностью просмотра информации об учебном процессе и документообороте ВУЗа и возможностью добавления новых данных об аспирантуре, группах, дипломных работах, дисциплинах, докторских, кандидатских, кафедрах, контрольных занятиях, нагрузках, научных направлениях, научных темах, пользователях, преподавателях, студентах, учебных планах, учебных поручениях, факультетах.\n" +
                "Приложение создано с божьей помощью при поддержке 'ООО Как я хочу спать'.\n\n\n" +
                "============== Системные требования ==============\n" +
                "Что бы у вас работала программа, нужно:\n" +
                "1. Иметь компьютер / ноутбук под управлением операционной системы Windows 7 / 8.1 / 8 / 10 с установленным.NET Framework 4.7.2\n" +
                "2. Открыть программу ESUM.exe из папки EXE\n" +
                "Минимальные требования к аппаратном и программному обеспечению, необходимому для корректной работы программы:\n" +
                "-  процессор: Pentium IV и выше;\n" +
                "-  объем оперативной памяти: 512 Мбайт и выше;\n" +
                "-  свободного места на жестком диске: 100 Мбайт;\n" +
                "-  операционная система: Windows 7 и выше;\n" +
                "-  наличие монитора VGA с разрешением не менее 1280x768 точек;\n" +
                "-  наличие манипулятора «мышь»;\n" +
                "-  клавиатура IBM PC любой модификации.", "О программе");
        }

        private void userHelpMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чтобы открыть какую-то таблицу, дважды щелкните по узлу дерева элементов в левом верхнем углу.\n\n" +
                "Под деревом таблиц находиться панель свойств выбранной таблицы. С помощью нее можно найти нужную вам информацию в таблице\n\n" +
                "Во вкладке \"Профиль\" можно изменить данные о себе или перезайти в приложение.\n\n" +
                "В настройках можно выбрать цветовую схему приложения\n\n" +
                "Данные можно экспортировать в текстовый файл, Word, Excel, на почту, а также распечатать", "Помощь");
        }

        private void HotKeysMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("[Ctrl + T] - Развернуть\\Свернуть все узлы\n" +
                "[Ctrl + Y] - Мой профиль\n" +
                "[Ctrl + \"+\"] - Добавить запись\n" +
                "[Ctrl + *] - Изменить запись\n" +
                "[Ctrl + \"-\"] - Удалить запись\n" +
                "[Ctrl + E] - Экспорт в Excel\n" +
                "[Ctrl + W] - Экспорт в Word\n" +
                "[Ctrl + I] - Экспорт в текстовый файл\n" +
                "[Ctrl + M] - Отправка на почту\n" +
                "[Ctrl + P] - Печать\n" +
                "[Ctrl + H] - Сменить пользователя\n\n" +
                "Если включена русская раскладка, можно нажаать Alt и выбирать пункты меню по нажатию клавиш с буквами, соответствующими первым буквам названий пунктов меню. Также можно использовать стрелки для переммещения по пунктам меню.", "Список горячих клавиш");
        }

        private void fileMenu_MouseEnter(object sender, EventArgs e)
        {
            if (ColorPackage.currentAppStyle == 2)
            {
                var s = (ToolStripMenuItem)sender;
                s.ForeColor = Color.Black;
            }
        }

        private void fileMenu_MouseLeave(object sender, EventArgs e)
        {
            if (ColorPackage.currentAppStyle == 2)
            {
                var s = (ToolStripMenuItem)sender;
                s.ForeColor = Color.White;
            }
        }

        private void toolStripGraphic_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }
    }
}