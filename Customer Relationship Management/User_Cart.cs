using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Cart : Form
    {
        public string currentuser { get; private set; }

        public User_Cart(string v)
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home();
            home.Location = this.Location;
            home.StartPosition = FormStartPosition.CenterScreen;
            home.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Products products = new User_Products();
            products.Location = this.Location;
            products.StartPosition = FormStartPosition.CenterScreen;
            products.Show(); this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_Reviews reviews = new User_Reviews(currentuser);
            reviews.Location = this.Location;
            reviews.StartPosition = FormStartPosition.CenterScreen;
            reviews.Show(); this.Close();
        }
    }
}
