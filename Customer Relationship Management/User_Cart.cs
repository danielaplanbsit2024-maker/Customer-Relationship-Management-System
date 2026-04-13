using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Cart : Form
    {
        public string CurrentUser { get; private set; }
        private readonly string ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

        public User_Cart(string username)
        {
            InitializeComponent();
            this.CurrentUser = username;

            // Configure Grid Appearance
            SetupDataGridView();

            this.Load += (s, e) => LoadCartData();
        }

        private void SetupDataGridView()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadCartData()
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar(
                        "SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser }
                    );

                    if (userIdObj != null && userIdObj != DBNull.Value)
                    {
                        int userId = Convert.ToInt32(userIdObj);

                        // Using 29 as a placeholder price for calculation logic
                        string sql = @"SELECT prdDescription AS [ITEM], 
                                             '29' AS [PRICE], 
                                             COUNT(prdDescription) AS [QTY] 
                                       FROM Products 
                                       WHERE id = @id 
                                       GROUP BY prdDescription";

                        DataTable dt = db.Select(sql, new Dictionary<string, object> { ["@id"] = userId });
                        dataGridView1.DataSource = dt;

                        // Add the Delete Button Column if it doesn't exist yet
                        if (!dataGridView1.Columns.Contains("btnDelete"))
                        {
                            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                            btnDelete.Name = "btnDelete";
                            btnDelete.HeaderText = "ACTION";
                            btnDelete.Text = "Remove";
                            btnDelete.UseColumnTextForButtonValue = true;
                            btnDelete.FlatStyle = FlatStyle.Flat;
                            dataGridView1.Columns.Add(btnDelete);
                        }

                        CalculateSummary();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading cart: " + ex.Message); }
        }

        private void CalculateSummary()
        {
            int totalItems = 0;
            double subtotal = 0;
            double deliveryFee = 45.00; // Example flat fee

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int qty = Convert.ToInt32(row.Cells["QTY"].Value);
                double price = Convert.ToDouble(row.Cells["PRICE"].Value);

                totalItems += qty;
                subtotal += (qty * price);
            }

            // Update your labels (using the names from your UI)
            label7.Text = totalItems.ToString();           // Total Items
            label8.Text = "P " + subtotal.ToString("N2");   // Subtotal
            label9.Text = "P " + deliveryFee.ToString("N2"); // Delivery Fee
            label10.Text = "P " + (subtotal + deliveryFee).ToString("N2"); // Grand Total
        }

        // --- GRID EVENTS ---

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Detect if the "Remove" button was clicked
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete" && e.RowIndex >= 0)
            {
                string itemName = dataGridView1.Rows[e.RowIndex].Cells["ITEM"].Value.ToString();

                if (MessageBox.Show($"Remove all {itemName} from cart?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RemoveItemFromDb(itemName);
                }
            }
        }

        private void RemoveItemFromDb(string itemName)
        {
            using (DBconnection db = new DBconnection(ConStr))
            {
                var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @username",
                    new Dictionary<string, object> { ["@username"] = CurrentUser });

                string sql = "DELETE FROM Products WHERE prdDescription = @name AND id = @uid";
                db.CRUD(sql, new Dictionary<string, object>
                {
                    ["@name"] = itemName,
                    ["@uid"] = userIdObj
                });

                LoadCartData(); // Refresh UI
            }
        }

        // --- NAVIGATION & CHECKOUT ---

        private void btnProceed_Click(object sender, EventArgs e) // Proceed to Checkout
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Oops");
                return;
            }

            StringBuilder sb = new StringBuilder();
            double subtotal = 0;
            double deliveryFee = 45.00;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                // Ensure we are grabbing the right column names from your SQL
                string itemName = row.Cells["ITEM"].Value?.ToString() ?? "Unknown";
                int qty = Convert.ToInt32(row.Cells["QTY"].Value ?? 0);
                double price = Convert.ToDouble(row.Cells["PRICE"].Value ?? 0);
                double lineTotal = qty * price;

                sb.AppendLine($"{itemName.PadRight(20)} x{qty} ... P{lineTotal:N2}");
                subtotal += lineTotal;
            }

            string finalSummary = sb.ToString();
            double finalTotal = subtotal + deliveryFee;

            // Pass the data to the checkout form
            User_Cart_Checkout checkout = new User_Cart_Checkout(CurrentUser, finalSummary, finalTotal);
            checkout.Location = this.Location;
            checkout.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e) // Clear Cart Button
        {
            if (MessageBox.Show("Clear entire cart?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var userIdObj = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @username",
                        new Dictionary<string, object> { ["@username"] = CurrentUser });

                    db.CRUD("DELETE FROM Products WHERE id = @id", new Dictionary<string, object> { ["@id"] = userIdObj });
                    LoadCartData();
                }
            }
        }

        // Navigation Buttons
        private void button1_Click(object sender, EventArgs e) => NavigateTo(u => new User_Products(u));
        private void button2_Click(object sender, EventArgs e) => NavigateTo(u => new User_Home(u));
        private void button5_Click(object sender, EventArgs e) => NavigateTo(u => new User_Reviews(u));

        private void button4_Click(object sender, EventArgs e)
        {
            btnProceed_Click(sender, e);

        }

        private void NavigateTo<T>(Func<string, T> formFactory) where T : Form
        {
            T nextForm = formFactory(CurrentUser);
            nextForm.Location = this.Location;
            nextForm.StartPosition = FormStartPosition.Manual;
            nextForm.Show();
            this.Close();
        }
    }
}