using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Reviews : Form
    {
        public string CurrentUser { get; private set; }
        private readonly string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        public User_Reviews(string username)
        {
            InitializeComponent();
            this.CurrentUser = username;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(reviewDescription.Text) || reviewDescription.Text == "FEEDBACK")
            {
                MessageBox.Show("Please enter your feedback before submitting.", "Empty Review");
                return;
            }

            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @user",
                        new Dictionary<string, object> { ["@user"] = CurrentUser });

                    if (userIdObj != null)
                    {
                        string sql = "INSERT INTO Reviews (id, reviewDescriptio) VALUES (@uid, @desc)";

                        db.CRUD(sql, new Dictionary<string, object>
                        {
                            ["@uid"] = userIdObj,
                            ["@desc"] = reviewDescription.Text.Trim()
                        });

                        MessageBox.Show("Thank you for your feedback!", "Review Submitted");

                        reviewDescription.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting review: " + ex.Message);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            User_Home home = new User_Home(CurrentUser);
            home.Location = this.Location;
            home.StartPosition = FormStartPosition.Manual; // Use Manual to stay at current Location
            home.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) => btnHome_Click(sender, e);

        private void button1_Click(object sender, EventArgs e)
        {
            User_Products products = new User_Products(CurrentUser);
            products.Location = this.Location;
            products.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User_Cart cart = new User_Cart(CurrentUser);
            cart.Location = this.Location;
            cart.Show();
            this.Close();
        }

        private void reviewDescription_TextChanged(object sender, EventArgs e) { }
    }
}