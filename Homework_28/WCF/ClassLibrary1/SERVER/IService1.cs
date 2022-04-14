using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace SERVER
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Connect(string name);
        [OperationContract]
        string Calc(int opr1, int opr2, char symbol);
    }
}
