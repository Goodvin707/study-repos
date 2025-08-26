// Задание 3: Определить структурный тип, описывающий гостиничный номер (название гостиницы, номер, Комфортность (люкс, полулюкс стандарт, эконом), количество человек, стоимость). Заполнить структурный массив 10-ю записями. Переписать из исходного массива в другой массив, информацию только о тех гостиничных номерах, название гостиницы которых оканчивается на сочетание букв «hostel». Затем новый массив отсортировать по комфортности по алфавиту.
using System;
using System.Collections.Generic;

namespace Practice_Day_6
{
    class Program
    {
        struct Hotel : IComparable
        {
            public string name;
            public int roomNumber;
            public string comfortable;
            public int peopleCount;
            public int cost;
            public void Print()
            {
                Console.WriteLine("Название: " + name + " Номер: " + roomNumber + " Комфортность: " + comfortable + " Количество человек: " + peopleCount + " Стоимость: " + cost);
            }
            int IComparable.CompareTo(object obj)
            {
                Hotel it = (Hotel)obj;
                if (this.name[0] == it.name[0])
                    return 0;
                else if (this.name[0] > it.name[0])
                    return 1;
                else return -1;
            }
        }

        static string NameGenerator(int x)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < x; i++)
                s += (char)r.Next(65, 91);
            return s;
        }
        static void Main()
        {
            Random r = new Random();
            Hotel[] hots = new Hotel[10];
            for (int i = 0; i < hots.Length; i++)
            {
                switch (r.Next(1, 3))
                {
                    case 1:
                        hots[i].name = NameGenerator(r.Next(5, 16));
                        break;
                    case 2:
                        hots[i].name = NameGenerator(r.Next(5, 16)) + "HOSTEL";
                        break;
                }
                hots[i].roomNumber = r.Next(1, 41);
                switch(r.Next(1, 5))
                {
                    case 1:
                        hots[i].comfortable = "Эконом";
                        break;
                    case 2:
                        hots[i].comfortable = "Стандарт";
                        break;
                    case 3:
                        hots[i].comfortable = "Полулюкс";
                        break;
                    case 4:
                        hots[i].comfortable = "Люкс";
                        break;
                }
                hots[i].peopleCount = r.Next(1, 5);
                hots[i].cost = r.Next(500, 16000);
                hots[i].Print();
            }
            Console.WriteLine();
            Array.Sort(hots);
            for (int i = 0; i < hots.Length; i++)
                hots[i].Print();
        }
    }
}
