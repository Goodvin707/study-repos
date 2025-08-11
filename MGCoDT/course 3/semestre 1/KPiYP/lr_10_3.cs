/*Задание 3: Создать класс колесо, имеющий радиус. Определить конструкторы и метод доступа. Создать класс машин, содержащий класс колесо. Дополнительно есть марка (строка), цена. Определить конструкторы и деструктор. Определить public- производный класс грузовик, имеющий дополнительно грузоподъемность. Определить конструкторы и функцию печати.
В случае недопустимых значений полей выбрасываются исключения.
Написать программу, демонстрирующую все разработанные элементы класса.*/
using System;

namespace AnotherOneTest
{
    class Program
    {
        abstract class Wheel
        {
            double radius;
            public double Radius
            {
                get { return radius; }
                set { radius = value; }
            }
            public Wheel()
            {
                this.Radius = 43.4;
            }
            public Wheel(double radius)
            {
                this.Radius = radius;
            }

        }
        class Automobile : Wheel
        {
            string mark;
            public string Mark
            {
                get { return mark; }
                set { mark = value; }
            }
            double price;
            public double Price
            {
                get { return price; }
                set { price = value; }
            }
            public Automobile()
            {
                this.Mark = "BMW";
                this.Price = 29999.999;
                this.Radius = 19.5;
            }
            public Automobile(string mark, double price, double radius)
            {
                this.Mark = mark;
                this.Price = price;
                this.Radius = radius;
            }
            ~Automobile()
            {
                Console.WriteLine("Вызван деструктор");
            }
        }
        class Truck : Automobile
        {
            private int capacity;
            public int Capacity
            {
                get { return capacity; }
                set { capacity = value; }
            }
            public Truck()
            {
                this.Mark = "BMW";
                this.Price = 1999.99; // руб
                this.Radius = 30.5; // см
                this.Capacity = 1500; // кг
            }
            public Truck(string mark, double price, double radius, int capacity)
            {
                this.Mark = mark;
                this.Price = price;
                this.Radius = radius;
                this.Capacity = capacity;
            }
            public void PrintAll()
            {
                Console.WriteLine($"Mark: {Mark}\tPrice: {Price}\tWheel radius: {Radius}\tCapacity: {Capacity}");
            }
        }
        static void Main()
        {
            Truck obj = new Truck("Volvo", 9999.99, 30.5, 2000);
        }
    }
}