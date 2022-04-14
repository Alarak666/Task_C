using System;
using System.Threading;
using System.Threading.Tasks;
namespace Task_3
{
    class Program
    {
        //        Задача на Timer...Вам необходимо...В 5 часов утра запустить метод в котором
        //закукарекает петух....И сразу в 10 потокох 10 куриц начнут нести яйцаа с рандомным
        //интервалом....Затем в 16.00 запуститься метод в который петух закукарекает ‘Хватит
        //нести яйца’ и курицы прекратят.


        //        По примеру с Task и cancellation попробовать переделать задачу с петухом и курицами по
        //предыдущей домашке.
        static void Main(string[] args)
        {
            int count = 10;
            Сock cock = new Сock();
            AutoResetEvent auto = new AutoResetEvent(false);
            TimerCallback callback = new TimerCallback(cock.Vote);

            Сhicken[] chicken = new Сhicken[]
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
                new Сhicken("10"),
            };

            Task[] tasks = new Task[10];

            for (int i = 0; i < count; i++)
            {
                tasks[i] = Task.Factory.StartNew(() => chicken[i-1].AddEgg());
            }
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("One or more exceptions occurred:");
                foreach (var ex in ae.InnerExceptions)
                    Console.WriteLine("   {0}: {1}", ex.GetType().Name, ex.Message);
            }
            Console.ReadKey();
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
            public void AddEgg()
            {
                Console.WriteLine($"Яйцо курицы -{name}");
                Thread.Sleep(500);
            }
        }
    }
}
