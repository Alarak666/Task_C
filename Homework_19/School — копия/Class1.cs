using System;

namespace Personal
{
    namespace Teacher
    {
        #region
        public abstract class Teacher
        {
            public string name;
            public float salary;
            public string subject;

            internal protected Teacher(string name, float salary, string subject)
            {
                this.name = name;
                this.salary = salary;
                this.subject = subject;
            }
            public virtual void teaching()
            {
                Console.WriteLine("Записываем дату " + DateTime.Now);
            }
        }
        public class Maths : Teacher
        {
            internal protected int SalaryCafedra;
            public Maths(string name, float salary, string subject, int SalaryCafedra) : base (name, salary, subject)
            {
                this.SalaryCafedra = SalaryCafedra;
            }
            public override void teaching()
            {
                base.teaching();
                Console.WriteLine("Сегодня ряд фибаначи");
                int Fibonacci(int n)
                {
                    if (n == 0)
                        return 0;
                    else if (n < 3)
                        return 1;
                    else
                        return Fibonacci(n - 2) + Fibonacci(n - 1);

                }
                for (int i = 0; i < 20; i++)
                {
                    Console.Write(Fibonacci(i) + " ");
                }
            }
        }
        public class History : Teacher
        {
            public History(string name, float salary, string subject) : base(name, salary, subject)
            {
            }
            public override void teaching()
            {
                Console.WriteLine("Читать учебник");
            }
        }
        #endregion
    }
    namespace Director
    {
        #region
        public class Director
        {
            public string name;
            protected float salary;
            public void SalaryPerson(object obj)
            {
                Console.WriteLine(obj);
            }
        }
       
        #endregion
       
    }
    namespace Staff
    {
        #region
        class Staff
        {
            public string name;
            protected float salary;
        }
        #endregion
    }
}
