using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Zuby.ADGV;

namespace Educ
{
    public partial class MainForm : Form
    {
        static string[] tableNames =
        {
            "facult_view",
            "kafedras_view",
            "groupes_view",
            "teachers_view",
            "students_view",
            "monitoring_view",
            "diploms_view",
            "loads_view",
            "disciplines_view",
            "doctoral_view",
            "sciencethemes_view",
        };

        AdvancedDataGridView dgView;
        AdvancedDataGridView[] dgViews;
        string tablename;
        public MainForm()
        {
            InitializeComponent();

            dgViews = new AdvancedDataGridView[tableNames.Length];
            AdvancedDataGridView.SetTranslations(AdvancedDataGridView.LoadTranslationsFromFile("lang.json"));
            AdvancedDataGridViewSearchToolBar.SetTranslations(AdvancedDataGridViewSearchToolBar.LoadTranslationsFromFile("lang.json"));
            for (int i = 0; i < tableNames.Length; i++)
            {
                dgView = new AdvancedDataGridView();
                dgView.Dock = DockStyle.Fill;
                dgView.BorderStyle = BorderStyle.None;
                dgView.BackgroundColor = Color.FromArgb(151, 60, 52);
                dgView.RowHeadersVisible = false;
                dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgView.MultiSelect = true;
                dgView.AllowUserToAddRows = false;
                dgView.AllowUserToDeleteRows = false;
                dgView.ReadOnly = true;
                dgView.AllowUserToResizeRows = false;
                dgView.AllowUserToOrderColumns = true;
                dgView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgView.DefaultCellStyle = new DataGridViewCellStyle()
                {
                    BackColor = Color.FromArgb(171, 80, 82),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.OrangeRed,
                };
                dgView.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
                {
                    BackColor = Color.FromArgb(161, 60, 72),
                };

                dgView.Name = tableNames[i];
                dgView.SetDoubleBuffered();

                string tablename = tabControl1.TabPages[i].Name.Remove(tabControl1.TabPages[i].Name.Length - 4) + "_view";
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM university.{tablename}", DataTransfer.connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, tablename);
                // dgView.DataSource = ds.Tables[tablename];
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = ds;
                dgView.DataSource = bindingSource1;

                DataTable dataTable = ds.Tables[tablename];
                bindingSource1.DataMember = dataTable.TableName;

                AdvancedDataGridViewSearchToolBar toolBar = new AdvancedDataGridViewSearchToolBar();
                toolBar.Dock = DockStyle.Top;
                toolBar.Name = tableNames[i] + "-toolbar";
                toolBar.Search += ToolBar_Search;

                tabControl1.TabPages[i].Controls.Add(dgView);
                tabControl1.TabPages[i].Controls.Add(toolBar);

                toolBar.SetColumns(dgView.Columns);

                dgView.FilterStringChanged += DgView_FilterStringChanged;
                dgView.SortStringChanged += DgView_SortStringChanged;
                dgView.SelectionChanged += DgView_SelectionChanged;
                dgView.ContextMenuStrip = contextMenuStrip1;

                dgViews[i] = dgView;
            }

            tablename = "facult_view";
            dgView = (tabControl1.SelectedTab.Controls.Find(tablename, false)[0] as AdvancedDataGridView);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            tabControl1.SelectTab(0);
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            listBox1.Width = flowLayoutPanel1.Width - 10;
            label2.Width = flowLayoutPanel1.Width;
            label6.Width = flowLayoutPanel1.Width;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tablename = tabControl1.SelectedTab.Name.Remove(tabControl1.SelectedTab.Name.Length - 4) + "_view";
            dgView = (tabControl1.SelectedTab.Controls.Find(tablename, false)[0] as AdvancedDataGridView);
            // Functional.UpdateTable(dgView, tablename);

            listBox1.Items.Clear();
            for (int i = 0; i < dgView.Columns.Count; i++)
            {
                if (dgView.Columns[i].ValueType.ToString() != "System.String" && dgView.Columns[i].ValueType.ToString() != "System.Boolean")
                    listBox1.Items.Add(dgView.Columns[i].HeaderText);
            }
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = 0;

            if (dgView.RowCount > 0)
            {
                dgView.Rows[0].Selected = false;
                dgView.Rows[0].Selected = true;
            }
            else
                statSelected.Text = "";

            filterStat.Text = dgView.FilterString == "" ? "Фильтры:" : dgView.FilterString;
            sortStat.Text = dgView.SortString == "" ? "| Сортировка:" : "| " + dgView.SortString;
        }

