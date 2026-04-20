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
            {
                // Align everything to a consistent Left position (X coordinate)
                int leftAlignX = 650; // Aligned to the right of the coffee stand
                label1.Left = leftAlignX;
                label1.Text = "WELCOME BACK!";

                // Create the name label
                Label lblName = new Label();
                lblName.Text = CurrentUser.ToUpper();
                lblName.Font = new Font("Gabriola", 40F, FontStyle.Bold);
                lblName.ForeColor = Color.FromArgb(75, 54, 33);
                lblName.AutoSize = true;
                lblName.BackColor = Color.Transparent;

                // Align Name perfectly with the "W" in "WELCOME"
                lblName.Location = new Point(leftAlignX, label1.Top + 120);

                this.Controls.Add(lblName);
                lblName.BringToFront();

                // Align the rest of the UI to the same left position
                //label2.Left = leftAlignX;
                //label3.Left = leftAlignX;
                //button4.Left = leftAlignX;

                // Shift everything down to make room for the name
                int verticalShift = 130;
                label2.Top += verticalShift;
                label3.Top = label2.Bottom + 10;
                button4.Top = label3.Bottom + 20;

                // Wire up logout button
                btnlogout.Click += btnlogout_Click;

                // AddNavigationButtons();
                UpdateCartCounter();
            }
        }

        private Label cartQuantityBadge;


        //private void AddNavigationButtons()
        //{
        //    // Add Home Button
        //    Button btnHome = new Button();
        //    btnHome.Text = "HOME";
        //    btnHome.Location = new Point(698, 13);
        //    btnHome.Size = new Size(147, 46);
        //    btnHome.FlatStyle = FlatStyle.Flat;
        //    btnHome.FlatAppearance.BorderSize = 0;
        //    btnHome.BackColor = Color.FromArgb(75, 54, 33);
        //    btnHome.ForeColor = SystemColors.Info;
        //    btnHome.Font = new Font("Verdana", 9F);
        //    btnHome.Click += (s, e) => { /* Already on Home */ };
        //    panel3.Controls.Add(btnHome);

        //    // Add Cart Button
        //    Button btnCart = new Button();
        //    btnCart.Text = "CART";
        //    btnCart.Location = new Point(854, 13);
        //    btnCart.Size = new Size(147, 46);
        //    btnCart.FlatStyle = FlatStyle.Flat;
        //    btnCart.FlatAppearance.BorderSize = 0;
        //    btnCart.BackColor = Color.FromArgb(75, 54, 33);
        //    btnCart.ForeColor = SystemColors.Info;
        //    btnCart.Font = new Font("Verdana", 9F);
        //    btnCart.Click += (s, e) => Navigate(u => new User_Cart(u));
        //    panel3.Controls.Add(btnCart);

        //    // Add Reviews Button
        //    Button btnReviews = new Button();
        //    btnReviews.Text = "REVIEWS";
        //    btnReviews.Location = new Point(1010, 13);
        //    btnReviews.Size = new Size(147, 46);
        //    btnReviews.FlatStyle = FlatStyle.Flat;
        //    btnReviews.FlatAppearance.BorderSize = 0;
        //    btnReviews.BackColor = Color.FromArgb(75, 54, 33);
        //    btnReviews.ForeColor = SystemColors.Info;
        //    btnReviews.Font = new Font("Verdana", 9F);
        //    btnReviews.Click += (s, e) => Navigate(u => new User_Reviews(u));
        //    panel3.Controls.Add(btnReviews);

        //    // Add Cart Quantity Badge
        //    cartQuantityBadge = new Label();
        //    cartQuantityBadge.AutoSize = true;
        //    cartQuantityBadge.Font = new Font("Verdana", 10F, FontStyle.Bold);
        //    cartQuantityBadge.ForeColor = Color.Red;
        //    cartQuantityBadge.BackColor = Color.Transparent;
        //    cartQuantityBadge.Location = new Point(954, 13);
        //    cartQuantityBadge.Text = "0";
        //    panel3.Controls.Add(cartQuantityBadge);
        //    cartQuantityBadge.BringToFront();
        //} 

        private void UpdateCartCounter()
        {
            if (string.IsNullOrEmpty(CurrentUser)) return;
            if (cartQuantityBadge != null)
            {
                cartQuantityBadge.Text = DBconnection.GetCartCount(CurrentUser).ToString();
            }
        }

        private void btnlogout_Click(object? sender, EventArgs e)
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

        private void Navigate<T>(Func<string, T> factory) where T : Form
        {
            T nextForm = factory(CurrentUser!);
            nextForm.Location = this.Location;
            nextForm.StartPosition = FormStartPosition.Manual;
            nextForm.Show();
            this.Close();
        }

        // Home Buttons
        private void button4_Click(object sender, EventArgs e) => Navigate(u => new User_Products(u));

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void homeUsername_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) => Navigate(u => new User_Products(u));

        private void button3_Click_1(object sender, EventArgs e) => Navigate(u => new User_Cart(u));

        private void button5_Click(object sender, EventArgs e) => Navigate(u => new User_Reviews(u));

        private void btnlogout_Click_1(object sender, EventArgs e)
        {

        }
    }
}