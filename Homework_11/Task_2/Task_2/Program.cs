using System;

namespace Task_2
{
    class Program
    {
        //У вас есть массив студентов..(Студент-это структура)...(У студента есть имя,кол-во
        //энергии, и средний балл за сессию)...Еще у вас есть массив делегатов с которыми
        //сообщены методы(помыть студента, накормить студента, уложить спать студента, и дать
        //стипендию, если средний балл более 4,5)....Весь этот массив делегатов должен пройтись по
        //8
        //каждому студенту...Методы накормить и уложить спать должны увеличивать энергию
        //студента на 1...
        delegate void Work();
        class Student
        {
            public string name { get; set; }
            public int energy;
            public float AvgRating;
            public Student(string name, int energy, float AvgRating)
            {
                this.name = name;
                this.energy = energy;
                this.AvgRating = AvgRating;
            }
            public void Wash()
            {
                Console.WriteLine($"Отмыть: {name}, {energy++}");
            }
            public void Feed()
            {
                Console.WriteLine($"Покормить: {name}, {energy++}");
            }
            public void Sleep()
            {
                Console.WriteLine($"Уложить спать: {name}, {energy++}");
            }
            public void Grant()
            {
                if (this.AvgRating > 4.5)
                    Console.WriteLine($"Спитендию получил: {name} ");
                else
                {
                    Console.WriteLine($"Спитендию не получил: {name} ");
                }
            }
        }

        static void Main(string[] args)
        {

            Student[] student = new Student[]
            {
                new Student("Антон", -1, 4.4f),
                new Student("Максим", 1, 4.5f),
                new Student("Егор", 0, 4.2f),
                new Student("Семен", 1, 4.9f)
            }; 
            for (int i = 0; i < student.Length; i++)
            {
                Work[] delegatwork = new Work[]
                {
                  new Work( student[i].Wash),
                  new Work( student[i].Feed),
                  new Work( student[i].Sleep),
                  new Work( student[i].Grant)
                };
                for (int j = 0; j < delegatwork.Length; j++)
                {
                    delegatwork[j].Invoke();
                }
            }
            foreach (var item in student)
            {
                Console.WriteLine($"{item.name}, {item.energy}, {item.AvgRating}");
            }
        }
    }
}