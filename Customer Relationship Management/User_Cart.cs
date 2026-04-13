using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Cart : Form
    {
        // Property to hold the logged-in username
        public string CurrentUser { get; private set; }

        // Connection string using |DataDirectory| for team compatibility
        private readonly string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        public User_Cart(string username)
        {
            InitializeComponent();
            this.CurrentUser = username;

            // Load data as soon as the form opens
            this.Load += (s, e) => LoadCartData();
        }

        private void LoadCartData()
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar(
                        "SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser }
                    );

                    if (userIdObj != null && userIdObj != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(userIdObj);

                        string sql = @"SELECT prdDescription AS [ITEM], 
                                     'TBA' AS [PRICE], 
                                     COUNT(prdDescription) AS [QTY] 
                               FROM Products 
                               WHERE id = @id 
                               GROUP BY prdDescription";

                        DataTable dt = db.Select(sql, new Dictionary<string, object> { ["@id"] = userId });
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cart: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Going to Products - Pass the CurrentUser!
            User_Products products = new User_Products(CurrentUser);
            products.Location = this.Location;
            products.StartPosition = FormStartPosition.CenterScreen;
            products.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Going to Home - Pass the CurrentUser!
            User_Home home = new User_Home(CurrentUser);
            home.Location = this.Location;
            home.StartPosition = FormStartPosition.CenterScreen;
            home.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Going to Reviews - Pass the CurrentUser!
            User_Reviews reviews = new User_Reviews(CurrentUser);
            reviews.Location = this.Location;
            reviews.StartPosition = FormStartPosition.CenterScreen;
            reviews.Show();
            this.Close();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            // Optional: Logic to delete items for this user
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 1. Ask for confirmation so the user doesn't delete their items by accident
            DialogResult result = MessageBox.Show("Are you sure you want to clear your entire cart?",
                                                  "Confirm Clear",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        // 2. Get the User's Id first
                        var userIdObj = db.ExecuteScalar(
                            "SELECT Id FROM Users WHERE username = @username",
                            new Dictionary<string, object> { ["@username"] = CurrentUser }
                        );

                        if (userIdObj != null && userIdObj != DBNull.Value)
                        {
                            int userId = Convert.ToInt32(userIdObj);

                            // 3. Delete all products belonging to this user
                            string sql = "DELETE FROM Products WHERE id = @id";
                            int rowsAffected = db.CRUD(sql, new Dictionary<string, object> { ["@id"] = userId });

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cart cleared successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // 4. Refresh the UI so the box becomes empty
                                LoadCartData();
                            }
                            else
                            {
                                MessageBox.Show("Your cart is already empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing cart: " + ex.Message);
                }
            }
        }
    }
}