// Задание 2: В текстовом файле содержатся длины сторон 20 прямоугольных параллелепипедов. Вычислить объемы этих параллелепипедов. Результаты расчета записать в файл в виде таблицы, содержащей колонки: длина первой стороны параллелепипеда, длина второй стороны параллелепипеда, длина третьей стороны параллелепипеда, объем параллелепипеда. Позаботьтесь о соответствующих заголовках для колонок. Файл с исходными данными сформируйте при помощи текстового редактора.

using System;
using System.IO;

namespace _18_2
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadLine();
            string result = "";
            result += "|   Сторона A   |   Сторона B   |   Сторона C   |     Объем     |\n";
            while (s != null)
            {
                string[] sarr = s.Split("; ");
                result += $"|{sarr[0]}\t\t|{sarr[1]}\t\t|{sarr[2]}\t\t|{Math.Round(Convert.ToDouble(sarr[0]) * Convert.ToDouble(sarr[1]) * Convert.ToDouble(sarr[2]), 1)}\t|\n";
                s = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(result);
            sw.Close();
        }
    }
}
