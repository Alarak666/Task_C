using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_1
{
    //    Создайте атрибут...При его использовании необходимо передавать два позиционный и
    //три именованных параметров(например версия(version) и дата релиза(release))....Далее с
    //помощью механизма рефлексии необходимо вывести метаданные этих атрибутов а также
    //отобразить список классов version = 7.01 или у которых дата релиза с начала ноября 2019
    //года.

    class Program
    {
        public class ValidationAttribute : System.Attribute
        {
            public string version { get; set; }
            public string release { get; set; }
            public ValidationAttribute(string version, string release)
            {
                this.version = version;
                this.release = release;
            }
            public override string ToString()
            {
                return $"version = {version}, release = {release}";

            }
           

        }
        [Validation("4.01", "09/09/2010")]
        class Person
        {
            
        }
        [Validation("7.01", "09/09/2000")]
        class Human
        {
         
        }
        [Validation("1.01", "09/09/2000")]
        class Boozer
        {

        }
        [Validation("2.01", "09/09/2019")]
        class Married
        {

        }

        [Validation("4.01", "09/09/2019")]
        public class User
        {
            
        }
        static void Main(string[] args)
        {
            User user = new User();
            Person person = new Person();
            Human human = new Human();
            Boozer boozer = new Boozer();
            Married married = new Married();
           
            Type [] type = new Type[]
            {
            typeof(User),
            typeof(Person),
            typeof(Human),
            typeof(Boozer),
            typeof(Married)
            };
            //object[] attx = type.GetCustomAttributes(false);
            //type = typeof(Person);
            //att = type.GetCustomAttributes(false);

            for (int i = 0; i < type.Length; i++)
            {

                object[] att = type[i].GetCustomAttributes(false);
                foreach (ValidationAttribute validation in att)
                {
                    if (Convert.ToDateTime(validation.release) >= Convert.ToDateTime("01/09/2019") || validation.version.Equals("7.01"))
                        Console.WriteLine(validation.ToString());
                }
            }
    
            
        }
        
    }
}
