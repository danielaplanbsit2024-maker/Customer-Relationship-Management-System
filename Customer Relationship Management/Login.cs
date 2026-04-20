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
        public string ConStr { get; private set; } = DBconnection.ConnectionString;

        public Login()
        {
            InitializeComponent();
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

                    var hashedPassword = DBconnection.HashPassword(password);

                    // 1. Check Admin (supporting both hashed and plain for old 'admin123' account)
                    var adminResult = db.ExecuteScalar("SELECT COUNT(1) FROM AdminUsers WHERE Username = @username AND ([Password] = @password OR [Password] = @hashed)",
                        new Dictionary<string, object>
                        {
                            ["@username"] = username,
                            ["@password"] = password,
                            ["@hashed"] = hashedPassword
                        });

                    if (adminResult != null && Convert.ToInt32(adminResult) == 1)
                    {
                        // Upgrade admin password to hash if it was plain
                        db.CRUD("UPDATE AdminUsers SET [Password] = @hashed WHERE Username = @username AND [Password] = @password",
                            new Dictionary<string, object> { ["@username"] = username, ["@password"] = password, ["@hashed"] = hashedPassword });

                        DBconnection.Log(username, "Login Success", "Auth", "Administrator accessed the dashboard.");
                        Dashboard dashboard = new Dashboard();
                        dashboard.Location = this.Location;
                        dashboard.StartPosition = FormStartPosition.Manual;
                        dashboard.FormClosed += (s, args) => this.Close(); 
                        dashboard.Show();
                        this.Hide();
                        return;
                    }

                    // 2. Check Users (supporting both hashed and plain)
                    var result = db.ExecuteScalar("SELECT COUNT(1) FROM Users WHERE Username = @username AND (Password = @password OR Password = @hashed)",
                        new Dictionary<string, object>
                        {
                            ["@username"] = username,
                            ["@password"] = password,
                            ["@hashed"] = hashedPassword
                        });

                    if (result != null && Convert.ToInt32(result) == 1)
                    {
                        // Upgrade user password to hash if it was plain
                        db.CRUD("UPDATE Users SET Password = @hashed WHERE Username = @username AND Password = @password",
                            new Dictionary<string, object> { ["@username"] = username, ["@password"] = password, ["@hashed"] = hashedPassword });

                        DBconnection.Log(username, "Login Success", "Auth", "Customer logged in.");
                        User_Home home = new User_Home(username!);
                        home.Location = this.Location;
                        home.StartPosition = FormStartPosition.Manual;
                        home.FormClosed += (s, args) => this.Close();
                        home.Show();
                        this.Hide();
                    }
                    else
                    {
                        DBconnection.Log(username ?? "Unknown", "Login Failed", "Auth", "Invalid credentials provided.");
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
            registerForm.WindowState = FormWindowState.Normal;
            registerForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtLoginUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
