using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClassLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServecCallback))]
    public interface IService1
    {
        [OperationContract]
        int Connect(string name);
        [OperationContract]
        void Disconnect(int id);
        [OperationContract (IsOneWay = true)]
        void SendMess(string msg, int id); 
    }
    public interface IServecCallback {
        [OperationContract]
        void MsgCallback(string msg);
    }
}
