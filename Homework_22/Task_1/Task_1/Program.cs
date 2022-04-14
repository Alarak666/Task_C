using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Task_1
{
    public class Program
    {
        //Создайте класс супер-герой.У которого есть поле класса пистолет и поле типа коллекции
        //(эта коллекция содержит набор заданий которые должен выполнить герой) ...Задание это
        //СТРУКТУРА...)..И реализуйте возможность XML и binary-пользовательской
        //сериализации...Т.е сеарилизуйте не все поля а только не которые и причем, для
        //безопасности(чтобы кто то не воспользовался вашим файлом) значения полей попробуйте
        //зашифровать ...Так же в примере поработайте с атрибутами OnSerializing и
        //OnDeserialized.
        [Serializable()]
        public struct Quest
        {
            public string name;
            public int score;
            public string status;

            public Quest(string name, int score, string status)
            {
                this.name = name;
                this.score = score;
                this.status = status;
            }
        }
        [Serializable()]
        public class SuperHero : IDisposable
        {
            public int hp;

            public string name;

            public int score;

            public Pistol pistol;
         
            public List<Quest> quests;
            public void Save(ref SuperHero super)// НОрмально
            {
                using (FileStream stream = new FileStream("Binary.xml", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    Console.WriteLine("Serialize");
                    binary.Serialize(stream, super);
                }
            }
            public SuperHero Continue( SuperHero super)// НОрмально
            {
                using (FileStream stream = new FileStream("Binary.xml", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    Console.WriteLine("Desirialize"); 
                  return super = (SuperHero)binary.Deserialize(stream);
                    

                }
                
            }
            public void SaveB( SuperHero super)// бинарно
            {
                using (FileStream stream = new FileStream("Binary.xml", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    Console.WriteLine("Serialize");
                    binary.Serialize(stream, super);
                }
            }
            public SuperHero ContinueB( SuperHero super)// бинарно
            {
                using (FileStream stream = new FileStream("Binary.xml", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    Console.WriteLine("Desirialize");
                    return super = (SuperHero)binary.Deserialize(stream);


                }

            }
            public SuperHero Otver( SuperHero super, int variant)
            {
                if (variant == 1)
                {
                    super.score += 10;
                    Console.WriteLine($"Правильно число не парное.\n Здоровье:{super.hp}\n Счет: {super.score}");
                    return super;
                }
                super.score += 10;
                Console.WriteLine($"Правильно число парное.\n Здоровье:{super.hp}\n Счет: {super.score}");
                return super;
            }
            ~SuperHero(SuperHero super)
            {
                Save(super);
            }
            public void Dispose()
            {
                Dispose();
            }
        }
        [Serializable()]
        public class Pistol
       {
            public float damage;
            public string name;
       }
        static void Main(string[] args)
        {
            List<Quest> quests = new List<Quest>()
            {
                new Quest("Убить парные числа - 10 ", 100, "0"),
            };
            using (SuperHero ANTON = new SuperHero { name = "Anton", pistol = new Pistol { name = "M16", damage = 12f }, score = 0, hp = 100, quests = quests })
            {

            
            Random rd = new Random();
            int variant;
            int variantRD;
            
            
            Console.WriteLine("Суть игры угадать чтоб выжить!!!\n 1-Уровень, угадать парное или нет число!\n 2-Уровень, угадать чтоб ваше число было меньше или больше!");
            Console.WriteLine("Загрузить игру? = 4");
            variant = int.Parse(Console.ReadLine());
            if (variant == 4)
            {
                Console.WriteLine("Бинарный = 1");
                Console.WriteLine("ХМЛ = 2");
                variant = int.Parse(Console.ReadLine());
                if(variant == 1)
                {
                    ANTON.ContinueB( ANTON);
                    Console.WriteLine($"Теперь {ANTON.name}, имеет ХП {ANTON.hp}, выполнил: {ANTON.score}");
                }
                else
                {
                    ANTON.Continue( ANTON);
                    Console.WriteLine($"Теперь {ANTON.name}, имеет ХП {ANTON.hp}, выполнил: {ANTON.score}");
                }
            }
            do
            {
                do
                {
                    if (variant < 3 && variant < 1)
                        Console.WriteLine("ALARM");
                    variant = int.Parse(Console.ReadLine());
                } while (variant > 2 );

                variantRD = rd.Next(1, 100);

                Console.WriteLine(variantRD);
                if ((variantRD % 2) == 0 && variant == 2)
                {
                    ANTON.Otver( ANTON, variant);
                }
                else if ((variantRD % 2) == 1 && variant == 1)
                {
                    ANTON.Otver( ANTON, variant);
                }
                else
                {
                    ANTON.hp -= 10;
                    Console.WriteLine($"Не верно, {ANTON.name}, получает урон{10} Теперь его здоровье:{ANTON.hp}");
                }
            } while (ANTON.hp > 0 && ANTON.score < quests[0].score);
            if (ANTON.hp < 0)
                Console.WriteLine($"Проиграл наш {ANTON.name}");
            else
                Console.WriteLine($"Победил наш {ANTON.name}");
        }
        }

    }
}
