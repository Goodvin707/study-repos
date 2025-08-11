using System;
using System.Collections.Generic;
using System.Text;

namespace MyClass
{
    abstract class Shape
    {
        protected double a;
        abstract public void Print();
        abstract public double Square();
        abstract public double Perimeter();
    }
}