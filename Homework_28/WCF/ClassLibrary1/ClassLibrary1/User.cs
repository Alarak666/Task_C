using System;
using System.ServiceModel;
namespace ClassLibrary1
{
    class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public OperationContext operationContext { get; set; }

    }
}
