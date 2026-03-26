using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TravelAgency_DB_GUI.Forms.UsersForm;

namespace TravelAgency_DB_GUI.Forms
{
    public partial class AlterUserDialogForm : Form
    {
        public bool IsEditMode { get; set; }
        public string OldUsername { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public AlterUserDialogForm()
        {
            InitializeComponent();
            InitializeRoles();
        }

        private void InitializeRoles()
        {
            cmbRole.Items.AddRange(UserRoles.AllRoles);
            cmbRole.SelectedIndex = 0;
        }

        // Проверка существования пользователя
        public bool UserExists(string username, string host = "localhost")
        {
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@User", username);
            parameters[1] = new MySqlParameter("@Host", host);
            return Convert.ToInt32(DatabaseController.ExecuteScalar("SELECT COUNT(*) FROM mysql.user WHERE user = @User AND host = @Host", parameters)) > 0;
        }

        private void UserDialogForm_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                Text = "Редактирование пользователя";
                txtUsername.Text = Username;
                txtUsername.ReadOnly = false; // Можно разрешить переименование
                cmbRole.SelectedItem = Role;
                lblPassword.Text = "Новый пароль (оставьте пустым, если не менять)";
            }
            else
            {
                Text = "Добавление пользователя";
                txtUsername.ReadOnly = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Введите имя пользователя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (!IsEditMode && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Проверка на существование (только для создания)
            if (!IsEditMode && UserExists(txtUsername.Text))
            {
                MessageBox.Show("Пользователь с таким именем уже существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            Username = txtUsername.Text;
            Password = txtPassword.Text;
            Role = cmbRole.SelectedItem.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
