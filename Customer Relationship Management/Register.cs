using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class Register : Form
    {
        private readonly string ConStr;

        public Register()
        {
            InitializeComponent();
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisterLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Location = this.Location;
            login.StartPosition = FormStartPosition.Manual;
            login.Show();
            this.Hide();
        }

        private void btnRegisterExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var username = txtRegisterUsername.Text?.Trim();
                var password = txtRegisterPassword.Text;
                var confirm = txtRegisterConfirmPass.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Username and password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirm)
                {
                    MessageBox.Show("Password and confirmation do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (DBconnection db = new DBconnection(ConStr))
                {
                    string sql = "INSERT INTO Users (Username, Password) VALUES (@username, @password)";
                    var parameters = new System.Collections.Generic.Dictionary<string, object>
                    {
                        { "@username", username },
                        { "@password", password }
                    };

                    int rowsAffected = db.CRUD(sql, parameters);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnRegisterLogin_Click(sender, e); // Redirect to login form
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
