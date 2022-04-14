using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_1_1_
{
    class Program
    {
        class Calcult
        {
            public float avg;
            public float AVG(int[] array)
            {
                float sum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                return avg = sum/array.Length;
            }
            public IAsyncResult BeginInvoke(int [] array, AsyncCallback callback, object @object)
            {
                Func<int[], float> sums = new Func<int[], float>(AVG);
                IAsyncResult result = sums.BeginInvoke(array, callback, @object);
                return result;
            }
            public float EndInvoke(IAsyncResult result)
            {
                Thread.Sleep(1000);
                AsyncResult asyncResult = result as AsyncResult;
                Func<int[], float> func = asyncResult.AsyncDelegate as Func<int[], float>;
                avg = func.EndInvoke(result);
                return avg;

            }
        }

        // Калькулятор
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            float avg;
            Calcult calcult = new Calcult();
            IAsyncResult asyncResults = calcult.BeginInvoke(array, CallBack, calcult); // Асинхроний метод
            IAsyncResult asyncResult = calcult.BeginInvoke(array, null, null);
            Console.WriteLine("Асинхроний {0}", avg = calcult.EndInvoke(asyncResult));
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        static void CallBack(IAsyncResult asyncResult)
        {
            Calcult calcult = (Calcult)asyncResult.AsyncState;
            float avg = calcult.EndInvoke(asyncResult);
            Console.WriteLine("Асинхроний CallBack {0}", avg);
        }
    }
}
