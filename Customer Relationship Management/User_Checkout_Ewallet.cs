using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Checkout_Ewallet : Form
    {
        private string CurrentUser, OrderDetails, FName, LName, Addr, PNo;
        private double TotalAmount;
        private readonly string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

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
                    var uid = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u", new Dictionary<string, object> { ["@u"] = CurrentUser });

                    db.CRUD("INSERT INTO EWallet (Id, walletName, phoneNo, amount) VALUES (@uid, @wn, @ph, @am)",
                        new Dictionary<string, object> { ["@uid"] = uid, ["@wn"] = name.Text.Trim(), ["@ph"] = phoneNo.Text.Trim(), ["@am"] = paidAmount });

                    string custSql = @"INSERT INTO Customers (id, firstName, lastName, deliveryAdd, [phoneNo.], paymentMethod, orderSummary) 
                                       VALUES (@uid, @fn, @ln, @ad, @ph, 'Gcash', @os)";

                    db.CRUD(custSql, new Dictionary<string, object>
                    {
                        ["@uid"] = uid,
                        ["@fn"] = FName,
                        ["@ln"] = LName,
                        ["@ad"] = Addr,
                        ["@ph"] = PNo,
                        ["@os"] = OrderDetails
                    });

                    db.CRUD("DELETE FROM Products WHERE id = @uid", new Dictionary<string, object> { ["@uid"] = uid });

                    MessageBox.Show("Payment Successful! Order Confirmed.");
                    Navigate(u => new User_Home(u));
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