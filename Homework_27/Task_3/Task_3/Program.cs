using System;
using System.Reflection;
using System.Runtime.Remoting;
namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
          
                AppDomain user_1 = AppDomain.CreateDomain("First");
                AppDomain user_2 = AppDomain.CreateDomain("Second");
                Assembly user = Assembly.LoadFrom("USER_1.dll");
                string assembly = user.FullName;
                Console.WriteLine(assembly);
                ObjectHandle handle = user_1.CreateInstance(assembly, "USER_1.Message");

                dynamic instance = handle.Unwrap();
                instance.Read();
                instance.Write();
                instance.Operation();
                

               
                user = Assembly.LoadFrom("USER_2.dll");
                assembly = user.FullName;
                Console.WriteLine(assembly);
                handle = user_2.CreateInstance(assembly, "USER_2.Class1");

                instance = handle.Unwrap();
                instance.Read();
                instance.Write();
                instance.Operation();
                Console.ReadKey();

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
      
    }
}
//AppDomain domain = AppDomain.CreateDomain("Second");
//string assembleName = Assembly.GetExecutingAssembly().GetName().Name;// (@"USER_1.dll").GetName().Name;
//string nametype = typeof(USER_1.Message).FullName;
//Console.WriteLine(assembleName);
//USER_1.Message.Read();
//USER_2.Class1.Read();
//Assembly[] assemblies = domain.GetAssemblies();
//foreach (Assembly asm in assemblies)
//{
//    Console.WriteLine(asm.GetName().Name);
//}
//try
//{
//    ObjectHandle handle = domain.CreateInstance(assembleName, nametype);
//    USER_1.Message instance = handle.Unwrap() as USER_1.Message;
//    instance.Operation();
//}
//catch(Exception e)
//{
//    Console.WriteLine(e.Message);
//}