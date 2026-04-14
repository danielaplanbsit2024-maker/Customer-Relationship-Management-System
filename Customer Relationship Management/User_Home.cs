using System;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Home : Form
    {
        public string? CurrentUser { get; private set; }

        public User_Home(string username)
        {
            InitializeComponent();
            CurrentUser = username;

            if (!string.IsNullOrEmpty(CurrentUser))
                label1.Text = $"WELCOME BACK, {CurrentUser.ToUpper()}!";
        }

        private void Navigate<T>(Func<string, T> factory) where T : Form
        {
            T nextForm = factory(CurrentUser!);
            nextForm.Location = this.Location;
            nextForm.StartPosition = FormStartPosition.Manual;
            nextForm.Show();
            this.Close();
        }

        // Home Buttons
        private void button1_Click(object sender, EventArgs e) => Navigate(u => new User_Products(u));
        private void button4_Click(object sender, EventArgs e) => Navigate(u => new User_Products(u));
        private void button3_Click(object sender, EventArgs e) => Navigate(u => new User_Cart(u));
        private void button5_Click(object sender, EventArgs e) => Navigate(u => new User_Reviews(u));
    }
}