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
        // Property to store the logged-in user's name
        public string CurrentUser { get; private set; }

        public User_Reviews(string username)
        {
            InitializeComponent();
            // SAVE the username passed from the previous form
            this.CurrentUser = username;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Pass CurrentUser to Home
            User_Home home = new User_Home(CurrentUser);
            home.Location = this.Location;
            home.StartPosition = FormStartPosition.CenterScreen;
            home.Show();
            this.Close(); // Use Close instead of Hide to save memory
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Pass CurrentUser to Products
            User_Products products = new User_Products(CurrentUser);
            products.Location = this.Location;
            products.StartPosition = FormStartPosition.CenterScreen;
            products.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Pass CurrentUser to Cart
            User_Cart cart = new User_Cart(CurrentUser);
            cart.Location = this.Location;
            cart.StartPosition = FormStartPosition.CenterScreen;
            cart.Show();
            this.Close();
        }
    }
}