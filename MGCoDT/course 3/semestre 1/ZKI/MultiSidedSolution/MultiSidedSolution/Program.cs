using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            string alfabetUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            int n = 6, m = 11;
            string s = "ОЕОЕНЫТНБТЕЛОНЛ__ОРОЕТС_ОГМАУБЙОЫКЩЫ__,ОЕ_НД_ЙСБЕАВ_ТЕ_Р_ПВСБАКРУЦ";
            string firstKey = "Соната";
            string itog = "";
            s = s.ToUpper().Replace(" ", "");
            firstKey = firstKey.ToUpper().Replace(" ", "");
            char[,] table = new char[n, m];
            int gind = 0;
            for (int i = 0; i < m; i++) // строки
            {
                for (int j = 0; j < n; j++) // столбцы
                {
                    table[j, i] = s[gind];
                    if (gind == s.Length - 1)
                        break;
                    gind++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(($"{table[i, j]} "));
                    itog += table[i, j];
                }
                Console.WriteLine();
            }

            string tabtxt = "";
            for (int i = 0; i < itog.Length; i++)
            {
                if (i != 0 && i % 5 == 0)
                    tabtxt += " ";
                tabtxt += itog[i];
            }
            Console.WriteLine(tabtxt);
            Console.WriteLine();

            int[] arr = new int[n];
            gind = 0;
            for (int i = 0; i < alfabetUp.Length; i++)
            {
                for (int j = 0; j < firstKey.Length; j++)
                {
                    if (alfabetUp[i] == firstKey[j])
                    {
                        arr[j] = gind;
                        if (gind == arr.Length - 1)
                            break;
                        gind++;
                    }
                }
            }
            itog = "";
            char[,] newTable = new char[n, m];
            for (int i = 0; i < n; i++)
            {
                Console.Write(firstKey[i] + " " + arr[i] + "| " + i + " |");
                for (int j = 0; j < m; j++)
                    Console.Write(($"{table[i, j]} "));
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < arr.Length; k++)
                    {
                        if (i == arr[k])
                            newTable[k, j] = table[i, j];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(firstKey[i] + " " + arr[i] + "| " + i + " |");
                for (int j = 0; j < m; j++)
                {
                    Console.Write(($"{newTable[i, j]} "));
                    itog += newTable[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n" + itog);
        }
    }
}