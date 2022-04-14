using System;

namespace Task_2
{
    class Program
    {
        class Question
        {
            public string name_Quest;
            public string variant_1;
            public string variant_2;
            public string variant_3;
            int i = 1;
            public Question(string quest, string var1, string var2, string var3) { name_Quest = quest; variant_1 = var1; variant_2 = var2; variant_3 = var3; }
            public void questionS()
            {
               
                Console.WriteLine($"Тест-{i}: {name_Quest};");
                Console.WriteLine($"Вариант-{1}: {variant_1};");
                Console.WriteLine($"Вариант-{2}: {variant_2};");
                Console.WriteLine($"Вариант-{3}: {variant_3};");
                i++;
            }
        }
        class Rating
        {
            public string user_answer;
            public string Good_answer;
            private int statistics;
            public int qty = 0;
            public Rating(string good, string user) { user_answer = user; Good_answer = good; }
            public void rating() // Правильный или не правильный ответ 
            {
                Console.WriteLine($"Ваш ответ:{user_answer}");
                Console.WriteLine($"Правильний ответ:{Good_answer}");
                if (user_answer == Good_answer)
                {
                    statistics++;
                    Console.WriteLine("Вы ответили правильно");
                }
                else
                    Console.WriteLine("Вы ответили не правильно");
            }
            public Rating(int Qty) { qty = Qty; }
            public void raiting()// Вывод  оценки 
            {
                Console.WriteLine($"Ваша оценка:{statistics} из {qty}");
            }
        }

        static void Main(string[] args)
        {
            string[] question = { "2+2?", "Столиця Аргентины?", "Кто убил Пушкина?", "Кто убил Кеннеди?" };
            string[] answer = { "2", "4", "6", "Буэнос-Айрес", "Москва", "Шри-Джаяварденепура-Котте", "Дантес", "Лютер", "Ярик", "Ли Ха́рви О́свальд", "Лютер", "Ярик" };
            string[] god_answer = {"4", "Буэнос-Айрес", "Дантес", "Ли Ха́рви О́свальд" };
            string[] User_Answer = new string[4];
            int index = 0;
            int Qty = 0;
            for (int i = 0; i < question.Length; i++)
            {
                string ques = question[i];
                string ans1 = answer[index];
                string ans2 = answer[index + 1];
                string ans3 = answer[index + 2];
                Question test = new Question(ques, ans1, ans2, ans3);
                test.questionS();
                int a = int.Parse(Console.ReadLine());
                User_Answer[i] = answer[a + index - 1];
                index += 3;
                Qty = i+1;
            }
            Console.WriteLine();
            for (int i = 0; i < question.Length; i++)
            {
                string ques = god_answer[i];
                string user_answ = User_Answer[i];
                Rating otvet = new Rating(ques, user_answ);
                otvet.rating();
            }
            Rating raiting = new Rating(Qty);
            raiting.raiting();
        }
        
    }
}
