/*Задание 4: В абстрактном классе Absolut объявить метод Find. В качестве параметров методу Find передается массив объектов типа класса Basovi и количество объектов. Метод Find определяет, находится ли среди объектов машина заданного года выпуска. Если такой объект имеется, то выводится марка автомобиля и порядковый номер объекта. Иначе выводится сообщение, что такой машины нет.
В классе Basovi имеется поле Parking для хранения наименования автопарка. Для работы с этим полем использовать свойство. Класс Basovi наследует класс Absolut. Объявить интерфейс Intface. Элементом интерфейса является метод RdAvto, которому в качестве параметров передается массив ссылок типа класса Basovi и количество объектов (объекты типа Basovi или Avto).
Количество объектов и ввод данных в массив объектов реализовать в методе RdAvto.
Класс Avto наследует класс Basovi и интерфейс Intface.
Элементом класса Avto является поле God, задающее год выпуска автомобиля. Для работы с полем God, использовать методы. Созданный массив объектов записать в бинарный файл.
В головном модуле в цикле for реализовать вызов соответствующих методов для ввода данных в массив объектов, поиска заданной в массиве объектов, завершение выполнения программы.*/

using System;
using System.IO;

namespace Praktice_Day_8
{
    interface Interface
    {
        public void RdAvto(ref Avto[] avtos, int n);
    }
    abstract class Absolut
    {
        public void Find(Avto[] avtos, int n)
        {
            for (int i = 0; i < avtos.Length; i++)
            {
                if (avtos[i].God == 2006)
                    Console.WriteLine(avtos[i].Parking);
            }
        }
    }
    class Basovi : Absolut
    {
        string parking = "A100";
        public string Parking
        {
            get { return this.parking; }
        }
    }
    class Avto : Basovi, Interface
    {
        int god;
        public Avto(int god)
        {
            this.god = god;
        }
        public Avto() { this.god = -1; }
        public void RdAvto(ref Avto[] avtos, int n)
        {
            Random rd = new Random();
            avtos = new Avto[n];
            for (int i = 0; i < avtos.Length; i++)
                avtos[i] = new Avto(rd.Next(2000, 2021));
            FileStream fs = new FileStream("abc.bin", FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs, System.Text.Encoding.Default);
            for (int i = 0; i < avtos.Length; i++)
                writer.Write(avtos[i].God);
        }
        public int God { get { return this.god; } set { this.god = value; } }
    }
    class Program
    {
        static void Main()
        {
            Avto[] mass = null;
            Avto avto = new Avto();
            avto.RdAvto(ref mass, 5);
            Basovi basovi = new Basovi();
            basovi.Find(mass, 5);
        }
    }
}
