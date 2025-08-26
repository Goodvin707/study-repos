// Задание 4: Сформировать коллекцию из целых чисел. Числа получать случайным образом из интервала [A, B]. Сформировать вторую коллекцию из квадратов чисел первой коллекции. Вывести результат на экран.
using System;
using System.Collections.Generic;

namespace Praktice_Day_5
{
    class Program
    {
        class Factory
        {
            int id;
            string name;
            readonly int selfstoimost;
            public int Selfstoimost
            {
                get { return selfstoimost; }
            }
            int price;
            int ceh;
            int month;
            int kolvo;
            public Factory(int id, string name, int selfstoimost, int price, int ceh, int month, int kolvo)
            {
                this.id = id;
                this.name = name;
                this.selfstoimost = selfstoimost;
                this.id = price;
                this.ceh = ceh;
                this.month = month;
                this.kolvo = kolvo;
            }
        }
        delegate int LowerSelfSt(List<Factory> lst);
        static void Main()
        {
            int n = 15;
            Console.Write("Введите A: ");
            int A = int.Parse(Console.ReadLine());
            Console.Write("Введите B: ");
            int B = int.Parse(Console.ReadLine());
            Random r = new Random();
            List <int> lst1 = new List<int>();
            for (int i = 0; i < n; i++)
            {
                lst1.Add(r.Next(A, B + 1));
                Console.Write(lst1[i] + " ");
            }
            Console.WriteLine();
            List<int> lst2 = new List<int>();
            for (int i = 0; i < n; i++)
            {
                lst2.Add(lst1[i] * lst1[i]);
                Console.Write(lst2[i] + " ");
            }
        }
    }
}
