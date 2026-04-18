using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Checkout_COD : Form
    {
        private string CurrentUser, OrderDetails, FName, LName, Addr, PNo;
        private double TotalAmount;
        private string ConStr = DBconnection.ConnectionString;

        public User_Checkout_COD(string user, string summary, double total, string fn, string ln, string ad, string ph)
        {
            InitializeComponent();
            CurrentUser = user;
            OrderDetails = summary;
            TotalAmount = total;
            FName = fn; LName = ln; Addr = ad; PNo = ph;

            // Wire up header buttons
            button2.Click += (s, e) => Navigate(u => new User_Home(u));
            button1.Click += (s, e) => Navigate(u => new User_Products(u));
            button3.Click += (s, e) => Navigate(u => new User_Cart(u));
            button5.Click += (s, e) => Navigate(u => new User_Reviews(u));
            
            // Process the order immediately when this confirmation screen is shown
            this.Load += (s, e) => PlaceOrder();
        }

        private void PlaceOrder()
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var uidObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u", new Dictionary<string, object> { ["@u"] = CurrentUser });
                    int uid = Convert.ToInt32(uidObj);

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
                    string orderSql = @"INSERT INTO Customers (id, firstName, lastName, deliveryAdd, [phoneNo], paymentMethod, orderSummary, TotalAmount, OrderDate) 
                                       VALUES (@uid, @fn, @ln, @ad, @ph, 'COD', @os, @total, GETDATE());
                                       SELECT SCOPE_IDENTITY();";

                    object result = db.ExecuteScalar(orderSql, new Dictionary<string, object>
                    {
                        ["@uid"] = uid, ["@fn"] = FName, ["@ln"] = LName, ["@ad"] = Addr, ["@ph"] = PNo, ["@os"] = OrderDetails, ["@total"] = TotalAmount
                    });

                    // Note: Scope_Identity might fail if no identity col, using uid for customerID as a fallback for the display
                    int customerID = result != null && result != DBNull.Value ? Convert.ToInt32(result) : uid;
                    label3.Text = $"Have payment ready when your order arrives. Have a good day!\n\nOrder Ref: {customerID}";

                    DBconnection.Log(CurrentUser, "Order Placed", "Checkout", $"COD Order Ref {customerID} for P{TotalAmount:N2}");

                    db.CRUD("DELETE FROM Products WHERE id = @uid", new Dictionary<string, object> { ["@uid"] = uid });
                }
            }
            catch (Exception ex) { MessageBox.Show("Error processing order: " + ex.Message); }
        }

        private void Navigate<T>(Func<string, T> f) where T : Form
        {
            var form = f(CurrentUser);
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.Show();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // Already handled in PlaceOrder for COD
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Navigate(u => new User_Cart(u));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Navigate(u => new User_Home(u));
        }
    }
}
