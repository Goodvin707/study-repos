/*Задание 1: Смоделировать структуру предприятия:
Классы	Свойства и методы
Фирма	название (get, set)
Отдел	название (get, set)
количество сотрудников (get, set)
Сотрудник	фио (get, set)
должность (get, set)
оклад (get, set)
рассчитать зарплату()
Штатный сотрудник	премия (get, set)
рассчитать зарплату()
Сотрудник по контракту	
рассчитать зарплату()

Обработать все Exception с помощью блока try…catch(Exception …) в методе «рассчитать зарплату» классов Штатный сотрудник и Сотрудник по контракту. При возникновении Exception выводить на экран сообщение об ошибке.
Описать собственный класс Exception PremiyaException. В методе «рассчитать зарплату» класса Штатный сотрудник выбрасывать собственное Exception типа PremiyaException при отрицательном значении свойства Премия. В этом же методе обработать PremiyaException в блоке catch. При возникновении Exception выводить сообщение об ошибке на экран.
В основной программе проверить работу блока обработки Exception метода «рассчитать зарплату».
Описать собственный класс Exception OkladException. В конструкторе реализовать проверку значения оклада, при отрицательном значении выбрасывать собственное Exception типа OkladException. Обработать Exception OkladException с помощью блока try…catch, в блоке обработки Exception вывести на экран сообщение «Невозможно создать сотрудника – указан отрицательный оклад: <оклад> » и повторно создать Exception.
В основной программе (main) обработать вызов конструктора класса Сотрудник и проверить работу обработчика Exception.*/

using System;

namespace MultiSidedSolution
{
    class Firm
    {
        string title;

        public Firm(string title)
        {
            this.title = title;
        }
    }
    class Department
    {
        string title;
        int employeCount;

        public Department(string title, int employeCount)
        {
            this.title = title;
            this.employeCount = employeCount;
        }
    }
    class Employee
    {
        protected string fio;
        protected string position;
        protected double salary;

        public Employee(string fio, string position, double salary)
        {
            this.fio = fio;
            this.position = position;
            this.salary = salary;
            try
            {
                if (salary < 0)
                    throw new OkladException($"[Невозможно создать сотрудника – указан отрицательный оклад: {salary}]");
            }
            catch (OkladException oe) { Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine(oe.Message); Console.ResetColor(); }
        }
        public virtual double CalculateSalary(int monthLen)
        {
            Random r = new Random();
            try { return Math.Round((salary / monthLen) * r.Next(15, monthLen - 8 + 1), 2); }
            catch (Exception) { Console.Write("[Произошла ошибка]"); }
            return 0;
            /*
             * ЗПП = О / КМ х РД
             * ЗПП — заработная плата к получению;
             * О — оклад или тарифная ставка;
             * КМ — длительность календарного месяца (28,29,30 или 31 день);
             * РД — количество отработанных рабочих дней в календарном месяце;
             */
        }
        public override string ToString() => $"{fio}   \t{position}   \t${salary}";
    }
    class StaffMember : Employee
    {
        double award;
        public StaffMember(string fio, string position, double salary, double award) : base(fio, position, salary)
        {
            this.award = award;
        }
        public override double CalculateSalary(int monthLen)
        {
            try
            {
                if (award < 0)
                    throw new PremiyaException("[Премия меньше нуля]");
                return Math.Round(base.CalculateSalary(monthLen) + award, 2);
            }
            catch (PremiyaException pe) { Console.ForegroundColor = ConsoleColor.Magenta; Console.Write(pe.Message); Console.ResetColor(); }
            return 0;
        }

        public override string ToString() => $"{fio}   \t{position}   \t{salary}    \t{award}";
    }
    class ContractEmployee : Employee
    {
        public ContractEmployee(string fio, string position, double salary) : base(fio, position, salary) { }
    }

    class PremiyaException : Exception
    {
        public PremiyaException(string message) : base(message) { }
    }
    class OkladException : Exception
    {
        public OkladException(string message) : base(message) { }
    }
    class Program
    {
        static string StrGenerator(int x)
        {
            Random r = new Random();
            string s = "";
            for (int i = 0; i < x; i++)
                s += (char)r.Next(65, 81);
            return s;
        }
        static void Main()
        {
            Random r = new Random();
            int monthLen = r.Next(28, 32);

            Employee[] empoloyes = new Employee[50];
            for (int i = 0; i < empoloyes.Length / 2; i++)
                empoloyes[i] = new StaffMember(StrGenerator(r.Next(5, 11)), StrGenerator(r.Next(5, 11)), Math.Round(r.Next(-1000, 9001) + r.NextDouble(), 2), Math.Round(r.Next(-1000, 5001) + r.NextDouble(), 2));
            for (int i = empoloyes.Length / 2; i < empoloyes.Length; i++)
                empoloyes[i] = new ContractEmployee(StrGenerator(r.Next(5, 11)), StrGenerator(r.Next(5, 11)), Math.Round(r.Next(-1000, 9001) + r.NextDouble(), 2));
            for (int i = 0; i < empoloyes.Length; i++)
            {
                Console.Write(empoloyes[i].ToString() + "  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" $" + empoloyes[i].CalculateSalary(monthLen));
                Console.ResetColor();
            }
        }
    }
}
