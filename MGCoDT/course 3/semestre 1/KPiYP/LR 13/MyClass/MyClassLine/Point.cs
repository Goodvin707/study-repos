using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLine
{
    class Point
    {
        double x;
        double y;
        public Point() { }
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void Show()
        {
            Console.WriteLine("Точка с координатами: ({0}, {1})", x, y);
        }
        public double Dlina(Point p1, Point p2)
        {
            double Dl = Math.Sqrt((p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y));
            return Dl;
        }
        public override string ToString()
        {
            string ss = x + " ; " + y;
            return ss;
        }
    }
}