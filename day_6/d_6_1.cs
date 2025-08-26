// Задание 1: Определить комбинированный (структурный) тип для представления информации по горным вершинам, состоящей из названия вершины и ее высоты. Ввести информацию по 10 вершинам. Вывести название самой высокой вершины из всех 10. 
using System;

namespace Practice_Day_6
{
    class Program
    {
        struct MountainPick
        {
            string name;
            int high;
            public int High
            {
                get { return high; }
                set { high = value; }
            }

            public MountainPick(string name, int high)
            {
                this.name = name;
                this.high = high;
            }
            public void Print()
            {
                Console.WriteLine("Гора: " + name + "   Высота вершины: " + high);
            }
        }
        static string NameGenerator(int x)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < x; i++)
            {
                s += (char)r.Next(65, 91);
            }
            return s;
        }
        static void Main()
        {
            Random r = new Random();
            MountainPick[] mounts = new MountainPick[10];
            int maxHigh = 0;
            for (int i = 0; i < mounts.Length; i++)
            {
                mounts[i] = new MountainPick(NameGenerator(r.Next(4, 12)), r.Next(1000, 10000));
                mounts[i].Print();
                if (mounts[i].High > maxHigh)
                    maxHigh = mounts[i].High;
            }
            Console.WriteLine();
            for (int i = 0; i < mounts.Length; i++)
                if (mounts[i].High == maxHigh)
                    mounts[i].Print();
        }
    }
}
