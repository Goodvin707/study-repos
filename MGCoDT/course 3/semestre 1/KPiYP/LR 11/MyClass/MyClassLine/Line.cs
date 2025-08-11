using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLine
{
    class Line
    {
        private Point pStart = new Point();
        private Point pEnd = new Point();
        public Line() { }
        public Line(Point pStart, Point pEnd)
        {
            this.pStart = pStart;
            this.pEnd = pEnd;
        }
        public void Show()
        {
            Console.WriteLine($"Отрезок с координатами: ({pStart}) - ({pEnd})");
        }
        public double DlinL()
        { return pStart.Dlina(pEnd, pStart); }

    }
}