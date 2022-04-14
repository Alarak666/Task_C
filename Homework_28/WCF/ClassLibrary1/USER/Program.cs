using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace USER
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CLIENT";

            // Указание, где ожидать входящие сообщения.
            Uri address = new Uri("http://localhost:4000/SERVER/IService1");  // ADDRESS.   (A)

            // Указание, как обмениваться сообщениями.
            BasicHttpBinding binding = new BasicHttpBinding();         // BINDING.   (B)

            // Создание Конечной Точки.
            EndpointAddress endpoint = new EndpointAddress(address);

            // Создание фабрики каналов.
            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(binding, endpoint);  // CONTRACT.  (C) 

            // Использование factory для создания канала (прокси).
            IService1 channel = factory.CreateChannel();

            // Использование канала для отправки сообщения получателю.
            var mess = channel.Connect("WCF");
           // var otvet = channel.Calc(2, 3, '*');
            Console.WriteLine(mess);
          //  Console.WriteLine(otvet);
            // Задержка.
            Console.ReadKey();
        }
    }
}
