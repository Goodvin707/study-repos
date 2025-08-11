// Задание 3: Напишите функцию, позволяющую по введенной строке (например, «Государственный экзамен состоится 25.06.2020») вывести на экран отдельно день государственного экзамена, месяц государственного экзамена и год государственного экзамена.
// С использованием регулярных выражений
using System;
using System.Text.RegularExpressions;
namespace AnotherOneTest
{
    class Program
    {
        static void OutDate(string s)
        {
            Regex regex = new Regex(@"(\d{2})\.\d{2}\.\d{4}");
            MatchCollection matches = regex.Matches(s);
            string date = "";
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    date = match.Value;
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
            Console.WriteLine(date);
            Console.WriteLine("Выберите действие\n1. Вывести день\n2. Вывести месяц\n3. Вывести год");
        there:
            int m = int.Parse(Console.ReadLine());
            switch (m)
            {
                case 1: Console.WriteLine($"День {date[0]}{date[1]}"); break;
                case 2:
                    if (date[3] != '0')
                        Console.WriteLine($"Месяц {date[3]}{date[4]}");
                    else
                        Console.WriteLine($"Месяц {date[4]}");
                    break;
                case 3: Console.WriteLine($"Год {date[6]}{date[7]}{date[8]}{date[9]}"); break;
                default: goto there;
            }
        }
        static void Main()
        {
            string s = "Государственный экзамен состоится 25.06.2020";
            OutDate(s);
        }
    }
}