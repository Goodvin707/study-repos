/*Задание 1: Создать класс Numbers. Закрытые поля класса – a, b два целых числа. Реализовать методы:
1. Конструктор с параметрами, присваивающий значения его полям;
2. Метод без параметров Nod, который вычисляет наибольший общий делитель этих чисел.
3. Метод без параметров Nok, который вычисляет наименьшее общее кратное этих чисел.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Praktice
{
    class Program
    {
        class Numbers
        {
            private int a;
            private int b;
            public int A
            {
                get { return a; }
                set { a = value; }
            }
            public int B
            {
                get { return b; }
                set { b = value; }
            }
            public Numbers(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
            public int Nod()
            {
                int nod = 1;
                for (int i = 1; i < (a < b ? b : a); i++)
                {
                    if (a % i == 0 && b % i == 0)
                        nod = i;
                }
                return nod;
            }
            public int Nok()
            {
                for (int i = 1; i < a * b; i++)
                {
                    if (i % a == 0 && i % b == 0)
                        return i;
                }
                return a * b;
            }
            public void Print()
            {
                Console.WriteLine($"a = {a}");
                Console.WriteLine($"b = {b}");
            }
        }
        static void Main()
        {
            Numbers nums = new Numbers(24, 16);
            nums.Print();
            Console.WriteLine($"NOD = {nums.Nod()}");
            Console.WriteLine($"NOK = {nums.Nok()}");
        }
    }
}