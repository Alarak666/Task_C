using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    //    Создать фабричный метод который возвращает коллекцию студентов, которые посещают
    //занятия и выполняют домашние задания....Использовать yield....В методе Main, в цикле
    //foreach на каждом студенте вы проверяете насколько хорошо он подготовился к
    //теории....Если пять и более студентов плохо подготовились к теории то цикл foreach
    //прерывается и выводиться сообщение ‘Печалька...(’.
    class Student
    {
        private string name;
        private int course;
        private bool attendLessons;
        private bool doesHomeworks;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Student(string name, int course, bool attendLessons, bool doesHomeworks)
        {
            this.name = name;
            this.course = course;
            this.attendLessons = attendLessons;
            this.doesHomeworks = doesHomeworks;
        }
        public bool IsGood()
        {
            return attendLessons && doesHomeworks;
        }
        public bool Prepared()
        {
            if (IsGood())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class Students
    {
        private List<Student> students;

        public Students(int size = 0)
        {
            students = new List<Student>(size);
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public void Add(string name, int course, bool attendLessons, bool doesHomeworks)
        {
            students.Add(new Student(name, course, attendLessons, doesHomeworks));
        }
        public IEnumerable GetStudents()
        {
            for (int i = 0; i < students.Count; ++i)
                yield return students[i];
        }
    }

    static void Main(string[] args)
    {
        Students students = new Students();
        Student student1 = new Student("Konstantin", 3, true, true);
        Student student2 = new Student("Ludmila", 3, true, true);
        Student student3 = new Student("Yuriy", 3, true, true);

        students.Add(student1);
        students.Add(student2);
        students.Add(student3);
        students.Add("Anton", 4, true, true);
        students.Add("Vladimir", 3, true, true);
        students.Add("Nilolay", 2, true, true);
        students.Add("Nastya", 1, false, false);
        students.Add("Aleksey", 2, false, true);
        students.Add("George", 3, true, false);
        students.Add("Alina", 2, false, true);
        students.Add("Vadim", 1, true, false);
        int badHomework = 0;
        foreach (Student student in students.GetStudents())
        {
            if (student.Prepared())
            {
                Console.WriteLine(student.Name + " хорошо подготовился к теории");
            }
            else
            {
                Console.WriteLine(student.Name + " плохо подготовился к теории  <---");
                ++badHomework;
            }
            if (badHomework >= 5)
            {
                Console.WriteLine("Печалька...(");
                break;
            }
        }
    }
}

