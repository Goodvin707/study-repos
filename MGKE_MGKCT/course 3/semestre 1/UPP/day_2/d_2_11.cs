/*Задание 10: Разработать рекурсивный метод для вывода на экран всех возможных разложений натурального числа n на слагаемые (без повторений). Например, для n=5 на экран должно быть выведено:
1+1+1+1+1=5
1+1+1+2=5
1+1+3=5
1+4=5
2+1+2=5
2+3=5*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Praktice
{
    class Program
    {
        static int a = 1, b = 1;
        static public void rec(int x)
        {
            for (int i = 1; i < x; i++)
            {
                Console.Write(a);
                for (int j = x - i; j > 1; j--)
                {
                    Console.Write(" + 1");
                }
                Console.Write(" + " + b);
                Console.WriteLine();
                b++;
            }
            b = a + 1;
            a++;
            if (x > 1)
                rec(x - 2);
        }
        public static void Main()
        {
            Console.Write("Введите n: ");
            int x = Convert.ToInt32(Console.ReadLine());
            rec(x);
        }
    }
}