using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Cart_Checkout : Form
    {
        private string CurrentUser;
        private string OrderDetails;
        private double TotalAmount;
        private readonly string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        public User_Cart_Checkout(string username, string summary, double total)
        {
            InitializeComponent();
            this.CurrentUser = username;
            this.OrderDetails = summary;
            this.TotalAmount = total;

            orderSummary.Clear();
            orderSummary.AppendText("\n - - - - - - YOUR ITEMS - - - - - -\n\n");

            orderSummary.AppendText(summary);

            orderSummary.AppendText("\n-------------------------------------\n");
            orderSummary.AppendText($"TOTAL TO PAY: P{total:N2}");
        }

        private void checkout_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstName.Text) ||
                string.IsNullOrWhiteSpace(lastName.Text) ||
                string.IsNullOrWhiteSpace(address.Text) ||
                string.IsNullOrWhiteSpace(phoneNo.Text))
            {
                MessageBox.Show("Please fill out all customer details (Name, Address, and Phone).", "Missing Information");
                return;
            }

            string payMethod = COD.Checked ? "COD" : Gcash.Checked ? "Gcash" : "";

            if (string.IsNullOrEmpty(payMethod))
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @user",
                        new Dictionary<string, object> { ["@user"] = CurrentUser });

                    if (userIdObj == null) throw new Exception("User session not found.");

                    string sql = @"INSERT INTO Customers (id, firstName, lastName, deliveryAdd, [phoneNo.], paymentMethod, orderSummary) 
                                   VALUES (@uid, @fname, @lname, @add, @phone, @pay, @sum)";

                    db.CRUD(sql, new Dictionary<string, object>
                    {
                        ["@uid"] = userIdObj,
                        ["@fname"] = firstName.Text.Trim(),
                        ["@lname"] = lastName.Text.Trim(),
                        ["@add"] = address.Text.Trim(),
                        ["@phone"] = phoneNo.Text.Trim(),
                        ["@pay"] = payMethod,
                        ["@sum"] = OrderDetails
                    });

                    db.CRUD("DELETE FROM Products WHERE id = @uid", new Dictionary<string, object> { ["@uid"] = userIdObj });

                    MessageBox.Show("Order Confirmed! Thank you for ordering at BigBrew.", "Success");

                    User_Home home = new User_Home(CurrentUser);
                    home.Location = this.Location;
                    home.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Checkout Error: " + ex.Message);
            }
        }

        private void backToCart_Click(object sender, EventArgs e)
        {
            User_Cart cart = new User_Cart(CurrentUser);
            cart.Location = this.Location;
            cart.Show();
            this.Close();
        }

        private void firstName_TextChanged(object sender, EventArgs e) { }
    }
}