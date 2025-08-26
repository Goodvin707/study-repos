/*Задание 5: Создать класс Figure для работы с геометрическими фигурами. В качестве полей класса задаются цвет фигуры, состояние «видимое/невидимое».
Реализовать операции: передвижение геометрической фигуры по горизонтали, по вертикали, изменение цвета, опрос состояния (видимый/невидимый). Метод вывода на экран должен выводить состояние всех полей объекта.
Создать класс Point (точка) как потомок геометрической фигуры. Создать класс Circle (окружность) как потомок точки. В класс Circle добавить метод, который вычисляет площадь окружности.
Создать класс Rectangle (прямоугольник) как потомок точки, реализовать метод вычисления площади прямоугольника.
Точка, окружность, прямоугольник должны поддерживать методы передвижения по горизонтали и вертикали, изменения цвета.
Подумать, какие методы можно объявить в интерфейсе, нужно ли объявлять абстрактный класс, какие методы и поля будут в абстрактном классе, какие методы будут виртуальными, какие перегруженными.*/
using System;
using System.Collections.Generic;

namespace PrakticeDay_7
{
    class Figure
    {
        protected string color;
        bool vis = false;
        protected List<List<char>> listY = new List<List<char>>();
        public bool Vis { get => vis; set => vis = value; }
        public void createFild(int x, int y)
        {

            for (int i = 0; i <= y; i++)
            {
                List<char> listX = new List<char>();
                for (int j = 0; j <= x; j++)
                    listX.Add(' ');
                listY.Add(listX);
            }
        }

        public int MoveYup(int pos)
        {

            List<char> listX = new List<char>();
            for (int j = 0; j < listY[0].Count; j++)
                listX.Add(' ');

            listY.Insert(0, listX);
            pos--;

            if (pos == 0) return 0;
            return MoveYup(pos);
        }
        public int MoveXup(int pos)
        {
            for (int i = 0; i < listY.Count - 1; i++)
                listY[i].Insert(0, ' ');
            pos--;
            if (pos == 0) return 0;
            return MoveXup(pos);
        }

        public int MoveYdown(int pos)
        {
            for (int i = 0; i < listY.Count - 1; i++)
            {
                if (listY[i][0] == '0')
                    return 0;
            }
            listY.RemoveAt(0);

            pos--;
            if (pos == 0) return 0;
            return MoveYdown(pos);
        }
        public int MoveXdown(int pos)
        {
            for (int i = 0; i < listY.Count - 1; i++)
            {
                if (listY[i][0] == '0')
                    return 0;
            }
            for (int i = 0; i < listY.Count - 1; i++)
                listY[i].RemoveAt(0);
            pos--;
            if (pos == 0) return 0;
            return MoveXdown(pos);
        }
        public void render()
        {
            for (int i = 0; i < listY.Count - 1; i++)
            {
                for (int j = 0; j < listY[i].Count - 1; j++)
                    Console.Write(listY[i][j]);
                Console.WriteLine();
            }
        }

