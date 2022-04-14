using System;
using System.Collections;

namespace Task_1
{
    //    (не обязательная задача) Описать структуру денежная банкнота...У банкноты есть номинал
    //и тип валюты(номинал - это перечисление со значениями 1,5,10,20 и т.д.),тип валюты –это
    //перечисление со зачениями :eur,usd,грн)...Т.е банкнота может быть 100 долларов или 10
    //гривен и т.д....а так же у вас есть класс Касса...Вам необходимо:
    // Реализовать в Кассе метод Add, для добавление банкноты в кассу.
    // Реализовать метод который будет возвращать количество купюр определенного
    //номинала конкретной валюты..Например, вы хотите подсчитать сколько у вас
    //100-доларовых бумажек или бумажек 5 гривен
    // Реализовать метод, в который вы передаете курс доллара и евро...Данный
    //метод возвращает сколько денег в кассе в гривнах....Т.е.доллары и евро надо
    //будет конвертировать.
    // Реализовать метод, в который вы передаете курс доллара и евро...Данный
    //метод возвращает сколько денег в кассе в гривнах или в евро или в
    //долларах....т.е.усложнить предыдущее решение.
    struct Banknote
    {
        public enum Nominal
        {
            ONE = 1,
            FIVE = 5,
            TEN = 10,
            TWENTY = 20,
            FIFTY = 50,
            HUNDRED = 100
        }

        public enum Currency
        {
            EUR,
            USD,
            UAH,
            RUB
        }

        public Nominal nominal;
        public Currency currency;

        public Banknote(Nominal nominal, Currency currency)
        {
            this.nominal = nominal;
            this.currency = currency;
        }
    }
    class Bankomat
    {
        private Banknote[] banknotes;
        private int index = 0;
        public Bankomat()
        {
            banknotes = new Banknote[]
            {
                new Banknote(Banknote.Nominal.HUNDRED, Banknote.Currency.EUR),
                new Banknote(Banknote.Nominal.HUNDRED, Banknote.Currency.EUR),
                new Banknote(Banknote.Nominal.HUNDRED, Banknote.Currency.EUR),
                new Banknote(Banknote.Nominal.HUNDRED, Banknote.Currency.EUR),
            };
        }
        public void Add(Banknote banknote)
        {
            index = banknotes.Length;
            Array.Resize(ref banknotes, banknotes.Length + 1);
            banknotes[index] = banknote;
        }
        public void Show()
        {
            for (int i = 0; i < banknotes.Length; i++)
            {
                Console.WriteLine($"Валюта: {banknotes[i].currency}, Номинал: {banknotes[i].nominal}");
            }
        }
        public string CountMoney(Banknote banknote)
        {
            int count = 0;

            for (int i = 0; i < banknotes.Length; ++i)
            {
                if (banknotes[i].nominal == banknote.nominal && banknotes[i].currency == banknote.currency)
                {
                    ++count;
                }
            }
            return $"Валюта: {banknote.currency}, Номинал: {banknote.nominal},  Количество: {count}";
        }
        public void SumOfMoney(float euroCourse, float dollarCourse)
        { 
            float eurCourse = 0, usdCourse = 0, uahCourse = 0;

            for (int i = 0; i < banknotes.Length; ++i)
            {
                if (banknotes[i].currency == Banknote.Currency.EUR)
                {
                    uahCourse += Convert.ToInt32(banknotes[i].nominal) * euroCourse;
                }
                else if (banknotes[i].currency == Banknote.Currency.USD)
                {
                    uahCourse += Convert.ToInt32(banknotes[i].nominal) * dollarCourse;
                }
                else
                {
                    uahCourse += Convert.ToInt32(banknotes[i].nominal);
                }
            }
            eurCourse = uahCourse / euroCourse;
            usdCourse = uahCourse / dollarCourse;
            Console.WriteLine("Курс евро: " + euroCourse);
            Console.WriteLine("Курс доллара: " + dollarCourse);
            Console.WriteLine("Кол-во бабок в евро: " + eurCourse);
            Console.WriteLine("Кол-во бабок в долларах: " + usdCourse);
            Console.WriteLine("Кол-во бабок в гривнах: " + uahCourse);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = Banknote.Nominal.HUNDRED;
            var b = Banknote.Currency.EUR;
            Bankomat bankomat = new Bankomat();
            bankomat.Add(new Banknote(Banknote.Nominal.HUNDRED, Banknote.Currency.EUR));
            bankomat.Add(new Banknote(Banknote.Nominal.FIVE, Banknote.Currency.EUR));
            bankomat.Add(new Banknote(Banknote.Nominal.HUNDRED, Banknote.Currency.UAH));
            bankomat.Add(new Banknote(Banknote.Nominal.HUNDRED, Banknote.Currency.USD));
            bankomat.Show();
            Console.WriteLine("Банкнот: " + bankomat.CountMoney(new Banknote(a , b)));
            bankomat.SumOfMoney(21f,43f);
        }
    }
}
