using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        //        Напишите регулярку для ввода числа от 0 до 99999...Обратите внимание что число 00 или
        //01 не должно быть валидным.....
        static void Main(string[] args)
        {
            Console.WriteLine("Формат 0 до 9999, без 01, 0001");
            while (true)
            {
                string a = null;
                string pattern = @"^(0|[1-9]\d{0,3})$";
                a = (Console.ReadLine());
                if (Regex.IsMatch(a.ToString(), pattern, RegexOptions.Compiled))
                    Console.WriteLine(a);
                else
                    Console.WriteLine("НЕ подходит");

            }
        }
    }
}