using System;
using System.IO;
using System.IO.IsolatedStorage;


namespace IsolatedStorageFileDemo
{
    class Program
    {
        static void Main()
        {
            
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            
            string[] directories = userStorage.GetDirectoryNames("SomeDiі");

            if (directories.Length == 0)
            {
                userStorage.CreateDirectory("SomeDiі");
            }

           
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(@"SomeDiі\1.txt", FileMode.Append, userStorage);

           
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("Запись Даних");
            userWriter.Close();

            
            string[] files = userStorage.GetFileNames(@"SomeDiі\1.txt");

            if (files.Length == 0)
            {
                Console.WriteLine("No data saved for this user");
            }
            else
            {
                userStream = new IsolatedStorageFileStream(@"SomeDiі\1.txt", FileMode.Open, userStorage);

                StreamReader userReader = new StreamReader(userStream);
                string contents = userReader.ReadToEnd();
                Console.WriteLine(contents);
            }

            Console.ReadKey();
        }
    }
}