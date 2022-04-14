using System;

namespace Task_4
{
    class Program
    {
        //Создать класс калькулятор.В калькуляторе есть методы: сложить,
        //умножить, делить
        class Calculator
        {
            public void Calculators( int action, double addition_1, double addition_2)
            {
               if (action == 1)
               {
                    addition_1 += addition_2; 
               }
               else if (action == 2)
               {
                    addition_1 -= addition_2;
               }
               else if (action == 3)
               {
                    addition_1 *= addition_2;
               }
               else if (action == 4)
               {
                    addition_1 /= addition_2;
               }
                Console.WriteLine($"Ответ:{addition_1}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Выберете действие, а потом ввидите два числа ");
            Console.WriteLine("1-Сложение");
            Console.WriteLine("2-Вычитание");
            Console.WriteLine("3-Умножение");
            Console.WriteLine("4-Деление");
            Console.WriteLine("5-Выход");
            int action = new int();
            double addition_1 = new int();
            double addition_2 = new int();
            do
            {
                action = int.Parse(Console.ReadLine());
                addition_1 = int.Parse(Console.ReadLine());
                addition_2 = int.Parse(Console.ReadLine());
                Calculator cal = new Calculator();
                cal.Calculators(action, addition_1, addition_2);
            } while (action != 5);
           
        }
    }
}
