using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20__1
{
    static class Data
    {
        static List<string> ts = new List<string>();
        static List<string> vs = new List<string>();
        public static List<string> Ts
        {
            get { return ts; }
            set { ts = value; }
        }
        public static List<string> Vs
        {
            get { return vs; }
            set { vs = value; }
        }
    }
}