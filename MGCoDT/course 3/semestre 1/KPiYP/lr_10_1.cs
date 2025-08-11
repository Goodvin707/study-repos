/* Задание 1: Составить программу, которая продемонстрирует работу варианта. Вводимые значения и результаты вывести на экран.
Создать базовый класс, а затем вложенный в него класс. Затем создать класс, который будет пытаться обратится к вложенному через базовый. Также создать экземпляр вложенного типа. Ход программы отобразить с комментариями.*/
using System;

namespace AnotherOneTest
{
    class Program
    {
        public abstract class BaseClass
        {
            public int MyProperty1 { get; set; }
            public double MyProperty2 { get; set; }
            public string MyProperty3 { get; set; }
            public BaseClass()
            {
                this.MyProperty1 = 1;
                this.MyProperty2 = 2.2;
                this.MyProperty3 = "I'm BaseClass";
            }
            public class EmbededClass
            {
                public int MyProperty1 { get; set; }
                public double MyProperty2 { get; set; }
                public string MyProperty3 { get; set; }
                public EmbededClass()
                {
                    this.MyProperty1 = 100;
                    this.MyProperty2 = 22.5;
                    this.MyProperty3 = "I'm EmbededClass. I'm inside BaseClass";
                }
            }
        }
        public class NextClass : BaseClass.EmbededClass
        {
            public NextClass()
            {
                this.MyProperty1 = 10;
                this.MyProperty2 = 2.5;
                this.MyProperty3 = "I'm inherit from the EmbededClass";
            }
            public void PrintInfo()
            {
                Console.WriteLine(this.MyProperty1 + "\n" + this.MyProperty2 + "\n" + this.MyProperty3);
            }
        }

        static void Main()
        {
            NextClass obj = new NextClass();
            obj.PrintInfo();
        }
    }
}