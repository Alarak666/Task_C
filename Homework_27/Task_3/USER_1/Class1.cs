using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace USER_1
{
    public class Message : MarshalByRefObject
    {
        public void Read()
        {
            Console.WriteLine("Читать сообщение");
        }
        public void Write()
        {
            Console.WriteLine("Писать сообщение");
        }
        public void Operation()
        {
            Console.WriteLine("Operation DomainId : {0}", AppDomain.CurrentDomain.Id);
            Console.WriteLine("Operation ThreadId : {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
