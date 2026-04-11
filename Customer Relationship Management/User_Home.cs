using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Home : Form
    {
        public string? CurrentUser { get; private set; }

        public User_Home()
        {
            InitializeComponent();
        }

        public User_Home(string username) : this()
        {
            CurrentUser = username;
            // show username in the UI if label1 exists
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    label1.Text = $"WELCOME BACK, {username.ToUpper()}!";
                }
            }
            catch
            {
                // Ignore if designer labels are not initialized yet
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void homeUsername_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Products products = new User_Products(CurrentUser!);
            products.Location = this.Location;
            products.Name = this.Name;
            products.StartPosition = FormStartPosition.CenterScreen;
            products.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_Products products = new User_Products(CurrentUser!);
            products.Location = this.Location;
            products.Name = this.Name;
            products.StartPosition = FormStartPosition.CenterScreen;
            products.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User_Cart cart = new User_Cart(CurrentUser!);
            cart.Location = this.Location;
            cart.StartPosition = FormStartPosition.CenterScreen;
            cart.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_Reviews reviews = new User_Reviews(CurrentUser!);
            reviews.Location = this.Location;
            reviews.StartPosition = FormStartPosition.CenterScreen;
            reviews.Show();
            this.Hide();
        }
    }
}
