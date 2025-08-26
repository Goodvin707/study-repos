/*Задание 2: Решить следующие задачи с использованием класса Stack:
1. Дан файл, в котором записан набор чисел. Переписать в другой файл все числа в обратном порядке.
2. Создать текстовый файл. Распечатать гласные буквы этого файла в обратном порядке.
3. Напечатать содержимое текстового файла t, выписывая литеры каждой его строки в обратном порядке.
4. Даны 2 строки s1 и s2. Из каждой можно читать по одному символу. Выяснить, является ли строка s2 обратной s1.
5. В текстовом файле записана без ошибок формула вида:
<формула> =<цифра>|M(<формула>,<формула>)|m(<формула>,<формула>)
<цифра>=0|1|2|3|4|5|6|7|8|9
M обозначает вычисление максимума, m – минимума
Вычислить значение этой формулы
Например M(m(3,5),M(1,2))=3
6.	В текстовом файле записана без ошибок формула вида:
<формула> =<цифра>|p(<формула>,<формула>)|m(<формула>,<формула>)
<цифра>=0|1|2|3|4|5|6|7|8|9
m (a, b) = (a-b) mod 10,
p (a, b) = (a+b) mod 10.
Вычислить значение этой формулы. Например, m (9, p (p (3, 5), m (3, 8))) = 6.
7.	Пусть символ # определен в текстовом редакторе как стирающий символ Backspace, т.е. строка abc#d##c в действительности является строкой ac.

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _16_2
{
    class Program
    {
        static int Max(int a, int b) => a > b ? a : b;
        static int Min(int a, int b) => a < b ? a : b;
        static int ChooseFunc(char m, int a, int b)
        {
            if (m == 'm')
                return Min(a, b);
            else
                return Max(a, b);
        }
        static int Func(Stack<char> stackM, Stack<int> stackNum)
        {
            if (stackM.Count == 1)
                return ChooseFunc(stackM.Pop(), stackNum.Pop(), stackNum.Pop());
            else
            {
                int a = (int)char.GetNumericValue(stackM.Pop());
                int b = (int)char.GetNumericValue(stackM.Pop());
                stackNum.Push(ChooseFunc(stackM.Pop(), a, b));
                return Func(stackM, stackNum);
            }
        }
        static void Main()
        {
            // 1. Дан файл, в котором записан набор чисел. Переписать в другой файл все числа в обратном порядке.
            StreamReader sr = new StreamReader("task1.txt");
            string s;
            s = sr.ReadLine();
            sr.Close();
            string[] numbers = s.Split(" ");
            string sRev = "";
            for (int i = numbers.Length - 1; i >= 0; i--)
                sRev += numbers[i] + " ";
            StreamWriter sw = new StreamWriter("result1.txt");
            sw.WriteLine(sRev);
            sw.Close();
            Console.WriteLine("1. В файле");


            // 2. Создать текстовый файл. Распечатать гласные буквы этого файла в обратном порядке.
            sr = new StreamReader("task2.txt");
            s = sr.ReadLine();
            string vowels = "";
            while (s != null)
            {
                s = s.ToUpper();
                for (int i = 0; i < s.Length; i++)
                    if (s[i] == 'А' || s[i] == 'У' || s[i] == 'Е' || s[i] == 'Ы' || s[i] == 'О' || s[i] == 'Э' || s[i] == 'Я' || s[i] == 'И' || s[i] == 'Ю')
                        vowels += s[i];
                s = sr.ReadLine();
            }
            sr.Close();
            vowels = new string(vowels.Reverse().ToArray());
            Console.WriteLine("2. Result: " + vowels);


            // 3. Напечатать содержимое текстового файла t, выписывая литеры каждой его строки в обратном порядке.
            sr = new StreamReader("t.txt");
            Console.WriteLine("\n3.");
            s = sr.ReadLine();
            while (s != null)
            {
                s = new string(s.Reverse().ToArray());
                Console.WriteLine(s);
                s = sr.ReadLine();
            }
            sr.Close();


            // 4. Даны 2 строки s1 и s2. Из каждой можно читать по одному символу. Выяснить, является ли строка s2 обратной s1.
            Console.WriteLine("\n4. Введите две строки");
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            Console.WriteLine(s1 == new string(s2.Reverse().ToArray()) ? "Строка s2 является обратной строке s1" : "Строка s2 не является обратной строке s1");

            /*5. В текстовом файле записана без ошибок формула вида:
<формула> =<цифра>|M(<формула>,<формула>)|m(<формула>,<формула>)
<цифра>=0|1|2|3|4|5|6|7|8|9
M обозначает вычисление максимума, m – минимума
Вычислить значение этой формулы
Например M(m(3,5),M(1,2))=3*/
            string exp = "M(m(3,5),M(1,2))=3";
            Stack<char> stackM = new Stack<char>();
            Stack<int> stackNum = new Stack<int>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == 'm' || exp[i] == 'M' || char.IsDigit(exp[i]))
                {
                    stackM.Push(exp[i]);
                }
                if (exp[i] == '=') break;
            }
            Console.WriteLine("6. " + Func(stackM, stackNum));

            /*6. В текстовом файле записана без ошибок формула вида:
<формула> =<цифра>|p(<формула>,<формула>)|m(<формула>,<формула>)
<цифра>=0|1|2|3|4|5|6|7|8|9
m (a, b) = (a-b) mod 10,
p (a, b) = (a+b) mod 10.
Вычислить значение этой формулы. Например, m (9, p (p (3, 5), m (3, 8))) = 6.*/
            string expr = "m (9, p (p (3, 5), m (3, 8)))";
            expr = Regex.Replace(expr, @"\s+", "");
            Regex m = new Regex(@"m\((-?\d+),(-?\d+)\)");
            Regex p = new Regex(@"p\((-?\d+),(-?\d+)\)");
            while (m.IsMatch(expr) || p.IsMatch(expr))
            {
                expr = m.Replace(expr, (Match m1) => ((int.Parse(m1.Groups[1].Value) - int.Parse(m1.Groups[2].Value)) % 10).ToString());
                expr = p.Replace(expr, (Match m1) => ((int.Parse(m1.Groups[1].Value) + int.Parse(m1.Groups[2].Value)) % 10).ToString());
            }
            Console.WriteLine("7. " + expr);

            // 7. Пусть символ # определен в текстовом редакторе как стирающий символ Backspace, т.е. строка abc#d##c в действительности является строкой ac.
            string st = "abc#d##c";
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i] == '#')
                {
                    st = st.Remove(i - 1, 2);
                    i -= 2;
                }
            }
            Console.WriteLine("7. " + st);
        }
    }
}
