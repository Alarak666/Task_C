using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
    //        Создайте Windows Form или WPF- приложение в котором вы заносите информацию о
    //студенте(имя, город, факультет, курс, средний балл)....В этой ж форме у вас отображается
    //список всех добавленных студентов....Отдельно у вас отображается информация сколько
    //студентов из каждого города, сколько обучается на каждом факультете и сколько на
    //каждом курсе...При решении задачи используйте коллекции...У наследуйтесь, от какой то
    //встроенной коллекции и чтобы при добавленние очередного сотрудника, вызывалось
    //событие и перерисовало список сотрудников на форме
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
