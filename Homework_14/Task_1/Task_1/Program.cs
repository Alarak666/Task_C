using System;
using System.Threading;

namespace Task_1
{
    //Создайте класс-обобщение...В данном классе будет поле массив, причем вместо типа будет
    //только указатель...это значит если вы при инстаницировании укажите int, то массив будет с
    //целыми числами, если float , то с float и т.д....Вам необходимо:
    // Описать индексатор
    // Добавить метод, который ищет элемент по указанному, значению и возвращает
    //индекс элемента.Если не находит элемент с таким значением то возвращает -1;
    //    P.S.: для наполнения массива значениями вы можете добавить соответствующий функционал в
    //класс...А можно упростить и создать пользовательский констуктор и в него передовать
    //соответствующий массив.
    class Masiv<T>
    {
        private T[] array;
        public Masiv(T[] array)
        {
            this.array = (T[])array.Clone();
        }
       public void sort(T[] array)
        {
            Console.WriteLine("Сортировка");
            Array.Sort(array);
            foreach (var item in array)
            {
                Console.Write(item +" ");
            }
        }
        public int inArray(T[] array, T key)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(key))
                    return 1;
            }
            return -1;
        }

        public void Print()
        {
            Console.WriteLine("Масив");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int? a = null;
            int? b = 1;
            Thread thread = new Thread(new ThreadStart(Program.m));
            thread.Start();
            Console.WriteLine(a.Equals(b));
            
        }
        public static void m()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("1");
            }
        }
    }
}
