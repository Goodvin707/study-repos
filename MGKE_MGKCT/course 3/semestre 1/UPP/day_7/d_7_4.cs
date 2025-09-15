/*Задание 4: Создать класс Transport, описывающий транспортное средство и содержащий:
• Поле вид топлива;
• Поле год выпуска;
• Поле средняя скорость.
• Конструктор, с тремя параметрами, присваивающий значения этим полям.
• Метод Print – вывод значений полей на экран.
• Метод Age, нахождение возраста транспортного средства. В параметре метода текущий год
Создать класс Car, дочерний к Transport, описывающий автомобиль и содержащий:
• Поле марка.
• Поле номер.
• Конструктор. В конструкторе класса использовать пять параметров – три поля родительского класса и два поля дочернего.
• Метод PrintC – вывод значений полей автомобиля на экран.
Создать класс Train, дочерний к Transport, описывающий поезд и содержащий:
• Поле количество вагонов
• Поле количество мест в вагоне.
• Поле всего мест в поезде.
• Конструктор. В конструкторе класса использовать пять параметров – три поля родительского класса и два поля дочернего. Вычислить значение поля всего мест в поезде.
• Метод PrintT– вывод значений полей поезда на экран.
В методе Main:
Для автомобиля:
• Случайным образом получить значения: год выпуска, средняя скорость, номер.
• Создать два автомобиля с бензиновыми двигателями.
• Применить к объектам унаследованные и собственные методы.
• Вывести информацию на экран.
Для поезда:
• Случайным образом получить значения: год выпуска, средняя скорость, количество вагонов, количество мест в вагоне.
• Создать две электрички.
• Применить к объектам унаследованные и собственные методы.
• Вывести информацию на экран.*/
using System;
using System.Collections.Generic;

namespace MultySidedSol
{
    class Program
    {
        class Transport
        {
            protected string fuel;
            protected int year;
            protected double averSpeed;
            public Transport(string fuel, int year, double averSpeed)
            {
                this.fuel = fuel;
                this.year = year;
                this.averSpeed = averSpeed;
            }
            public void Print()
            {
                Console.WriteLine($"Топливо: {fuel}  Год выпуска: {year}  Средняя скорость: {averSpeed}");
            }
            public void Age(int currentYear)
            {
                Console.WriteLine($"Возраст: {currentYear - year}");
            }
        }
        class Car : Transport
        {
            string mark;
            int number;
            public Car(string mark, int number, string fuel, int year, double averSpeed) : base(fuel, year, averSpeed)
            {
                this.mark = mark;
                this.number = number;
            }
            public void PrintC()
            {
                Console.WriteLine($"Марка: {mark}  Номер: {number}");
                Console.WriteLine($"Топливо: {fuel}  Год выпуска: {year}  Средняя скорость: {averSpeed}");
            }
        }
        class Train : Transport
        {
            int colVagons;
            int colPlaces;
            int allPPlaces;
            public Train(int colVagons, int colPlaces, string fuel, int year, double averSpeed) : base(fuel, year, averSpeed)
            {
                this.colVagons = colVagons;
                this.colPlaces = colPlaces;
                this.allPPlaces = colPlaces * colVagons;
            }
            public void PrintT()
            {
                Console.WriteLine($"Количество вагонов: {colVagons}  Количество мест в вагоне: {colPlaces}  Общее количество мест: {allPPlaces}");
                Console.WriteLine($"Топливо: {fuel}  Год выпуска: {year}  Средняя скорость: {averSpeed}");
            }
        }
        static string SGen(int x)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < x; i++)
                s += r.Next(65, 91);
            return s;
        }
        static string FuelGen(int x)
        {
            switch (x)
            {
                case 1:
                    return "Gasoline";
                case 2:
                    return "Diesel";
                case 3:
                    return "Electricity";
                case 4:
                    return "Coal";
            }
            return "";
        }
        static void Main()
        {
            Random r = new Random();
            DateTime dateTime = DateTime.Today;
            int year = dateTime.Year;
            Console.Write("Автомобили\n ");
            Car car1 = new Car(SGen(r.Next(3, 10)), r.Next(1000, 10000), FuelGen(r.Next(1, 3)), r.Next(2008, 2021), r.Next(25, 120));
            Car car2 = new Car(SGen(r.Next(3, 10)), r.Next(1000, 10000), FuelGen(r.Next(1, 3)), r.Next(2008, 2021), r.Next(25, 120));
            car1.Age(year);
            car1.PrintC();
            car2.Age(year);
            car2.PrintC();
            Console.Write("Поезда\n ");
            Train train1 = new Train(r.Next(10, 31), r.Next(10, 26), FuelGen(r.Next(3, 5)), r.Next(1998, 2020), r.Next(25, 120));
            Train train2 = new Train(r.Next(10, 31), r.Next(10, 26), FuelGen(r.Next(3, 5)), r.Next(1998, 2020), r.Next(25, 120));
            train1.Age(year);
            train1.PrintT();
            train2.Age(year);
            train2.PrintT();
        }
    }
}
