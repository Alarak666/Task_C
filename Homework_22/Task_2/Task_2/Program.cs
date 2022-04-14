using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task_2
{
    class Program
    {
        [Serializable]
        public class Person : ISerializable
        {
            public string name;
            public string surname;

            public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("name", name);
                info.AddValue("surname", surname);
            }
            public void Seria(Person person)
            {
                using (FileStream stream = new FileStream("file.xml", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(stream, person);
                };
            }
            protected Person(SerializationInfo propertyBag, StreamingContext context)
            {
                name = propertyBag.GetString("name");
                surname = propertyBag.GetString("surname");
            }
            public Person(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
            }
            public override string ToString()
            {
                return "name: " + name + " surname: " + surname;
            }
            public Person DESeria(Person person)
            {
                using (FileStream stream = new FileStream("file.xml", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                   return person =(Person)binary.Deserialize(stream);
                };
            }
            static void Main(string[] args)
            {
                Person person = new Person ( "Anton", "Razan" );
                person.Seria(person);
              Console.WriteLine(  person.DESeria(person).ToString());
            }
        }
    }
}
