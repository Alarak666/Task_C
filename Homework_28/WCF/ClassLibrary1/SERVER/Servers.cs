using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SERVER;

namespace SERVER
{
  
    class Servers : IService1
    {
        public string Calc (int opr1, int opr2, char symbol)
        {
            float otvet;
            switch (symbol)
            {                
                case '+':
                    otvet = opr1 + opr2;
                    return $"{opr1} + {opr2} = {otvet}";
                case '-':
                    otvet = opr1 - opr2;
                    return $"{opr1} - {opr2} = {otvet}";
                case '*':
                    otvet = opr1 + opr2;
                    return $"{opr1} + {opr2} = {otvet}";
                case '/':
                    if(opr2 != 0)
                    {
                        otvet = opr1 + opr2;
                        return $"{opr1} + {opr2} = {otvet}";
                    }
                    throw new NotImplementedException("Нельзя делить на 0");
                default:
                    return "Неправильное значение";
            }
        }
        public void Connect(string name)
        {
            Console.WriteLine(@"Делаем результат");
        }
    }
}
