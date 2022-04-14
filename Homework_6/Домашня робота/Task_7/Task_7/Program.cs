using System;
using System.IO;

namespace Task_7
{
    class Program
    {
        class Bookshop 
        {
            private float cash;
            public string name_book ;
            public string name_ganre;
            Book[] books = new Book[]
           {
                new Book ("Алфавит",10.3f,"Обучение"),
                new Book ("Алфавит_1",20.4f,"Обучение"),
                new Book ("Алфавит_1",30.5f,"Обучение")
           };
            public void ShowCash()
            {
                Console.WriteLine($"Касса {cash}");
            }
            public void addBook(string name, float price, string ganre)
            {
                Array.Resize(ref books, books.Length + 1);
                Array.Reverse(books);
                books[0] = new Book(name, price, ganre);
                Array.Reverse(books);
            }
            public void OutputOnMonitor()
            {
                foreach (var a in books)
                {
                    Console.WriteLine($"Книга:{a.Name},Стоимость:{a.Price},Жанр{a.Ganre}");
                }
            }
            public void SellBook (string name)
            {
                int index = 0;
                for (int i = 0; i < books.Length; i++)
                {
                    if (name == books[i].Name)
                    {
                        Console.WriteLine($"Продаем книгу:{books[i].name}, Стоимость:{books[i].price}");
                        cash += books[i].Price;
                        for (int j = i; j > books.Length-1; j++)
                        {
                            books[j] = books[j + 1];
                        }
                        Array.Resize(ref books, books.Length - 1);
                    }
                    else
                        index++;
                }
                if (books.Length == index)
                    Console.WriteLine("Такой книги нету");
            }
            public void moneyUp(string ganre)
            {
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i].ganre == ganre)
                    {
                        books[i].price *= 1.2f;
                    }
                }
            }
        }
        class Book
        {
            public string name;
            public float price;
            public string ganre;
            public Book() { }
            public Book(string name, float price, string ganre)
            {
                this.name = name;
                this.price = price;
                this.ganre = ganre;
            }

            public string Name 
            { 
                get 
                { 
                    return name; 
                } 
                set 
                { 
                    name = value;
                } 
            }
            public string Ganre 
            { 
                get 
                { 
                    return ganre; 
                } 
                set 
                { 
                    ganre = value; 
                } 
            }
            public float Price
            {
                get
                {
                    return price;
                }
                set
                {
                    price = value;
                }
            }
            
        }
        static void Main(string[] args)
        {
            Bookshop bookshop = new Bookshop();
            //bookshop.addBook("safa", 12.4f, "df");
            //bookshop.OutputOnMonitor();
            //bookshop.SellBook(bookshop.name_book = "safa");
            //Console.WriteLine();
            //bookshop.OutputOnMonitor();
            //Console.WriteLine();
            //bookshop.ShowCash();
            //Console.WriteLine();
            //bookshop.SellBook(bookshop.name_book = "safa");
            //Console.WriteLine();
            //bookshop.OutputOnMonitor();
            //bookshop.moneyUp(bookshop.name_ganre = "Обучение");
            //bookshop.OutputOnMonitor();

            bool work = true;
            int chang = new int();
            Console.WriteLine("1 - Add; 2-sell; 3- Cash; 4-OutMonitor 5 - Exit");
            do
            {
                Console.WriteLine("ШО дальше?");
                chang = int.Parse(Console.ReadLine());
                switch (chang)
                {
                    case 1 :
                        string name;
                        float price;
                        string ganre;
                        Console.WriteLine(@"Введiть назву книги");
                        name = Console.ReadLine();
                        Console.WriteLine(@"Введiть Цiну");
                        price = float.Parse(Console.ReadLine());
                        Console.WriteLine(@"Введiть Жанр");
                        ganre = Console.ReadLine();
                        bookshop.addBook(name,price,ganre);
                        break;
                    case 2:
                        Console.WriteLine(@"Продать книгу");
                        Console.WriteLine(@"Введiть назву книги");
                        name = Console.ReadLine();
                        bookshop.SellBook(name);
                        break;
                    case 3:
                        Console.WriteLine(@"Всi книги_)");
                        bookshop.ShowCash();
                        break;
                    case 4:
                        bookshop.OutputOnMonitor();
                        break;
                    default :
                        work = false;
                        break;
                }
            } while (work);
        }
    }
}
