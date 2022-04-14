using System;
using System.Threading;

namespace Task_3
{
    class Program
    {
    //В методе Main создайте 10 потоков и запустите с разной задержкой....В методы, которые
    //будут выполняться в других потоках передайте какое-то текстовое сообщение и выведите
    //на экран.
        void chars()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine('s');
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(chars);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine('c');
            }
        }
    }
}
