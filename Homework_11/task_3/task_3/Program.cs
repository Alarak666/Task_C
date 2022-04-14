using System;
using System.Threading;

namespace task_3
{
    class Program
    {
        //        Есть класс дом.....В классе ДОМ описать событие:

        // ‘случился пожар’ и навесить обработчик на класс ‘Пожарное отделени’е метод
        //приезда пожарная машина...
        // ‘День рождение’ и навесить обработчик, на класс ‘Друг’ , который на этом
        //событии должен вызывать метод громко играет музыка и ‘Хихикает’....
        // Событие ‘Приехала мама’ – навесить обработчик, в котором класс Мама
        //вызывает метод и спрашивает кто эта девочка ....

        public delegate void Action();
        class House
        {
            public event Action fires;
            public void fireTruck()
            {
                Random rd = new Random();
                Console.WriteLine("Пожар");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Набрать номер: ");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{rd.Next(0, 2)}");
                }
                Console.WriteLine();
                fires?.Invoke();
            }
        }
        class Friend
        {
           public event Action holiday;
            public void birthday()
            {
                Console.WriteLine("Празник");
                holiday?.Invoke();
            }
        }
        class MAM
        {
            public event Action mamAtHome;
            public void maM()
            {
                Console.WriteLine("Мама дома!");
                mamAtHome?.Invoke();
            }
        }
        public static void fire()
        {
            Console.WriteLine("У нас пожар");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void happy()
        {
            Console.WriteLine("У нас пожар, валера пришел");

        }
        public static void danger()
        {
            Console.WriteLine("Закрываем Доту, учим уроки");
        }
        static void Main(string[] args)
        {
            House house = new House();
            house.fires += new Action(fire);

            MAM mam = new MAM();
            mam.mamAtHome += new Action(danger);

            Friend friend = new Friend();
            friend.holiday += new Action(happy);

            for (int i = 0; i < 3; i++)
            {
                if (i == 1)
                    house.fireTruck();
                else if (i == 2)
                    friend.birthday();
                else
                    mam.maM();
                Console.WriteLine(new string('-', 20));
                Thread.Sleep(2000);
            }
        }
    }
}
