using System;

namespace Task_3
{
    class Program
    {
        /*Класс Developer_array...У него есть методы: добавить в начало, добавить в
              конец,добавить по указанному индексу....и метод который возвращает есть
              ли в массиве элемент с таким значением
        */
        class Developer_array
        {

            public static void input_begin(ref int [] array, int user_changes)// Вствить елемент в начало 
            { 
                Array.Resize(ref array, array.Length + 1);
                for (int i = array.Length-1; i > 0; i--)
                {
                    array[i] = array[i - 1];
                }
                array[0] = user_changes;
                foreach( int a in array)
                {
                    Console.Write($"{a} ");
                }
                Console.WriteLine();
            }
            public static void input_end(ref int[] array, int user_changes)
            {
                Array.Resize(ref array, array.Length + 1);
                Array.Reverse(array);
                array[0] = user_changes;
                Array.Reverse(array);
                foreach (int a in array)
                {
                    Console.Write($"{a} ");
                }
                Console.WriteLine();
            }
            public static void input_index(ref int[] array, int user_changes, int index)
            {
                Array.Resize(ref array, array.Length + 1);
                int index_1 = 0 ;
                for (int i = 0; i<array.Length; i++)
                {
                    
                    if (index == i)
                    {
                        index_1 = array[i];
                        array[i] = user_changes;
                    }
                    if (i > index)
                    {
                        int index_2 = array[i];
                        array[i] = index_1;
                        index_1 = index_2;
                    }
                }
                foreach (int a in array)
                {
                    Console.Write($"{a} ");
                }
                Console.WriteLine();
            }
            public static void input_search(ref int[] array, int user_changes)
            {
              int j = 0;
                for (int i =0; i<array.Length;i++)
                { 
                    if (user_changes == array[i])
                        Console.WriteLine($"Значення-{array[i]}, номер-{i}");
                    else
                        j++;
                }
                if(j==array.Length)
                    Console.WriteLine("Нету");
            }
        }
        static void Main(string[] args)
        {
            int[] array = {1, 2, 3, 4, 5, 6 };
            int user_change = new int();
            int index = new int();
            int user_change_exit = new int();
            Console.WriteLine("Нажмите 1 - чтоб вставить число в начало");
            Console.WriteLine("Нажмите 2 - чтоб вставить число в конец");
            Console.WriteLine("Нажмите 3 - чтоб вставить число в любое место массива");
            Console.WriteLine("Нажмите 4 - чтоб найти число в массиве");
            Console.WriteLine("Нажмите 5 - для выхода!");
            do
            {
                user_change_exit = int.Parse(Console.ReadLine());
                switch (user_change_exit)
                {
                    case 1:
                        Console.WriteLine("Введите число");
                        user_change = int.Parse(Console.ReadLine());
                        Developer_array.input_begin(ref array, user_change);
                        break;
                    case 2:
                        Console.WriteLine("Введите число");
                        user_change = int.Parse(Console.ReadLine());
                        Developer_array.input_end(ref array, user_change);
                        break;
                    case 3:
                        Console.WriteLine("Введите число, а потом индекс");
                        user_change = int.Parse(Console.ReadLine());
                        index = int.Parse(Console.ReadLine());
                        Developer_array.input_index(ref array, user_change, index);
                        break;
                    case 4:
                        Console.WriteLine("Введите число");
                        user_change = int.Parse(Console.ReadLine());
                        Developer_array.input_search(ref array, user_change);
                        break;
                }
            } while (user_change_exit != 5);
        }
    }
}