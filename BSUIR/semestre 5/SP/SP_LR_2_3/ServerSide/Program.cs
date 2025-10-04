using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSide
{
    class Server
    {
        static Semaphore sem = new Semaphore(2, 2);
        public Server() { }
        public void ServerIPX()
        {
            NamedPipeServerStream sps = new NamedPipeServerStream("char", PipeDirection.InOut, 3);

            sps.WaitForConnection();
            sem.WaitOne();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nКо мне подключился клиент. Мой поток: " + Thread.CurrentThread.ManagedThreadId);
            Console.ForegroundColor = ConsoleColor.Yellow;

            StreamWriter sw = new StreamWriter(sps);
            StreamReader sr = new StreamReader(sps);
            sw.AutoFlush = true;
            
            while(true)
            {
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine("Выберите пункт меню");
                Console.WriteLine("1. Отправить на клиент строку\n2. Отключить клиента\n");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.Write("\nВведите строку, которая будет отправлена на клиент: ");
                        sw.WriteLine(Console.ReadLine());
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("\n" + sem.Release());
                        break;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Server objServ = new Server();
            Thread[] mas = new Thread[3];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = new Thread(objServ.ServerIPX);
                mas[i].Start();
                Console.WriteLine("Запущен сервер в потоке: " + mas[i].ManagedThreadId);
            }
        }
    }
}