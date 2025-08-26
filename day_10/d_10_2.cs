/*Задание 2: 
Полную структуру классов и их взаимосвязь продумать самостоятельно.
Для абстрактного класса определить какие методы должны быть абстрактными, а какие обычными.
Исходные данные считываются из файла.
Создать абстрактный класс Figure с методами вычисления площади и периметра, а также методом, выводящим  информацию о фигуре на экран.
Создать производные классы: Rectangle (прямоугольник), Circle (круг), Triangle (треугольник) со своими методами вычисления площади и периметра.
Создать массив n фигур и вывести полную информацию о фигурах на экран.*/

using System;
using System.IO;

namespace _10._2
{
    class Program
    {
        abstract class Figure
        {
            public abstract int Perimeter();
            public abstract int Square();
            public abstract void Print();
        }
        class Rectangle : Figure
        {
            int a;
            int b;
            public Rectangle(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
            public override int Perimeter()
            {
                return (a + b) * 2;
            }
            public override int Square()
            {
                return a * b;
            }
            public override void Print()
            {
                Console.WriteLine("a: " + a + " b: = " + b);
            }
        }
        class Circle : Figure
        {
            int r;
            public Circle(int r)
            {
                this.r = r;
            }
            public override int Perimeter()
            {
                return (int)(2 * 3.14 * r);
            }
            public override int Square()
            {
                return (int)(3.14 * (r * r));
            }
            public override void Print()
            {
                Console.WriteLine("r: " + r);
            }
        }
        class Trinangle : Figure
        {
            int a;
            int b;
            int c;
            public Trinangle(int a, int b, int c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }
            public override int Perimeter()
            {
                return a + b + c;
            }
            public override int Square()
            {
                int p = (a + b + c) / 2;
                return (int)(Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
            }
            public override void Print()
            {
                Console.WriteLine("a: " + a + " b: " + b + " c: " + c);
            }
        }
        static void Main()
        {
            Console.WriteLine("1. Считать с файла\n2. Сгенерировать");
            int menu = int.Parse(Console.ReadLine());
            Random r = new Random();
            int n;
            Figure[] figures;
            switch (menu)
            {
                case 1:
                    figures = new Figure[6];
                    
                    string s = "";
                    for (int i = 0; i < 6; i++)
                    {
                        StreamReader f = new StreamReader("data.txt");
                        while (!f.EndOfStream)
                        {
                            s = f.ReadLine();
                            int a = Convert.ToInt32(s) + r.Next(3, 8);
                            s = f.ReadLine();
                            int b = Convert.ToInt32(s) + r.Next(3, 8);
                            figures[i] = new Rectangle(a, b);

                            i++;
                            s = f.ReadLine();
                            int radius = Convert.ToInt32(s) + r.Next(3, 8);
                            figures[i] = new Circle(radius);

                            i++;
                            s = f.ReadLine();
                            int x = Convert.ToInt32(s) + r.Next(3, 8);
                            s = f.ReadLine();
                            int y = Convert.ToInt32(s) + r.Next(3, 8);
                            s = f.ReadLine();
                            int z = Convert.ToInt32(s) + r.Next(3, 8);
                            figures[i] = new Trinangle(x, y, z);
                        }
                        f.Close();
                    }
                    for (int i = 0; i < figures.Length; i++)
                        figures[i].Print();
                    break;
                case 2:
                    n = int.Parse(Console.ReadLine());
                    figures = new Figure[n];
                    for (int i = 0; i < figures.Length; i++)
                    {
                        int rr = r.Next(1, 4);
                        switch (rr)
                        {
                            case 1:
                                figures[i] = new Rectangle(r.Next(2, 16), r.Next(2, 16));
                                Console.WriteLine("Прямоугольник");
                                break;
                            case 2:
                                figures[i] = new Circle(r.Next(2, 11));
                                Console.WriteLine("Круг");
                                break;
                            case 3:
                                figures[i] = new Trinangle(r.Next(3, 16), r.Next(3, 16), r.Next(3, 16));
                                Console.WriteLine("Треугольник");
                                break;
                        }
                        figures[i].Print();
                    }
                    break;
            }
        }
    }
}
