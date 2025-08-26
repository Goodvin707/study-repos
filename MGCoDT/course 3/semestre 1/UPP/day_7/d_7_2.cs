// Задание 2: Переделать предыдущую задачу своего варианта. Вместо массива объектов использовать коллекцию объектов.
// В коллекцию можно добавлять объекты без ограничений.
using System;
using System.Collections.Generic;

namespace PrakticeDay_7
{
    class Program
    {
        class Tree
        {
            int id;
            public int Id
            {
                get { return id; }
            }
            int height;
            public int Height
            {
                get { return height; }
            }
            int age;
            public int Age
            {
                get { return age; }
            }
            public Tree(int id, int height, int age)
            {
                this.id = id;
                this.height = height;
                this.age = age;
            }
            public string ToStr()
            {
                return $"ID: {id}  Высота: {height}  Возраст: {age}";
            }
        }
        class Forest
        {
            List<Tree> trees;
            public Forest()
            {
                trees = new List<Tree>();
            }
            public bool Zap(Tree tree)
            {
                if (!trees.Contains(tree))
                {
                    trees.Add(tree);
                    return true;
                }
                return false;
            }
            public void Max(int h)
            {
                int max = 0;
                for (int i = 0; i < trees.Count; i++)
                {
                    if (trees[i].Height == h)
                    {
                        if (trees[i].Age > max)
                            max = trees[i].Age;
                    }
                }
                for (int i = 0; i < trees.Count; i++)
                {
                    if (trees[i].Age == max)
                        Console.WriteLine(trees[i].ToStr());
                }
            }
            public string ToStr()
            {
                string s = "";
                for (int i = 0; i < trees.Count; i++)
                    s += $"ID: {trees[i].Id}  Высота: {trees[i].Height}  Возраст: {trees[i].Age}\n";
                return s;
            }
        }
        static void Main()
        {
            Random r = new Random();
            Forest f = new Forest();
            for (int i = 0; i < 10; i++)
            {
                Tree tree = new Tree(i, r.Next(20, 52), r.Next(50, 500));
                if (!f.Zap(tree))
                    Console.WriteLine(tree.Id);
            }
            Console.WriteLine(f.ToStr());
            int max = int.Parse(Console.ReadLine());
            f.Max(max);
        }
    }
}
