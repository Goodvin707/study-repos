// Задание 2: Напишите функцию, заменяющий во веденном предложении все заданные пользователем буквы на другую заданную букву.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string Replace(string s)
        {
            Console.WriteLine($"{s}\nВведите буквы, которые хотите заменить");
            string sm = "", b = " ";
            while(b != "")
            {
                b = Console.ReadLine();
                sm += b;
            }
            Console.WriteLine("Введите букву, на которую хотите их заменить ");
            char z = char.Parse(Console.ReadLine());
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < sm.Length; j++)
                {
                    if (s[i] == sm[j])
                        s = s.Replace(s[i], z);
                }
            }
            return s;
        }
        static void Main()
        {
            string s = "Государственный экзамен состоится 25.06.2020";
            Console.WriteLine(Replace(s));
            Console.ReadKey();
        }
    }
}