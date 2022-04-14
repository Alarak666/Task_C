using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SERVER;

namespace SERVER
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";

            // Указание адреса, где ожидать входящие сообщения.
            Uri address = new Uri("http://localhost:4000/SERVER/IService1"); // ADDRESS.    (A)
            BasicHttpBinding binding = new BasicHttpBinding();        // BINDING.    (B)
            Type contract = typeof(IService1);                        // CONTRACT.   (C) 


            // Создание провайдера Хостинга с указанием Сервиса.
            ServiceHost host = new ServiceHost(typeof(Servers));

            // Добавление "Конечной Точки".
            host.AddServiceEndpoint(contract, binding, address);

            // Начало ожидания прихода сообщений.
            host.Open();
            Console.WriteLine("Приложение готово к приему сообщений.");
            Console.ReadKey();


            // Завершение ожидания прихода сообщений.
            host.Close();
        }
    }
}
