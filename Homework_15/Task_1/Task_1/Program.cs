using System;

namespace Task_1
{
    //У вас есть класс Товар...вам необходимо попробывать разную реализацию метода Clone
    //(глубокое/поверхностое клонирование).... У Товар есть поле Адрес –это класс а у Адреса
    //есть поле City, city – это тоже класс.
    
    class Product : ICloneable
    {
        public string product { get; set; }
        Address address = new Address();
        public Product(string product)
        {
            this.product = product;
            Console.Write(address.name ="Адресс: "+ "Ottava.31");
        }
        class Address 
        {
            public string name;

            City city = new City();
        public Address()
        {
            Console.Write(city.name = "Город: "+"Washington "); 
        }
       
        }
        class City
        {
            public string name;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product(" Продукт: "+"Продукт_1");
            Product clone = product.Clone() as Product;
            Console.WriteLine("\nБез изменений");
            Console.WriteLine(clone.product);
            Console.WriteLine("После изменений");
            clone.product = "Продукт_2";
            Console.WriteLine(product.product);
            Console.WriteLine($"{clone.product},  ");

        }
    }
}
