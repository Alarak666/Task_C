using System;
using Personal.Teacher;
using Personal.Director;
namespace School
{
    //    Создайте библеотеку, с пространством имен ‘Силиконовая долина’...В данной библиотеке
    //опишите классы ‘Сигвей’, ‘Умные часы’, ‘Колайдер’....При описание классов, добавить
    //модификаторы доступа internal и internal protected....Соответственно, создать консольное
    //приложение и воспользоваться...попытаться воспользоваться классами и их методами из
    //библиотеки ‘Силиконовая долина’
    class Program
    {
        static void Main(string[] args)
        {
            Maths maths = new Maths("Абрам", 20f, "Математика",100);
            History history = new History("Оля", 20f, "История");
            maths.teaching();
            history.teaching();
            Director director = new Director();
            director.SalaryPerson(maths.salary);
            
        }
    }
}
