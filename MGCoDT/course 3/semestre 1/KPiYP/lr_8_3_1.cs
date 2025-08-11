// Задание 3: Напишите функцию, позволяющую по введенной строке (например, «Государственный экзамен состоится 25.06.2020») вывести на экран отдельно день государственного экзамена, месяц государственного экзамена и год государственного экзамена.
// Без регулярных выражений
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void OutDate(string s)
        {
            char[] day = new char[2];
            char[] month = new char[2];
            char[] year = new char[4];
            int point = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '.' && point == 0)
                {
                    point++;
                    day[0] = s[i - 2];
                    day[1] = s[i - 1];
                    month[0] =  s[i + 1];
                    month[1] = s[i + 2];
                    continue;
                }
                if (s[i] == '.' && point == 1)
                {
                    point++;
                    year[0] = s[i + 1];
                    year[1] = s[i + 2];
                    year[2] = s[i + 3];
                    year[3] = s[i + 4];
                }
            }
            Console.WriteLine("Выберите действие\n1. Вывести день\n2. Вывести месяц\n3. Вывести год");
            there:
            int m = int.Parse(Console.ReadLine());
            switch (m)
            {
                case 1: Console.WriteLine($"День {day[0]}{day[1]}"); break;
                case 2: Console.WriteLine($"Месяц {month[0]}{month[1]}"); break;
                case 3: Console.WriteLine($"Год {year[0]}{year[1]}{year[2]}{year[3]}"); break;
                default: goto there;
            }
        }
        static void Main()
        {
            string s = "Государственный экзамен состоится 25.06.2020";
            OutDate(s);
            Console.ReadKey();
        }
    }
}