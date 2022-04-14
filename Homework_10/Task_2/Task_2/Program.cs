using System;

namespace Task_2
{
   // Создайте класс рыбка....Добавьте ей, с помощью расширяющих методов, возможность
   //бегать и говорить....Причем метод говорить принимает, как аргумент то что рыбка должна
   //сказать.
    public static class FishExtension
    {
        public static int x;
        public static int y;
        public static void Move(this string move, int x, int y)
        {
            Console.WriteLine(move);
            Paint(x, y);
            

        }
        public static void Speak(this string speak, string say)
        {
            Console.WriteLine( $"{speak} {say}");
        }
        public static void Speaks(this string speak, int count)
        {
            count--;
            Console.WriteLine(speak + count);
            if (count != 0)
                speak.Speaks(count);
            Console.WriteLine(speak + count);
        }
        public static void Paint(int x, int y)
        {
            for (int i = 0; i < y; i++)
            {
                Console.WriteLine();
                if (i == y-1)
                {
                    new string(' ', x); Console.WriteLine("    *");
                    new string(' ', x); Console.WriteLine(" * * *");
                    new string(' ', x); Console.WriteLine("  *   *");
                    new string(' ', x); Console.WriteLine(" * * *");
                    new string(' ', x); Console.WriteLine("    *");
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string Fish = "Артем";
            Fish.Move(2, 5);
            Fish.Speak("Рыба");
            Fish.Speaks(4);
        }
    }
}
