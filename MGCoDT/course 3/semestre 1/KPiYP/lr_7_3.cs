// Задание 3: Дана строка текста. Найти номер первого элемента равного ‘+’. Упорядочить по убыванию элементы массива расположенные за этим элементом.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string s = "4920 - 42893 + 3424 + 45";
            Console.WriteLine(s);
            int plus = s.IndexOf('+');
            s = s.Substring(plus);
            int[] n = new int[s.Length];
            for (int i = 0; i < s.Length; i++) {
                int code = char.ConvertToUtf32(s, i);
                Console.WriteLine(code);
                n[i] = code;
            }
            Array.Sort(n);
            s = "";
            Console.Write("\nРезультат: ");
            for (int i = 0; i < n.Length; i++)
            {
                s += Convert.ToChar(n[i]);
                Console.Write($"{s[i]} ");
            }
            Console.ReadKey();
        }
    }
}