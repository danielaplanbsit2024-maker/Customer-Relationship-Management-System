using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Products : Form
    {
        private string? CurrentUser;
        public string ConStr { get; private set; }

        public User_Products()
        {
            InitializeComponent();
            ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\joaqu\\source\\repos\\Customer-Relationship-Management-System\\Customer Relationship Management\\Database.mdf\";Integrated Security=True";
        }

        // Optional constructor so caller can pass the logged-in username
        public User_Products(string username) : this()
        {
            CurrentUser = username;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var productDesc = label3.Text?.Trim();
                    if (string.IsNullOrEmpty(productDesc))
                    {
                        MessageBox.Show("Product description cannot be empty.");
                        return;
                    }

                    if (string.IsNullOrEmpty(CurrentUser))
                    {
                        MessageBox.Show("No logged-in user available. Make sure you pass the username when opening this form.");
                        return;
                    }

                    // get the user's Id
                    var userIdObj = db.ExecuteScalar(
                        "SELECT Id FROM Users WHERE Username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser }
                    );

                    if (userIdObj == null || userIdObj == DBNull.Value)
                    {
                        MessageBox.Show("Unable to find current user in database.");
                        return;
                    }

                    int userId = Convert.ToInt32(userIdObj);

                    // insert product and user id (do not insert identity column)
                    string SQL = "INSERT INTO Products (prdDescription, id) VALUES (@product, @id)";
                    var parameters = new Dictionary<string, object>
                    {
                        ["@product"] = productDesc,
                        ["@id"] = userId
                    };

                    db.CRUD(SQL, parameters);
                    MessageBox.Show("Product added successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }

}
