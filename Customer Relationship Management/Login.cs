using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class Login : Form
    {
        public string ConStr { get; private set; }

        public Login()
        {
            InitializeComponent();
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnLoginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtLoginUsername.Text == "admin" || txtLoginPassword.Text == "admin123") { 
                    Dashboard dashboard = new Dashboard();
                    dashboard.Location = this.Location;
                    dashboard.StartPosition = FormStartPosition.Manual;
                    dashboard.Show();
                    this.Hide();
            }

            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var username = txtLoginUsername.Text?.Trim();
                    var password = txtLoginPassword.Text;

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Username and password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var result = db.ExecuteScalar("SELECT COUNT(1) FROM Users WHERE Username = @username AND Password = @password",
                        new Dictionary<string, object>
                        {
                            ["@username"] = username,
                            ["@password"] = password
                        });

                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        User_Home home = new User_Home(username!);
                        home.Location = this.Location;
                        home.StartPosition = FormStartPosition.Manual;
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoginRegister_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Location = this.Location;
            registerForm.StartPosition = FormStartPosition.Manual;
            registerForm.Show();
            this.Hide();
        }
    }
}
