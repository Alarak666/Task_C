using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel; 
using System.Text;

namespace ClassLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        List<User> users = new List<User>();
        int next_Id = 1;
        public int Connect(string name)
        {
            User user = new User()
            {
                id = next_Id,
                Name = name,
                operationContext = OperationContext.Current
            };
            next_Id++;
            users.Add(user);
            SendMess(user.Name + "COnnect",0);
            return user.id;
        }
        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.id == id);
            if(user != null)
            {
                users.Remove(user);
                SendMess(user.Name + "Exit", 0);
            }
        }
        public void SendMess(string msg, int id)
        {
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = users.FirstOrDefault(i => i.id == id);
                if (user != null)
                    answer += $": {user.Name}";
                answer += msg;
                item.operationContext.GetCallbackChannel<IServecCallback>().MsgCallback(answer);
            }
        }

    }
}
