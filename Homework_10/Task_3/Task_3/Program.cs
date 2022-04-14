using System;

namespace Task_3
{
    //Создать класс Ferrari, особенность этого класса что более 100 экземпляров Ferrari создать нельзя
    class Ferrari
    {
        private int count { get; set; }
        private string Name{ get; set; }
        public Ferrari(int count, string Name)
        {
            if (count < 100)
            {
                this.count = count;
                this.Name = Name;
            }
            else
                Console.WriteLine($"Больше {count}, екземпляров нельзя");
          
        }
    }
    class Program
    {
        static void Main(string[] args)
        {          
            Ferrari[] ferrari = new Ferrari[100];
            for (int i = 0; i < 100; i++)
            {
                ferrari[i] = new Ferrari(i, "Вася");
                Console.WriteLine(ferrari[i]);
            }
            new Ferrari(1, "");
        }
    }
}
