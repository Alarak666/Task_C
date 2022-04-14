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
            public int sum;
            public int Sumator(int a, int b)
            {
                sum = a + b;
                return sum;
            }
            public IAsyncResult BeginInvoke(int a, int b, AsyncCallback callback, object @object)
            {
                Func<int, int, int> sums = new Func<int, int, int>(Sumator);
                IAsyncResult result = sums.BeginInvoke(a, b, callback, @object);
                return result;
            }
            public int EndInvoke(IAsyncResult result)
            {
                Thread.Sleep(1000);
                AsyncResult asyncResult = result as AsyncResult;
                Func<int, int, int> func = asyncResult.AsyncDelegate as Func<int, int, int>;
                sum = func.EndInvoke(result);
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
            IAsyncResult asyncResults = calcult.BeginInvoke(a, b, CallBack, calcult); // Асинхроний метод
            IAsyncResult asyncResult = calcult.BeginInvoke(a, b, null, null);
            Console.WriteLine("Асинхроний {0}", sum = calcult.EndInvoke(asyncResult));
            Console.ReadKey();
        }
        static void CallBack(IAsyncResult asyncResult)
        {
            Calcult calcult = (Calcult)asyncResult.AsyncState;
            int sum = calcult.EndInvoke(asyncResult);
            Console.WriteLine("Асинхроний CallBack {0}", sum);
        }
    }
}
