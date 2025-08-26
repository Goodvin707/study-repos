/*Задание 2: Проект «Кинотеатр»
Классы: Viewer (Зритель), Cinema (КИНОТЕАТР), Security (Дежурный), Light (Cвет), Hardware (АППАРАТНАЯ) и Program (тестирующий).
В классе Program вводится количество мест в зале и название фильма.
Далее в цикле создаются объекты класса Viewer и для каждого из них вызывается метод PushViewer класса Cinema, который имитирует заполнение зала зрителями.
Когда зал окажется полностью заполненным, в классе Cinema генерируется событие NotPlaces (нет мест).
В классе Security событие NotPlaces обрабатывается (обработчик CloseZal). По завершении работы метода CloseZal генерируется событие SwitchOff (выключаем свет).
В классе Light событие SwitchOff обрабатывается (обработчик Turn) и возникает следующее событие Begin (начало фильма).
В классе Hardware событие Begin обрабатывается (обработчик FilmOn) выводится сообщение – "Начинается фильм".

Класс: Viewer(Зритель)
	Поле - номер зрителя
	Свойство для чтения поля
	Конструктор с параметром

Класс: Cinema(КИНОТЕАТР)
	Поле количество мест в зале.
	Конструктор –с параметром
	Метод PushViewer. В параметре метода очередной зритель (объект класса Viewer). В методе отображается процесс заполнения зала - выводится сообщение "Зритель <Номер зрителя> занял свое место" и, после того как последний зритель займет свое место, генерируется событие NotPlaces
	Класс: Security (Дежурный)
	Метод CloseZal() - обработчик события NotPlaces, выдает сообщение "Дежурный закрыл зал " и генерирует событие SwitchOff

Класс:Light(Свет).
	Метод Turn() - обработчик события SwitchOff, выводит сообщение "Выключаем свет!" и генерирует событие Begin.
	Класс:Hardware(АППАРАТНАЯ)
	Поле - название фильма
	Конструктор –с параметром
	Метод FilmOn() - обработчик события Begin выводит сообщение: "Начинается фильм <Название фильма>"*/

using System;
using System.Collections.Generic;

namespace Praktice_Day_5
{
    class Program
    {
        class Viewer
        {
            string nomer;
            public string Nomer
            {
                get { return nomer; }
            }
            public Viewer(string nomer)
            {
                this.nomer = nomer;
            }
        }
        class Cinema
        {
            int AllPlaces;
            bool therePlaces;
            List<Viewer> vivs;
            public bool TherePlaces
            {
                get { return therePlaces; }
            }
            public Cinema(int AllPlaces)
            {
                this.AllPlaces = AllPlaces;
                vivs = new List<Viewer>();
                this.therePlaces = true;
            }
            public void PushViewer(Viewer viv)
            {
                Random r = new Random();
                if ((NotPlaces != null) && vivs.Count > AllPlaces - 1)
                {
                    NotPlaces();
                    therePlaces = false;
                }
                else
                {
                    vivs.Add(viv);
                    Console.ForegroundColor = System.ConsoleColor.Green;
                    Console.WriteLine($"Зритель {viv.Nomer} занял свое место");
                }
            }
            public delegate void NotPlacesEventHandler();
            public static event NotPlacesEventHandler NotPlaces;

        }
        class Security
        {
            public void CloseZal()
            {
                Console.ForegroundColor = System.ConsoleColor.Blue;
                Console.WriteLine("Дежурный закрыл зал");
                Cinema.NotPlaces -= this.CloseZal;
                SwitchOff();
            }
            public delegate void SwitchOffEventHandler();
            public static event SwitchOffEventHandler SwitchOff;
        }
        class Light
        {
            public void Turn()
            {
                Console.ForegroundColor = System.ConsoleColor.Blue;
                Console.WriteLine("Выключаем свет");
                Security.SwitchOff -= this.Turn;
                Begin();
            }
            public delegate void BeginEventHandler();
            public static event BeginEventHandler Begin;
        }
        class Hardware
        {
            string film;
            public Hardware(string film)
            {
                this.film = film;
            }
            public void FilmOn()
            {
                Console.ForegroundColor = System.ConsoleColor.Blue;
                Console.WriteLine("Начинается фильм: " + film);
                Light.Begin -= this.FilmOn;
            }
        }
        static void Main()
        {
            Console.ForegroundColor = System.ConsoleColor.White;
            Console.Write("Введите количество меств зале: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите название фильма: ");
            string s = Console.ReadLine();
            Cinema cin = new Cinema(n);
            Security sec = new Security();
            Light light = new Light();
            Hardware hardware = new Hardware(s);
            Cinema.NotPlaces += sec.CloseZal;
            Security.SwitchOff += light.Turn;
            Light.Begin += hardware.FilmOn;
            int i = 1;
            while (cin.TherePlaces)
            {
                Viewer manOrWoman = new Viewer("зритель " + i);
                cin.PushViewer(manOrWoman);
                i++;
            }
        }
    }
}
