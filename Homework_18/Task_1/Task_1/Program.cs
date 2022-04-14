using System;
using System.Linq;
using System.Collections.Generic;
namespace Task_1
{
     //Создайте коллекцию продуктов со следующими данными: Код товара, название товара,тип
     //товара, цена.... Используя LINQ запрос, выведите на экран код товара с ценой выше 30.
    class Program
    {
        class Product
        {
            public int code;
            public string name;
            public int price;
            public string type;
            public Product(int code, string name, int price, string type)
            {
                this.code = code;
                this.name = name;
                this.price = price;
                this.type = type;
            }
        }
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>() 
            {
                new Product(1, "Макарони", 120,"1-сорт"),
                new Product(1, "Макарони_1", 110,"2-сорт"),
                new Product(1, "Макарони_2", 100,"3-сорт"),
                new Product(1, "Макарони_3", 29,"4-сорт"),
            };
            var result = from product in products
                         where product.price < 30
                         select new {Code = product.code, Name = product.name};
            foreach (var item in result)
            {
                Console.WriteLine($"Код: {item.Code}, Номер: {item.Name}");
            }
        }
    }
}
