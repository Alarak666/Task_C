using System;
using System.Threading;

namespace Task_1
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
                IAsyncResult asyncResult = result as IAsyncResult;
                Func<int, int, int> func = asyncResult.AsyncState as Func<int, int, int>;
                sum = func.EndInvoke(result);
                return sum;
            }
        }
       
        // Калькулятор
        static void Main(string[] args)
        {
            int a = 12;
            int b = 12;
            Calcult calcult = new Calcult();
            IAsyncResult asyncResults = calcult.BeginInvoke(a, b, CallBack, calcult);
        }
        static void CallBack(IAsyncResult asyncResult)
        {
            Calcult calcult = (Calcult)asyncResult.AsyncState;
            int sum = calcult.EndInvoke(asyncResult);
        }
    }
}
