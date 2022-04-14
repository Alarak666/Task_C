using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections;

namespace SERVER
{
    [ServiceContract]
    interface IService
    {
        [OperationContract]
        void Message();
        [OperationContract]
        int GetSum(int a, int b);
        [OperationContract]
        float GetCash();
        [OperationContract]
        ArrayList OutputOnMonitor();
        [OperationContract]
        void addBook(string name, float price, string ganre);
        [OperationContract]
        float SellBook(string name);
    }
    [DataConract]
    class Bookshop
    {
        [DataMember]
        private float cash;
        [DataMember]
        public string name_book;
        [DataMember]
        public string name_ganre;
        public float Cash
        {
            get
            {
                return cash;
            }
            set
            {
                cash = value;
            }
        }
        Book[] books = new Book[]
       {
                new Book ("Алфавит",10.3f,"Обучение"),
                new Book ("Алфавит_1",20.4f,"Обучение"),
                new Book ("Алфавит_1",30.5f,"Обучение")
       };
        [OperationContractAttribute]
        public void ShowCash()//
        {
            Console.WriteLine($"Касса {cash}");
        }
        [OperationContractAttribute]
        public void addBook(string name, float price, string ganre)//
        {
            Array.Resize(ref books, books.Length + 1);
            Array.Reverse(books);
            books[0] = new Book(name, price, ganre);
            Array.Reverse(books);
        }
        [OperationContractAttribute]
        public void OutputOnMonitor()//
        {
            foreach (var a in books)
            {
                Console.WriteLine($"Книга:{a.Name},Стоимость:{a.Price},Жанр{a.Ganre}");
            }
        }
        [OperationContractAttribute]
        public void SellBook(string name)//
        {
            int index = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (name == books[i].Name)
                {
                    Console.WriteLine($"Продаем книгу:{books[i].name}, Стоимость:{books[i].price}");
                    cash += books[i].Price;
                    for (int j = i; j > books.Length - 1; j++)
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
        [OperationContractAttribute]
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
    [DataConract]
    class Book
    {
        [DataMember]
        public string name;
        [DataMember]
        public float price;
        [DataMember]
        public string ganre;

        public Book(string name, float price, string ganre)
        {
            this.name = name;
            this.price = price;
            this.ganre = ganre;
        }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
    public int GetSum(int a, int b)
    {
        return a += b;
    }

    public void Message()
    {
        Console.WriteLine("Connect");
    }
}
class Services : IService
    {
        Bookshop bookshop = new Bookshop();
        [DataMember]
        Book[] books = new Book[]
        {
            new Book ("Алфавит",10.3f,"Обучение"),
            new Book ("Алфавит_1",20.4f,"Обучение"),
            new Book ("Алфавит_1",30.5f,"Обучение")
        };
        public float GetCash()
        {
          return bookshop.Cash;
        }
        public ArrayList OutputOnMonitor()
        {
            ArrayList list = new ArrayList();
            
            foreach (var a in books)
            {
                list.Add($"Книга:{a.name},Стоимость:{a.Price},Жанр{a.Ganre}");
                
            }
            return list;
        }
        public void addBook(string name, float price, string ganre)
        {
            Array.Resize(ref books, books.Length + 1);
            Array.Reverse(books);
            books[0] = new Book(name, price, ganre);
            Array.Reverse(books);
        }
        public float SellBook(string name)//
        {
            int index = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (name == books[i].Name)
                {
                    Console.WriteLine($"Продаем книгу:{books[i].name}, Стоимость:{books[i].price}");
                    bookshop.Cash += books[i].Price;
                    for (int j = i; j > books.Length - 1; j++)
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
            return bookshop.Cash;
        }
        public int GetSum(int a, int b)
        {
            return a + b;
        }
        public void Message()
        {
            Console.WriteLine("CONECT");
        }
    }
    class Server
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:6666/IService");
            BasicHttpBinding binding = new BasicHttpBinding();
            Type contract = typeof(IService);
            ServiceHost service = new ServiceHost(typeof(Services));
            service.AddServiceEndpoint(contract, binding, address);
            service.Open();
            Console.WriteLine("Service, Open");
            int disconect = 0;
            do
            {
                Console.ReadLine();
            } while (disconect < 0);
        }
    }
}
