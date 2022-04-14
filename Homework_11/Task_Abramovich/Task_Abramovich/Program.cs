using System;
using System.Threading;

namespace task_3
{
    class Program
    {
        //        Создайте класс Абрамович и событие ‘Корпоратив’... методы, которые могут быть
        //сообщены с этим событием принимают один аргумент с модификатором ref (это кошелек
        //Абрамовича) ...Привяжите на это событие методы разных классов которые будут
        //устраивать фейерверки, дискотеки, кормить гостей и т.д.....каждый метод будет из
        //кошелька Абрамовича забирать солидную сумму
        public delegate void Action(ref int money);
        class Abramovich
        {
            public event Action Corporativ;
            public string name;
            private int money;
            public int Money => money;
            public Abramovich(string name, int money)
            {
                this.name = name;
                this.money = money;
            }
            public void InvokeCorporativ()
            {
                Corporativ.Invoke(ref money);
            }
        }
        class Fireworks
        {
            private int cost;
            public void fireworks(ref int money)
            {
                cost = 10;
                if (money >= cost)
                {
                    Console.WriteLine("Фейерверк");
                    money -= cost;
                }
                else
                    Console.WriteLine("нет денег_(");
                Thread.Sleep(1000);
            }
        }
        class Disco
        {
            private int cost;
            public void disco(ref int money)
            {
                cost = 10;
                if (money >= cost)
                {
                    Console.WriteLine("Танцы");
                    money -= cost;
                }
                else
                    Console.WriteLine("нет денег_(");
                Thread.Sleep(1000);
            }
        }
        class Dinner
        {
            private int cost;
            public void dinner(ref int money)
            {
                cost = 10;
                if (money >= cost)
                {
                    Console.WriteLine("Кушать");
                    money -= cost;
                }
                else
                    Console.WriteLine("нет денег_(");
                Thread.Sleep(1000);
            }

        }
        class Hospital
        {
            private int cost;
            public void treatment(ref int money)
            {
                cost = 80;
                if (money > cost)
                {
                    money -= cost;
                    Console.WriteLine("Лечение");
                }
                else
                    Console.WriteLine("Нужен кредит" + "деньги " + money);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Abramovich abramovich = new Abramovich("ВАЛЕРА",100);
            Hospital hospital = new Hospital();
            Dinner dinner = new Dinner();
            Fireworks fireworks = new Fireworks();
            Disco disco = new Disco();
            abramovich.Corporativ += dinner.dinner;
            abramovich.Corporativ += fireworks.fireworks;
            abramovich.Corporativ += disco.disco;
            abramovich.InvokeCorporativ();
            Console.WriteLine(abramovich.Money);
            abramovich.Corporativ += hospital.treatment;
            abramovich.InvokeCorporativ();

        }
    }
}
