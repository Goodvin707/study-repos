using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using TravelAgency_DB_GUI.Utils;

public static class DatabaseController
{
    private static string connectionString;

    static DatabaseController() => connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

    public static string ConnectionString
    {
        get => connectionString;
        set
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringSettings = config.ConnectionStrings.ConnectionStrings["MySqlConnection"];
            connectionStringSettings.ConnectionString = value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

            connectionString = value;
        }
    }

    /// <summary>
    /// Метод для выполнения запросов (INSERT, UPDATE, DELETE)
    /// </summary>
    /// <param name="query">Строка SQL-запроса</param>
    /// <param name="parameters">Параметры запроса</param>
    /// <returns>Количество затронутых строк</returns>
    public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);
                try
                {
                    connection.Open();
                    int a = command.ExecuteNonQuery();
                    Logger.LogQuery(query, parameters, a);
                    return a;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
        }
    }

    /// <summary>
    /// Метод для получения данных (SELECT)
    /// </summary>
    /// <param name="query">Строка SQL-запроса</param>
    /// <param name="parameters">Параметры запроса</param>
    /// <returns>MySqlDataReader</returns>
    public static MySqlDataReader ExecuteReader(string query, params MySqlParameter[] parameters)
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddRange(parameters);

            Logger.LogQuery(query, parameters);

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (MySqlException ex)
        {
            connection.Close();
            MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    /// <summary>
    /// Метод для получения одного значения (COUNT, SUM, MAX и т.д.)
    /// </summary>
    /// <param name="query">Строка SQL-запроса</param>
    /// <param name="parameters">Параметры запроса</param>
    /// <returns>object</returns>
    public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddRange(parameters);

                try
                {
                    connection.Open();

                    Logger.LogQuery(query, parameters);

                    return command.ExecuteScalar();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Ошибка базы данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }

    public static bool TestConnection()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException) { return false; }
        }
    }

    public static bool TestConnection(string user, string password)
    {
        ConnectionString = $"Server=localhost;Database=tour_agency;Uid={user};Pwd={password};";
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex.Message}\r\n{ex.SqlState}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    public static int BuildInsertQuery(TabControl tabControl)
    {
        string columns = "";
        string values = "";
        DataGridView dataGridView = tabControl.SelectedTab.Controls[0] as DataGridView;
        List<MySqlParameter> parameters = new List<MySqlParameter>(dataGridView.Columns.Count);

        for (int i = 1; i < dataGridView.Columns.Count; i++)
        {
            var cellValue = dataGridView.SelectedRows[0].Cells[i].Value;
            if (cellValue.ToString().StartsWith("\""))
            {
                cellValue = cellValue.ToString().Split('"')[1];
            }

            if (dataGridView.Columns[i].ReadOnly != true)
            {
                parameters.Add(new MySqlParameter(dataGridView.Columns[i].Name, dataGridView.SelectedRows[0].Cells[i].Value));
                columns += $"{dataGridView.Columns[i].Name}, ";
                values += $"@{dataGridView.Columns[i].Name}, ";
            }
        }
        if (columns.Length > 0 || values.Length > 0)
        {
            columns = columns.Remove(columns.Length - 2);
            values = values.Remove(values.Length - 2);
        }
        string query = $"INSERT INTO {tabControl.SelectedTab.Name} ({columns}) VALUES ({values})";

        int affectedRows = ExecuteNonQuery(query, parameters.ToArray());

        return affectedRows;
    }

    public static int BuildUpdateQuery(TabControl tabControl)
    {
        string values = "";
        DataGridView dataGridView = tabControl.SelectedTab.Controls[0] as DataGridView;
        List<MySqlParameter> parameters = new List<MySqlParameter>(dataGridView.Columns.Count);

        for (int i = 1; i < dataGridView.Columns.Count; i++)
        {
            var cellValue = dataGridView.SelectedRows[0].Cells[i].Value;
            if (cellValue.ToString().StartsWith("\""))
            {
                cellValue = cellValue.ToString().Split('"')[1];
            }

            if (dataGridView.Columns[i].ReadOnly != true)
            {
                parameters.Add(new MySqlParameter(dataGridView.Columns[i].Name, cellValue));
                values += $"{dataGridView.Columns[i].Name}=@{dataGridView.Columns[i].Name}, ";
            }
        }
        values = values.Remove(values.Length - 2);

        string query = $"UPDATE {tabControl.SelectedTab.Name} SET {values} WHERE id={dataGridView.SelectedRows[0].Cells[0].Value}";

        int affectedRows = ExecuteNonQuery(query, parameters.ToArray());

        return affectedRows;
    }

    public static int BuildDeleteQuery(TabControl tabControl)
    {
        DataGridView dataGridView = tabControl.SelectedTab.Controls[0] as DataGridView;
        string query = $"DELETE from {tabControl.SelectedTab.Name} WHERE id={dataGridView.SelectedRows[0].Cells[0].Value}";

        int affectedRows = ExecuteNonQuery(query);

        return affectedRows;
    }
}