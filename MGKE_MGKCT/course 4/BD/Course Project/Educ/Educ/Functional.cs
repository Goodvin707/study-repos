using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zuby.ADGV;

namespace Educ
{
    static class Functional
    {
        static public void UpdateTable(AdvancedDataGridView dgView, string tablename, MySqlConnection connection)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter($"SELECT * FROM university.{tablename}", connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, tablename);
            dgView.DataSource = ds.Tables[tablename];
        }

        static public string ConvertToMySqlDateFormat(string dateOld)
        {
            //дд.мм.гггг --> гггг-мм-дд
            if (dateOld.Length > 10)
                dateOld = dateOld.Remove(10);
            string[] nums = dateOld.Split('.');
            string result = "";
            for (int i = nums.Length - 1; i >= 0; i--)
                result += "-" + nums[i];
            result = result.Remove(0, 1);

            return result;
        }

        static public string FindTheKeyByValue(string value, string fieldName, string tableName, MySqlConnection connection)
        {
            MySqlDataReader rdr = new MySqlCommand($"SELECT id FROM university.{tableName} Where {fieldName}='{value}'", connection).ExecuteReader();
            if (rdr.HasRows)
                rdr.Read();
            else
            {
                rdr.Close();
                return $"[No rows founded by this query: (table: {tableName}; {fieldName}: {value})]";
            }
            string s = rdr.GetString(0);
            rdr.Close();
            return s;
        }

        static public string FindTeacherKey(string fio, MySqlConnection connection)
        {
            MySqlDataReader rdr = new MySqlCommand($"SELECT id FROM university.teachers Where surname='{fio.Split(' ')[0]}' and name Like '{fio.Split(' ')[1][0]}%' and patronymic Like '{fio.Split(' ')[2][0]}%'", connection).ExecuteReader();
            if (rdr.HasRows)
                rdr.Read();
            else
            {
                rdr.Close();
                return $"[No teacher's keys founded by this query]";
            }
            string s = rdr.GetString(0);
            rdr.Close();
            return s;
        }
    }
}