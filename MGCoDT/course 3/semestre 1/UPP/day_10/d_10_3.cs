/*Задание 3: 
В класс  Point добавить:
Индексатор, позволяющий по индексу 0 обращаться к полю x, по индексу 1 – к полю y, при других значениях индекса выдается сообщение об ошибке.
Перегрузку:
операции ++ (--): одновременно увеличивает (уменьшает) значение полей х и у на 1;
констант true и false: обращение к экземпляру класса дает значение true, если значение полей x и у совпадает, иначе false;
операции бинарный +:  одновременно добавляет к полям х и у значение скаляра;
преобразования типа Point в string (и наоборот).*/

using System;

namespace _10._3
{
    class Program
    {
        class Point
        {
            int x;
            int y;
            const bool XequalYTrue = true;
            const bool XequalYFalse = false;
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
        }
    }
}
