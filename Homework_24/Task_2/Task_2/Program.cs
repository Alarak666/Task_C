using System;
using System.Threading;

namespace Task_2
{
    //    Задача на RegisterWaitForSingleObject ...У вас есть бригада строителей: каменьщик,
    //гвоздезабиватель и собиратель табуреток...Все они работают в отдельных потоках...Вам
    //необходимо наладить рабочий процесс...Чтобы каменьщик клал по одному кирпичу в 3
    //секунду... гвоздезабиватель , забивал по гвоздю в 1.5 секунды и табуреточник- по 1
    //табуретке в 5 секнуд....И у вас еще есть возможность подгонять строителей...Если
    //нажимаете ‘К’ каменьщик сразу кладет кирпичь...если ‘Г’ то гвоздезабиватель забивает
    //гвоздь и т.д..
    class Program
    {
        
       
        static void Main(string[] args)
        {
            
            Collector collector = new Collector();
            Nailer nailer = new Nailer();
            Bricklayer bricklayer = new Bricklayer();

            AutoResetEvent auto = new AutoResetEvent(false);
            AutoResetEvent auto1 = new AutoResetEvent(false);
            AutoResetEvent auto2 = new AutoResetEvent(false);
            WaitOrTimerCallback callback = new WaitOrTimerCallback(bricklayer.Bricklay);
            WaitOrTimerCallback callback1 = new WaitOrTimerCallback(nailer.Nailr);
            WaitOrTimerCallback callback2 = new WaitOrTimerCallback(collector.Collect);
            RegisteredWaitHandle handle = ThreadPool.RegisterWaitForSingleObject(auto, callback, null, 5000, false);
            RegisteredWaitHandle handle1 = ThreadPool.RegisterWaitForSingleObject(auto1, callback1, null, 6000, false);
            RegisteredWaitHandle handle2 = ThreadPool.RegisterWaitForSingleObject(auto2, callback2, null, 7000, false);
            while (true)
            {
                string operation = Console.ReadKey(true).KeyChar.ToString().ToUpper();
                if (operation == "A")
                {
                    auto.Set();
                }
                if (operation == "S")
                {
                    auto1.Set();
                }
                if (operation == "D")
                {
                    auto2.Set();
                }
            }
        }
        class Bricklayer
        {
            public void Bricklay(object state, bool timedOut)
            {

                Console.WriteLine("Положить камень");
            }
        }

        class Nailer
        {
            public void Nailr(object state, bool timedOut)
            {

                Console.WriteLine("Забить гвоздь");
            }
        }
        class Collector
        {
            public void Collect(object state, bool timedOut)
            {

                Console.WriteLine($"Собрать");
            }
        }
    }
}
