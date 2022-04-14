using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_3
{
    class Program
    {
        //3.Создайте класс Tovar, с необходимыми полями....Переопределите методы Equals и
        //GetHashCode, таким образом, чтобы если товары одного названия, типа и цены то они равны.И
        // далее сделать HAshTable, в которой ключами будут товары, а значения экземпляр класса
        // Поставщик
        class Tovar 
        {
            private string name { get; set; }
            private int price { get; set; }
            private string type { get; set; }
            public Tovar(string name, int price, string type)
            {
                this.name = name;
                this.price = price;
                this.type = type;
            }

            public override bool Equals(object obj)
            {
                if (obj is Tovar && this.name == (obj as Tovar).name && this.price == (obj as Tovar).price && this.type == (obj as Tovar).type)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override int GetHashCode()
            {
                return name.GetHashCode() + price.GetHashCode() + type.GetHashCode();
            }
            public override string ToString()
            {
                return $"name: {name}";
            }
        }

        class Provider
        {
            string name { get; set; }

            public Provider(string name)
            {
                this.name = name;
            }
        }

        class HashTableOfTovars : Hashtable
        {
            Hashtable tovars = new Hashtable();
        }

        static void Main(string[] args)
        {
            Tovar[] tovars = new Tovar[]
            {
                new Tovar("Макарони", 10, "Премиум"),
                new Tovar("Пирожки", 12, "Высший сорт"),
                new Tovar("Пирожки", 12, "Высший сорт"),
                new Tovar("Макарони", 15, "3-сорт"),
            };
            Provider[] providers = new Provider[]
            {
                new Provider("Borsch"),
                new Provider("Milka"),
                
            };

            Hashtable hash_table = new Hashtable();
            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < tovars.Length; ++i)
                {
                    if (tovars[i].Equals(tovars[j]))
                        hash_table.Add(tovars[i].GetHashCode(), providers[i]);
                }
            }
        
            foreach ( var keys in hash_table.Keys)
            {
                Console.WriteLine(keys + " "+ hash_table[keys].ToString());
            }
        }
    }
}
