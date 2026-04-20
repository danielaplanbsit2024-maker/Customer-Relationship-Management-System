using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Cart_Checkout : Form
    {
        private string CurrentUser, OrderDetails;
        private double TotalAmount;
        private string ConStr = DBconnection.ConnectionString;

        public User_Cart_Checkout(string username, string summary, double total)
        {
            InitializeComponent();
            CurrentUser = username;
            OrderDetails = summary;
            TotalAmount = total;

            double displayTotal = string.IsNullOrWhiteSpace(summary) ? 0 : total;

            orderSummary.Text = $"\n - - - - - - YOUR ITEMS - - - - - -\n\n{summary}" +
                                $"\n-------------------------------------\nTOTAL TO PAY: P{displayTotal:N2}";
            
            // Update TotalAmount if summary is empty to prevent charging delivery fee on empty cart
            if (string.IsNullOrWhiteSpace(summary))
            {
                TotalAmount = 0;
            }
        }

        private void checkout_Click(object sender, EventArgs e)
        {
            if (AnyFieldEmpty()) return;

            string payMethod = COD.Checked ? "COD" : Gcash.Checked ? "Gcash" : "";
            if (string.IsNullOrEmpty(payMethod))
            {
                MessageBox.Show("Select a payment method.");
                return;
            }

            if (payMethod == "Gcash")
            {
                new User_Checkout_Ewallet(CurrentUser, OrderDetails, TotalAmount, firstName.Text, lastName.Text, address.Text, phoneNo.Text)
                {
                    Location = this.Location
                }.Show();
                this.Hide();
            }
            else if (payMethod == "COD")
            {
                new User_Checkout_COD(CurrentUser, OrderDetails, TotalAmount, firstName.Text, lastName.Text, address.Text, phoneNo.Text)
                {
                    Location = this.Location
                }.Show();
                this.Hide();
            }
        }

        private void ProcessOrder(string payMethod)
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var uid = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u", new Dictionary<string, object> { ["@u"] = CurrentUser });

                    string sql = @"INSERT INTO Customers (id, firstName, lastName, deliveryAdd, [phoneNo], paymentMethod, orderSummary) 
                                   VALUES (@uid, @fn, @ln, @ad, @ph, @pm, @os)";

                    db.CRUD(sql, new Dictionary<string, object>
                    {
                        ["@uid"] = uid,
                        ["@fn"] = firstName.Text.Trim(),
                        ["@ln"] = lastName.Text.Trim(),
                        ["@ad"] = address.Text.Trim(),
                        ["@ph"] = phoneNo.Text.Trim(),
                        ["@pm"] = payMethod,
                        ["@os"] = OrderDetails
                    });

                    db.CRUD("DELETE FROM Products WHERE id = @uid", new Dictionary<string, object> { ["@uid"] = uid });

                    object invoiceIdObj = db.ExecuteScalar("SELECT SCOPE_IDENTITY()");
                    string invoiceId = invoiceIdObj != null ? invoiceIdObj.ToString() : "N/A";

                    DBconnection.SaveReceipt(invoiceId, firstName.Text + " " + lastName.Text, payMethod, OrderDetails, (decimal)TotalAmount);

                    MessageBox.Show("Order Confirmed! Thank you for ordering at BigBrew.");
                    new User_Home(CurrentUser) { Location = this.Location }.Show();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void User_Cart_Checkout_Load(object sender, EventArgs e)
        {
            DBconnection.BindNumericOnly(phoneNo); // Fixed the textbox name here
        }

        private bool AnyFieldEmpty()
        {
            if (string.IsNullOrWhiteSpace(firstName.Text) || string.IsNullOrWhiteSpace(lastName.Text) ||
                string.IsNullOrWhiteSpace(address.Text) || string.IsNullOrWhiteSpace(phoneNo.Text))
            {
                MessageBox.Show("Please fill out all customer details.");
                return true;
            }
            return false;
        }

        private void backToCart_Click(object sender, EventArgs e)
        {
            new User_Cart(CurrentUser) { Location = this.Location }.Show();
            this.Close();
        }
    }
}
