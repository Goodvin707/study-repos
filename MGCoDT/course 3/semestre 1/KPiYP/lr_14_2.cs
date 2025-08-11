// Задание 2: Измените метод CompareTo так, чтобы метод Sort сортировал массив точек по убыванию расстояния между точкой и началом координат.
using System;

namespace MultySidedSolution
{
    class DemoPoint : IComparable
    {
        protected int x;
        protected int y;
        public DemoPoint(int x, int y)
        {
            this.x = x; this.y = y;
        }
        public void Show()
        {
            Console.WriteLine($"Точка на плоскости: ({x}, {y})");
        }
        public double Dlina()
        {
            return Math.Sqrt(x * x + y * y);
        }
        //реализация метода CompareTo
        public int CompareTo(object obj)
        {
            DemoPoint b = (DemoPoint)obj; //преобразуем к типу DemoPoint
            return this.Dlina().CompareTo(b.Dlina());
        }
    }
    class Program
    {
        static void Main()
        {
            //создаем массив ссылок
            DemoPoint[] a = new DemoPoint[4];
            a[0] = new DemoPoint(5, -1);
            a[1] = new DemoPoint(-3, 3);
            a[2] = new DemoPoint(3, 4);
            a[3] = new DemoPoint(0, 1);
            //сортируем массив точек, при этом в качестве критерия сортировки будет  
            //использоваться собственная реализация метода CompareTo
            Array.Sort(a);
            Console.WriteLine();
            foreach (DemoPoint x in a)
            {
                x.Show();
                Console.WriteLine($"Dlina={x.Dlina():f2} ");
            }
        }
    }
}