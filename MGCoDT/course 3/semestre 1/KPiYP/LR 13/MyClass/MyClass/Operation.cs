using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    class Operation
    {
        public static void PrintTitle(Book b)
        {
            b.Show();
        }
        public static void MetodObrabotchik(Book b)
        {
            Console.WriteLine("Книга {0} сдана в срок.", b.ToString());
        }
    }
}