// Задание 2: Исходный текст набран с ошибками: Выражения, заключенные в скобки имеют один или более пробелов вначале и в конце (или нет). Вывести исходный текст, убрав в нем пробелы после открывающейся скобки, а также перед закрывающейся скобкой. В исходном тексте может быть много выражений заключенных в скобки.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            string s = "(Надо (  понять (нет)   ) где лишние пробелы )) ) )";
            Console.WriteLine(s);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    if (s[i + 1] == ' ')
                    {
                        s = s.Remove(i + 1, 1);
                        i--;
                    }
                }
            }
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')')
                {
                    if (s[i - 1] == ' ')
                        s = s.Remove(i - 1, 1);
                }
            }
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}