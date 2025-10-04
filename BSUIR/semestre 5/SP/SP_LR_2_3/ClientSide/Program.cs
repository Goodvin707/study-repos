using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Pipes;
using System.IO;
using System.Diagnostics;

namespace ClientSide
{
    class Worker
    {
        public Worker() { }
        public void Client()
        {
            NamedPipeClientStream clp = new NamedPipeClientStream(".", "char", PipeDirection.InOut);
            clp.Connect();
            StreamWriter sw = new StreamWriter(clp);
            StreamReader sr = new StreamReader(clp);
            sw.AutoFlush = true;
            sw.WriteLine($"Клиент с процессом: {Process.GetCurrentProcess().Id}");

            while (true)
            {
                string s = sr.ReadLine();
                Console.WriteLine(s);
                Console.Write("Введите строку, которая будет отправлена на сервер: ");
                sw.WriteLine(Console.ReadLine());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Worker objWorker = new Worker();
            Thread objTrh = new Thread(objWorker.Client);
            objTrh.Start();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Запущен клиент с процессом: {Process.GetCurrentProcess().Id}");
        }
    }
}