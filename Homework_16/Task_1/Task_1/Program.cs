using System;

namespace Task_1
{
    class Program
    {
        //Создайте структуру описывающую точку в трехмерной системе координат.Организуйте
        //возможность сложения, умножения, сравнение на больше и меньше и еще на равно и на не
        //равно двух точек в трехмерной системе, через использование перегрузки оператора +, *,<, >
        //и т.д...
        struct Point : IComparable
        {
            private int x, y, z;
            public Point (int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public static Point operator +(Point p, Point p1) 
            {
                return new Point(p.x + p1.x, p.y + p1.y, p.z + p1.z);
            }
            public static Point operator -(Point p, Point p1)
            {
                return new Point(p.x - p1.x, p.y - p1.y, p.z - p1.z);
            }
            public static Point operator *(Point p, Point p1)
            {
                return new Point(p.x * p1.x, p.y * p1.y, p.z * p1.z);
            }
            public static Point operator /(Point p, Point p1)
            {
                return new Point(p.x / p1.x, p.y / p1.y, p.z / p1.z);
            }
            public static Point operator %(Point p, Point p1)
            {
                return new Point(p.x % p1.x, p.y % p1.y, p.z % p1.z);
            }
            public static bool operator ==(Point p, Point p1)
            {
                return p.Equals(p1);
            }
            public static bool operator !=(Point p, Point p1)
            {
                return !p.Equals(p1);
            }
            public static bool operator >(Point p, Point p1)
            {
                return p.CompareTo(p1) > 0;
            }
            public static bool operator <(Point p, Point p1)
            {
                return p.CompareTo(p1) < 0;
            }
            public static bool operator <=(Point p, Point p1)
            {
                return p.CompareTo(p1) <= 0;
            }
            public static bool operator >=(Point p, Point p1)
            {
                return p.CompareTo(p1) <= 0;
            }
            public override string ToString()
            {
                return string.Format("[{0}, {1}, {2}]", x, y , z);
            }
            public int CompareTo(object obj)
            {
                if (obj is Point)
                {
                    Point p = (Point)obj;

                    if (this.x > p.x && this.y > p.y && this.z > p.z)
                    {
                        return 1;
                    }
                    else if (this.x < p.x && this.y < p.y && this.z < p.z)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        static void Main(string[] args)
        {
            Point point1 = new Point(1, 1, 1);
            Point point2 = new Point(2, 2, 3);
            Console.WriteLine("Точка_1 " + point1.ToString());
            Console.WriteLine("Точка_2 " + point1.ToString());
            Console.WriteLine("Точка_1 +  Точка_2 = {0}", point1 + point2);
            Console.WriteLine("Точка_1 -  Точка_2 = {0}", point1 - point2);
            Console.WriteLine("Точка_1 *  Точка_2 = {0}", point1 * point2);
            Console.WriteLine("Точка_1 /  Точка_2 = {0}", point1 / point2);
            Console.WriteLine("Точка_1 >  Точка_2 = {0}", point1 > point2);
            Console.WriteLine("Точка_1 <  Точка_2 = {0}", point1 < point2);
            Console.WriteLine("Точка_1 >= Точка_2 = {0}", point1 >= point2);
            Console.WriteLine("Точка_1 <= Точка_2 = {0}", point1 <= point2);
            Console.WriteLine("Точка_1 ==  Точка_2 = {0}", point1 == point2);
            Console.WriteLine("Точка_1 != Точка_2 = {0}", point1 != point2);

        }
    }
}
