using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESUM
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (CheckForInternetConnection())
                Application.Run(new Preload());
            else
                Application.Run(new Autorise());
        }

        public static bool CheckForInternetConnection()
        {
            String host = "google.com";
            int timeout = 1000;
            try { return new Ping().Send(host, timeout, new byte[32], new PingOptions()).Status == IPStatus.Success; }
            catch (PingException) { return false; }
        }
    }
}