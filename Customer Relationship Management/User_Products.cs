using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Products : Form
    {
        private string? CurrentUser;
        private object id;

        public string ConStr { get; private set; }

        public User_Products()
        {
            InitializeComponent();
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        }

        // Optional constructor so caller can pass the logged-in username
        public User_Products(string username) : this()
        {
            CurrentUser = username;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var productDesc = label3.Text?.Trim();
                    if (string.IsNullOrEmpty(productDesc))
                    {
                        MessageBox.Show("Product description cannot be empty.");
                        return;
                    }

                    if (string.IsNullOrEmpty(CurrentUser))
                    {
                        MessageBox.Show("No logged-in user available. Make sure you pass the username when opening this form.");
                        return;
                    }

                    // get the user's Id
                    var userIdObj = db.ExecuteScalar(
                        "SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser }
                    );

                    if (userIdObj == null || userIdObj == DBNull.Value)
                    {
                        MessageBox.Show("Unable to find current user in database.");
                        return;
                    }

                    int id = Convert.ToInt32(userIdObj);

                    // insert product and user id (do not insert identity column)
                    // Use a dedicated UserId column to track which user added the product  
                    string SQL = "INSERT INTO Products (prdDescription, id) VALUES (@product, @id)";
                    var parameters = new Dictionary<string, object>
                    {
                        ["@product"] = productDesc,
                        ["@id"] = id
                    };

                    db.CRUD(SQL, parameters);
                    MessageBox.Show("Product added successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void cartQuantity_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {

                    // get the user's Id
                    var userIdObj = db.ExecuteScalar(
                         "SELECT Id FROM Users WHERE username = @username",
                         new Dictionary<string, object> { ["@username"] = CurrentUser }
                     );

                    if (userIdObj == null || userIdObj == DBNull.Value)
                    {
                        return;
                    }

                    int id = Convert.ToInt32(userIdObj);

                    // Count products that belong to this user (assumes Products has a UserId column)
                    string SQL = "SELECT COUNT(*) FROM Products WHERE id = @id";
                    var countObj = db.ExecuteScalar(SQL, new Dictionary<string, object> { ["@id"] = id });
                    cartQuantity.Text = SQL;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser!);
            home.Location = this.Location;
            home.Name = this.Name;
            home.StartPosition = FormStartPosition.CenterScreen;
            home.Show();
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
