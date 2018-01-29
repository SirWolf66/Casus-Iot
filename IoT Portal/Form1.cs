using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoT_Portal
{
    public partial class Form1 : Form
    {
        List<string> usernameList = new List<string>();
        List<string> passwordList = new List<string>();

        public Form1()
        {
            usernameList.Add("Kevin");
            usernameList.Add("Mark");
            usernameList.Add("Gilbert");
            usernameList.Add("Root");

            passwordList.Add("Deketelaere");
            passwordList.Add("Qwerty!23456");
            passwordList.Add("VerySecure123");
            passwordList.Add("R00t");
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            int index = usernameList.IndexOf(usernameBox.Text); // test what happens when fail
            if (passwordList[index] == passwordBox.Text)
            {
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBConnector test = new DBConnector();
            test.OpenDB();
            test.SendReadQuery()
            test.CloseDB();
        }
    }
}
