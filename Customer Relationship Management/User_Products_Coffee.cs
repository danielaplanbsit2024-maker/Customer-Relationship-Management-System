using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Products_Coffee : Form
    {
        private string? CurrentUser;
        public string ConStr { get; private set; }

        // Default constructor (required by Designer)
        public User_Products_Coffee()
        {
            InitializeComponent();
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        }

        // --- FIXED: RECEIVING CONSTRUCTOR ---
        // This removes the red outline error in your Milktea/Praf classes!
        public User_Products_Coffee(string username) : this()
        {
            CurrentUser = username;
            // Load counter as soon as the form opens
            this.Load += (s, e) => UpdateCartCounter();
        }

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
                    // 1. Get User Id
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser });

                    if (userIdObj != null && userIdObj != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(userIdObj);

                        // 2. Insert with Category "Coffee"
                        string SQL = "INSERT INTO Products (prdDescription, prdCategory, id) VALUES (@product, @category, @id)";
                        db.CRUD(SQL, new Dictionary<string, object>
                        {
                            ["@product"] = productDesc,
                            ["@category"] = "Coffee",
                            ["@id"] = userId
                        });

                        MessageBox.Show($"{productDesc} added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateCartCounter();
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
                    var count = db.ExecuteScalar("SELECT COUNT(*) FROM Products p JOIN Users u ON p.id = u.Id WHERE u.username = @user",
                        new Dictionary<string, object> { ["@user"] = CurrentUser });

                    cartQuantity.Text = count?.ToString() ?? "0";
                }
            }
            catch { /* Silent fail */ }
        }

        // --- PRODUCT BUTTONS ---
        private void button10_Click(object sender, EventArgs e) => AddToCart(label3.Text);
        private void button11_Click(object sender, EventArgs e) => AddToCart(label4.Text);
        private void button12_Click(object sender, EventArgs e) => AddToCart(label5.Text);
        private void button13_Click(object sender, EventArgs e) => AddToCart(label6.Text);
        private void button14_Click(object sender, EventArgs e) => AddToCart(label7.Text);
        private void button15_Click(object sender, EventArgs e) => AddToCart(label8.Text);

        // --- NAVIGATION (PASSING USERNAME BACK) ---

        private void milktea_Click(object sender, EventArgs e) // Update name to match your button
        {
            User_Products milktea = new User_Products(CurrentUser!);
            milktea.Location = this.Location; milktea.Show(); this.Hide();
        }

        private void praf_Click(object sender, EventArgs e)
        {
            User_Products_Praf praf = new User_Products_Praf(CurrentUser!);
            praf.Location = this.Location; praf.Show(); this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser!);
            home.Location = this.Location; home.Show(); this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser!);
            home.Location = this.Location; home.Show(); this.Hide();
            home.StartPosition = FormStartPosition.CenterParent;
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_Products products = new User_Products(CurrentUser!);
            products.Location = this.Location;
            products.StartPosition = FormStartPosition.CenterParent;
            products.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_Products products = new User_Products(CurrentUser!);
            products.Location = this.Location;
            products.StartPosition = FormStartPosition.CenterParent;
            products.Show(); this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            User_Products_Praf praf = new User_Products_Praf(CurrentUser!);
            praf.Location = this.Location;
            praf.StartPosition = FormStartPosition.CenterParent;
            praf.Show(); this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User_Cart cart = new User_Cart(CurrentUser!);
            cart.Location = this.Location;
            cart.StartPosition = FormStartPosition.CenterParent;
            cart.Show(); this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_Reviews reviews = new User_Reviews(CurrentUser!);
            reviews.Location = this.Location;
            reviews.StartPosition = FormStartPosition.CenterParent;
            reviews.Show(); this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            User_Products_FruitTea fruitTea = new User_Products_FruitTea();
            fruitTea.Location = this.Location;
            fruitTea.StartPosition = FormStartPosition.CenterParent;
            fruitTea.Show(); this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            User_Products_Brosty brosty = new User_Products_Brosty(CurrentUser!);
            brosty.Location = this.Location;
            brosty.StartPosition = FormStartPosition.CenterParent;
            brosty.Show(); this.Hide();
        }
    }
}