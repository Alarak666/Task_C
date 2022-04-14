using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;

namespace CLIENT
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
    class CLIENT
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:6666/IService");
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(address);
            ChannelFactory<IService> factory = new ChannelFactory<IService>(binding, endpoint);
            IService channel = factory.CreateChannel(endpoint, address);
            Console.WriteLine("GO-GO");
            Console.WriteLine(channel.GetSum(2, 3));
            Console.WriteLine(channel.GetCash());
            Console.WriteLine(channel.OutputOnMonitor());
            foreach(var a in channel.OutputOnMonitor())
            {
                Console.WriteLine($"{a} ");
            }
            channel.addBook("HHHH", 666, "GG");
            Console.WriteLine();
            foreach (var a in channel.OutputOnMonitor())
            {
                Console.WriteLine($"{a} ");
            }
            channel.OutputOnMonitor();
            Console.WriteLine();
            Console.WriteLine(channel.SellBook("Алфавит"));
            foreach (var a in channel.OutputOnMonitor())
            {
                Console.WriteLine($"{a} ");
            }
            Console.ReadKey();
        }
    }
}