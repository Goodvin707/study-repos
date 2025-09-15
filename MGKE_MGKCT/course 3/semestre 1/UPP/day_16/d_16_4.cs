/*Задание 4: Дан XML-документ с двухуровневой вложенностью. У элемента "Пользователь” присутствует атрибут имя и следующие элементы: "Компания", "Пол", "Возраст", "Должность". Вывести информацию по следующим запросам:
• Вывести всех мужчин/женщин, возраст которых больше введенного значения;
• Вывести всех мужчин/женщин указанной должности.*/

using System;
using System.Xml;
using System.Collections.Generic;
namespace _16_4
{
    class User
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string JobTitle { get; set; }
        public override string ToString() => $"{Name} {Company} {Gender} {Age} {JobTitle}";
    }
    class Program
    {
        static void Main()
        {
            List<User> users = new List<User>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Task.xml");
            var xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    User user = new User();
                    XmlNode? attr = xnode.Attributes.GetNamedItem("name");
                    user.Name = attr?.Value;

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "company")
                            user.Company = childnode.InnerText;
                        if (childnode.Name == "gender")
                            user.Gender = childnode.InnerText;
                        if (childnode.Name == "age")
                            user.Age = int.Parse(childnode.InnerText);
                        if (childnode.Name == "jobtitle")
                            user.JobTitle = childnode.InnerText;
                    }
                    users.Add(user);
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Выберите зарос");
            Console.WriteLine("1. Вывести всех мужчин/женщин, возраст которых больше введенного значения");
            Console.WriteLine("2. Вывести всех мужчин/женщин указанной должности");
            int menu = int.Parse(Console.ReadLine());
            switch (menu)
            {
                case 1:
                    Console.Write("Введите возраст: ");
                    int age = int.Parse(Console.ReadLine());
                    for (int i = 0; i < users.Count; i++)
                        if (users[i].Age > age)
                            Console.WriteLine(users[i].ToString());
                    break;
                case 2:
                    Console.Write("Укажите должность: ");
                    string jt = Console.ReadLine();
                    for (int i = 0; i < users.Count; i++)
                        if (users[i].JobTitle == jt)
                            Console.WriteLine(users[i].ToString());
                    break;
                default:
                    Console.WriteLine("Ну лан...");
                    break;
            }
        }
    }
}
