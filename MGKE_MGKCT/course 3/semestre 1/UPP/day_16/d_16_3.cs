// Задание 3: Дан XML-документ с двухуровневой вложенностью. Вывести дочерние элементы, которые встречаются в каждом родительском элементе. Вывести родительские элементы, удовлетворяющие полученному списку, их количество и общее количество родительских элементов в XML-документе.

using System;
using System.Linq;

namespace _16_3
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var doc = System.Xml.Linq.XDocument.Parse(@"<?xml version=_1.0_?>
<users>
  <user>
    <fio>Иванов Иван Иванович</fio>
    <adress>Москва</adress>
    <tell>747</tell>
  </user>
  <user>
    <fio>Харитонов Фёдор Викторович</fio>
    <adress>Саратов</adress>
    <tell>8891</tell>
  </user>
</users>".Replace('_', '"'));
            var dests = doc.Element("users").Descendants("user").ToList();
            for (int i = 0; i < dests.Count; i++)
            {
                var items = dests[i].Elements().ToList();
                for (int j = 0; j < items.Count; j++)
                    Console.WriteLine(items[j]);
                Console.WriteLine("Elentents Count: " + items.Count + "\n");
            }
            var destscount = doc.Element("users").Descendants("user").Count();
            Console.WriteLine("Parents Count: " + destscount);
        }
    }
}
