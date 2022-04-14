using System;

namespace Task_1
{
    class Program
    {
        //Дан массив товаров(Товар это класс)....Дан массив покупателей(Покупатель это
        //класс)...Каждый покупатель просссматривает массив товаров и ложит себе в корзину товар
        //на который хватает денег...(и конечно у покупателя денежка уменьшается)...В конце
        //вывести инофрмацию о каждом покупателе...на какую сумму скупился и что купил.
        
        class Product
        {

            public string name;
            public float price;
            public int qty;
            public string description;
            public Product(string name, float price, int qty, string description)
            {
                this.name = name;
                this.price = price;
                this.qty = qty;
                this.description = description;
            }
            public static void Addtovar(ref Product[] products, string name, float price, int qty, string description)
            {
                Array.Resize(ref products, products.Length + 1);
                for (int i = products.Length-1; i < products.Length; i++)
                {
                    products[i] = new Product(name, price, qty, description);
                }
            }
            public void ShowTovar()
            {
                Console.WriteLine($"Товар:{name}, Цена:{price}, Количество:{qty}, Описание:{description};");
            }
        }
        class Customer
        {
            public string customerName;
            private float cash;
            public string sellProduct ;

            public Customer(string customerName, float cash)
            {
                this.customerName = customerName;
                this.cash = cash;
            }
            public void Buy (Product[] products)
            { 
                for (int i = 0; i < products.Length; i++)
                {
                    if (cash > products[i].price)
                    {
                        sellProduct = products[i].name + " ";
                        cash -= products[i].price;
                        if (i == 0 )
                        Console.Write($"Покупатель:{customerName}, Купил:{sellProduct}, ");
                        Console.Write($"{sellProduct}, ");
                    }
                }
                if (sellProduct == null)
                    Console.WriteLine( "Ничего не купил " + "Денег: " + cash);
            }
        }
        static void Main(string[] args)
        {
            Customer[] customer = new Customer[]
                {
                new Customer("Anton", 123f),
                new Customer("Valera",666f)
                };
            Product[] products = new Product[]
                {
                new Product("Консерва",21f,10,"Тунец"),
                new Product("Консерва",11f,10,"Таранька"),
                new Product("Макароны",20f,10,"ItAlIaNo"),
                new Product("Макароны",21f,10,"ItAlIaNa"),
                new Product("Вода",1f,10,"Coca-cola"),
                new Product("Вода",10f,10,"Pepsi"),
                new Product("Гречка",40f,10,"Премиум"),
                new Product("фейерверк",20f,10,"Атлант"),
                new Product("фейерверк",110f,10,"Атлантик"),
                };
            Product.Addtovar(ref products, "Макароны", 4, 12, "Украина");
            for (int i = 0; i < products.Length; i++)
            {
                products[i].ShowTovar();
            }

            for (int i = 0; i < customer.Length; i++)
            {

                customer[i].Buy(products);
            }
        }
    }
}
