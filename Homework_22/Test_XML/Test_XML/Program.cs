using System;
using System.IO;

using System.Xml.Serialization;

namespace Test_XML
{
    public class Program
    {
        public class Socka
        {
            public string name { get; set; }
            public string Surname { get; set; }

            public void Save()
            {
                var serializer = new XmlSerializer(typeof(Socka));
                using (var stream = new FileStream("thx.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(stream, this);
                };
            }
        }
        static void Main(string[] args)
        {
            Socka socka = new Socka();
            socka.name = "pengvin";
            socka.Surname = "pengvin";
            socka.Save();
        }
    }
}
