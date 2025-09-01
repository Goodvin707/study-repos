using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace D31.Models
{
    static public class DataContext
    {
        static public string getConnectionString() => ConfigurationManager.AppSettings.Get("DefaultConnection");
        
    }
}
