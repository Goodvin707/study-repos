// Задание 3: В текстовом файле содержатся длины сторон 15 прямоугольников. Вычислить периметры и площади этих прямоугольников. Результаты расчета записать в файл в виде таблицы, содержащей колонки: длина первой стороны прямоугольника, длина второй стороны прямоугольника, периметр прямоугольника, площадь прямоугольника. Позаботьтесь о соответствующих заголовках для колонок. Файл с исходными данными сформируйте при помощи текстового редактора.

using System;
using System.IO;

namespace _18_3
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadLine();
            string result = "";
            result += "|   Сторона A   |   Сторона B   |    Периметр   |    Площадь    |\n";
            while (s != null)
            {
                string[] sarr = s.Split("; ");
                result += $"|{sarr[0]}\t\t|{sarr[1]}\t\t|{Math.Round((Convert.ToDouble(sarr[0]) + Convert.ToDouble(sarr[1])) * 2, 1)}\t\t|{Math.Round((Convert.ToDouble(sarr[0]) * Convert.ToDouble(sarr[1])), 1)}   \t|\n";
                s = sr.ReadLine();
            }
            sr.Close();

            StreamWriter sw = new StreamWriter("output.txt");
            sw.WriteLine(result);
            sw.Close();
        }
    }
}
