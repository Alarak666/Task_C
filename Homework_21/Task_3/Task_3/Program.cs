using System;
using System.IO;
using System.Xml.Serialization;

namespace Serialization
{ 
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // стандартный конструктор без параметров
        public Person()
        { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Maxim",12);
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using(FileStream stream = new FileStream("person.xml",FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, person);
            }
            using (FileStream stream = new FileStream("person.xml", FileMode.OpenOrCreate))
            {
                Person persons = (Person)serializer.Deserialize(stream);
                Console.WriteLine($"{persons.Age} {persons.Name}");
            }

            Console.ReadLine();
        }
    }
}