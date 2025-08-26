/*Задание 20: После поступления в ВУЗ о студентах собрана информация: фамилия, нуждается ли в общежитии, стаж работы, что окончил, какой язык изучал. Составить программу, определяющую:
1) сколько человек нуждаются в общежитии;
2) списки студентов, проработавших 2 и более лет;
3) списки языковых групп;
4) сколько студентов имеют некоторый рабочий стаж;
5) сколько студентов изучали английский язык.*/

using System;
using System.Collections.Generic;

namespace AnotherOneTest
{
    class Program
    {
        struct Student
        {
            public string secName;
            public bool dorm;
            public int workExp;
            public string ended;
            public string language;
            public Student(string secName, bool inDorm, int workExp, string ended, string language)
            {
                this.secName = secName;
                this.dorm = inDorm;
                this.workExp = workExp;
                this.ended = ended;
                this.language = language;
            }
            public void Print()
            {
                Console.WriteLine("Фамилия: " + secName);
                if (dorm)
                    Console.WriteLine(" Нуждается в общежитии");
                else
                    Console.WriteLine(" Не нуждается в общежитии");
                if (workExp == 1)
                    Console.WriteLine(" Стаж работы: " + workExp + " год");
                else
                    Console.WriteLine(" Стаж работы: " + workExp + " года");
                Console.WriteLine(" Закончил: " + ended);
                Console.WriteLine(" Изучал язык: " + language);
            }
        }
        static string StrGen(int x)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < x; i++)
                s += Convert.ToChar(r.Next(65, 91));
            return s;
        }
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetWindowSize(60, 35);
            Random r = new Random();
            Student[] students = new Student[r.Next(20, 31)];
            int countInDorm = 0, countEng = 0;
            for (int i = 0; i < students.Length; i++)
            {
                students[i].secName = StrGen(r.Next(5, 12));
                if (r.Next(1, 3) == 1)
                {
                    students[i].dorm = true;
                    countInDorm++;
                }
                else
                    students[i].dorm = false;
                students[i].workExp = r.Next(1, 5);
                students[i].ended = StrGen(r.Next(3, 8));
                int lang = r.Next(1, 4);
                switch (lang)
                {
                    case 1: students[i].language = "русский"; break;
                    case 2: students[i].language = "английский"; countEng++; break;
                    case 3: students[i].language = "немецкий"; break;
                }
                students[i].Print();
                Console.WriteLine();
            }
            Console.WriteLine("Выберите действие\n1) Сколько человек нуждаются в общежитии;\n2) Списки студентов, проработавших 2 и более лет;\n3) Списки языковых групп;\n4) Сколько студентов имеют некоторый рабочий стаж;\n5) Сколько студентов изучали английский язык.");
            int menu = int.Parse(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    Console.WriteLine("Кол-во нуждающихся в общежитии: " + countInDorm);
                    break;
                case 2:
                    Console.WriteLine("---------Список студентов со стажем 2 и более лет---------");
                    for (int i = 0; i < students.Length; i++)
                    {
                        if (students[i].workExp >= 2)
                            students[i].Print();
                    }
                    Console.WriteLine("----------------------------------------------------------");
                    break;
                case 3:
                    Console.WriteLine("--------------Список языковых групп--------------");
                    List<string> s = new List<string>();
                    int gind = 0;
                    for (int i = 0; i < students.Length; i++)
                    {
                        if (!s.Contains(students[i].language))
                        {
                            s.Add(students[i].language);
                            gind++;
                        }
                    }
                    while(gind > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine($"\nГруппа языка: {s[gind - 1]}");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        for (int i = 0; i < students.Length; i++)
                        {
                            if (students[i].language == s[gind - 1])
                                students[i].Print();
                        }
                        gind--;
                    }
                    Console.WriteLine("-------------------------------------------------");
                    break;
                case 4:
                    Console.Write("Введите рабочий стаж: ");
                    int we = int.Parse(Console.ReadLine());
                    int count = 0;
                    Console.WriteLine("-------------------------------------------------");
                    for (int i = 0; i < students.Length; i++)
                    {
                        if (students[i].workExp == we)
                        {
                            students[i].Print();
                            count++;
                        }
                    }
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Количество: " + count);
                    Console.WriteLine("-----------------------");
                    break;
                case 5:
                    Console.WriteLine("Кол-во студентов, изучавших английский: " + countEng);
                    break;
            }
        }
    }
}