        private void DgView_SelectionChanged(object sender, EventArgs e) => statSelected.Text = "Выбрано: " + dgView.SelectedRows.Count + " из " + dgView.Rows.Count;

        private void DgView_FilterStringChanged(object sender, AdvancedDataGridView.FilterEventArgs e) => filterStat.Text = dgView.FilterString == "" ? "Фильтры:" : dgView.FilterString;

        private void DgView_SortStringChanged(object sender, AdvancedDataGridView.SortEventArgs e) => sortStat.Text = dgView.SortString == "" ? "| Сортировка:" : "| " + dgView.SortString;

        private void addtoolStripButton_Click(object sender, EventArgs e)
        {
            if (new AddEditDelRecord(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Name.Remove(tabControl1.SelectedTab.Name.Length - 4) + "_view", dgView.Columns).ShowDialog() == DialogResult.OK)
                UpdateTable(tablename);
        }

        private void edittoolStripButton_Click(object sender, EventArgs e)
        {
            if (new AddEditDelRecord(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Name.Remove(tabControl1.SelectedTab.Name.Length - 4) + "_view", dgView.Columns, dgView.SelectedRows[0].Cells).ShowDialog() == DialogResult.OK)
                UpdateTable(tablename);
        }

        private void deltoolStripButton_Click(object sender, EventArgs e)
        {
            if (new AddEditDelRecord(tabControl1.SelectedTab.Text, tabControl1.SelectedTab.Name.Remove(tabControl1.SelectedTab.Name.Length - 4) + "_view", dgView.SelectedRows[0].Cells).ShowDialog() == DialogResult.OK)
                UpdateTable(tablename);
        }

        private void journaltoolStripButton_Click(object sender, EventArgs e) => new Journals().Show();

        private void shhleftpanel_Click(object sender, EventArgs e) => splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;

