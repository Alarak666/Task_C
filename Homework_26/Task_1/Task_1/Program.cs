using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Calculator
    {
        public async void  AVG(int[] array)
        {
            await Task.Run(() =>
            {
                float sum = new int();
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                Console.WriteLine( $"{sum /=array.Length}");
            });
        }
    }
    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();
            int[] vs = new int[] {1,2,3,4,5,6,7,8,9,10};
            calculator.AVG(vs);
            Console.ReadKey();
        }
    }
}
