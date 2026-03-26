using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelAgency_DB_GUI.Utils
{
    static internal class Validator
    {
        public static void TryInsert(TabControl tabControl1)
        {
            DataGridView dataGridView = tabControl1.SelectedTab.Controls[0] as DataGridView;
            string columns = "";
            string values = "";
            string defaultValue;
            List<MySqlParameter> parameters = new List<MySqlParameter>(dataGridView.Columns.Count);

            for (int i = 1; i < dataGridView.Columns.Count; i++)
            {
                defaultValue = Validator.DefineDefaultValue(dataGridView.Columns[i].ValueType);

                parameters.Add(new MySqlParameter(dataGridView.Columns[i].Name, defaultValue));
                columns += $"{dataGridView.Columns[i].Name}, ";
                values += $"@{dataGridView.SelectedRows[0].Cells[i].Value}, ";
            }
            columns = columns.Remove(columns.Length - 2);
            values = values.Remove(values.Length - 2);

            string query = $"INSERT INTO {tabControl1.SelectedTab.Name} ({columns}) VALUES ({values})";

            DatabaseController.ExecuteNonQuery(query, parameters.ToArray());
            //Logger.LogQuery(query);
        }
        public static string DefineDefaultValue(Type type)
        {
            string s = "";
            switch (type.ToString())
            {
                case "System.Boolean":
                    s = "0";
                    break;
                case "System.Int32":
                    s = "0";
                    break;
                case "System.DateTime":
                    s = "10.10.2010";
                    break;
                case "System.Decimal":
                    s = "1.0";
                    break;
                case "System.String":
                    s = DateTime.Now.ToString();
                    break;
            }
            return s;
        }

        public static bool ValidateInt(string value, int min, int max)
        {
            if (int.TryParse(value, out int result))
            {
                if (result < min || result > max)
                    return false;
            }
            return true;
        }

        public static bool ValidateDouble(string value, int min, int max)
        {
            if (double.TryParse(value, out double result))
            {
                if (result < min || result > max)
                    return false;
            }
            return true;
        }

        public static bool ValidateValueList(string[] value) => true;
    }
}
