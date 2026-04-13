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
        public string ConStr { get; private set; }

        public User_Products()
        {
            InitializeComponent();
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        }

        public User_Products(string username) : this()
        {
            CurrentUser = username;
            this.Load += (s, e) => UpdateCartCounter();
        }


        // --- REUSABLE METHOD ---
        private void AddToCart(string productDesc, string category)
        {
            try
            {
                if (string.IsNullOrEmpty(productDesc))
                {
                    MessageBox.Show("Product description is missing.");
                    return;
                }

                if (string.IsNullOrEmpty(CurrentUser))
                {
                    MessageBox.Show("No logged-in user available.");
                    return;
                }

                using (DBconnection db = new DBconnection(ConStr))
                {
                    // 1. Get User Id
                    var userIdObj = db.ExecuteScalar(
                        "SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser }
                    );

                    if (userIdObj == null || userIdObj == DBNull.Value)
                    {
                        MessageBox.Show("User not found.");
                        return;
                    }

                    int userId = Convert.ToInt32(userIdObj);

                    // 2. Insert Product
                    string SQL = "INSERT INTO Products (prdDescription, prdCategory, id) VALUES (@product, @category, @id)";
                    var parameters = new Dictionary<string, object>
                    {
                        ["@product"] = productDesc,
                        ["@category"] = category,
                        ["@id"] = userId
                    };

                    db.CRUD(SQL, parameters);

                    MessageBox.Show($"{productDesc} added to cart!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Update the UI counter
                    UpdateCartCounter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void UpdateCartCounter()
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentUser)) return;

                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar(
                        "SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser }
                    );

                    if (userIdObj != null && userIdObj != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(userIdObj);
                        string SQL = "SELECT COUNT(*) FROM Products WHERE id = @id";
                        var countObj = db.ExecuteScalar(SQL, new Dictionary<string, object> { ["@id"] = userId });
                        cartQuantity.Text = countObj?.ToString() ?? "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Counter refresh failed: " + ex.Message);
            }
        }

        // --- BUTTON CLICKS ---

        private void button10_Click(object sender, EventArgs e)
        {
            // Assuming label3 is the name for product 1
            AddToCart(label3.Text, "Milktea");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Update labelX to whatever label matches this product button
            AddToCart(label4.Text, "Milktea");
        }

        // --- NAVIGATION ---
        private void button2_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser!);
            home.Location = this.Location;
            home.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User_Cart cart = new User_Cart(CurrentUser!);
            cart.Location = this.Location;
            cart.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User_Reviews reviews = new User_Reviews(CurrentUser!);
            reviews.Location = this.Location;
            reviews.Show();
            this.Hide();
        }

        private void cartQuantity_Click(object sender, EventArgs e) => UpdateCartCounter();
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void button5_Click_1(object sender, EventArgs e)
        {
            User_Reviews reviews = new User_Reviews(CurrentUser!);
            reviews.Location = this.Location;
            reviews.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser!);
            home.Location = this.Location;
            home.Show();
            this.Hide();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            AddToCart(label5.Text, "Milktea");
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            AddToCart(label8.Text, "Milktea");
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            AddToCart(label7.Text, "Milktea");
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            AddToCart(label6.Text, "Milktea");
        }

        private void praf_Click(object sender, EventArgs e)
        {
            User_Products_Praf praf = new User_Products_Praf(CurrentUser!);
            praf.Location = this.Location;
            praf.Show();
            this.Hide();
        }

        private void coffee_Click(object sender, EventArgs e)
        {
            User_Products_Coffee coffee = new User_Products_Coffee(CurrentUser!);
            coffee.Location = this.Location;
            coffee.Show();
            this.Hide();
        }

        private void fruittea_Click(object sender, EventArgs e)
        {
            User_Products_FruitTea fruitTea = new User_Products_FruitTea(CurrentUser!);
            fruitTea.Location = this.Location;
            fruitTea.Show();
            this.Hide();
        }

        private void brosty_Click(object sender, EventArgs e)
        {
            User_Products_Brosty brosty = new User_Products_Brosty(CurrentUser!);
            brosty.Location = this.Location;
            brosty.Show();
            this.Hide();
        }
    }
}