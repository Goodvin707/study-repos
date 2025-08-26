/*Задание 3: Создать коллекцию объектов и сделать выборку, соответствующую варианту, используя лямбда-выражения.
Класс «Фабрика»

«Фабрика» должна содержать следующую информацию:
Код изделия;
Наименование изделия;
Себестоимость изделия;
Цена;
Номер цеха
Номер месяца;
Выпуск изделия в штуках.
Из коллекции класса «Фабрика» выбираются и выводятся на экран изделия с наименьшей себестоимостью*/
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
            Random r = new Random();
            List <Factory> lst = new List<Factory>();
            for (int i = 0; i < 10; i++)
            {
                lst.Add(new Factory(r.Next(1000, 10000), "tovar", r.Next(10, 1000), r.Next(500, 1501), r.Next(1, 11), r.Next(1, 13), r.Next(100, 501)));
            }
            LowerSelfSt delte = lst =>
            {
                int min = 999;
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].Selfstoimost < min)
                        min = lst[i].Selfstoimost;
                }
                return min;
            };
            Console.WriteLine(delte(lst));
        }
    }
}
