using System;

namespace Tast_1
{
    class Program
    {
        class Student
        {
            static int NextID = 0;
            public int ID;
            public string name;
            public int Facultet;
            public string surname;
            public Student(string a, string b, int c) 
            {
                this.ID = NextID++;
                name = a; 
                surname = b; 
                Facultet = c; 
            }
            static public void _NextID()
            {
                Console.WriteLine(NextID);
            }
            public void GetInfo()
            {
                Console.WriteLine($"Name: {name}, Facultet: {Facultet}, Surname: {surname}, ID: {ID}");
            }
        }


        static void Main(string[] args)
        {
            Student._NextID();
            Student Sanya = new Student("Sanya", "Gilenko", 3);
            Student._NextID();
            Student Artem = new Student("Artem", "Gulen", 3);
            Student._NextID();
            Student Vanya = new Student("Vanya", "gulic", 3);
            Sanya.GetInfo();
            Artem.GetInfo();
            Vanya.GetInfo();
            Student._NextID();
        }
    }
}
