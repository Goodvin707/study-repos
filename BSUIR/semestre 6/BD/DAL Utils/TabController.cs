using DocumentFormat.OpenXml.Office.CustomUI;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TravelAgency_DB_GUI.DAL_Utils;

namespace TravelAgency_DB_GUI.Utils
{
    static internal class TabController
    {
        static public void InitNewTab(TabControl tabControl, ControlEventArgs e)
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.Name = e.Control.Name;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.MultiSelect = false;
            dataGridView.BackgroundColor = Color.WhiteSmoke;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Teal;
            dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.White;

            var tab = tabControl.TabPages[tabControl.TabPages.Count - 1];
            tab.Controls.Add(dataGridView);

            LoadTable(tab);
            if (tabControl.TabCount == 1)
                LoadSearch(dataGridView);
        }

        static public void LoadSearch(DataGridView dataGridView)
        {
            SearchController.Fields.Items.Clear();
            for (int i = 0; i < dataGridView?.ColumnCount; i++)
                SearchController.Fields.Items.Add(dataGridView.Columns[i].HeaderText);

            if (SearchController.Fields.Items.Count > 0)
                SearchController.Fields.SelectedIndex = 0;
        }

        static public void LoadTable(TabPage tab)
        {
            DataGridView dataGridView = tab.Controls[0] as DataGridView;

            string query = $@"SELECT * FROM {tab.Name}_v";

            using (MySqlDataReader reader = DatabaseController.ExecuteReader(query))
            {
                if (reader != null)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView.DataSource = dt;
                }
            }

            SkipSomeColumns(dataGridView, tab);
        }

        private static void SkipSomeColumns(DataGridView dataGridView, TabPage tab)
        {
            string fields = "";

            using (MySqlDataReader reader = DatabaseController.ExecuteReader($@"SELECT * FROM {tab.Name} limit 1"))
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    fields += reader.GetName(i) + ";";
                }
            }

            string[] splittedFields = fields.Remove(fields.Length - 1).Split(';');

            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns[0].ReadOnly = true;

                

                for (int i = 1, j = 1; i < dataGridView.Columns.Count; i++, j++)
                {
                    if (tab.Name == "booking_services")
                    {
                        if (i == 2 || i == 3 || i == 5)
                        {
                            dataGridView.Columns[i].ReadOnly = true;
                            j--;
                        }
                        else
                            dataGridView.Columns[i].Name = splittedFields[j];
                    }
                    else if (tab.Name == "employee_commissions")
                    {
                        if (i == 3 || i == 4)
                        {
                            dataGridView.Columns[i].ReadOnly = true;
                            j--;
                        }
                        else
                            dataGridView.Columns[i].Name = splittedFields[j];
                    }
                    else if (tab.Name == "hotels")
                    {
                        if (i == 1)
                        {
                            dataGridView.Columns[i].ReadOnly = true;
                            j--;
                        }
                        else
                            dataGridView.Columns[i].Name = splittedFields[j];
                    }
                    else
                    {
                        dataGridView.Columns[i].Name = splittedFields[i];
                    }
                }
            }
        }
    }
}