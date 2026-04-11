using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Reviews : Form
    {
        public string currentuser { get; private set; }

        public User_Reviews(string v)
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home();
            home.Location = this.Location;
            home.StartPosition = FormStartPosition.CenterScreen;
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Products products = new User_Products(currentuser);
            products.Location = this.Location;
            products.StartPosition = FormStartPosition.CenterScreen;
            products.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User_Cart cart = new User_Cart(currentuser);
            cart.Location = this.Location;
            cart.StartPosition = FormStartPosition.CenterScreen;
            cart.Show();
            this.Hide();
        }
    }
}
