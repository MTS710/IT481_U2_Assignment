using System;
using System.Windows.Forms;

namespace IT481_U2_Assignment
{
    public partial class Form1 : Form
    {
        private Controller database;

        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database = new Controller("Server = LAPTOP-U7LAS3OD\\SQLEXPRESS; " +
                                       "Trusted_Connection=true;" +
                                       "Database=northwind;" +
                                       "User Instance=false;" +
                                       "Connection timeout=30");

            MessageBox.Show("Connection information sent");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Get the count
            string count = database.getCustomerCount();
            MessageBox.Show(count, "Customer count");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get the names
            string names = (string)database.getCompanyNames();
            MessageBox.Show(names, "Company names");

        }
    }
}
