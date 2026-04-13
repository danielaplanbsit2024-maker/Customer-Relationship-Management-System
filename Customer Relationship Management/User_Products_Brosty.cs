using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Products_Brosty : Form
    {
        private string? CurrentUser;
        public string ConStr { get; private set; }

        public User_Products_Brosty()
        {
            InitializeComponent();
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        }

        // --- RECEIVING CONSTRUCTOR ---
        // Ensures the username is passed and the cart counter updates on load
        public User_Products_Brosty(string username) : this()
        {
            CurrentUser = username;
            this.Load += (s, e) => UpdateCartCounter();
        }

        // --- DATABASE LOGIC ---

        private void AddToCart(string productDesc)
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentUser))
                {
                    MessageBox.Show("No logged-in user available.");
                    return;
                }

                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser });

                    if (userIdObj != null && userIdObj != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(userIdObj);

                        // Category set to "Brosty"
                        string SQL = "INSERT INTO Products (prdDescription, prdCategory, id) VALUES (@product, @category, @id)";
                        db.CRUD(SQL, new Dictionary<string, object>
                        {
                            ["@product"] = productDesc,
                            ["@category"] = "Brosty",
                            ["@id"] = userId
                        });

                        UpdateCartCounter();
                        MessageBox.Show($"{productDesc} added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void UpdateCartCounter()
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentUser)) return;
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser });

                    if (userIdObj != null && userIdObj != DBNull.Value)
                    {
                        var count = db.ExecuteScalar("SELECT COUNT(*) FROM Products WHERE id = @id",
                            new Dictionary<string, object> { ["@id"] = Convert.ToInt32(userIdObj) });

                        cartQuantity.Text = count?.ToString() ?? "0";
                    }
                }
            }
            catch { /* Silent fail */ }
        }

        // --- PRODUCT BUTTONS ---

        private void button10_Click_1(object sender, EventArgs e) => AddToCart(label3.Text);

        private void button11_Click_1(object sender, EventArgs e) => AddToCart(label4.Text);

        private void button12_Click_1(object sender, EventArgs e) => AddToCart(label5.Text);

        private void button15_Click_1(object sender, EventArgs e) => AddToCart(label8.Text);


        private void button14_Click_1(object sender, EventArgs e) => AddToCart(label7.Text);


        private void button13_Click_1(object sender, EventArgs e) => AddToCart(label6.Text);

        // --- NAVIGATION BUTTONS (Passing CurrentUser!) 

        private void button2_Click_1(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser!);
            home.Location = this.Location;
            home.StartPosition = FormStartPosition.CenterScreen;
            home.Show(); this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            User_Products products = new User_Products(CurrentUser!);
            products.Location = this.Location;
            products.StartPosition = FormStartPosition.CenterScreen;
            products.Show(); this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            User_Cart cart = new User_Cart(CurrentUser!);
            cart.Location = this.Location;
            cart.StartPosition = FormStartPosition.CenterScreen;
            cart.Show(); this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            User_Reviews reviews = new User_Reviews(CurrentUser!);
            reviews.Location = this.Location;
            reviews.StartPosition = FormStartPosition.CenterScreen;
            reviews.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_Products products = new User_Products(CurrentUser!);
            products.Location = this.Location;
            products.StartPosition = FormStartPosition.CenterScreen;
            products.Show(); this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            User_Products_Praf praf = new User_Products_Praf(CurrentUser!);
            praf.Location = this.Location;
            praf.StartPosition = FormStartPosition.CenterScreen;
            praf.Show(); this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            User_Products_Coffee coffee = new User_Products_Coffee(CurrentUser!);
            coffee.Location = this.Location;
            coffee.StartPosition = FormStartPosition.CenterScreen;
            coffee.Show(); this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            User_Products_FruitTea fruitTea = new User_Products_FruitTea(CurrentUser!);
            fruitTea.Location = this.Location;
            fruitTea.StartPosition = FormStartPosition.CenterScreen;
            fruitTea.Show(); this.Hide();
        }
    }
}