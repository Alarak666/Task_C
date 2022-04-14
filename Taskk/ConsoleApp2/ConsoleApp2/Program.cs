using System;

namespace ConsoleApp2
{
    class Program
    {
        struct Person
        {
            public string name;
        }
        class Person2
        {
            public string name;
        }
        static void Main(string[] args)
        {
            unsafe
            {
                int* a ;
                int b = 10;
                a = &b ;
                Console.WriteLine(++*a);
                Console.WriteLine(++b);
            }
            Person person = new Person { name ="sd"};
            Person2 person2 = new Person2 { name = "da" };
           

            
            //int hh1, mm1, ss1, hh2, mm2, ss2;
            //hh1 = 23; mm1 = 59; ss1 = 50; hh2 = 23; mm2 = 59; ss2 = 52;

            //int[] amount_of_numbers = new int[10];
            //int[] hh = new int[2];
            //int[] mm = new int[2];
            //int[] ss = new int[2];
            //string a = "hyi";
            //if (a[1] == 'h')
            //{

            //}
            //Console.WriteLine();

            //for (int i = hh1; i <= hh2; ++i)
            //{
            //    for (int j = mm1; j <= mm2; ++j)
            //    {
            //        for (int k = ss1; k <= ss2; ++k)
            //        {

            //            hh[0] = i / 10;
            //            hh[1] = i % 10;
            //            mm[0] = j / 10;
            //            mm[1] = j % 10;
            //            ss[0] = k / 10;
            //            ss[1] = k % 10;

            //            for (int l = 0; l < 10; ++l)
            //            {
            //                if (hh[0] == l)
            //                {
            //                    ++amount_of_numbers[l];
            //                }
            //                if (hh[1] == l)
            //                {
            //                    ++amount_of_numbers[l];
            //                }
            //                if (mm[0] == l)
            //                {
            //                    ++amount_of_numbers[l];
            //                }
            //                if (mm[1] == l)
            //                {
            //                    ++amount_of_numbers[l];
            //                }
            //                if (ss[0] == l)
            //                {
            //                    ++amount_of_numbers[l];
            //                }
            //                if (ss[1] == i)
            //                {
            //                    ++amount_of_numbers[l];
            //                }
            //            }
            //        }
            //    }
            //}
            //for (int i = 0; i < 10; ++i)
            //{
            //    Console.WriteLine(amount_of_numbers[i]);
            //}
        }
    }
}
