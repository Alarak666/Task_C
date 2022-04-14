using System;
using System.Collections;
using System.Collections.Generic;
namespace Task_1
{
    //    Создайте класс Сильпо....Когда вы создаете экземпляр этого класса, в методе Main, то вы
    //   указываете, являетесь вы VIP- персоной или нет...Далее передаете ваш экземпляр в
    //foreach... в foreach мы перебираем товары из Сильпо....товар(экземпляр класса
    //Товар)...Причем если вы VIP-персона, то вам показывают хамон, маракую и зефир в
    //шоколаде, а если нет то показывают просроченные сухарики и воду без газа....(попробуйте
    //решить задачу через yield)
    class Program
    {
        class User
        {
            public string name;
            public int money;
            public int ViP;
            public User(string name, int money, int ViP)
            {
                this.name = name;
                this.money = money;
                this.ViP = ViP;
            }
        }
        class Product
        {
            public string name;
            public int price;
            public byte VIP ;
            public Product(string name, int price, byte VIP)
            {
                this.name = name;
                this.price = price;
                this.VIP = VIP;
            }
        }
        class Silpo 
        {
            public List<Product> products;
            public Silpo()
            {
                products = new List<Product>();
                products.Add(new Product("Soap0", 5, 0));
                products.Add(new Product("Soap1", 10, 0));
                products.Add(new Product("Soap2", 15, 1));
                products.Add(new Product("Soap3", 20, 1));
                products.Add(new Product("Soap4", 25, 1));
                products.Add(new Product("Soap5", 30, 1));
                products.Add(new Product("Soap6", 35, 1));
                products.Add(new Product("Soap7", 40, 1));
                products.Add(new Product("Soap8", 45, 1));
            }
            public int Add(Product product)
            {
                products.Add(product);
                return products.Count;
            }
            public Product this[int index]
            {
                get
                {   if(index < products.Count)
                        return products[index];
                    return null;
                }
            }
            public IEnumerable GetProduct(User user)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].VIP == user.ViP)
                    {
                        yield return $"Название товара: {products[i].name}, Название : {products[i].price} ";
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Silpo silpo = new Silpo();
            silpo.Add(new Product("SoapVIP", 66, 1));
            User[] user = new User[]
            {
                new User("Максим", 100, 1),
                new User("Марк", 500, 0)
            };
            foreach (var product in silpo.GetProduct(user[0])) 
            {
                Console.WriteLine($"{product}");
            }
            Console.WriteLine(new string('-',30));
            foreach (var product in silpo.GetProduct(user[1]))
            {
                Console.WriteLine($"{product}");
            }
        }
    }
}
