using System;

namespace Task_6
{
    class Program
    {
        //Создать класс студент...У студента есть массив скилов...Добавить метод
        //который добавляет очередной скил студенту и метод,который проверяет
        //есть ли определенный скил у студента
        class Student
        {
            string [] skill = {"Дышать", "Пить", "Есть", "Тратить деньги" };
            public void add_skill(string skills)
            {
                Array.Resize(ref skill, skill.Length + 1);
                Array.Reverse(skill);
                skill[0] = skills;
                Array.Reverse(skill);
                Console.Write($"Скили ");
                foreach (var i in skill)
                {
                    Console.Write($"{i}, ");
                }
            }
            public void search_skill(string skills) 
            {
                int absent = 0;
                for (int i = 0; i < skill.Length; i++)
                {
                    if (skill[i] == skills)
                    {
                        Console.WriteLine($"Скил-{skill[i]} ");
                    }
                    else
                        absent++;
                }
                if (absent == skill.Length)
                    Console.WriteLine("Данного скила нет");
            }
            public void show_student()
            {
                Console.WriteLine($"Скили: ");
                foreach (var i in skill)
                {
                    Console.Write($"{i}, ");
                }
            }
        }
        static void Main(string[] args)
        {
            Student Maxim = new Student();
            string a = "Ходить";
            string b = "Ходиь";
            Maxim.add_skill(a);
            Console.WriteLine();
            Maxim.search_skill(a);
            Console.WriteLine();
            Maxim.search_skill(b);
            Console.WriteLine();
            Maxim.show_student();

        }
    }
}
