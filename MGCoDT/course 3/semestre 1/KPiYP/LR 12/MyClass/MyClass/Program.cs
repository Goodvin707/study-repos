using System;

namespace MyClass
{
    class Program
    {
        static void Main()
        {
            int a = 0, b = 0, c = 0;
        there:
            try
            {
                a = int.Parse(Console.ReadLine());
                b = int.Parse(Console.ReadLine());
                c = int.Parse(Console.ReadLine());
                if (a < 1 || b < 1 || c < 1)
                    throw new Exception();
            }
            catch (FormatException)
            {
                Console.WriteLine("Некоррекнтый ввод");
                goto there;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Слишком большое значение");
                goto there;
            }
            catch (Exception)
            {
                Console.WriteLine("Введено отрицательное число");
                goto there;
            }
            Triangle obj1 = new Triangle(a, b, c);
            obj1.Print();
            obj1.Square();
            obj1.Perimeter();


            Book obj2 = new Book("Push King", "Text", "Aversev", 236, 2007, 12121212, true);
            obj2.Take();
            obj2.Show();
        }
    }
}