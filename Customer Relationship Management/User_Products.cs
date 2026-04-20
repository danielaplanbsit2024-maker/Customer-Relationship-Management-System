using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Products : Form
    {
        private string CurrentUser;
        private string ConStr = DBconnection.ConnectionString;

        public User_Products(string username)
        {
            InitializeComponent();
            CurrentUser = username;
            this.Load += (s, e) => UpdateCartCounter();
        }

        private void AddToCart(string productDesc, string category)
        {
            if (string.IsNullOrEmpty(CurrentUser)) return;

            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var uid = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u",
                        new Dictionary<string, object> { ["@u"] = CurrentUser });

                    if (uid == null) return;

                    string sql = "INSERT INTO Products (prdDescription, prdCategory, id) VALUES (@p, @c, @id)";
                    db.CRUD(sql, new Dictionary<string, object>
                    {
                        ["@p"] = productDesc,
                        ["@c"] = category,
                        ["@id"] = uid
                    });

                    MessageBox.Show($"{productDesc} added to cart!", "Success");
                    UpdateCartCounter();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void UpdateCartCounter()
        {
            if (string.IsNullOrEmpty(CurrentUser)) return;
            cartQuantity.Text = DBconnection.GetCartCount(CurrentUser).ToString();
        }

        // --- PRODUCT CLICKS ---
        private void button10_Click(object sender, EventArgs e) => AddToCart(label3.Text, "Milktea");
        private void button11_Click(object sender, EventArgs e) => AddToCart(label4.Text, "Milktea");
        private void button12_Click_1(object sender, EventArgs e) => AddToCart(label5.Text, "Milktea");
        private void button13_Click_1(object sender, EventArgs e) => AddToCart(label6.Text, "Milktea");
        private void button14_Click_1(object sender, EventArgs e) => AddToCart(label7.Text, "Milktea");
        private void button15_Click_1(object sender, EventArgs e) => AddToCart(label8.Text, "Milktea");

        // --- NAVIGATION ---
        private void Navigate<T>(Func<string, T> factory) where T : Form
        {
            T nextForm = factory(CurrentUser);
            nextForm.Location = this.Location;
            nextForm.StartPosition = FormStartPosition.Manual;
            nextForm.Show();
            this.Hide();
        }


        // Category Switches
        private void praf_Click(object sender, EventArgs e) => Navigate(u => new User_Products_Praf(u));
        private void coffee_Click(object sender, EventArgs e) => Navigate(u => new User_Products_Coffee(u));
        private void fruittea_Click(object sender, EventArgs e) => Navigate(u => new User_Products_FruitTea(u));
        private void brosty_Click(object sender, EventArgs e) => Navigate(u => new User_Products_Brosty(u));
        private void button2_Click_1(object sender, EventArgs e) => Navigate(u => new User_Home(u));
        private void button3_Click(object sender, EventArgs e) => Navigate(u => new User_Cart(u));
        private void button5_Click_1(object sender, EventArgs e) => Navigate(u => new User_Reviews(u));

        private void User_Products_Load(object sender, EventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login loginForm = new Login();
                loginForm.Location = this.Location;
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.Show();
                this.Close();
            }
        }
    }
}