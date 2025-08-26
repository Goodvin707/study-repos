/*Задание 6: Разработать программу для базовой расстановки кораблей на поле для игры «Морской бой».
Предусмотреть 4 типа кораблей: однопалубный, двухпалубный, трехпалубный и четырехпалубный.
Корабли не должны соприкасаться между собой даже углами.
Для каждого корабля реализовать метод, определяющий, касается ли он другого (заданного) корабля на поле.
Реализовать следующие методы проверки: потоплен корабли или нет; подбит или нет.
Реализовать механизм наследования классов.*/
using System;
using System.Collections.Generic;
using System.Threading;

namespace PrakticeDay_7
{
    class Figure
    {
        class Ship
        {
            byte deck; // 1 - 4
            public byte Deck
            {
                get { return deck; }
                set { deck = value; }
            }
            bool location; // t - гор. f - верт.
            public bool Location
            {
                get { return location; }
                set { location = value; }
            }
            public Ship()
            {
                this.deck = 1;
                this.location = true;
            }
            public Ship(byte deck)
            {
                this.deck = deck;
            }
            public bool CheckForContact(bool[,] Forbiddenfield, int x, int y)
            {
                if (location == true) // Горизонтально
                {
                    while (y + deck > 10)
                        y--;
                    while (x >= 10)
                        x--;
                    for (int i = y; i < y + deck; i++)
                        if (Forbiddenfield[x, i] == false)
                            return false;

                }
                else // Вертикально
                {
                    while (x + deck > 10)
                        x--;
                    while (y >= 10)
                        y--;
                    for (int i = x; i < x + deck; i++)
                        if (Forbiddenfield[i, y] == false)
                            return false;
                }
                return true;
            }
        }
        static void Main()
        {
            Random r = new Random();
            bool[,] Forbiddenfield = new bool[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Forbiddenfield[i, j] = true;
            string[,] field = new string[10, 10];
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    field[i, j] = "~ ";
            Console.WriteLine();

            Ship[] ships = new Ship[10];
            ships[0] = new Ship(4);
            ships[1] = new Ship(3);
            ships[2] = new Ship(3);
            ships[3] = new Ship(2);
            ships[4] = new Ship(2);
            ships[5] = new Ship(2);
            ships[6] = new Ship(1);
            ships[7] = new Ship(1);
            ships[8] = new Ship(1);
            ships[9] = new Ship(1);
            for (int shipIt = 0; shipIt < ships.Length; shipIt++)
            {
            there:
                Console.Clear();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (field[i, j] == "[]")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(field[i, j]);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(field[i, j]);
                        }
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(200);
                Console.WriteLine("Расположение\n1. Горизонтально\n2. Вертикально");
                switch (r.Next(1, 3)) //int.Parse(Console.ReadLine()))
                {
                    case 1:
                        ships[shipIt].Location = true;
                        break;
                    case 2:
                        ships[shipIt].Location = false;
                        break;
                }
                Console.WriteLine("Куда ставим?");
                int x = r.Next(0, 10); //int.Parse(Console.ReadLine());
                int y = r.Next(0, 10); //int.Parse(Console.ReadLine());
                if (!ships[shipIt].CheckForContact(Forbiddenfield, x, y))
                    goto there;
                if (ships[shipIt].Deck == 1)
                {
                    field[x, y] = "[]";

                    Forbiddenfield[x, y] = false;

                    try
                    { Forbiddenfield[x + 1, y] = false; }
                    catch (IndexOutOfRangeException) { }
                    try
                    { Forbiddenfield[x - 1, y] = false; }
                    catch (IndexOutOfRangeException) { }
                    try
                    { Forbiddenfield[x, y + 1] = false; }
                    catch (IndexOutOfRangeException) { }
                    try
                    { Forbiddenfield[x, y - 1] = false; }
                    catch (IndexOutOfRangeException) { }
                    try
                    { Forbiddenfield[x + 1, y - 1] = false; }
                    catch (IndexOutOfRangeException) { }
                    try
                    { Forbiddenfield[x + 1, y + 1] = false; }
                    catch (IndexOutOfRangeException) { }
                    try
                    { Forbiddenfield[x - 1, y + 1] = false; }
                    catch (IndexOutOfRangeException) { }
                    try
                    { Forbiddenfield[x - 1, y - 1] = false; }
                    catch (IndexOutOfRangeException) { }
                }
                else
                {
                    if (ships[shipIt].Location == true) // Горизонтально
                    {
                        while (y + ships[shipIt].Deck > 10)
                            y--;
                        while (x >= 10)
                            x--;
                        for (int j = y; j < y + ships[shipIt].Deck; j++)
                        {
                            field[x, j] = "[]";
                            Forbiddenfield[x, j] = false;

                            try
                            {
                                Forbiddenfield[x + 1, j - 1] = false;
                                Forbiddenfield[x, j - 1] = false;
                                Forbiddenfield[x - 1, j - 1] = false;
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                Forbiddenfield[x + 1, j - 1] = false;
                                Forbiddenfield[x + 1, j] = false;
                                Forbiddenfield[x + 1, j + 1] = false;
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                Forbiddenfield[x + 1, j + 1] = false;
                                Forbiddenfield[x, j + 1] = false;
                                Forbiddenfield[x - 1, j + 1] = false;
                            }
                            catch (IndexOutOfRangeException) { }
                            try
                            {
                                Forbiddenfield[x - 1, j + 1] = false;
                                Forbiddenfield[x - 1, j] = false;
                                Forbiddenfield[x - 1, j - 1] = false;
                            }
                            catch (IndexOutOfRangeException) { }
                        }
                    }
                    else // Вертикально
                    {
                        while (x + ships[shipIt].Deck > 10)
                            x--;
                        while (y >= 10)
                            y--;
                        for (int i = x; i < x + ships[shipIt].Deck; i++)
                        {
                            field[i, y] = "[]";
                            Forbiddenfield[i, y] = false;
                            try
                            { Forbiddenfield[i + 1, y - 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i, y - 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i - 1, y - 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i + 1, y - 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i + 1, y] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i + 1, y + 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i + 1, y + 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i, y + 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i - 1, y + 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i - 1, y + 1] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i - 1, y] = false; }
                            catch (IndexOutOfRangeException) { }
                            try
                            { Forbiddenfield[i - 1, y - 1] = false; }
                            catch (IndexOutOfRangeException) { }
                        }
                    }
                }
            }
            bool[] Targets = new bool[20];
            for (int i = 0; i < 20; i++)
                Targets[i] = true;
            int x1;
            int y1;
            int ii = 0;
            do
            {
            МылоМачало:
                Console.Clear();
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (field[i, j] == "[]")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(field[i, j]);
                        }
                        if (field[i, j] == "~ ")
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(field[i, j]);
                        }
                        if (field[i, j] == "X ")
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(field[i, j]);
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Введите коррдинаты атаки");
                Console.Write("x: ");
                x1 = int.Parse(Console.ReadLine());
                Console.Write("y: ");
                y1 = int.Parse(Console.ReadLine());
                x1--; y1--;
                if (x1 < 0 || x1 > 10 || y1 < 0 || y1 > 10)
                    goto МылоМачало;
                if (field[x1, y1] == "[]")
                {
                    field[x1, y1] = "X ";
                    Targets[ii] = false;
                    ii++;
                }
            } while (Targets[Targets.Length - 1] != false);
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (field[i, j] == "[]")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(field[i, j]);
                    }
                    if (field[i, j] == "~ ")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(field[i, j]);
                    }
                    if (field[i, j] == "X ")
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(field[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("☺ Вы победили! ☻");
        }
    }
}