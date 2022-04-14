using System;
using System.Threading;
namespace Task_2
{
  //Создайте в первичном потоке вторичный поток, причем первичный должен ждать
  //окончание вторичного потока.Во вторичном потоке создайте и запустите третичный поток
  //и при этом, третичный поток должен быть фоновым.То есть вторичный не ждет окончания
  //работы третичного.
    class Program
    {
        static void Method()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + "-Второй");
                Thread.Sleep(1000);
            }
        }
        static void Method1()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine(i + "-Третий");
                Thread.Sleep(100);
                i++;
            }
        }
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Method);
            Thread first = new Thread(threadStart);
            Thread second = new Thread(Method1);
            first.Start();
            second.Start();
            second.IsBackground = true;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + "-Первый");
                Thread.Sleep(200);
            }
           
        }
    }
}
