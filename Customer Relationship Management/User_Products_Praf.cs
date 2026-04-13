using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Products_Praf : Form
    {
        private string? CurrentUser;
        public string ConStr { get; private set; }

        public User_Products_Praf()
        {
            InitializeComponent();
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        }

        public User_Products_Praf(string username) : this()
        {
            CurrentUser = username;
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
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser });

                    if (userIdObj != null && userIdObj != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(userIdObj);
                        string SQL = "INSERT INTO Products (prdDescription, prdCategory, id) VALUES (@product, @category, @id)";

                        db.CRUD(SQL, new Dictionary<string, object>
                        {
                            ["@product"] = productDesc,
                            ["@category"] = "Frappe", // Categorized as Frappe for this class
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

        // --- PRODUCT BUTTONS (Frappe Items) ---
        // Ensure the label names (label3, label4, etc.) match your Designer names

        private void button10_Click(object sender, EventArgs e) => AddToCart(label3.Text);
        private void button11_Click(object sender, EventArgs e) => AddToCart(label4.Text);
        private void button12_Click(object sender, EventArgs e) => AddToCart(label5.Text);
        private void button13_Click(object sender, EventArgs e) => AddToCart(label6.Text);
        private void button14_Click(object sender, EventArgs e) => AddToCart(label7.Text);
        private void button15_Click(object sender, EventArgs e) => AddToCart(label8.Text);

        // --- NAVIGATION (PASSING THE USERNAME) ---

        private void button4_Click(object sender, EventArgs e) // Milktea Button
        {
            User_Products milktea = new User_Products(CurrentUser!);
            milktea.Location = this.Location;
            milktea.Show();
            this.Hide();
        }

        private void coffee_Click(object sender, EventArgs e)
        {
            User_Products_Coffee coffee = new User_Products_Coffee();
            coffee.Location = this.Location;
            coffee.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser!);
            home.Location = this.Location;
            home.Show();
            this.Hide();
        }

        private void praf_Click(object sender, EventArgs e) { /* Already on this page */ }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void fruittea_Click_1(object sender, EventArgs e)
        {
            User_Products_FruitTea fruitTea = new User_Products_FruitTea();
            fruitTea.Location = this.Location;
            fruitTea.StartPosition = FormStartPosition.CenterScreen;
            fruitTea.Show();
            this.Hide();
        }

        private void brosty_Click_1(object sender, EventArgs e)
        {
            User_Products_Brosty brosty = new User_Products_Brosty();
            brosty.Location = this.Location;
            brosty.StartPosition = FormStartPosition.CenterScreen;
            brosty.Show();
            this.Hide();
        }
    }
}