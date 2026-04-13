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
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @username", new Dictionary<string, object> { ["@username"] = CurrentUser });
                    if (userIdObj != null)
                    {
                        string SQL = "INSERT INTO Products (prdDescription, prdCategory, id) VALUES (@product, @category, @id)";
                        db.CRUD(SQL, new Dictionary<string, object> { ["@product"] = productDesc, ["@category"] = "Frappe", ["@id"] = Convert.ToInt32(userIdObj) });
                        UpdateCartCounter();
                        MessageBox.Show($"{productDesc} added!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void UpdateCartCounter()
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentUser)) return;
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @username", new Dictionary<string, object> { ["@username"] = CurrentUser });
                    if (userIdObj != null)
                    {
                        var count = db.ExecuteScalar("SELECT COUNT(*) FROM Products WHERE id = @id", new Dictionary<string, object> { ["@id"] = Convert.ToInt32(userIdObj) });
                        cartQuantity.Text = count?.ToString() ?? "0";
                    }
                }
            }
            catch { }
        }

        // NAVIGATION - FIXED TO PASS USERNAME
        private void coffee_Click(object sender, EventArgs e)
        {
            User_Products_Coffee coffee = new User_Products_Coffee();
            coffee.Location = this.Location;
            coffee.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) // This is your "Milktea" button
        {
            User_Products products = new User_Products(CurrentUser!);
            products.Location = this.Location;
            products.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser!);
            home.Location = this.Location;
            home.Show();
            this.Hide();
        }

        private void praf_Click(object sender, EventArgs e)
        {

        }
    }
}