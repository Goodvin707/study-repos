/*Задание 5: В абстрактном классе Abs_ut объявить метод Poisk. В качестве параметров методу Poisk передается массив объектов типа класса Basovi и количество объектов. Метод Poisk определяет, находится ли среди объектов собака заданной породы. Если такой объект имеется, то выводится порядковый номер объекта. Иначе выводится сообщение, что такой породы нет.
В классе Basovi имеется поле Vladelec для хранения фамилии владельца собаки. Для работы с этим полем реализовать соответствующие методы.
Класс Basovi наследует класс Abs_ut. Объявить интерфейс Inter. Элементом интерфейса является метод Reading, которому в качестве параметров передается массив ссылок типа класса Basovi и количество объектов (объекты типа Basovi или Dog).
Количество объектов и ввод данных в массив объектов реализовать в методе Reading.
Класс Dog наследует класс Basovi и интерфейс Inter.
Элементом класса Dog является поле Age, задающее возраст собаки. Для работы с полем Age, использовать свойство.
Созданный массив объектов записать в бинарный файл. В головном модуле в цикле while реализовать вызов соответствующих методов для ввода данных в массив объектов, поиска собаки заданной породы, завершение выполнения программы.*/
using System;
using System.IO;

namespace Praktice_Day_8
{
    interface Inter
    {
        public void Reading(ref Dog[] avtos, int n);
    }
    abstract class Abs_ut
    {
        public void Find(Dog[] avtos, int n)
        {
            for (int i = 0; i < avtos.Length; i++)
            {
                if (avtos[i].Age == 2006)
                    Console.WriteLine(avtos[i].Parking);
            }
        }
    }
    class Basovi : Abs_ut
    {
        string vladelec = "A100";
        public string Parking
        {
            get { return this.vladelec; }
        }
    }
    class Dog : Basovi, Inter
    {
        int age;
        public Dog(int god)
        {
            this.age = god;
        }
        public Dog() { this.age = -1; }
        public void Reading(ref Dog[] avtos, int n)
        {
            Random rd = new Random();
            avtos = new Dog[n];
            for (int i = 0; i < avtos.Length; i++)
                avtos[i] = new Dog(rd.Next(2000, 2021));
            FileStream fs = new FileStream("abc.bin", FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs, System.Text.Encoding.Default);
            for (int i = 0; i < avtos.Length; i++)
                writer.Write(avtos[i].Age);
        }
        public int Age { get { return this.age; } set { this.age = value; } }
    }
    class Program
    {
        static void Main()
        {
            Dog[] mass = null;
            Dog avto = new Dog();
            avto.Reading(ref mass, 5);
            Basovi basovi = new Basovi();
            basovi.Find(mass, 5);
        }
    }
}
