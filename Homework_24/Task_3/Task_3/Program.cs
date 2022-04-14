using System;
using System.Threading;

namespace Task_3
{
    class Program
    {
        //        Задача на Timer...Вам необходимо...В 5 часов утра запустить метод в котором
        //закукарекает петух....И сразу в 10 потокох 10 куриц начнут нести яйцаа с рандомным
        //интервалом....Затем в 16.00 запуститься метод в который петух закукарекает ‘Хватит
        //нести яйца’ и курицы прекратят.
        
        static void Main(string[] args)
        {
            int count = 10; 
            Сock cock = new Сock();
            AutoResetEvent auto = new AutoResetEvent(false);
            TimerCallback callback = new TimerCallback(cock.Vote);
            Сhicken[] сhicken = new Сhicken[]
            {
                new Сhicken("1"),
                new Сhicken("2"),
                new Сhicken("3"),
                new Сhicken("4"),
                new Сhicken("5"),
                new Сhicken("6"),
                new Сhicken("7"),
                new Сhicken("8"),
                new Сhicken("9"),
                new Сhicken("10")
            };

            WaitHandle[] events = new WaitHandle[]
            {
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false),
                new AutoResetEvent(false),
            };

            Timer timer = new Timer(callback,auto,10000,100);
            while (true)
            {
                for (int i = 0; i < count; i++)
                {
                    ThreadPool.QueueUserWorkItem(сhicken[i].AddEgg, events[i]);
                    Thread.Sleep(500);
                }
                WaitHandle.WaitAll(events);
                timer.Dispose();
            }
        }
        
      
        class Сock
        {
            public void Vote(object state)
            {
                Console.WriteLine("Пять утра");
                (state as AutoResetEvent).Set();
            }
            
        }
        class Сhicken
        {
            public string name;

            public Сhicken(string name)
            {
                this.name = name;
            }
            public void AddEgg(object state)
            {
                Console.WriteLine($"Яйцо курицы -{name}");
                (state as AutoResetEvent).Set();
                Thread.Sleep(500);
            }
        }
    }
}
