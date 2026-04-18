using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Confirm_Ewallet : Form
    {
        private string CurrentUser;
        private int CustomerID;

        public User_Confirm_Ewallet(string user, int cid)
        {
            InitializeComponent();
            CurrentUser = user;
            CustomerID = cid;

            label3.Text = $"Enjoy your order when it arrives. Have a good day!\n\nCustomer ID: {CustomerID}";
            
            // Wire up event handlers
            Backtohome.Click += (s, e) => Navigate(u => new User_Home(u));
            button2.Click += (s, e) => Navigate(u => new User_Home(u));
            button1.Click += (s, e) => Navigate(u => new User_Products(u));
            button3.Click += (s, e) => Navigate(u => new User_Cart(u));
            button5.Click += (s, e) => Navigate(u => new User_Reviews(u));
        }

        private void Navigate<T>(Func<string, T> f) where T : Form
        {
            var form = f(CurrentUser);
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.Show();
            this.Close();
        }
    }
}
