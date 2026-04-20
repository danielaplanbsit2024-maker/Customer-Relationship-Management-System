using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class Customers : Form
    {
        private string ConStr = DBconnection.ConnectionString;

        public Customers()
        {
            InitializeComponent();
            WireNavigation();
            HighlightActiveTab();

            // Grid UI Setup
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Load += (s, e) => LoadCustomerData();
            dataGridView1.SelectionChanged += (s, e) => OnCustomerSelected();

            // Filters and Actions
            textBox1.TextChanged += (s, e) => LoadCustomerData();
            comboBox1.SelectedIndexChanged += (s, e) => LoadCustomerData();
            button5.Click += (s, e) => ClearFilters(); // CLEAR
            button2.Click += (s, e) => RedeemRewards(); // REDEEM
            button1.Click += (s, e) => EditCustomer(); // EDIT PROFILE
            button6.Click += (s, e) => AddCustomer(); // ADD NEW
        }

        private void AddCustomer()
        {
            Form addForm = new Form()
            {
                Width = 430,
                Height = 390,
                Text = "Add New Customer",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.Tan,
                Font = new Font("Verdana", 9),
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblF = new Label() { Text = "First Name:", Left = 20, Top = 20, Width = 110 };
            TextBox txtF = new TextBox() { Left = 145, Top = 18, Width = 240 };
            Label lblL = new Label() { Text = "Last Name:", Left = 20, Top = 60, Width = 110 };
            TextBox txtL = new TextBox() { Left = 145, Top = 58, Width = 240 };
            Label lblP = new Label() { Text = "Phone No:", Left = 20, Top = 100, Width = 110 };
            TextBox txtP = new TextBox() { Left = 145, Top = 98, Width = 240 };
            Label lblA = new Label() { Text = "Address:", Left = 20, Top = 140, Width = 110 };
            TextBox txtA = new TextBox() { Left = 145, Top = 138, Width = 240, Height = 70, Multiline = true };
            Label lblPoints = new Label() { Text = "Loyalty Points:", Left = 20, Top = 225, Width = 110 };
            NumericUpDown numPoints = new NumericUpDown() { Left = 145, Top = 223, Width = 120, Minimum = 0, Maximum = 1000 };

            Button btnSave = new Button()
            {
                Text = "ADD CUSTOMER",
                Left = 145,
                Top = 280,
                Width = 180,
                Height = 42,
                BackColor = Color.Sienna,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnSave.Click += (s, e) =>
            {
                string firstName = txtF.Text.Trim();
                string lastName = txtL.Text.Trim();
                string phone = txtP.Text.Trim();
                string address = txtA.Text.Trim();
                int loyaltyPoints = Decimal.ToInt32(numPoints.Value);

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(phone))
                {
                    MessageBox.Show("First name, last name, and phone number are required.");
                    return;
                }

                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        // Manual admin-added customers use negative IDs so they never collide with Users.Id identity values.
                        object nextIdObj = db.ExecuteScalar(
                            "SELECT ISNULL(MIN(CASE WHEN id <= 0 THEN id END), 0) - 1 FROM CustomerProfiles");
                        int nextCustomerId = Convert.ToInt32(nextIdObj);

                        db.CRUD(
                            @"INSERT INTO CustomerProfiles (id, firstName, lastName, phoneNo, deliveryAdd, LoyaltyPoints)
                              VALUES (@id, @fn, @ln, @ph, @ad, @lp)",
                            new Dictionary<string, object>
                            {
                                ["@id"] = nextCustomerId,
                                ["@fn"] = firstName,
                                ["@ln"] = lastName,
                                ["@ph"] = phone,
                                ["@ad"] = address,
                                ["@lp"] = loyaltyPoints
                            });

                        DBconnection.Log("Admin", "Customer Added", "Customers",
                            $"Added customer profile {firstName} {lastName} ({phone}).");

                        addForm.Tag = nextCustomerId;
                    }

                    addForm.DialogResult = DialogResult.OK;
                    addForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding customer: " + ex.Message);
                }
            };

            addForm.Controls.AddRange(new Control[] { lblF, txtF, lblL, txtL, lblP, txtP, lblA, txtA, lblPoints, numPoints, btnSave });

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomerData();

                if (addForm.Tag is int customerId)
                {
                    SelectCustomerRow(customerId);
                }

                MessageBox.Show("Customer added successfully!");
            }
        }

        private void EditCustomer()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to edit.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string cid = row.Cells["CustomerID"].Value.ToString();
            string fullName = row.Cells["FullName"].Value.ToString();
            string phone = row.Cells["ContactNo."].Value.ToString();

            // Split current name
            string[] names = fullName.Split(new[] { ' ' }, 2);
            string fName = names.Length > 0 ? names[0] : "";
            string lName = names.Length > 1 ? names[1] : "";

            // Create a quick dynamic dialog for editing
            Form editForm = new Form()
            {
                Width = 400,
                Height = 300,
                Text = "Edit Customer Profile",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.Tan,
                Font = new Font("Verdana", 9)
            };

            Label lblF = new Label() { Text = "First Name:", Left = 20, Top = 20, Width = 100 };
            TextBox txtF = new TextBox() { Text = fName, Left = 130, Top = 18, Width = 200 };
            Label lblL = new Label() { Text = "Last Name:", Left = 20, Top = 60, Width = 100 };
            TextBox txtL = new TextBox() { Text = lName, Left = 130, Top = 58, Width = 200 };
            Label lblP = new Label() { Text = "Phone No:", Left = 20, Top = 100, Width = 100 };
            TextBox txtP = new TextBox() { Text = phone, Left = 130, Top = 98, Width = 200 };

            Button btnSave = new Button() { Text = "SAVE CHANGES", Left = 130, Top = 160, Width = 200, Height = 40, BackColor = Color.Sienna, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnSave.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtF.Text) || string.IsNullOrWhiteSpace(txtL.Text) || string.IsNullOrWhiteSpace(txtP.Text))
                {
                    MessageBox.Show("All fields are required.");
                    return;
                }

                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        string sql = "UPDATE CustomerProfiles SET firstName = @fn, lastName = @ln, phoneNo = @ph WHERE id = @id";
                        db.CRUD(sql, new Dictionary<string, object>
                        {
                            ["@fn"] = txtF.Text.Trim(),
                            ["@ln"] = txtL.Text.Trim(),
                            ["@ph"] = txtP.Text.Trim(),
                            ["@id"] = cid
                        });

                        // Also update Name/Phone in the latest order logs to keep history readable (Optional but good for Integrity)
                        db.CRUD("UPDATE Customers SET firstName = @fn, lastName = @ln, phoneNo = @ph WHERE id = @id",
                            new Dictionary<string, object> { ["@fn"] = txtF.Text.Trim(), ["@ln"] = txtL.Text.Trim(), ["@ph"] = txtP.Text.Trim(), ["@id"] = cid });
                    }
                    editForm.DialogResult = DialogResult.OK;
                    editForm.Close();
                }
                catch (Exception ex) { MessageBox.Show("Error updating customer: " + ex.Message); }
            };

            editForm.Controls.AddRange(new Control[] { lblF, txtF, lblL, txtL, lblP, txtP, btnSave });

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Profile updated successfully!");
                LoadCustomerData();
            }
        }

        private void LoadCustomerData()
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    string sql = @"SELECT p.id AS [CustomerID], (p.firstName + ' ' + p.lastName) AS [FullName], 
                                   p.phoneNo AS [ContactNo.], ISNULL(SUM(c.TotalAmount), 0) AS [TotalSpend], 
                                   p.LoyaltyPoints AS [LoyaltyPoints], MAX(c.OrderDate) AS [LastVisitDate]
                                   FROM CustomerProfiles p
                                   LEFT JOIN Customers c ON p.id = c.id
                                   GROUP BY p.id, p.firstName, p.lastName, p.phoneNo, p.LoyaltyPoints
                                   HAVING 1=1";

                    var parameters = new Dictionary<string, object>();

                    string search = textBox1.Text.Trim();
                    if (!string.IsNullOrEmpty(search) && search != "SEARCH NAME / CONTACT#")
                    {
                        sql += " AND (p.firstName LIKE @s OR p.lastName LIKE @s OR p.phoneNo LIKE @s OR p.id LIKE @s)";
                        parameters["@s"] = "%" + search + "%";
                    }

                    if (comboBox1.SelectedIndex != -1)
                    {
                        string filter = comboBox1.SelectedItem.ToString();
                        if (filter == "VIP") sql += " AND p.LoyaltyPoints >= 50";
                        else if (filter == "New") sql += " AND p.LoyaltyPoints < 10";
                        else if (filter == "Inactive") sql += " AND (MAX(c.OrderDate) < DATEADD(month, -1, GETDATE()) OR MAX(c.OrderDate) IS NULL)";
                    }

                    DataTable dt = db.Select(sql, parameters);
                    dataGridView1.DataSource = dt;

                    label16.Visible = dt.Rows.Count == 0;
                    label5.Visible = dt.Rows.Count == 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading customers: " + ex.Message); }
        }

        private void OnCustomerSelected()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                string name = row.Cells["FullName"].Value?.ToString() ?? "N/A";

                object pointsObj = row.Cells["LoyaltyPoints"].Value;
                int points = (pointsObj == null || pointsObj == DBNull.Value) ? 0 : Convert.ToInt32(pointsObj);

                label3.Text = $"CURRENTLY SELECTED: {name}";

                string status = points >= 50 ? "GOLD" : points >= 20 ? "SILVER" : "BRONZE";
                label4.Text = $"LOYALTY STATUS: {status}";

                button2.Text = $"REDEEM REWARDS ({points} pts)";
                button2.Enabled = points >= 25;
            }
            else
            {
                label3.Text = "CURRENTLY SELECTED: NONE";
                label4.Text = "LOYALTY STATUS: -";
                button2.Text = "REDEEM REWARDS (0 pts)";
                button2.Enabled = false;
            }
        }

        private void ClearFilters()
        {
            textBox1.Text = "SEARCH NAME / CONTACT#";
            comboBox1.SelectedIndex = -1;
            LoadCustomerData();
        }

        private void SelectCustomerRow(int customerId)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["CustomerID"].Value == null || row.Cells["CustomerID"].Value == DBNull.Value)
                {
                    continue;
                }

                if (Convert.ToInt32(row.Cells["CustomerID"].Value) != customerId)
                {
                    continue;
                }

                dataGridView1.ClearSelection();
                row.Selected = true;
                dataGridView1.CurrentCell = row.Cells["CustomerID"];

                if (row.Index >= 0)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                }

                OnCustomerSelected();
                break;
            }
        }

        private void RedeemRewards()
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            var row = dataGridView1.SelectedRows[0];
            string cid = row.Cells["CustomerID"].Value?.ToString() ?? "";

            object pointsObj = row.Cells["LoyaltyPoints"].Value;
            int currentPoints = (pointsObj == null || pointsObj == DBNull.Value) ? 0 : Convert.ToInt32(pointsObj);

            if (currentPoints < 25)
            {
                MessageBox.Show("Not enough points to redeem rewards.");
                return;
            }

            if (MessageBox.Show($"Redeem 25 points for this customer?", "Redeem Rewards", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        db.CRUD("UPDATE CustomerProfiles SET LoyaltyPoints = LoyaltyPoints - 25 WHERE id = @id",
                            new Dictionary<string, object> { ["@id"] = cid });
                    }
                    MessageBox.Show("Rewards redeemed successfully!");
                    LoadCustomerData();
                }
                catch (Exception ex) { MessageBox.Show("Error redeeming rewards: " + ex.Message); }
            }
        }

        private void WireNavigation()
        {
            // Hide and Reposition

            btnCustomersToSales.Left = btnCustomersToDashboard.Right;
            btnDashboardToCustomers.Left = btnCustomersToSales.Right;
            btnCustomersToHistory.Left = btnDashboardToCustomers.Right;
            btnCustomersLogout.Left = 1026;

            btnCustomersToDashboard.Click += (s, e) => Navigate(new Dashboard());
            btnCustomersToSales.Click += (s, e) => Navigate(new Sales());
            btnCustomersToHistory.Click += (s, e) => Navigate(new History());

            btnCustomersLogout.Click += (s, e) =>
            {
                new Login() { Location = this.Location, StartPosition = FormStartPosition.Manual }.Show();
                this.Close();
            };
        }

        private void HighlightActiveTab()
        {
            btnDashboardToCustomers.BackColor = Color.FromArgb(75, 54, 33);
        }

        private void Navigate(Form target)
        {
            target.Location = this.Location;
            target.StartPosition = FormStartPosition.Manual;
            target.Show();
            this.Close();
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboardToCustomers_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomersToSales_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
