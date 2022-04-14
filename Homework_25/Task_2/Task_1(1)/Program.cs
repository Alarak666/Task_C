using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Task_1_1_
{
    class Program
    {
        class Calcult
        {
            public int sum;
            public int Sumator(int a, int b)
            {
                sum = a + b;
                return sum;
            }
        }
        // Калькулятор
        static void Main(string[] args)
        {
            int a = 12;
            int b = 12;
            int sum;
            Calcult calcult = new Calcult();
            Task<int> task = new Task<int>(()=> calcult.Sumator(a,b));
            task.Start();
            Console.WriteLine(sum = task.Result);
            Console.ReadKey();
        }
    }
}
