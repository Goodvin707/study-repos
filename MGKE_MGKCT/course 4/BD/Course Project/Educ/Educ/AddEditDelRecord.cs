using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Educ
{
    public partial class AddEditDelRecord : Form
    {
        DataGridViewColumnCollection GlobalColumns;
        DataGridViewCellCollection GlobalRowCells;
        string GtabName, GtableName;
        public AddEditDelRecord(string tabName, string tableName, DataGridViewCellCollection rowCells)
        {
            InitializeComponent();
            this.Text = "Удалить запись из \"" + tabName + "\"";
            addbutton.Text = "Удалить";

            DataTransfer.connection.Open();
            MySqlDataReader reader = new MySqlCommand($"SELECT * FROM university.{tableName}", DataTransfer.connection).ExecuteReader();
            
            string s = "Запись содержит данные:\n\n";
            for (int i = 0; i < rowCells.Count; i++)
            {
                s += reader.GetName(i).ToString() + ": ";
                s += "\"" + rowCells[i].Value + "\"\n";
            }
            reader.Close();
            DataTransfer.connection.Close();

            flowLayoutPanel1.Controls.Add(new Label() { Text = s, AutoSize = false, Width = flowLayoutPanel1.Width - 40, Height = flowLayoutPanel1.Height });
            
            
            GlobalRowCells = rowCells;
            GtabName = tabName;
            GtableName = tableName;
        }
        
        public AddEditDelRecord(string tabName, string tableName, DataGridViewColumnCollection columns, DataGridViewCellCollection rowCells)
        {
            InitializeComponent();
            this.Text = "Изменить запись в \"" + tabName + "\"";
            addbutton.Text = "Изменить";
            GlobalColumns = columns;
            GlobalRowCells = rowCells;
            GtabName = tabName;
            GtableName = tableName;
        }

        public AddEditDelRecord(string tabName, string tableName, DataGridViewColumnCollection columns)
        {
            InitializeComponent();
            this.Text = "Добавить запись в \"" + tabName + "\"";
            GlobalColumns = columns;
            GtabName = tabName;
            GtableName = tableName;
        }

        private void AddEditDelRecord_Load(object sender, EventArgs e)
        {
            if (addbutton.Text != "Удалить")
            {
                DataTransfer.connection.Open();
                MySqlDataReader reader = new MySqlCommand($"SELECT * FROM university.{GtableName}", DataTransfer.connection).ExecuteReader();
                string[] types = new string[GlobalColumns.Count - 1];
                string[] fieldNames = new string[GlobalColumns.Count - 1];
                for (int i = 0; i < GlobalColumns.Count - 1; i++)
                {
                    types[i] = reader.GetFieldType(reader.GetName(i + 1)).ToString();
                    fieldNames[i] = reader.GetName(i + 1).ToString();
                }
                reader.Close();

                for (int i = 0; i < types.Length; i++)
                {
                    flowLayoutPanel1.Controls.Add(new Label() { Text = GlobalColumns[i + 1].HeaderText.ToString(), TextAlign = ContentAlignment.BottomLeft, AutoSize = false, Width = flowLayoutPanel1.Width - 40 });
                    switch (types[i])
                    {
                        case "System.String":
                            switch (GtableName)
                            {
                                case "facult_view":
                                    flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    break;
                                case "kafedras_view":
                                    if (fieldNames[i] != "Факультет")
                                        flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    else
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT title FROM university.facult", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    break;
                                case "groupes_view":
                                    if (fieldNames[i] != "Факультет")
                                        flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    else
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT title FROM university.facult", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    break;
                                case "teachers_view":
                                    if (fieldNames[i] == "Кафедра")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT title FROM university.kafedras", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "Категория" || fieldNames[i] == "Пол")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT DISTINCT {fieldNames[i]} FROM university.{GtableName}", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 228, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else
                                        flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    break;
                                case "students_view":
                                    if (fieldNames[i] == "Группа")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT concat(id, ' ', title) FROM university.groupes", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 228, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "Пол")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT DISTINCT {fieldNames[i]} FROM university.{GtableName}", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 228, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else
                                        flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    break;
                                case "monitoring_view":
                                    if (fieldNames[i] == "Дисциплина")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT title FROM university.disciplines", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "Форма контроля")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT DISTINCT mon_type FROM university.monitoring", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 128, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "Писал")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT Concat(surname, ' ', left(name, 1), '. ', left(patronymic, 1), '. из группы \"', groupes.id, ' ', groupes.title, '\"') FROM university.students Join university.groupes On university.groupes.id=university.students.id_groupes", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "Проводил")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT Concat(surname, ' ', left(name, 1), '. ', left(patronymic, 1), '. с кафедры \"', kafedras.title, '\"') FROM university.teachers Join university.kafedras On university.kafedras.id=university.teachers.id_kafedras", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    break;
                                case "diploms_view":
                                    if (fieldNames[i] == "Тема дипломной работы")
                                        flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    else if (fieldNames[i] == "Дисциплина")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT title FROM university.disciplines", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "Выполнял")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT Concat(surname, ' ', left(name, 1), '. ', left(patronymic, 1), '. из группы \"', groupes.id, ' ', groupes.title, '\"') FROM university.students Join university.groupes On university.groupes.id=university.students.id_groupes", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "Проводил")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT Concat(surname, ' ', left(name, 1), '. ', left(patronymic, 1), '. с кафедры \"', kafedras.title, '\"') FROM university.teachers Join university.kafedras On university.kafedras.id=university.teachers.id_kafedras", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    break;
                                case "loads_view":
                                    if (fieldNames[i] == "Дисциплина")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT title FROM university.disciplines", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "ФИО преподавателя")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT Concat(surname, ' ', left(name, 1), '. ', left(patronymic, 1), '. с кафедры \"', kafedras.title, '\"') FROM university.teachers Join university.kafedras On university.kafedras.id=university.teachers.id_kafedras", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    else if (fieldNames[i] == "Вид занятия")
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT DISTINCT lesson_type FROM university.loads", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 128, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    break;
                                case "disciplines_view":
                                    flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    break;
                                case "doctoral_view":
                                    if (fieldNames[i] == "Название")
                                        flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    else
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT Concat(surname, ' ', left(name, 1), '. ', left(patronymic, 1), '. с кафедры \"', kafedras.title, '\"') FROM university.teachers Join university.kafedras On university.kafedras.id=university.teachers.id_kafedras", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    break;
                                case "sciencethemes_view":
                                    if (fieldNames[i] == "Тема")
                                        flowLayoutPanel1.Controls.Add(new TextBox() { Width = 228, Name = "val" });
                                    else
                                    {
                                        MySqlDataReader rdr = new MySqlCommand($"SELECT Concat(surname, ' ', left(name, 1), '. ', left(patronymic, 1), '. с кафедры \"', kafedras.title, '\"') FROM university.teachers Join university.kafedras On university.kafedras.id=university.teachers.id_kafedras", DataTransfer.connection).ExecuteReader();
                                        List<string> values = new List<string>();
                                        while (rdr.Read())
                                            values.Add(rdr.GetString(0));
                                        rdr.Close();

                                        flowLayoutPanel1.Controls.Add(new ComboBox() { Width = 328, DropDownStyle = ComboBoxStyle.DropDownList, Sorted = true, DataSource = values.ToArray(), Name = "val" });
                                    }
                                    break;
                            }
                            break;
                        case "System.DateTime":
                            flowLayoutPanel1.Controls.Add(new DateTimePicker() { Value = DateTime.Today, Format = DateTimePickerFormat.Short, MinDate = new DateTime(1950, 1, 1), MaxDate = new DateTime(2024, 1, 1), Name = "val" });
                            break;
                        case "System.Int32":
                            switch (GtableName)
                            {
                                case "groupes_view":
                                    flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, Minimum = 1, Maximum = 5, Name = "val" });
                                    break;
                                case "students_view":
                                    flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, Minimum = 1980, Maximum = DateTime.Today.Year, Name = "val" });
                                    break;
                                case "teachers_view":
                                    flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, Minimum = 0, Maximum = 15, Name = "val" });
                                    break;
                                case "monitoring_view":
                                    flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, Minimum = 1, Maximum = 10, Name = "val" });
                                    break;
                                case "loads_view":
                                    if (fieldNames[i] == "Часы")
                                        flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, Minimum = 2, Maximum = 300, Name = "val" });
                                    else
                                        flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, Minimum = 1, Maximum = 2, Name = "val" });
                                    break;
                            }
                            // flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, ThousandsSeparator = true, Name = "val" });
                            break;
                        case "System.Decimal":
                            switch (GtableName)
                            {
                                case "students_view":
                                    flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, ThousandsSeparator = true, Increment = 100, DecimalPlaces = 2, Minimum = 0, Maximum = 800, Value = 300, Name = "val" });
                                    break;
                                case "teachers_view":
                                    flowLayoutPanel1.Controls.Add(new NumericUpDown() { Width = 70, ThousandsSeparator = true, Increment = 100, DecimalPlaces = 2, Minimum = 800, Maximum = 5000, Value = 1000, Name = "val" });
                                    break;
                            }                            
                            break;
                        case "System.Boolean":
                            flowLayoutPanel1.Controls.Add(new RadioButton() { Checked = true, Text = "Имеются", Name = "val" });
                            flowLayoutPanel1.Controls.Add(new RadioButton() { Text = "Не имеются", Name = "val" });
                            break;
                    }
                }
                DataTransfer.connection.Close();
            }

            if (addbutton.Text == "Изменить")
            {
                string s = "";
                for (int i = 1; i < GlobalColumns.Count; i++)
                    s += GlobalRowCells[i].Value + ";";

                string[] arr = s.Remove(s.Length - 1).Split(';');
                Control[] controls = flowLayoutPanel1.Controls.Find("val", false);
                for (int i = 0; i < controls.Length; i++)
                {
                    if (controls[i] is RadioButton)
                    {
                        (controls[i] as RadioButton).Checked = true;
                        if (arr[i] == "False")
                            (controls[i + 1] as RadioButton).Checked = true;
                    }
                    else
                    {
                        if (i >= controls.Length - 1)
                            controls[controls.Length - 1].Text = arr[arr.Length - 1];
                        else
                            controls[i].Text = arr[i];
                    }
                }
            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            string query = "Use university;";
            DataTransfer.connection.Open();

            GtableName = GtableName.Replace("_view", "");
            Control[] controls = flowLayoutPanel1.Controls.Find("val", false);

            int emptyFieldCount = 0;
            for (int i = 0; i < controls.Length; i++)
            {
                if (controls[i] is TextBox && controls[i].Text == "")
                    emptyFieldCount++;
            }
            if (emptyFieldCount > 0)
                MessageBox.Show($"В {emptyFieldCount} полях пустое значение", "Пропущено поле");
            else
            {
                switch (addbutton.Text)
                {
                    case "Добавить":
                        query += $"Insert Into {GtableName} ";
                        switch (GtableName)
                        {
                            case "facult":
                                query += $"(title) Values ('{controls[0].Text}')";
                                break;
                            case "kafedras":
                                query += $"(id_facult, title) Values ({Functional.FindTheKeyByValue(controls[0].Text, "title", "facult", DataTransfer.connection)}, '{controls[1].Text}')";
                                break;
                            case "groupes":
                                query += $"(id_facult, title, curse) Values ({Functional.FindTheKeyByValue(controls[0].Text, "title", "facult", DataTransfer.connection)}, '{controls[1].Text}', {controls[2].Text})";
                                break;
                            case "teachers":
                                query += $"(id_kafedras, surname, name, patronymic, category, birthdate, children, salary, gender) Values " +
                                    $"({Functional.FindTheKeyByValue(controls[0].Text, "title", "kafedras", DataTransfer.connection)}," +
                                    $"'{controls[1].Text}'," +
                                    $"'{controls[2].Text}'," +
                                    $"'{controls[3].Text}'," +
                                    $"'{controls[4].Text}'," +
                                    $"'{Functional.ConvertToMySqlDateFormat(controls[5].Text)}'," +
                                    $"{controls[6].Text}," +
                                    $"'{controls[7].Text}'," +
                                    $"'{controls[8].Text}')";
                                break;
                            case "students":
                                query += $"(id_groupes, surname, name, patronymic, gender, birthdate, admission_year, children, scholarship) Values " +
                                    $"({controls[0].Text.Split(' ')[0]}," +
                                    $"'{controls[1].Text}'," +
                                    $"'{controls[2].Text}'," +
                                    $"'{controls[3].Text}'," +
                                    $"'{controls[4].Text}'," +
                                    $"'{Functional.ConvertToMySqlDateFormat(controls[5].Text)}'," +
                                    $"{controls[6].Text}," +
                                    ((controls[7] as RadioButton).Checked ? "1," : "0,") +
                                $"'{controls[9].Text}')";
                                break;
                            case "monitoring":
                                query += $"(id_disciplines, mon_type, mark, event_date, id_students, id_teachers) Values " +
                                    $"({Functional.FindTheKeyByValue(controls[0].Text, "title", "disciplines", DataTransfer.connection)}," +
                                    $"'{controls[1].Text}'," +
                                    $"{controls[2].Text}," +
                                    $"'{Functional.ConvertToMySqlDateFormat(controls[3].Text)}'," +
                                    $"{Functional.FindTheKeyByValue(controls[4].Text.Split(' ')[0], "surname", "students", DataTransfer.connection)}," +
                                    $"{Functional.FindTeacherKey(controls[5].Text, DataTransfer.connection)})";
                                break;
                            case "diploms":
                                query += $"(theme, id_disciplines, id_students, id_teachers, deadline) Values " +
                                    $"('{controls[0].Text}'," +
                                    $"{Functional.FindTheKeyByValue(controls[1].Text, "title", "disciplines", DataTransfer.connection)}," +
                                    $"{Functional.FindTheKeyByValue(controls[2].Text.Split(' ')[0], "surname", "students", DataTransfer.connection)}," +
                                    $"{Functional.FindTeacherKey(controls[3].Text, DataTransfer.connection)}," +
                                    $"'{Functional.ConvertToMySqlDateFormat(controls[4].Text)}')";
                                break;
                            case "loads":
                                query += $"(id_disciplines, id_teachers, hours, semestre, lesson_type) Values " +
                                    $"({Functional.FindTheKeyByValue(controls[0].Text, "title", "disciplines", DataTransfer.connection)}," +
                                    $"{Functional.FindTeacherKey(controls[1].Text, DataTransfer.connection)}," +
                                    $"{controls[2].Text}," +
                                    $"{controls[3].Text}," +
                                    $"'{controls[4].Text}')";
                                break;
                            case "disciplines":
                                query += $"(title) Values ('{controls[0].Text}')";
                                break;
                            case "doctoral":
                                query += $"(id_teachers, title, publishdate) Values " +
                                    $"({Functional.FindTeacherKey(controls[0].Text, DataTransfer.connection)}," +
                                    $"'{controls[1].Text}'," +
                                    $"'{Functional.ConvertToMySqlDateFormat(controls[2].Text)}')";
                                break;
                            case "sciencethemes":
                                query += $"(id_teachers, title) Values " +
                                    $"({Functional.FindTeacherKey(controls[0].Text, DataTransfer.connection)}," +
                                    $"'{controls[1].Text}')";
                                break;
                        }
                        break;
                    case "Изменить":
                        query += $"Update table {GtableName} Set ";
                        switch (GtableName)
                        {
                            case "facult":
                                query += $"title='{controls[0].Text}'";
                                break;
                            case "kafedras":
                                query += $"id_facult={Functional.FindTheKeyByValue(controls[0].Text, "title", "facult", DataTransfer.connection)}, title='{controls[1].Text}'";
                                break;
                            case "groupes":
                                query += $"id_facult={Functional.FindTheKeyByValue(controls[0].Text, "title", "facult", DataTransfer.connection)}, title='{controls[1].Text}', curse={controls[2].Text}";
                                break;
                            case "teachers":
                                query +=
                                    $"id_kafedras={Functional.FindTheKeyByValue(controls[0].Text, "title", "kafedras", DataTransfer.connection)}," +
                                    $"surname='{controls[1].Text}'," +
                                    $"name='{controls[2].Text}'," +
                                    $"patronymic='{controls[3].Text}'," +
                                    $"category='{controls[4].Text}'," +
                                    $"birthdate='{Functional.ConvertToMySqlDateFormat(controls[5].Text)}'," +
                                    $"children={controls[6].Text}," +
                                    $"salary='{controls[7].Text}'," +
                                    $"gender='{controls[8].Text}'";
                                break;
                            case "students":
                                query +=
                                    $"id_groupes={controls[0].Text.Split(' ')[0]}," +
                                    $"surname='{controls[1].Text}'," +
                                    $"name='{controls[2].Text}'," +
                                    $"patronymic='{controls[3].Text}'," +
                                    $"gender='{controls[4].Text}'," +
                                    $"birthdate'{Functional.ConvertToMySqlDateFormat(controls[5].Text)}'," +
                                    $"admission_year={controls[6].Text}," +
                                    $"children={controls[7].Text}," +
                                    $"scholarship='{controls[9].Text}'";
                                break;
                            case "monitoring":
                                query +=
                                    $"id_disciplines={Functional.FindTheKeyByValue(controls[0].Text, "title", "disciplines", DataTransfer.connection)}," +
                                    $"mon_type='{controls[1].Text}'," +
                                    $"mark={controls[2].Text}," +
                                    $"event_date='{Functional.ConvertToMySqlDateFormat(controls[3].Text)}'," +
                                    $"id_students={Functional.FindTheKeyByValue(controls[4].Text.Split(' ')[0], "surname", "students", DataTransfer.connection)}," +
                                    $"id_teachers={Functional.FindTeacherKey(controls[5].Text, DataTransfer.connection)}";
                                break;
                            case "diploms":
                                query +=
                                    $"theme='{controls[0].Text}'," +
                                    $"id_disciplines={Functional.FindTheKeyByValue(controls[1].Text, "title", "disciplines", DataTransfer.connection)}," +
                                    $"id_students={Functional.FindTheKeyByValue(controls[2].Text.Split(' ')[0], "surname", "students", DataTransfer.connection)}," +
                                    $"id_teachers={Functional.FindTeacherKey(controls[3].Text, DataTransfer.connection)}," +
                                    $"deadline='{Functional.ConvertToMySqlDateFormat(controls[4].Text)}'";
                                break;
                            case "loads":
                                query +=
                                    $"id_disciplines={Functional.FindTheKeyByValue(controls[0].Text, "title", "disciplines", DataTransfer.connection)}," +
                                    $"id_teachers={Functional.FindTeacherKey(controls[1].Text, DataTransfer.connection)}," +
                                    $"hours={controls[2].Text}," +
                                    $"semestre={controls[3].Text}," +
                                    $"lesson_type='{controls[4].Text}'";
                                break;
                            case "disciplines":
                                query += $"title='{controls[0].Text}'";
                                break;
                            case "doctoral":
                                query +=
                                    $"id_teachers={Functional.FindTeacherKey(controls[0].Text, DataTransfer.connection)}," +
                                    $"title='{controls[1].Text}'," +
                                    $"publishdate='{Functional.ConvertToMySqlDateFormat(controls[2].Text)}'";
                                break;
                            case "sciencethemes":
                                query +=
                                    $"id_teachers={Functional.FindTeacherKey(controls[0].Text, DataTransfer.connection)}," +
                                    $"title='{controls[1].Text}'";
                                break;
                        }
                        query += $" Where id={GlobalRowCells[0].Value}";
                        // new MySqlCommand(query, DataTransfer.connection).ExecuteNonQuery();
                        break;
                    case "Удалить":
                        query += $"Delete from {GtableName} Where id={GlobalRowCells[0].Value}";
                        // new MySqlCommand(query, DataTransfer.connection).ExecuteNonQuery();
                        break;
                }
                Console.WriteLine(query);
                try
                {
                    new MySqlCommand(query, DataTransfer.connection).ExecuteNonQuery();
                    DialogResult = DialogResult.OK;
                }
                catch (MySqlException ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            DataTransfer.connection.Close();
        }

        private void вставитьtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] s = Clipboard.GetText().Split(ClipSettings.Separator);
            Control[] controls = flowLayoutPanel1.Controls.Find("val", false);
            for (int i = 0; i < controls.Length; i++)
                if (!(controls[i] is RadioButton))
                    controls[i].Text = s[i].Replace(ClipSettings.Separator.ToString(), "").Trim();
        }

        private void вБуферToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = "";
            Control[] controls = flowLayoutPanel1.Controls.Find("val", false);
            for (int i = 0; i < controls.Length; i++)
            {
                if (!(controls[i] is RadioButton))
                {
                    s += controls[i].Text; 
                    if (i != controls.Length - 1)
                        s += ClipSettings.Separator + " ";
                }
            }
            Clipboard.SetText(s);
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control[] controls = flowLayoutPanel1.Controls.Find("val", false);
            for (int i = 0; i < controls.Length; i++)
                if (!(controls[i] is RadioButton))
                    controls[i].Text = "";
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}


//switch (GtableName)
//{
//    case "facult":
//        break;
//    case "kafedras":
//        break;
//    case "groupes":
//        break;
//    case "teachers":
//        break;
//    case "students":
//        break;
//    case "monitoring":
//        break;
//    case "diploms":
//        break;
//    case "loads":
//        break;
//    case "disciplines":
//        break;
//    case "doctoral":
//        break;
//    case "sciencethemes":
//        break;
//}