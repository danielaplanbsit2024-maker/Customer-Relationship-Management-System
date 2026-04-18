using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Products_Brosty : Form
    {
        private string CurrentUser;
        private string ConStr = DBconnection.ConnectionString;

        public User_Products_Brosty(string username)
        {
            InitializeComponent();
            CurrentUser = username;
            this.Load += (s, e) => UpdateCartCounter();
        }

        private void AddToCart(string productDesc)
        {
            if (string.IsNullOrEmpty(CurrentUser)) return;

            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var uid = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u", new Dictionary<string, object> { ["@u"] = CurrentUser });
                    if (uid == null) return;

                    db.CRUD("INSERT INTO Products (prdDescription, prdCategory, id) VALUES (@p, 'Brosty', @id)",
                        new Dictionary<string, object> { ["@p"] = productDesc, ["@id"] = uid });

                    UpdateCartCounter();
                    MessageBox.Show($"{productDesc} added to cart!", "Success");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void UpdateCartCounter()
        {
            cartQuantity.Text = DBconnection.GetCartCount(CurrentUser).ToString();
        }

        // --- PRODUCT BUTTONS ---
        private void button10_Click_1(object sender, EventArgs e) => AddToCart(label3.Text);
        private void button11_Click_1(object sender, EventArgs e) => AddToCart(label4.Text);
        private void button12_Click_1(object sender, EventArgs e) => AddToCart(label5.Text);
        private void button13_Click_1(object sender, EventArgs e) => AddToCart(label6.Text);
        private void button14_Click_1(object sender, EventArgs e) => AddToCart(label7.Text);
        private void button15_Click_1(object sender, EventArgs e) => AddToCart(label8.Text);

        // --- NAVIGATION ---
        private void Navigate<T>(Func<string, T> factory) where T : Form
        {
            T nextForm = factory(CurrentUser);
            nextForm.Location = this.Location;
            nextForm.StartPosition = FormStartPosition.Manual;
            nextForm.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e) => Navigate(u => new User_Home(u));
        private void button1_Click_1(object sender, EventArgs e) => Navigate(u => new User_Products(u));
        private void button3_Click_1(object sender, EventArgs e) => Navigate(u => new User_Cart(u));
        private void button5_Click_1(object sender, EventArgs e) => Navigate(u => new User_Reviews(u));
        private void button6_Click(object sender, EventArgs e) => Navigate(u => new User_Products_Praf(u));
        private void button7_Click(object sender, EventArgs e) => Navigate(u => new User_Products_Coffee(u));
        private void button8_Click(object sender, EventArgs e) => Navigate(u => new User_Products_FruitTea(u));
        private void button4_Click(object sender, EventArgs e) => Navigate(u => new User_Home(u));
    }
}