using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Checkout_Ewallet : Form
    {
        private string CurrentUser, OrderDetails, FName, LName, Addr, PNo;
        private double TotalAmount;
        private string ConStr = DBconnection.ConnectionString;

        public User_Checkout_Ewallet(string user, string summary, double total, string fn, string ln, string ad, string ph)
        {
            InitializeComponent();
            CurrentUser = user;
            OrderDetails = summary;
            TotalAmount = total;
            FName = fn; LName = ln; Addr = ad; PNo = ph;

            amountToBePaid.Text = $"P {TotalAmount:N2}";
        }

        private void confirmPayment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(phoneNo.Text) || string.IsNullOrWhiteSpace(Amount.Text))
            {
                MessageBox.Show("Please fill out all GCash payment details.");
                return;
            }

            if (!double.TryParse(Amount.Text, out double paidAmount) || paidAmount < TotalAmount)
            {
                MessageBox.Show($"Insufficient amount. Total required is P{TotalAmount:N2}");
                return;
            }

            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var uidObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u", new Dictionary<string, object> { ["@u"] = CurrentUser });
                    int uid = Convert.ToInt32(uidObj);

                    db.CRUD("INSERT INTO EWallet (Id, walletName, phoneNo, amount) VALUES (@uid, @wn, @ph, @am)",
                        new Dictionary<string, object> { ["@uid"] = uid, ["@wn"] = name.Text.Trim(), ["@ph"] = phoneNo.Text.Trim(), ["@am"] = paidAmount });

                    // 1. UPSERT Customer Profile (Normalization & Integrity)
                    string profileSql = @"
                        IF EXISTS (SELECT 1 FROM CustomerProfiles WHERE id = @uid)
                        BEGIN
                            UPDATE CustomerProfiles SET firstName=@fn, lastName=@ln, phoneNo=@ph, deliveryAdd=@ad, LoyaltyPoints = LoyaltyPoints + 1
                            WHERE id = @uid;
                        END
                        ELSE
                        BEGIN
                            INSERT INTO CustomerProfiles (id, firstName, lastName, phoneNo, deliveryAdd, LoyaltyPoints)
                            VALUES (@uid, @fn, @ln, @ph, @ad, 1);
                        END";

                    db.CRUD(profileSql, new Dictionary<string, object>
                    {
                        ["@uid"] = uid, ["@fn"] = FName, ["@ln"] = LName, ["@ph"] = PNo, ["@ad"] = Addr
                    });

                    // 2. Always INSERT into Customers (Order History Integrity)
                    string custSql = @"INSERT INTO Customers (id, firstName, lastName, deliveryAdd, [phoneNo], paymentMethod, orderSummary, TotalAmount, OrderDate) 
                                       VALUES (@uid, @fn, @ln, @ad, @ph, 'Gcash', @os, @total, GETDATE());
                                       SELECT SCOPE_IDENTITY();";

                    object result = db.ExecuteScalar(custSql, new Dictionary<string, object>
                    {
                        ["@uid"] = uid,
                        ["@fn"] = FName,
                        ["@ln"] = LName,
                        ["@ad"] = Addr,
                        ["@ph"] = PNo,
                        ["@os"] = OrderDetails,
                        ["@total"] = TotalAmount
                    });

                    int customerID = result != null && result != DBNull.Value ? Convert.ToInt32(result) : uid;

                    DBconnection.Log(CurrentUser, "Order Placed", "Checkout", $"GCash Order Ref {customerID} for P{TotalAmount:N2}");

                    db.CRUD("DELETE FROM Products WHERE id = @uid", new Dictionary<string, object> { ["@uid"] = uid });

                    new User_Confirm_Ewallet(CurrentUser, customerID) { Location = this.Location }.Show();
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Payment Error: " + ex.Message); }
        }

        private void Navigate<T>(Func<string, T> f) where T : Form
        {
            var form = f(CurrentUser);
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.Show();
            this.Close();
        }

        private void btnhome_Click(object sender, EventArgs e) => Navigate(u => new User_Home(u));
        private void btnProducts_Click(object sender, EventArgs e) => Navigate(u => new User_Products(u));
        private void cart_Click(object sender, EventArgs e) => Navigate(u => new User_Cart(u));
        private void Reviews_Click(object sender, EventArgs e) => Navigate(u => new User_Reviews(u));
    }
}