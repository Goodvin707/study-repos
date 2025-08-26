/*Задание 1: 
1. Во всех задачах данного раздела подразумевается, что исходная информация хранится в текстовом файле input.txt, каждая строка которого содержит полную информацию о некотором объекте, результирующая информация должна быть записана в файл output.txt.
2. Для хранения данных внутри программы организовать массив структур.
3. В типе структура реализуется метод CompareTo интерфейса IComparable, перегружается метод ToString базового класса object и необходимые операции отношения, поля данных и дополнительные методы продумайте самостоятельно.
4. На основе данных входного файла составить список студентов группы, включив следующие данные: ФИО, год рождения, домашний адрес, какую школу окончил. Вывести в новый файл информацию о студентах, окончивших заданную школу, отсортировав их по году рождения.*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _16_1
{
    struct Student : IComparable<Student>
    {
        public string fio;
        public int birthYear;
        public string adress;
        public string school;
        public Student(string fio, int birthYear, string adress, string school)
        {
            this.fio = fio;
            this.birthYear = birthYear;
            this.adress = adress;
            this.school = school;
        }
        public int CompareTo(Student s) => this.birthYear.CompareTo(s.birthYear);
        public override string ToString() => $"{fio}, {birthYear}, {adress}, {school}";
    }
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            StreamReader sr = new StreamReader("input.txt");
            string s;
            s = sr.ReadLine();
            while (s != null)
            {
                string[] words = s.Split(", ");
                students.Add(new Student(words[0], Convert.ToInt32(words[1]), words[2], words[3]));
                Console.WriteLine(students[^1].ToString());
                s = sr.ReadLine();
            }
            sr.Close();

            List<Student> studentsBySchool = new List<Student>();
            Console.Write("\nВведите номер школы: ");
            string findSchool = Console.ReadLine();
            for (int i = 0; i < students.Count; i++)
                if (findSchool == students[i].school)
                    studentsBySchool.Add(students[i]);

            studentsBySchool.Sort();
            for (int i = 0; i < studentsBySchool.Count; i++)
                Console.WriteLine(studentsBySchool[i].ToString());

            StreamWriter sw = new StreamWriter("output.txt");
            for (int i = 0; i < studentsBySchool.Count; i++)
                sw.WriteLine(studentsBySchool[i].ToString());
            sw.Close();
        }
    }
}
