using System;

namespace Task_1
{
    //    Вам необходимо описать класс книжный магазин...В нем вы описуете поле которое
    //содержит массив книг...Книга – это структура, в которой описаны поля: название, автор,
    //жанр,цена...Вам необходимо:
    // Описать индексатор, в который вы передаете имя автора, а индексатор вам
    //возвращает название книги, первой попавшейся.
    // Описать индексатор, в который вы передаете жанр, и цену а индексатор вам
    //возвращает массив книг этого жанра с указанной или менее ценой.
    // В класс книжный магазин, добавить метод Add, который будет в массив книг
    //добавлять очередную книгу.
    struct Book
    {
        public string name;
        public string avtor;
        public string ganre;
        public int price;
        public Book(string name, string avtor, string ganre, int price)
        {
            this.name = name;
            this.avtor = avtor;
            this.ganre = ganre;
            this.price = price;
        }
    }
    class BookCase
    {
        Book[] books;
        public BookCase() 
        {
            books = new Book[] 
            {
                new Book("Алфавит_1","Университет_Кулиша","Обучение",10),
                new Book("Алфавит_2","Университет_Суворова","Обучение",20),
                new Book("Алфавит_3","Университет_Кутузова","Обучение",30),
                new Book("Алфавит_4","Университет","Обучение",40)
            };
        }
      
        public void ShowBook()
        {
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"Книга_№ {i+1}\n{new string(' ', 5)}Название: {books[i].name}, Автор: {books[i].avtor}, Жанр: {books[i].ganre}, Стоимость: {books[i].price}");
            }
        }
        public string this[string index]
        {
            get
            {
                for (int i = 0; i < books.Length; i++)
                    if (books[i].avtor == index)
                        return books[i].name;
                    return $"Нету такой книги {index}";
            }
        }
        public string this[string ganre, int price]
        {
            get
            {
                int j = 0;
                for (int i = 0; i < books.Length; i++)
                    if (books[i].ganre == ganre && books[i].price <= price)
                    {
                        j++;
                        Console.WriteLine($"Название: {books[i].name}, Автор: {books[i].avtor}, Жанр: {books[i].ganre}, Стоимость: {books[i].price}");
                    }
                    if (j > 0) return $"Все книги цена которых меньша {price}, с жанром {ganre}";
                return $"Или жанр не тот, {ganre}, или цена большая :3{price}";
            }
        }
        public Book this[int index]
        {
            set
            {
                if (index != books.Length)
                {
                    Array.Resize(ref books, books.Length+1);
                    books[index-1].name = value.name;
                    books[index-1].avtor = value.avtor;
                    books[index-1].ganre = value.ganre;
                    books[index-1].price = value.price;
                }
                else
                    Console.WriteLine("Место занято");   
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BookCase bookCase = new BookCase();
            Console.WriteLine(bookCase["Университет_Суворова"]);
            Console.WriteLine(bookCase["Университет_Суворва"]);
            bookCase.ShowBook();
            Console.WriteLine("\n" + bookCase["Обучение", 33]);
            bookCase[5] = new Book { name = "GG", avtor = "SS", ganre = "GR", price = 1000 };
            Console.WriteLine("С новой книгой _)");
            bookCase.ShowBook();
        }
    }
}
