using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Task_2
{
    //    Напишите WPF-или WindowsForm приложение для поиска заданного файла на диске.
    //   Добавьте код, использующий класс FileStream и позволяющий просматривать контент
    //файла в окне WPF-или WindowsForm приложение.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public TextBox NewTextBox()
        {
            string path = Path.Text;
            TextBox text = new TextBox();
            Controls.Add(text);
            text.Left = 10;
            text.Top =  10;
            text.Height = 300;
            text.Width = 200;
            text.Multiline = true;
            text.ScrollBars = ScrollBars.Both;
          
            using (StreamReader stream = new StreamReader(path, true))
            {
                text.Text = stream.ReadToEnd();
                stream.Dispose();
            }
            return text;
        }
        void button1_Click(object sender, EventArgs e)
        {
            NewTextBox();
        }
    }
}
