using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public class Student
        {
            public string name { get; set; }
            public string surname { get; set; }
            public string patronymic { get; set; }
            public string city { get; set; }
            public string faculty { get; set; }
            public int course { get; set; }
            public int avgScore { get; set; }
            
            public Student() { }
            public Student(string name, string surname, string patronymic, string city, string faculty, int course, int avgScore)
            {
                this.name = name;
                this.surname = surname;
                this.patronymic = patronymic;
                this.city = city;
                this.faculty = faculty;
                this.course = course;
                this.avgScore = avgScore;
            }
        }
        public List<Student> students = new List<Student>();
        
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            students.Add(new Student("Антон", "Рязанов", "Сергеевич", "Херсон", "Биология", 1, 5));
            students.Add(new Student("Егор", "Рязанов", "Сергеевич", "Херсон", "Биология", 2, 4));
            students.Add(new Student("Владимир", "Рязанов", "Сергеевич", "Херсон", "Биология", 1, 5));
            students.Add(new Student("Влад", "Рязанов", "Сергеевич", "Херсон", "Биология", 2, 4));
            dataGridView1.AllowUserToAddRows = false;
            try
            {
                students.Add(new Student(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text)));
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите все поля");
            }
            DataTable table = new DataTable();
            table.Columns.Add("Имя", typeof(string));
            table.Columns.Add("Фамилия", typeof(string));
            table.Columns.Add("Отчество", typeof(string));
            table.Columns.Add("Город", typeof(string));
            table.Columns.Add("Факультет", typeof(string));
            table.Columns.Add("Курс", typeof(int));
            table.Columns.Add("Средний бал", typeof(int));
            dataGridView1.DataSource = table;
            for (int i = 0; i < students.Count; i++)
            {
                table.Rows.Add(students[i].name, students[i].surname, students[i].patronymic, students[i].city, students[i].faculty, students[i].course, students[i].avgScore);
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int cit = 0; // город
            int cour = 0;// курс
            int facul = 0;// факул
            try
            {
                for (int i = 0; i < students.Count; i++)
                {

                    if (students[i].course == Convert.ToInt32(textBox9.Text))
                    {
                        label14.Visible = true;
                        cour++;
                        label14.Text = cour.ToString();
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Введите Курс");
            }
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].faculty == textBox10.Text)
                {
                    label15.Visible = true;
                    facul++;
                    label15.Text = facul.ToString();
                }
            }
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].city == textBox8.Text)
                {
                    label13.Visible = true;
                    cit++;
                    label13.Text = cit.ToString();
                }
            }
        }
    }
}
