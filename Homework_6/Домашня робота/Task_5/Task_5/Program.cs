using System;

namespace Task_5
{
    class Program
    {
        //Создать класс автомобиль..У него есть модель, год, цвет, цена...Создать
        //массив экземпляров класса автомобиль...Вывести модель и цвет
        //автомобилей которым меньше 10 лет и с ценой меньше 200000
       enum Color
       {
            Red,
            Grey,
            Blue,
            Dark,
            Green,
            Yellow,
            Pink
       }
        class Car
        {
            public string model;
            public int year;
            public int price;
            public Color color;
            public Car(string model, int year, int price, Color color)
            {
                this.model = model;
                this.year = year;
                this.price = price;
                this.color = color;
            }
            public int Year
            {
                get { return year; }
            }
            public int Price
            {
                get { return price; }
            }
            public void Cars()
            { 
                Console.WriteLine($"Модель:{model}\n  Год:{year}\n  Цена:{price}\n  Цвет:{color}");
            }
        }
        
        static void Main(string[] args)
        {
            Car[] car = new Car[5];
            car[0] = new Car("BMW1", 1, 250000, Color.Red);
            car[1] = new Car("BMW2", 2, 50000, Color.Green);
            car[2] = new Car("BMW3", 11, 2000, Color.Pink);
            car[3] = new Car("BMW4", 12, 21000, Color.Yellow);
            car[4] = new Car("BMW5", 5, 50000, Color.Grey);
            for (int i = 0; i < car.Length; i++)
            {
                if (car[i].Price < 200000 && car[i].Year > 10)
                    car[i].Cars();
            }
        }
    }
}