        public void createColor()
        {
            Console.WriteLine("Выбрать цвет фигуры");
            Console.WriteLine("красный - 1");
            Console.WriteLine("зеленый - 2");
            Console.WriteLine("синий   - 3");
            int color = Convert.ToInt16(Console.ReadLine());
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    this.color = "красный";
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    this.color = "зеленый";
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    this.color = "синий";
                    break;
            }
        }
    }
    class Point : Figure
    {
        protected int x;
        protected int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        List<char> redact = new List<char>();
        protected void CreatePoint(int x, int y)
        {
            try
            {
                listY[y][x] = '0';
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
    }
    class Circle : Point
    {
        int R;
        public Circle(int R, int x, int y) : base(x, y)
        {
            this.R = R;
        }
        public double S()

        {
            return Math.PI * Math.Pow(R, 2);
        }
        public void createCircle()
        {
            if (x - R < 0)
            {
                for (int i = 0; i < R - x + 1 * 2; i++)
                {
                    MoveXup(1);
                }
            }
            if (y - R < 0)
            {
                for (int i = 0; i < R - y + 1; i++)
                    MoveYup(1);
            }
            this.x = x + (R - x);
            this.y = y + (R - y);

            CreatePoint(x - R, y);
            CreatePoint(x, y + R - 3);
            CreatePoint(x + R, y);
            CreatePoint(x, y - R + 3);
            CreatePoint(x - R + 1, y + R - 4);
            CreatePoint(x + R - 1, y + R - 4);
            CreatePoint(x - R + 1, y - R + 4);
            CreatePoint(x + R - 1, y - R + 4);
        }
    }

    class Ractangle : Point
    {
        int a, b;
        public Ractangle(int a, int b, int x, int y) : base(x, y)
        {
            this.a = a;
            this.b = b;
            this.x = x;
            this.y = y;
        }

        public void CreateRactangl()
        {

            if (x - b < 0)
            {
                for (int i = 0; i < b - x + 1; i++)
                {
                    MoveXup(1);
                }
            }
            if (y - a < 0)
            {
                for (int i = 0; i < a - y + 1; i++)
                {
                    MoveYup(1);
                }
            }
            this.x = x + (b - x);
            this.y = y + (a - y);
            int z = 0;
            do
            {
                CreatePoint(x + z, y);
                z++;
            } while (x + z <= x + a);

            int z2 = 0;
            do
            {
                CreatePoint(x, y + z2);
                z2++;
            } while (y + z2 <= y + b);

            int z3 = 0;
            do
            {
                CreatePoint(x + a, y + z3);
                z3++;
            } while (x + z3 <= x + a - (a - x));
            int z4 = 0;
            do
            {
                CreatePoint(x + z4, y + b);
                z4++;
            } while (x + z4 <= x + b + (a - x));
        }
    }

    class Program
    {

        static void Main()
        {
            int R = 0, x = 0, y = 0, a = 0, b = 0;
            Circle circle = new Circle(R, x, y);
            Ractangle ractangle = new Ractangle(a, b, x, y);

        мыломачало:
            Console.Clear();
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("|Создать круг          - 1|");
            Console.WriteLine("|Создать прямоугольник - 2|");
            Console.WriteLine("+-------------------------+");
            Console.Write("Действие: ");
            int f;
            try { f = Convert.ToInt16(Console.ReadLine()); }
            catch (Exception) { goto мыломачало; }
            try
            {
                switch (f)
                {
                    case 1:
                        Console.WriteLine("Введите радиус фигуры");
                        R = Convert.ToInt16(Console.ReadLine());
                        circle = new Circle(R, x, y);
                        circle.createFild(20, 20);
                        circle.Vis = true;
                        ractangle.Vis = false;
                        circle.createCircle();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Введите длинну");
                        a = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("Введите ширену");
                        b = Convert.ToInt16(Console.ReadLine());
                        /*  Console.WriteLine("Введите кординату Х");
                          x = Convert.ToInt16(Console.ReadLine());
                          Console.WriteLine("Введите кординату Y");
                          y = Convert.ToInt16(Console.ReadLine());*/

                        ractangle = new Ractangle(a - 1, b - 1, x, y);
                        ractangle.createFild(10, 10);
                        circle.Vis = false;
                        ractangle.Vis = true;
                        ractangle.CreateRactangl();
                        Console.Clear();
                        break;
                }
            }
            catch (Exception)
            {
                goto мыломачало;
            }
            do
            {
                Console.Clear();
                if (circle.Vis)
                    circle.render();
                if (ractangle.Vis)
                    ractangle.render();

                Console.WriteLine("+-------------------------+");
                Console.WriteLine("|Изменить цвет         - 1|");
                Console.WriteLine("|Создать новую фигру   - 2|");
                Console.WriteLine("|Переместить фигуру    - 3|");
                Console.WriteLine("+-------------------------+\n\n");
                Console.Write("Действие:");
                int task = 0;
                try { task = Convert.ToInt16(Console.ReadLine()); }
                catch (Exception) { goto мыломачало; }

                int task2;
                switch (task)
                {
                    case 1:
                        if (circle.Vis)
                            circle.createColor();
                        else ractangle.createColor();
                        Console.Clear();
                        break;
                    case 2:
                        goto мыломачало;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("+-----------------------------+");
                        Console.WriteLine("|Переместить фигуру вправо - 1|");
                        Console.WriteLine("|Переместить фигуру вверх  - 2|");
                        Console.WriteLine("|Переместить фигуру вниз   - 3|");
                        Console.WriteLine("|Переместить фигуру влево  - 4|");
                        Console.WriteLine("+-----------------------------+\n\n");
                        Console.Write("Действие:");

                        try { task2 = Convert.ToInt16(Console.ReadLine()); }
                        catch (Exception) { goto мыломачало; }
                        int pos;
                        switch (task2)
                        {
                            case 1:
                                pos = Convert.ToInt16(Console.ReadLine());
                                if (circle.Vis == true)
                                    circle.MoveXup(pos);
                                else ractangle.MoveXup(pos);
                                break;
                            case 2:
                                pos = Convert.ToInt16(Console.ReadLine());
                                if (circle.Vis == true)
                                    circle.MoveYdown(pos);
                                else ractangle.MoveYdown(pos);
                                break;
                            case 3:
                                pos = Convert.ToInt16(Console.ReadLine());
                                if (circle.Vis == true)
                                    circle.MoveYup(pos);
                                else ractangle.MoveYup(pos);
                                break;
                            case 4:
                                pos = Convert.ToInt16(Console.ReadLine());
                                if (circle.Vis == true)
                                    circle.MoveXdown(pos);
                                else ractangle.MoveXdown(pos);
                                break;
                        }
                        break;
                }
            } while (true);
        }
    }
}