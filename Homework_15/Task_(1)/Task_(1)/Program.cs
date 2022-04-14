using System;

namespace Task_1
{
    //У вас есть класс Товар...вам необходимо попробывать разную реализацию метода Clone
    //(глубокое/поверхностое клонирование).... У Товар есть поле Адрес –это класс а у Адреса
    //есть поле City, city – это тоже класс.

    class Product : ICloneable
    {
        public string product { get; set; }
        public Address address { get; set; }
        public City city { get; set; }
        public object Clone()
        {

            Address address = new Address { name = this.address.name};
            City city = new City { name = this.city.name };
            return new Product()
            {
                product = product,
                address = address,
                city = city
            };
        }
        public object CloneMemberWiseClone()
        {

            return MemberwiseClone();
        }
    }
    class Address
    {
        public string name { get; set; }
    }
    class City
    {
        public string name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product() { product = "Product_1", address = new Address()
                                            { name = "Ottava_1" }, city = new City()
                                            { name = "Washington" } 
                                            };
            Product clone = product.Clone() as Product;
            clone.address.name = "sdsd"; 
            Console.WriteLine("Глубокое клонирование");
            Console.WriteLine($"Назва продукту: {product.product};\nАдреса: {product.address.name};\nГород: {product.city.name};\n");
            Console.WriteLine($"Назва продукту: {clone.product};\nАдреса: {clone.address.name};\nГород: {clone.city.name};\n");
            Console.WriteLine("Поверхностное клонирование");
            Product cloneW = product.CloneMemberWiseClone() as Product;
            cloneW.address.name = "sdsd";
            Console.WriteLine($"Назва продукту: {product.product};\nАдреса: {product.address.name};\nГород: {product.city.name};\n");
            Console.WriteLine($"Назва продукту: {cloneW.product};\nАдреса: {cloneW.address.name};\nГород: {cloneW.city.name};\n");
        }
    }
}
