// Задание 4: Государство. Название; столица; численность населения; государственный язык; занимаемая площадь, денежная единица, форма правления (монархия, республика и т.д.), фамилия президента. Выбор государства по денежной единицы, занимаемой площади (> заданного значения).
// Форму правления реализовать с помощью перечисления.
using System;
using System.Net.Http.Headers;

namespace MultiSidedSolution
{
    enum FormOfGovernment
    {
        MONARCHY = 0,
        REPUBLIC
    }
    class Government
    {
        string title;
        string capital;
        int peopleCount;
        string language;
        double areaSquare;
        string currency;
        FormOfGovernment fg;
        string presidenrSurname;

        public Government() {}

        public Government(
            string title,
            string capital,
            int peopleCount,
            string language,
            double areaSquare,
            string currency,
            FormOfGovernment fg,
            string presidenrSurname)
        {
            this.title = title;
            this.capital = capital;
            this.peopleCount = peopleCount;
            this.language = language;
            this.areaSquare = areaSquare;
            this.currency = currency;
            this.fg = fg;
            this.presidenrSurname = presidenrSurname;
        }

        public string Currency { get => currency; set => currency = value; }
        public double AreaSquare { get => areaSquare; set => areaSquare = value; }
        public string Title { get => title; set => title = value; }

        public override string ToString()
        {
            return $"{this.title}; {this.currency}; {this.areaSquare} km^2";
        }
    }


    class Program
    {
        static void Main()
        {
            Government[] governments = new Government[10];
            for (int i = 0; i < governments.Length; i++)
            {
                governments[i] = new Government();
                governments[i].Title = i % 2 == 0 ? "Russia" : "USA";
                governments[i].Currency = i % 2 == 0 ? "RUB" : "USD";
                governments[i].AreaSquare = i % 2 == 0 ? 1.2 : 100;
            }

            string val = "RUB";
            for (int i = 0;i < governments.Length; i++)
            {
                if (governments[i].Currency == val)
                {
                    Console.WriteLine(governments[i].ToString());
                }
            }

            double v = 100;
            for (int i = 0; i < governments.Length; i++)
            {
                if (governments[i].AreaSquare == v)
                {
                    Console.WriteLine(governments[i].ToString());
                }
            }
        }
    }
}