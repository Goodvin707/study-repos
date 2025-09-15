/*Задание 1: 
Создать класс  Point, разработав следующие элементы класса:
1. Поля:
	1. int x, y;
	2. Конструкторы, позволяющие создать экземпляр класса:
		1. с нулевыми координатами;
		2.  с заданными координатами.
3. Методы, позволяющие:
	1. вывести координаты точки на экран;
	2. рассчитать расстояние от начала координат до точки;
	3. переместить точку на плоскости на вектор (a, b).
4. Свойства:
	1. получить-установить координаты точки (доступное для чтений и записи);
	2. позволяющие умножить координаты точки на скаляр (доступное только для записи).*/

using System;

namespace Praktice_Day_10
{
    class Program
    {
        class Point
        {
            int x;
            int y;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
            public int Scalar
            {
                set
                {
                    x = x * value;
                    y = y * value;
                }
            }
            public Point()
            {
                x = 0;
                y = 0;
            }
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public void Print()
            {
                Console.WriteLine("X: " + x + "; Y: " + y);
            }
            public void DistanceFrom0_0()
            {
                Console.WriteLine("Расстояние от начала координат: " + Math.Round(Math.Sqrt(x*x + y*y), 0));
            }
            public void Move(int a, int b)
            {
                x += a;
                y += b;
            }
        }
        static void Main()
        {
            Point point = new Point(5, 4);
            point.Print();
            point.DistanceFrom0_0();
            point.Move(3, 4);
            point.Print();
            point.DistanceFrom0_0();
        }
    }
}
