using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESUM
{
    class User
    {
        static string login;
        static string password;
        static string email;
        static public string Login { get => login; set => login = value; }
        static public string Password { get => password; set => password = value; }
        static public string Email { get => email; set => email = value; }
        static public string GetHash(string s) => Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(s)));
    }
}