        private void ToolBar_Search(object sender, AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            bool restartsearch = true;
            int startColumn = 0;
            int startRow = 0;
            if (!e.FromBegin)
            {
                bool endcol = dgView.CurrentCell.ColumnIndex + 1 >= dgView.ColumnCount;
                bool endrow = dgView.CurrentCell.RowIndex + 1 >= dgView.RowCount;

                if (endcol && endrow)
                {
                    startColumn = dgView.CurrentCell.ColumnIndex;
                    startRow = dgView.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : dgView.CurrentCell.ColumnIndex + 1;
                    startRow = dgView.CurrentCell.RowIndex + (endcol ? 1 : 0);
                }
            }
            DataGridViewCell c = dgView.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);
            if (c == null && restartsearch)
                c = dgView.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    0,
                    0,
                    e.WholeWord,
                    e.CaseSensitive);
            if (c != null)
                dgView.CurrentCell = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Выбрать")
            {
                if (listBox1.Items.Count > 0)
                {
                    button1.Text = "Изменить";
                    listBox1.Enabled = false;
                    flowLayoutPanel3.Enabled = true;
                    flowLayoutPanel4.Enabled = true;
                    button2.Enabled = true;
                    // listBox1.SelectedIndex = 0;
                    label5.Text = "Выбрано: " + listBox1.SelectedItem.ToString();

                    string field = listBox1.SelectedItem.ToString();
                    for (int i = 0; i < dgView.Rows.Count; i++)
                    {
                        if (!comboBox1.Items.Contains(dgView[field, i].Value))
                            comboBox1.Items.Add(dgView[field, i].Value);
                        if (!comboBox2.Items.Contains(dgView[field, i].Value))
                            comboBox2.Items.Add(dgView[field, i].Value);
                    }
                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;
                }
            }
            else
            {
                button1.Text = "Выбрать";
                listBox1.Enabled = true;
                flowLayoutPanel3.Enabled = false;
                flowLayoutPanel4.Enabled = false;
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                button2.Enabled = false;
                label5.Text = "Выбрано: ";
                
                string tablename = tabControl1.SelectedTab.Name.Remove(tabControl1.SelectedTab.Name.Length - 4) + "_view";
                MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM university.{tablename}", DataTransfer.connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, tablename);
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = ds;
                dgView.DataSource = bindingSource1;

                DataTable dataTable = ds.Tables[tablename];
                bindingSource1.DataMember = dataTable.TableName;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            for (int i = comboBox1.SelectedIndex; i < comboBox1.Items.Count; i++)
                comboBox2.Items.Add(comboBox1.Items[i]);
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tablename = tabControl1.SelectedTab.Name.Remove(tabControl1.SelectedTab.Name.Length - 4) + "_view";
            string query = $"SELECT * FROM university.{tablename} Where `{listBox1.SelectedItem}` between '{comboBox1.SelectedItem}' and '{comboBox2.SelectedItem}'";
            if (dgView[listBox1.SelectedItem.ToString(), 0].ValueType.ToString() == "System.DateTime")
                query = $"SELECT * FROM university.{tablename} Where `{listBox1.SelectedItem}` between '{Functional.ConvertToMySqlDateFormat(comboBox1.SelectedItem.ToString())}' and '{Functional.ConvertToMySqlDateFormat(comboBox2.SelectedItem.ToString())}'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, DataTransfer.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tablename);
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = ds;
            dgView.DataSource = bindingSource1;

            DataTable dataTable = ds.Tables[tablename];
            bindingSource1.DataMember = dataTable.TableName;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < dgViews.Length; i++)
                    dgViews[i].Columns[0].Visible = false;
            }
            else
            {
                for (int i = 0; i < dgViews.Length; i++)
                    dgViews[i].Columns[0].Visible = true;
            }
        }

        public void UpdateTable(string tablename)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM university.{tablename}", DataTransfer.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tablename);
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = ds;
            dgView.DataSource = bindingSource1;

            DataTable dataTable = ds.Tables[tablename];
            bindingSource1.DataMember = dataTable.TableName;
        }

        private void toolCopyRow_Click(object sender, EventArgs e)
        {
            string s = "";
            for (int i = checkBox1.Checked ? 1 : 0; i < dgView.SelectedRows[0].Cells.Count; i++)
            {
                s += dgView.SelectedRows[0].Cells[i].Value;
                if (i != dgView.SelectedRows[0].Cells.Count - 1)
                    s += ClipSettings.Separator + " ";
            }
            s += "\n";
            Clipboard.SetText(s);
        }

        private void toolCopySelectedRows_Click(object sender, EventArgs e)
        {
            string s = "";
            for (int i = 0; i < dgView.SelectedRows.Count; i++)
            {
                for (int j = checkBox1.Checked ? 1 : 0; j < dgView.SelectedRows[i].Cells.Count; j++)
                {
                    s += dgView.SelectedRows[i].Cells[j].Value;
                    if (j != dgView.SelectedRows[i].Cells.Count - 1)
                        s += ClipSettings.Separator + " ";
                }
                s += "\n";
            }
            Clipboard.SetText(s);
        }

        private void toolCopyAllRows_Click(object sender, EventArgs e)
        {
            string s = "";
            for (int i = 0; i < dgView.Rows.Count; i++)
            {
                for (int j = checkBox1.Checked ? 1 : 0; j < dgView.Rows[i].Cells.Count; j++)
                {
                    s += dgView.Rows[i].Cells[j].Value;
                    if (j != dgView.Rows[i].Cells.Count - 1)
                        s += ClipSettings.Separator + " ";
                }
                s += "\n";
            }
            Clipboard.SetText(s);
        }

        private void clipFormatMenuItem_Click(object sender, EventArgs e) => new ClipFormat().ShowDialog(this);
    }
}