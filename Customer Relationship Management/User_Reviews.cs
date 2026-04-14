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
            CurrentUser = username;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string feedback = reviewDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(feedback) || feedback == "FEEDBACK")
            {
                MessageBox.Show("Please enter your feedback before submitting.", "Empty Review");
                return;
            }

            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var uid = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u",
                        new Dictionary<string, object> { ["@u"] = CurrentUser });

                    if (uid != null)
                    {
                        db.CRUD("INSERT INTO Reviews (id, reviewDescriptio) VALUES (@uid, @desc)",
                            new Dictionary<string, object> { ["@uid"] = uid, ["@desc"] = feedback });

                        MessageBox.Show("Thank you for your feedback!", "Review Submitted");
                        reviewDescription.Clear();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        // --- NAVIGATION HELPER ---
        private void Navigate<T>(Func<string, T> factory) where T : Form
        {
            T nextForm = factory(CurrentUser);
            nextForm.Location = this.Location;
            nextForm.StartPosition = FormStartPosition.Manual;
            nextForm.Show();
            this.Close();
        }

        // --- NAVIGATION BUTTONS ---
        private void btnHome_Click(object sender, EventArgs e) => Navigate(u => new User_Home(u));
        private void button2_Click(object sender, EventArgs e) => Navigate(u => new User_Home(u));
        private void button1_Click(object sender, EventArgs e) => Navigate(u => new User_Products(u));
        private void button3_Click(object sender, EventArgs e) => Navigate(u => new User_Cart(u));
    }
}