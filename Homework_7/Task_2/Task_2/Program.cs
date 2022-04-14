using System;

namespace Task_2
{
    class Program
    {
        class Hero
        {
            public string name;
            public float health;
            public float energy; // енергия
            public byte species; // улучшение
            public int hero; // номер хероя
            public Hero(string name, float health, float energy, byte species, int hero)
            {
                this.name = name;
                this.health = health;
                this.energy = energy;
                this.species = species;
                this.hero = hero;
            }
            public int Damage( ref float hero, int buff) // урон героям
            {
                Random random = new Random();
                int rd = random.Next(10, 20);
                if (buff == 1)
                    hero -= 0;
                else
                    hero -= rd;
                return rd;
            }
        }
        class Shooter : Hero
        {
            private int ammunition;// патрони
            public Shooter(string name, float health, float energy, byte species, int hero)
                : base(name, health, energy, species,hero)
            {
                ammunition = 0;
            }
            public string attackBot (ref float hp, ref byte species)
            {
                int buff = species;
                if (ammunition > 0)
                {
                    ammunition--;
                    if(species != 1)
                    {
                        hp -= 10;
                        return ($"Наносит урона {10 - buff }");
                    }
                    else
                    {
                        hp -= 10 - buff;
                        return ($"Наносит урона {10 - buff }");
                    }
                }
                else
                {
                    Reload();
                    return "ПИФ-Паф, перезарядка";
                } 
            }
            public void Reload()
            {
                ammunition = 5;
            }
            class Healer : Hero
            {
                public float heals = 15;
                public Healer(string name, float health, float energy, byte species, int hero)
                                : base(name, health, energy, species,hero)
                {
                    this.hero = hero;
                }
                public string heal( ref float hero)
                {
                    energy -= 15;
                    if (energy >= 15)
                        return Convert.ToString( hero += heals);
                    energyReload();
                    return ("Не хватает енергии" + energy);
                }
                public void energyReload()
                {
                    energy += 5;
                }
            }
            class Support : Hero
            {
                public string[] help = new string[3] { "Неуязвимость ", "+10 hp", "+10 к урону" };
                public Support(string name, float health, float energy, byte species, int hero)
                                               : base(name, health, energy, species, hero)
                {
                }
                public string addBuff(ref byte species, ref float health)//Одно из трех умений 
                {
                    Random random = new Random();
                    int rd = random.Next(0, 2);
                    if (rd == 0)
                    {
                        species += 1;
                        return help[0];
                    }
                    if (rd == 1)
                    {
                        health += 10;
                        return help[1];
                    }  
                    else
                    {
                        health += 10;
                        return help[2];
                    }
                }
            }
            static void Main(string[] args)
            {
                int ded = 3;
                int buff = 1; // на каждое парно число будет даватся баф
                float hp = 100;
                int choice;
                Random random = new Random();
                Shooter hero1 = new Shooter("Alarak", 100, 0, 0, 1);
                Healer hero2 = new Healer("Uter", 100, 100, 0, 2);
                Support hero3 = new Support("Tiranda", 100, 100, 0, 3);
                Console.WriteLine($"Герои: 1){hero1.name}, hp {hero1.health} 2){hero2.name}, hp {hero2.health} 3){hero3.name}, hp {hero3.health}");
                do
                {
                    bool exit = true; // виход из цикла атаки
                    int rd = random.Next(0, 2); // рандомный герой для бафа
                    Console.WriteLine("Виберете героя для атаки");
                    do
                    {
                        choice = int.Parse(Console.ReadLine());
                        switch (choice) // урон по героям
                        {
                            case 1:
                                Console.WriteLine($"Вы атакуете героя {hero1.name}, hp {hero1.health}");
                                Console.WriteLine($"Нанесено урона -{hero1.Damage(ref hero1.health, hero1.species)}\n{hero1.name}, hp {hero1.health} \n");
                                choic(ref exit);
                                continue;
                            case 2:
                                Console.WriteLine($"Вы атакуете героя {hero2.name}, hp {hero2.health}");
                                Console.WriteLine($"Нанесено урона -{hero2.Damage(ref hero2.health, hero1.species)}\n{hero2.name}, hp {hero2.health}\n");
                                choic(ref exit);
                                continue;
                            case 3:
                                Console.WriteLine($"Вы атакуете героя {hero3.name}, hp {hero3.health}");
                                Console.WriteLine($"Нанесено урона -{hero3.Damage(ref hero3.health, hero1.species)}\n{hero3.name}, hp {hero3.health}\n");
                                choic(ref exit);
                                continue;
                            default:
                                Console.WriteLine("Выберете героя 1, 2, 3");
                                continue;
                        }
                    } while (exit);
                    if (buff % 2 == 0) // Баф рандомного героя, если парное 
                    {
                        if (rd == 0)
                            Console.WriteLine($"{hero1.name} получает усиление, {hero3.addBuff(ref hero1.species, ref hero1.health)}");
                        else if (rd == 1)
                            Console.WriteLine($"{hero2.name} получает усиление, {hero3.addBuff(ref hero2.species, ref hero2.health)}");
                        else if (rd == 2)
                            Console.WriteLine($"{hero3.name} получает усиление, {hero3.addBuff(ref hero3.species, ref hero3.health)}");
                    }
                    if (hero2.health > 0) //ХИЛ
                    {
                        if (hero1.health < hero2.health)
                            Console.WriteLine($"{hero1.name}, получает исцеление {hero2.heal(ref hero1.health)}");
                        else if (hero2.health < hero3.health)
                                Console.WriteLine($"{hero2.name}, получает исцеление {hero2.heal(ref hero2.health)}");
                            else
                                Console.WriteLine($"{hero3.name}, получает исцеление {hero2.heal(ref hero3.health)}");
                    }
                    Console.WriteLine($"Враг атакует: и {hero1.attackBot(ref hp, ref hero1.species)}");
                    Console.WriteLine("Ваше hp " + hp + "\n");
                    buff++;
                        hp += 5;
                    if (hero1.health <= 0 && hero2.health <= 0 && hero3.health <= 0)
                        ded = 0;
                } while (hp != 0 && ded != 0);
                if (hp < 0)
                    Console.WriteLine("Поражение");
                else
                    Console.WriteLine("Победа");
            }
            public static void choic(ref bool exit)
            {
                exit = false;
            }
        }
    }
}