using System;
using System.Threading;

namespace Thread_Step_1
{
    class Program
    {
        static void WriteString(object _Data)
        {
            string str_for_out = (string)_Data;
            for (int i = 0; i <= 1000; i++)
                Console.Write(str_for_out);
        }

        static void Main()
        {
            Thread th_1 = new Thread(WriteString);
            Thread th_2 = new Thread(WriteString);
            Thread th_3 = new Thread(WriteString);
            Thread th_4 = new Thread(WriteString);

            th_1.Priority = ThreadPriority.Highest;
            th_2.Priority = ThreadPriority.BelowNormal;
            th_3.Priority = ThreadPriority.Normal;
            th_4.Priority = ThreadPriority.Lowest;

            th_1.Start("1");
            th_2.Start("2");
            th_3.Start("3");
            th_4.Start("4");
            Console.WriteLine("\nВсе потоки запущены ");

            th_1.Join();
            th_2.Join();
            th_3.Join();
            th_4.Join();
            Console.ReadKey();
        }
    }
}