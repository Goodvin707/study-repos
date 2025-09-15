/*Задание 1: Создать класс Tree – дерево, содержащий:
• Закрытое поле id - идентификатор;
• Закрытое поле height - высота;
• Закрытое поле age - возраст;
• Конструктор, с тремя параметрами, присваивающий значения этим полям;
• Свойства для чтения всех полей;
• Метод ToStr, формирующий строку значений полей объекта с комментариями.

Создать класс Forest – лес, содержащий:
• Закрытое поле Tree [] а - массив из нескольких деревьев, объектов класса Tree;
• Конструктор, с одним параметром n. Параметр n- количество деревьев в лесу. Конструктор создает пустой массив Tree [] а на n деревьев.
• Метод Zap – с одним параметром. Получает в качестве параметра дерево и размещает его в свободную ячейку массива а. Дерево помещается в массив, если свободное место есть. Метод возвращает значение true, если дерево в лесу и false, если нет;
• Метод Max (входной параметр высота) – определяющий, самое старое дерево данной высоты.
• Метод ToStr, формирующий строку содержащую список деревьев леса с комментариями.

В методе Main:
• Создать массив из пяти деревьев (объектов класса Tree со случайными высотой и возрастом и идентификаторами: id-0, id -1, …). Высота деревьев 20-21 метр;
• Вывести информацию о каждом дереве с помощью метода ToStr;
• Создать объект класса Forest со случайным количеством деревьев (от 2 до 6);
• С помощью метода Zap выполнить заполнение леса деревьями. Если дерево не в лесу, то вывести его идентификатор.
• С помощью метода ToStr для леса вывести список деревьев леса.
• Ввести с клавиатуры высоту дерева.
• С помощью метода Max определить, самое старое дерево данной высоты.
*/
using System;

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
            Tree[] a;
            public Forest(int n)
            {
                a = new Tree[n];
            }
            public bool Zap(Tree tree)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == null)
                    {
                        a[i] = tree;
                        return true;
                    }
                }
                return false;
            }
            public void Max(int h)
            {
                int max = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i].Height == h)
                    {
                        if (a[i].Age > max)
                            max = a[i].Age;
                    }
                }
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i].Age == max)
                        Console.WriteLine(a[i].ToStr());
                }
            }
            public string ToStr()
            {
                string s = "";
                for (int i = 0; i < a.Length; i++)
                    s += $"ID: {a[i].Id}  Высота: {a[i].Height}  Возраст: {a[i].Age}\n";
                return s;
            }
        }
        static void Main()
        {
            Random r = new Random();
            Forest f = new Forest(5);
            for (int i = 0; i < 6; i++)
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