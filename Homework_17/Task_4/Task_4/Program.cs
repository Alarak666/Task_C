using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    //4. Сделать sorted list в которого вы добавляете студентов ....Каждый студент это ФИО и
    //средний бал....Вам необходимо сделать свой comparer , чтобы студенты были отсортированы
    //по среднему баллу
    class Student
    {
        private string fio;
        private int appraisal;

        public string FIO
        {
            get
            {
                return fio;
            }
        }

        public int Appraisal
        {
            get
            {
                return appraisal;
            }
        }

        public Student(string fio, int appraisal)
        {
            this.fio = fio;
            this.appraisal = appraisal;
        }
    }
    class SortedList : IComparer<Student>
    {
        private List<Student> students;
        public SortedList(int size = 0)
        {
            students = new List<Student>(size);
        }
        public void Add(Student student)
        {
            students.Add(student);
        }
        public void Add(string FIO, int appraisal)
        {
            students.Add(new Student(FIO, appraisal));
        }
        public int Compare(Student student1, Student student2)
        {
            if (student1.Appraisal < student2.Appraisal)
                return -1;
            else if (student1.Appraisal == student2.Appraisal)
                return 0;
            else
                return 1;
        }
        public void SortByAppraisal()
        {
            for (int i = 0; i < students.Count; ++i)
            {
                Student min_student = students[i];
                int min_index = i;
                for (int j = i + 1; j < students.Count; ++j)
                {
                    if (Compare(students[j], min_student) == -1)
                    {
                        min_student = students[j];
                        min_index = j;
                    }
                }
                students[min_index] = students[i];
                students[i] = min_student;
            }
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var student in students)
            {
                yield return student;
            }
        }
    }
    static void Main(string[] args)
    {
        SortedList students = new SortedList();
        Student student1 = new Student("Konstantin", 3);
        Student student2 = new Student("Alina", 2);
        Student student3 = new Student("Natasha", 5);

        students.Add(student1);
        students.Add(student2);
        students.Add(student3);
        students.Add("Anton", 9);
        students.Add("Vladimir", 3);
        students.Add("Nilolay", 6);
        students.Add("Nastya", 1);
        students.Add("Aleksey", 8);
        students.Add("George", 4);
        students.Add("Alina", 7);
        students.Add("Vadim", 1);
        foreach (Student student in students)
        {
            Console.WriteLine("Оценка студента " + student.FIO + ": " + student.Appraisal);
        }
        Console.WriteLine(new string('-',30));
        students.SortByAppraisal();
        foreach (Student student in students)
        {
            Console.WriteLine("Оценка студента " + student.FIO + ": " + student.Appraisal);
        }
    }
}

