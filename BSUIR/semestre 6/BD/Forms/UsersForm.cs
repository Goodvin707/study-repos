using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TravelAgency_DB_GUI.Forms
{
    public partial class UsersForm : Form
    {
        private BindingSource _bindingSource = new BindingSource();

        public class MySqlUser
        {
            public string Host { get; set; } = "localhost";
            public string User { get; set; }
            public string Role { get; set; }
        }

        public static class UserRoles
        {
            public const string SalesAgent = "sales_agent";
            public const string ProductManager = "product_manager";
            public const string Admin = "admin";

            public static readonly string[] AllRoles =
            {
                SalesAgent,
                ProductManager,
                Admin
            };
        }

        public UsersForm(TextBox loggerTextBox)
        {
            InitializeComponent();
            
            dataGridView.DataSource = _bindingSource;

            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                _bindingSource.DataSource = GetAllUsers();
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Получение списка пользователей
        public DataTable GetAllUsers()
        {
            string query = @"SELECT * FROM users_and_roles_view";

            DataTable dt = new DataTable();

            using (var reader = DatabaseController.ExecuteReader(query))
            {
                if (reader != null)
                    dt.Load(reader);
            }
            
            return dt;
        }

        // Создание пользователя
        public bool CreateUser(string username, string password, string role, string host = "localhost")
        {
            try
            {
                string createQuery = $"CREATE USER '{username}'@'{host}' IDENTIFIED BY @Password";
                DatabaseController.ExecuteNonQuery(createQuery, new MySqlParameter("@Password", password));

                // Назначение роли (привилегий)
                AssignRole(username, host, role);

                string setDefaultRole = $"SET DEFAULT ROLE {role} TO '{username}'@'{host}'";
                DatabaseController.ExecuteNonQuery(setDefaultRole);


                // Применение привилегий
                DatabaseController.ExecuteNonQuery("FLUSH PRIVILEGES");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка создания пользователя: {ex.Message}");
            }
        }

        // Изменение пользователя
        public bool UpdateUser(string oldUsername, string newUsername, string newPassword,
                              string role, string host = "localhost")
        {
            try
            {
                // Переименование (если имя изменилось)
                if (oldUsername != newUsername)
                {
                    string renameQuery = $"RENAME USER '{oldUsername}'@'{host}' TO '{newUsername}'@'{host}'";
                    DatabaseController.ExecuteNonQuery(renameQuery);
                }

                // Смена пароля (если указан)
                if (!string.IsNullOrEmpty(newPassword))
                {
                    string passwordQuery = $"ALTER USER '{newUsername}'@'{host}' IDENTIFIED BY @Password";
                    DatabaseController.ExecuteNonQuery(passwordQuery, new MySqlParameter("@Password", newPassword));
                }

                // Обновление роли
                RevokeAllRoles(newUsername, host);
                AssignRole(newUsername, host, role);

                DatabaseController.ExecuteNonQuery("FLUSH PRIVILEGES");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка обновления пользователя: {ex.Message}");
            }
        }

        // Удаление пользователя
        public bool DeleteUser(string username, string host = "localhost")
        {
            try
            {
                string query = $"DROP USER '{username}'@'{host}'";
                DatabaseController.ExecuteNonQuery(query);
                DatabaseController.ExecuteNonQuery("FLUSH PRIVILEGES");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка удаления пользователя: {ex.Message}");
            }
        }

        // Приватные методы для работы с ролями
        private string GetUserRole(string username)
        {
            // Упрощённая логика: проверяем привилегии для определения роли
            using (var reader = DatabaseController.ExecuteReader($"SHOW GRANTS FOR '{username}'@'localhost'"))
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        string grant = reader[0].ToString();
                        foreach (var role in UserRoles.AllRoles)
                        {
                            if (grant.Contains(role)) return role;
                        }
                    }
                }
            }
            
            return "unknown";
        }

        private void AssignRole(string username, string host, string role)
        {
            string query = $"GRANT '{role}'@'%' TO '{username}'@'{host}'";
            DatabaseController.ExecuteNonQuery(query);
        }

        private void RevokeAllRoles(string username, string host)
        {
            string query = $"REVOKE 'sales_agent'@'%', 'product_manager'@'%' FROM '{username}'@'{host}'";
            DatabaseController.ExecuteNonQuery(query);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var form = new AlterUserDialogForm())
            {
                form.IsEditMode = false;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CreateUser(
                            form.Username,
                            form.Password,
                            form.Role
                        );
                        MessageBox.Show("Пользователь создан!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var form = new AlterUserDialogForm())
            {
                form.IsEditMode = true;
                form.OldUsername = dataGridView.CurrentRow.Cells[0].Value.ToString();
                form.Username = dataGridView.CurrentRow.Cells[0].Value.ToString();
                form.Role = dataGridView.CurrentRow.Cells[2].Value.ToString();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        UpdateUser(
                            form.OldUsername,
                            form.Username,
                            form.Password,
                            form.Role
                        );
                        MessageBox.Show("Пользователь обновлён!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = (MySqlUser)dataGridView.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"Удалить пользователя '{user.User}'?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteUser(user.User, user.Host);
                    MessageBox.Show("Пользователь удалён!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();
    }
}
