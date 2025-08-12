using System;

namespace MultySidedSolution
{
    abstract class Figure
    {
        public abstract String Name { get; }
    }

    class O : Figure
    {
        String name = "O";
        public override String Name { get { return name; } }
    }
    class I : Figure
    {
        String name = "T";
        public override String Name { get { return name; } }
    }
    class S : Figure
    {
        String name = "S";
        public override String Name { get { return name; } }
    }
    class Z : Figure
    {
        String name = "Z";
        public override String Name { get { return name; } }
    }
    class L : Figure
    {
        String name = "L";
        public override String Name { get { return name; } }
    }
    class J : Figure
    {
        String name = "J";
        public override String Name { get { return name; } }
    }
    class T : Figure
    {
        String name = "T";
        public override String Name { get { return name; } }
    }
    abstract class FigureCreator
    {
        public abstract Figure FactoryMethod();
    }

    class OCreator : FigureCreator
    {
        public override Figure FactoryMethod()
        {
            return new O();
        }
    }

    class ICreator : FigureCreator
    {
        public override Figure FactoryMethod()
        {
            return new I();
        }
    }
    class SCreator : FigureCreator
    {
        public override Figure FactoryMethod()
        {
            return new S();
        }
    }
    class ZCreator : FigureCreator
    {
        public override Figure FactoryMethod()
        {
            return new Z();
        }
    }
    class LCreator : FigureCreator
    {
        public override Figure FactoryMethod()
        {
            return new L();
        }
    }
    class JCreator : FigureCreator
    {
        public override Figure FactoryMethod()
        {
            return new J();
        }
    }
    class TCreator : FigureCreator
    {
        public override Figure FactoryMethod()
        {
            return new T();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            FigureCreator[] creators = {
                new OCreator(),
                new ICreator(),
                new SCreator(),
                new ZCreator(),
                new LCreator(),
                new JCreator(),
                new TCreator()
            };
            Console.WriteLine("[10 Рандомных фигур]");
            for (int i = 0; i < 9; i++)
            {
                var figure = creators[rand.Next(0, creators.Length)].FactoryMethod();
                Console.WriteLine(figure.Name);
            }
            Console.ReadKey();
        }
    }
}