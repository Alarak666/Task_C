using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_2
{
    // Создать текстовый файл и записать в него, random, миллионы почтовых ящиков gmail,
    //yandex, ukr.net....Далее прочитать данные из файла и используя регулярки посчитать
    //сколько у вас почтовых ящиков gmail, yandex и т.д.
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            List<string> mail = new List<string>();
            mail.Add("@yandex.ru");
            mail.Add("@ukr.net");
            mail.Add("@mail.ru");
            mail.Add("@gmail.com");
            string pattern = @"\w+(@gmail\.com|@yandex\.ru|@mail\.ru|@ukr\.net)";
            for (int i = 0; i < 1000000; i++)
            {
                string s = "";
                for (int j = 0; j < 20; j++)
                    if (j % 2 == 0)
                        s += (char)(rd.Next(65, 90));
                    else
                        s += (char)(rd.Next(97, 122));
                s += mail[rd.Next(0, 3)];
                if (Regex.IsMatch(s, pattern, RegexOptions.Compiled))
                {
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\popel\OneDrive\Робочий стіл\EMAIL.txt", true, Encoding.Default))
                    {
                        sw.WriteLine(s);
                    }
                }
            }
            using (StreamReader reader = new StreamReader(@"C:\Users\popel\OneDrive\Робочий стіл\ds.txt", true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    for (int g = 0; g < mail.Count; g++)
                    {

                    }
                    Console.WriteLine(line);
                }
            };
            DateTime starttime = DateTime.Now;
            int ya, gm, ur, ma;
            ya = gm = ur = ma = 0;
            using (StreamReader reader = new StreamReader(@"C:\Users\popel\OneDrive\Робочий стіл\EMAIL.txt", true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, @"\w+\@yandex\.ru", RegexOptions.Compiled))
                        ya++;// yandex.ru
                    else if (Regex.IsMatch(line, @"\w+\@mail\.ru", RegexOptions.Compiled))
                        ma++;// mail.ru
                    else if (Regex.IsMatch(line, @"\w+\@gmail\.com", RegexOptions.Compiled))
                        gm++;// gmail.com
                    else if (Regex.IsMatch(line, @"\w+\@ukr\.net", RegexOptions.Compiled))
                        ur++;// ukr.net
                }
            }; 
            DateTime endtime = DateTime.Now;
            Console.WriteLine($"yandex - {ya};\ngmail - {gm};\nukr - {ur};\nmail - {ma}");
            Console.WriteLine();
            Console.WriteLine(endtime - starttime);
            Console.ReadLine();
        }
    }
}