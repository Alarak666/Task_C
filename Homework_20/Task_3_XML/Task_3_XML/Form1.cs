using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Task_3_XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            clear();
        }
        public class Users
        {
            public List<User> userList { get; set; } = new List<User>();
        }
        public class User
        {
            public string id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string salary { get; set; }
            public string position { get; set; }
            public User() { }

            public User(string id, string name, string surname, string salary, string position)
            {
                this.id = id;
                this.name = name;
                this.surname = surname;
                this.salary = salary;
                this.position = position;
            }
        }
        private void clear()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            User user = new User(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            Add(user);
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            Users users = DeserialazirXML();
            foreach(User user in users.userList)
            {
                Add(user);
            }
        }
        private void Add(User user)
        {
            ListViewItem list = new ListViewItem(user.id);
            list.Tag = user;
            listView1.Items.Add(list);
        }
        private void SerialazizeXML(Users users)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Users));
            using (FileStream stream = new FileStream("User.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(stream, users);
            }
        }
        private Users DeserialazirXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Users));
            using (FileStream stream = new FileStream("User.xml", FileMode.OpenOrCreate))
            {
              return (Users)xml.Deserialize(stream);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Tag != null)
                {
                    users.userList.Add((User)item.Tag);
                }
            }
            SerialazizeXML(users);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                User user = (User)listView1.SelectedItems[0].Tag;
                if(user != null)
                {
                    textBox1.Text = user.id;
                    textBox2.Text = user.name;
                    textBox3.Text = user.surname;
                    textBox4.Text = user.position;
                    textBox5.Text = user.salary;
                }
            }
            else if (listView1.SelectedItems.Count == 0)
                clear();
        }
    }
}
