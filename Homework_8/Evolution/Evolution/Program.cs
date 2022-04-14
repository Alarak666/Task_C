
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Evolution
{
    //    (обязательно ) Используя наследования или интерфейсы, реализуйте эволюцию... Телефон-
    //> телефон с радио->телефон который отправляет SMS->мобильный телефон с чернобелым
    //экраном-> мобильный телефон с цветным экраном->Iphone->GOOGLE Glass> ->умные
    //часы////Задача на вашу фантазию.
    class Program
    {
        interface Iradioable
        {
            string music(int frequency);
        }
        interface ISMS
        {
            string sendLetter(string name, string sms);
        }
        interface IInstagram
        {
            void news();
        }
        interface Icall
        {
            void call(string name);
            class Motorola : Iradioable, ISMS
            {
                ArrayList musicList = new ArrayList();
                ArrayList contact = new ArrayList();
                public string music(int frequency)
                {
                    addMusic();
                    string play;
                    play = (string)musicList[0];
                    for (int i = 0; i < musicList.Count; i++)
                    {
                        if (frequency == i)
                            return Convert.ToString(musicList[i]);
                    }
                    return play;
                }
                public void addMusic()
                {
                    musicList.Add("Panzerkampf");
                    musicList.Add("Deutschland");
                    musicList.Add("Bismarck");
                }
                public void contacts()
                {
                    contact.Add("Антон");
                    contact.Add("Вадим");
                    contact.Add("Сергей");
                }
                public string sendLetter(string name, string sms)
                {
                    contacts();
                    for (int i = 0; i < contact.Count; i++)
                    {
                        if (Convert.ToString(contact[i]) == name)
                            return $"Пользователь: {name}\nСообщение отправленно:\n{sms}";
                    }
                    return ("Нету пользователя с таким именем");
                }
            }
            class Nokia666 : ISMS, Iradioable, IInstagram
            {
                ArrayList musicList = new ArrayList();
                ArrayList contact = new ArrayList();
                public string music(int frequency)
                {
                    addMusic();
                    string play;
                    play = (string)musicList[0];
                    for (int i = 0; i < musicList.Count; i++)
                    {
                        if (frequency == i)
                            return Convert.ToString(musicList[i]);
                    }
                    return play;
                }
                public void addMusic()
                {
                    musicList.Add("Panzerkampf");
                    musicList.Add("Deutschland");
                    musicList.Add("Bismarck");
                }
                public void contacts()
                {
                    contact.Add("Антон");
                    contact.Add("Вадим");
                    contact.Add("Сергей");
                }
                public string sendLetter(string name, string sms)
                {
                    contacts();
                    for (int i = 0; i < contact.Count; i++)
                    {
                        if (Convert.ToString(contact[i]) == name)
                            return $"Пользователь: {name}\nСообщение отправленно:\n{sms}";
                    }
                    return ("Нету пользователя с таким именем");
                }
                public void news()
                {
                    Console.WriteLine("Новости");
                }
            }
            class SamsungX : ISMS, Iradioable, IInstagram, Icall
            {
                ArrayList musicList = new ArrayList();
                ArrayList contact = new ArrayList();
                public string music(int frequency)
                {
                    addMusic();
                    string play;
                    play = (string)musicList[0];
                    for (int i = 0; i < musicList.Count; i++)
                    {
                        if (frequency == i)
                            return Convert.ToString(musicList[i]);
                    }
                    return play;
                }
                public void addMusic()
                {
                    musicList.Add("Panzerkampf");
                    musicList.Add("Deutschland");
                    musicList.Add("Bismarck");
                }
                public void contacts()
                {
                    contact.Add("Антон");
                    contact.Add("Вадим");
                    contact.Add("Сергей");
                }
                public string sendLetter(string name, string sms)
                {
                    contacts();
                    for (int i = 0; i < contact.Count; i++)
                    {
                        if (Convert.ToString(contact[i]) == name)
                            return $"Пользователь: {name}\nСообщение отправленно:\n{sms}";
                    }
                    return ("Нету пользователя с таким именем");
                }
                public void news()
                {
                    Console.WriteLine("Новости");
                }

                public void call(string name)
                {
                    contacts();
                    for (int i = 0; i < contact.Count; i++)
                    {
                        if (Convert.ToString(contact[i]) == name)
                        {
                            Console.WriteLine(name + " Соиденение");
                            Thread.Sleep(5000);
                            Console.WriteLine(name + " Hello");
                            Thread.Sleep(2000);
                            Console.WriteLine("Good bye");
                        }
                    }
                }
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Моторола\n");
                Iradioable iradioable = new Motorola();
                Console.WriteLine(iradioable.music(2));
                ISMS sMS = new Motorola();
                Console.WriteLine(sMS.sendLetter("Антон", "Пора на роботу"));
                //
                Console.WriteLine("\nNokia666\n");
                Iradioable iradioable1 = new Nokia666();
                Console.WriteLine(iradioable1.music(3));
                ISMS sms1 = new Nokia666();
                Console.WriteLine(sms1.sendLetter("Антон", "Пора на роботу"));
                IInstagram instagram = new Nokia666();
                instagram.news();
                //
                Console.WriteLine("\nSamsungX\n");
                Iradioable iradioable2 = new SamsungX();
                Console.WriteLine(iradioable2.music(5));
                ISMS sms2 = new SamsungX();
                Console.WriteLine( sms2.sendLetter("Антон", "Пора на роботу"));
                IInstagram instagram1 = new SamsungX();
                instagram1.news();
                Icall call = new SamsungX();
                call.call("Антон");
            }
        }
    }
}
