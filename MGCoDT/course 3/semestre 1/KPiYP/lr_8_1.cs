/*Задание 1: Вывести на экран 3 исходных строки не менее, чем из 5 слов. Создать новую строку из двух на выбор, затем расположить их в алфавитном порядке.
Ход программы отобразить пояснениями на экране.*/
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
            string s;
            string s1 = " Надо понять (нет) где лишние пробелы.";
            string s2 = " Queue, vector, string, bump, saga.";
            string s3 = " Sfkjdshf shkfjh skjfhkdjs jkdshkjfh skj.";
            Console.WriteLine($"1.{s1}\n2.{s2}\n3.{s3}");
            m:
            Console.WriteLine("Выберите строку по номеру");
            int menu = int.Parse(Console.ReadLine()), menu1;
            switch (menu)
            {
                case 1:
                    m1:
                    Console.WriteLine("Выберите ещё одну строку по номеру");
                    menu1 = int.Parse(Console.ReadLine());
                    switch (menu1)
                    {
                        case 1: s = s1 + s1; break;
                        case 2: s = s1 + s2; break;
                        case 3: s = s1 + s3; break;
                        default: goto m1;
                    }
                    break;
                case 2:
                    m2:
                    Console.WriteLine("Выберите ещё одну строку по номеру");
                    menu1 = int.Parse(Console.ReadLine());
                    switch (menu1)
                    {
                        case 1: s = s2 + s1; break;
                        case 2: s = s2 + s2; break;
                        case 3: s = s2 + s3; break;
                        default: goto m2;
                    }
                    break;
                case 3:
                    m3:
                    Console.WriteLine("Выберите ещё одну строку по номеру");
                    menu1 = int.Parse(Console.ReadLine());
                    switch (menu1)
                    {
                        case 1: s = s3 + s1; break;
                        case 2: s = s3 + s2; break;
                        case 3: s = s3 + s3; break;
                        default: goto m3;
                    }
                    break;
                default: goto m;
            }
            Console.WriteLine($"Новая строка: {s}");
            string[] sm = {s, s1, s2, s3 };
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < sm.Length - 1; ++i)
                    if (sm[i].CompareTo(sm[i + 1]) > 0)
                    {
                        string buf = sm[i];
                        sm[i] = sm[i + 1];
                        sm[i + 1] = buf;
                        flag = true;
                    }
            }
            Console.WriteLine();
            foreach (string ss in sm)
                Console.WriteLine($"{ss} ");
            Console.ReadKey();
        }
    }
}