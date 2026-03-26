using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_DB_GUI.Forms;

namespace TravelAgency_DB_GUI.Utils
{
    static internal class Logger
    {
        public static List<string> queries = new List<string>();
        public static string lastQuery = "";
        public static TextBox loggerTextBox;

        static public string LogQuery(string query, MySqlParameter[] parameters, int recordsAffected = -1)
        {
            lastQuery = "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + "]\r\n";
            if (recordsAffected == -1)
                lastQuery += "Запрос: " + query;
            else
                lastQuery += "Запрос: " + query + "\r\n" + "Затронуто записей: " + recordsAffected;

            string sParameters = "";

            for (int i = 0; i < parameters.Length; i++)
            {
                sParameters += parameters[i].ParameterName + "=" + parameters[i].Value + ";";
            }
            
            loggerTextBox.Text += lastQuery + "\r\n" + sParameters + "\r\n\r\n";
            return lastQuery;
        }
    }
}
