using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESUM
{
    class Users
    {
        string login;
        string password;
        string email;
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }

        public Users (string login, string password, string email)
        {
            this.login = login;
            this.password = password;
            this.email = email;
        }
    }
}