using System;
namespace Index_UK_EN_RU
{
    class Program
    {
        class Dictionary
        {
            private string[] key = new string[5];
            private string[] valueEN = new string[5];
            private string[] valueUA= new string[5];

            public Dictionary()
            {
                key[0] = "книга"; valueEN[0] = "book"; valueUA[0] = "книга";
                 key[1] = "карандаш"; valueEN[1] = "pen"; valueUA[1] = "олівець";
                 key[2] = "солнце"; valueEN[2] = "sun"; valueUA[2] = "сонечко";
                key[3] = "яблоко"; valueEN[3] = "apple"; valueUA[3] = "яблуко";
                key[4] = "стол"; valueEN[4] = "table"; valueUA[4] = "стіл";
            }

            public string this[string index]
            {
                get
                {
                    for (int i = 0; i < key.Length; i++)
                        if (key[i] == index)
                            return key[i] + " - " + valueEN[i];

                    return string.Format("{0} - нет перевода для этого слова.", index);
                }
            }

            public string this[int index]
            {
                get
                {
                    if (index >= 0 && index < key.Length)
                        return key[index] + " - " + valueEN[index] + " - "+ valueUA[index];
                    else
                        return "Попытка обращения за пределы массива.";
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Dictionary dictionary = new Dictionary();

            Console.WriteLine(dictionary["карандаш"]);
            Console.WriteLine(dictionary["карандаш"]);
            Console.WriteLine(dictionary["солнце"]);
            Console.WriteLine(dictionary["стол"]);
            Console.WriteLine(dictionary["карандаш"]);
            Console.WriteLine(dictionary["яблоко"]);
            Console.WriteLine(dictionary["солнце"]);

            Console.WriteLine(new string('-', 20));

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(dictionary[i]);
            }

            // Delay.
            Console.ReadKey();

        }
    }
}
