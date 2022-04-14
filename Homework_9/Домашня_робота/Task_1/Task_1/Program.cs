using System;

namespace Task_1
{
    //Создать класс Гардероб..У него есть индексатор, где вы по номерку можете отдать или
    //получить вещь но только когда работает гардероб....У гардероба есть поле со скольки и до
    //скольки он работает....Внутри гардероба вещи хранятся в массиве string...Так как с датой
    //мы не работали то время можно задавать целым числом рандомно.
    class Program
    {
        class Wardrobe
        {
            private string[] clothe = new string[10];
            static  Random random = new Random();
            int rd = random.Next(0, 23);
            int start = 8, end = 20;// начало и конец дня
            public string this[int index]
            {
                get
                {
                    if (index < clothe.Length)
                    {
                        if (rd >= start && rd <= end)
                            return clothe[index];
                        return $"Закрыто, откроется через: {Open()}";
                    }
                    else
                        return $"Нельзя посмотреть одежду в номере: {index}, максимум: {clothe.Length}";
                }
                set
                {  
                    if (rd >= start && rd <= end)
                    {
                        if (index < clothe.Length)
                        {
                            if (clothe[index] is null)
                            {
                                clothe[index] = value;
                                Console.WriteLine($"Одежа:{value}, номер:{index}");
                            }
                            else
                                Console.WriteLine($"Нельзя положить одежду в номер: {index}, там {clothe[index]}");
                        }
                        else
                            Console.WriteLine($"Нельзя положить одежду в номер: {index}, максимум: {clothe.Length}");
                    }
                    else
                        Console.WriteLine($"Закрыто, откроется через: {Open()}");
                }
            }
            private void Show()
            {
                for (int i = 0; i < clothe.Length; i++)
                {
                    Console.WriteLine(clothe[i]);
                }
            }
            private int Open()
            {
                if (rd < start)
                    return start - rd;
                else
                    return (rd - end)- rd;
            }
            static void Main(string[] args)
            {
                Wardrobe wardrobe = new Wardrobe();
                wardrobe[0] = "Куртка";
                wardrobe[1] = "Куртка_1";
                wardrobe[2] = "Куртка_2";
                wardrobe[3] = "Куртка_3";
                wardrobe[3] = "Куртка_3";
                Console.WriteLine();
                wardrobe.Show();
            }
        }
    }
}
