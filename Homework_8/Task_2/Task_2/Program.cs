using System;
using System.Threading;

namespace Task_2
{
    class Program
    {
        //Есть хор..(массив различных животных)...Животное это абстрактный класс у которого 
        //абстрактный метод петь песни...Соответственно наследники переопределяют его и поют по
        //разному....и еще собака реализует интерфейс “Вилять хвостом”.....вам необходимо
        //перебрать массив животных и на каждом вызвать метод “Петь песни”....а если ваш
        //экземпляр реализует интерфейс “Вилять хвостом”...то вызвать его метод
        interface Itail
        {
            void tail();
        }
        abstract class Animal
        {
            public string name;
            public Animal(string name)
            {
                this.name = name;
            }
            public abstract void sing();
        }
        class Cat : Animal
        {
            public Cat(string name)
                : base(name)
            {

            }
            public override void sing()
            {
                Console.WriteLine("meow-meow");
            }
        }
        class Penguin : Animal
        {
            public Penguin(string name)
                : base(name)
            {

            }
            public override void sing()
            {
                Console.WriteLine("piy-piy");
            }
        }
        class Dog : Animal, Itail
        {
            public Dog(string name)
                : base(name)
            {

            }
            public override void sing()
            {
                Console.WriteLine("woof-woof");
            }
            public void tail()
            {
                int weight = 10;
                int height = 8;
                int tboool = 0;// выход из цикла
                do
                {
                    for (int i = 0; i < height; i++) // Собака хвост вверх
                    {
                        for (int j = 0; j < weight; j++)
                        {
                            if (j == 2 || (j == 5 && i > 0))// ноги
                                Console.Write("*");
                            else if ((j > 5) && (i == 2 || i == 4)) // голова
                                Console.Write("*");
                            else if ((j > 3 && j < 5) && (i == 2 && i == 4)) // тулуб
                                Console.Write("*");
                            else if (j == 9 && i > 1 && i < 5)
                                Console.Write("*");
                            else if ((i > 2 && i < 5) && (j == 3 || j == 4))
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine(" ");
                    Thread.Sleep(1000);
                    for (int i = 0; i < height; i++) // Собака хвост вниз
                    {
                        for (int j = 0; j < weight; j++)
                        {
                            if ((j == 2 && i > 2) || (j == 5 && i > 0))// ноги
                                Console.Write("*");
                            else if ((j > 5) && (i == 2 || i == 4)) // голова
                                Console.Write("*");
                            else if ((j > 3 && j < 5) && (i == 2 && i == 4)) // тулуб
                                Console.Write("*");
                            else if (j == 9 && i > 1 && i < 5)
                                Console.Write("*");
                            else if ((i > 2 && i < 5) && (j == 3 || j == 4))
                                Console.Write("*");
                            else if (i == 3 && j < 3)
                                Console.Write("*");
                            else
                                Console.Write(" ");
                        }
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine(" ");
                    Thread.Sleep(1000);
                    tboool++;
                } while (tboool != 4);

            }
            static void Main(string[] args)
            {

            try
            {
                    Animal[] animals = new Animal[]
                {
                new Cat ("Murzik"),
                new Penguin("Riko"),
                new Dog ("Pes")
                };
                for (int i = 0; i < animals.Length; i++)
                {
                    animals[i].sing();
                }
                Console.WriteLine("\nPes");
                Itail itail = new Dog("Pes");
                itail.tail();
            }
            catch(SystemException)
            {
                
            }
        }
    }
}
