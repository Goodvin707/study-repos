/*Задания 4, 5: Дан класс Point, который определяет точку на координатной плоскости. Реализовать подсчет количества созданных экземпляров типа Point. Класс Point объявляется как нестатический.
Модифицировать класс Point следующим образом:
добавить статический метод LengthPoints() для вычисления расстояния между двумя точками. В качестве параметров метод должен получать экземпляры типа Point.
В функции main() продемонстрировать вызов статического метода LengthPoints().*/

using System;

namespace _10._4
{
    class Program
    {
        class Point
        {
            int x;
            int y;
            const bool XequalYTrue = true;
            const bool XequalYFalse = false;
            public static int count;
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
            static Point()
            {
                count = 0;
            }
            public Point()
            {
                x = 0;
                y = 0;
                count++;
            }
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
                count++;
            }
            public int this[int index]
            {
                get
                {
                    if (x == y)
                        Console.WriteLine(XequalYTrue);
                    else
                        Console.WriteLine(XequalYFalse);

                    if (index == 0)
                        return x;
                    if (index == 1)
                        return y;
                    if (index > 1 || index < 0)
                        Console.WriteLine("IndexOutOfRangeException");
                    return 0;
                }
            }
            public static Point operator +(Point p, int scal)
            {
                p.x += scal;
                p.y += scal;
                return p;
            }
            public static Point operator ++(Point p)
            {
                p.x++;
                p.y++;
                return p;
            }
            public static Point operator --(Point p)
            {
                p.x--;
                p.y--;
                return p;
            }
            public string ToStr()
            {
                return $"X: {x} Y: {y}";
            }
            public Point ToPoint(string s)
            {
                Point point = new Point();
                string buffer = "";
                for (int i = 3; i < s.Length; i++)
                {
                    if (!char.IsDigit(s[i]))
                        break;
                    buffer += s[i];
                }
                point.x = Convert.ToInt32(buffer);
                buffer = "";
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (!char.IsDigit(s[i]))
                        break;
                    buffer += s[i];
                }
                string revBuffer = "";
                for (int i = 0; i < buffer.Length; i++)
                    revBuffer += buffer[i];
                point.y = Convert.ToInt32(revBuffer);
                return point;
            }
            public void Print()
            {
                Console.WriteLine("X: " + x + "; Y: " + y);
            }
            public void DistanceFrom0_0()
            {
                Console.WriteLine("Расстояние от начала координат: " + Math.Round(Math.Sqrt(x * x + y * y), 0));
            }
            public void Move(int a, int b)
            {
                x += a;
                y += b;
            }
            static public double LengthPoints(Point A, Point B)
            {
                return Math.Round(Math.Sqrt((B.x - A.x) * (B.x - A.x) + (B.y - A.y) * (B.y - A.y)), 1);
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
            Console.WriteLine();

            Console.WriteLine(point[0] + " " + point[1]);
            point++;
            Console.WriteLine(point[0] + " " + point[1]);
            point--;
            Console.WriteLine(point[0] + " " + point[1]);
            point += 14;
            Console.WriteLine(point[0] + " " + point[1]);
            Console.WriteLine();

            string ps = point.ToStr();
            point.ToPoint(ps);
            point.Print();

            Point point2 = new Point(4, 5);
            point2.Print();
            Console.WriteLine("Длина между точками: " + Point.LengthPoints(point, point2));
        }
    }
}
