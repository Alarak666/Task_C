using System;
using System.Linq;
using System.Collections.Generic;
namespace Task_1
{
    //    Создайте коллекцию автомобилей(марка автомобиля, год выпуска, цвет) ... И создавать
    //коллекцию владельцев(марка автомобиля, имя покупателя и его номер телефона.).. ....
    //Используя LINQ запрос, (запрос с join) выведите на экран имя покупателя и его номер
    //телефона, марка автомобиля, год выпуска, цвет...Причем результат должен отсортирован
    //по именам владельцев
    class Program
    {
        class Car
        {
            public enum Color
            {
                Red,
                Blue,
                Orange,
                Pink,
                Purpo
            }
            public string marka;
            public int year;
            public Car(string marka, int year, Color colar)
            {
                this.marka = marka;
                this.year = year;
                Color color = colar;
            }
        }
        class Owner
        {
            public string marka;
            public string name;
            public string phone;
            public Owner(string marka, string name, string phone)
            {
                this.marka = marka;
                this.name = name;
                this.phone = phone;
            }
        }
        static void Main(string[] args)
        {
            List<Owner> owners = new List<Owner>()
            {
                new Owner("BMW", "Гусак", "38066666666"),
                new Owner("BMW_1", "Антон", "38066661666"),
                new Owner("BMW_2", "Валера", "38066662666"),
            };
            List<Car> cars = new List<Car>()
            {
                new Car("BMW", 1970, Car.Color.Blue),
                new Car("BMW_1", 1971, Car.Color.Red),
                new Car("BMW_2", 1972, Car.Color.Pink),
            };
            var result = from car in cars
                         join owner in owners on car.marka equals owner.marka
                         orderby owner.name
                         select new { Name = owner.name, Phone = owner.phone, Marka = car.marka, Year = car.year }

            ;
            foreach (var item in result)
            {
                Console.WriteLine($"Владелец: {item.Name}, Номер: {item.Phone}\n Марка: { item.Marka}, Год: { item.Year}");
            }
        }
    }
}
