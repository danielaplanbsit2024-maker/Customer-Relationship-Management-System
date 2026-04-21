using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class History : Form
    {
        private const string SearchPlaceholder = "SEARCH DETAILS";
        private string ConStr = DBconnection.ConnectionString;
        private bool suppressFilterReload;
        private DataTable currentHistoryData = new DataTable();

        public History()
        {
            InitializeComponent();
            WireNavigation();
            HighlightActiveTab();
            ConfigureGrid();
            ConfigureFilters();
            ConfigureSearchPlaceholder();

            Load += (s, e) => RefreshHistoryView();
            comboBox1.SelectedIndexChanged += (s, e) => ReloadHistoryData();
            dateTimePicker2.ValueChanged += (s, e) => ReloadHistoryData();
            dateTimePicker2.CloseUp += (s, e) => ReloadHistoryData();
            textBox1.TextChanged += (s, e) => ReloadHistoryData();

            button3.Click += (s, e) => ClearLogs();
            button1.Click += (s, e) => ExportLogs();
            btnAddadmin.Click += (s, e) => ShowAdminManager();
            btnMonitor.Click += (s, e) => ShowUserMonitor();
        }

        private void ConfigureGrid()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void ConfigureFilters()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM dd, yyyy";
            dateTimePicker2.ShowCheckBox = true;
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker2.Checked = false;
        }

        private void ConfigureSearchPlaceholder()
        {
            textBox1.ForeColor = Color.Gray;
            textBox1.Text = SearchPlaceholder;
            textBox1.GotFocus += (s, e) =>
            {
                if (textBox1.Text == SearchPlaceholder)
                {
                    textBox1.Text = string.Empty;
                    textBox1.ForeColor = Color.Black;
                }
            };
            textBox1.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Text = SearchPlaceholder;
                    textBox1.ForeColor = Color.Gray;
                }
            };
        }

        private void RefreshHistoryView()
        {
            LoadUserOptions();
            LoadHistoryData();
        }

        private void ReloadHistoryData()
        {
            if (!suppressFilterReload)
            {
                LoadHistoryData();
            }
        }

        private void LoadUserOptions()
        {
            try
            {
                suppressFilterReload = true;
                string selectedUser = comboBox1.SelectedItem?.ToString() ?? "All";

                using (DBconnection db = new DBconnection(ConStr))
                {
                    DataTable users = db.Select(
                        "SELECT DISTINCT [User] FROM AuditLogs WHERE NULLIF(LTRIM(RTRIM([User])), '') IS NOT NULL ORDER BY [User]",
                        new Dictionary<string, object>());

                    comboBox1.BeginUpdate();
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("All");

                    foreach (DataRow row in users.Rows)
                    {
                        string userName = row["User"]?.ToString() ?? string.Empty;
                        if (!string.IsNullOrWhiteSpace(userName))
                        {
                            comboBox1.Items.Add(userName);
                        }
                    }

                    comboBox1.SelectedItem = comboBox1.Items.Contains(selectedUser) ? selectedUser : "All";
                    comboBox1.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading user filters: " + ex.Message);
            }
            finally
            {
                suppressFilterReload = false;
            }
        }

        private void LoadHistoryData()
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    // Filter to show only Admin/System logs (exclude customer logins and orders)
                    string sql = @"SELECT LogID AS [Log ID],
                                          TimeStamp AS [Timestamp],
                                          [User],
                                          Action,
                                          Module,
                                          Details AS [Description / Notes]
                                   FROM AuditLogs
                                   WHERE (Action NOT LIKE 'Customer logged in%' AND Module <> 'Checkout')
                                     AND (Module <> 'User' OR Action LIKE 'Admin%')";
                    var parameters = new Dictionary<string, object>();

                    string selectedUser = comboBox1.SelectedItem?.ToString() ?? "All";
                    if (!string.Equals(selectedUser, "All", StringComparison.OrdinalIgnoreCase))
                    {
                        sql += " AND [User] = @user";
                        parameters["@user"] = selectedUser;
                    }

                    if (dateTimePicker2.Checked)
                    {
                        sql += " AND CAST(TimeStamp AS DATE) = CAST(@date AS DATE)";
                        parameters["@date"] = dateTimePicker2.Value.Date;
                    }

                    string search = textBox1.Text.Trim();
                    if (!string.IsNullOrWhiteSpace(search) && search != SearchPlaceholder)
                    {
                        sql += @" AND (
                                    CAST(LogID AS NVARCHAR(50)) LIKE @search
                                    OR [User] LIKE @search
                                    OR Action LIKE @search
                                    OR Module LIKE @search
                                    OR Details LIKE @search
                                 )";
                        parameters["@search"] = "%" + search + "%";
                    }

                    sql += " ORDER BY TimeStamp DESC, LogID DESC";

                    currentHistoryData = db.Select(sql, parameters);
                    dataGridView1.DataSource = currentHistoryData;

                    DataGridViewColumn? timestampColumn = dataGridView1.Columns["Timestamp"];
                    if (timestampColumn != null)
                    {
                        timestampColumn.DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt";
                    }

                    UpdateHistoryState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading history: " + ex.Message);
            }
        }

        private void UpdateHistoryState()
        {
            bool hasRows = currentHistoryData.Rows.Count > 0;

            label16.Text = hasRows ? string.Empty : "[no logs found]";
            label5.Text = hasRows ? string.Empty : "No audit log entries matched the selected filters.";
            label16.Visible = !hasRows;
            label5.Visible = !hasRows;
            label17.Text = $"LOGS AVAILABLE: {currentHistoryData.Rows.Count}";
        }

        private void ClearLogs()
        {
            if (MessageBox.Show("Are you sure you want to permanently clear all audit logs?", "Confirm Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        db.CRUD("DELETE FROM AuditLogs");
                    }
                    MessageBox.Show("Logs cleared successfully.");
                    RefreshHistoryView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing logs: " + ex.Message);
                }
            }
        }

        private void ExportLogs()
        {
            ExportDataGridToCsv(dataGridView1, "admin-audit-logs");
        }

        private string EscapeCsvValue(string value)
        {
            if (value.Contains(",") || value.Contains("\"") || value.Contains(Environment.NewLine))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }

        private void ShowAdminManager()
        {
            Form managerForm = new Form
            {
                Width = 920,
                Height = 620,
                Text = "Admin Manager",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(245, 236, 224),
                Font = new Font("Verdana", 9F)
            };

            TabControl tabs = new TabControl
            {
                Dock = DockStyle.Fill
            };

            TabPage existingTab = new TabPage("Existing Admins") { BackColor = Color.WhiteSmoke };
            TabPage addTab = new TabPage("Add Admin") { BackColor = Color.WhiteSmoke };

            DataGridView adminGrid = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 420,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White
            };

            Panel existingActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 90
            };

            Button btnRefreshAdmins = CreateAdminActionButton("REFRESH", 24, 20, Color.SaddleBrown, Color.White);
            Button btnEditAdmin = CreateAdminActionButton("EDIT", 214, 20, Color.Peru, Color.White);
            Button btnDeleteAdmin = CreateAdminActionButton("DELETE", 404, 20, Color.PeachPuff, Color.FromArgb(85, 61, 30));

            Label lblExistingNote = new Label
            {
                AutoSize = false,
                Left = 594,
                Top = 30,
                Width = 280,
                Height = 28,
                Text = "Manage admin usernames and passwords.",
                ForeColor = Color.FromArgb(85, 61, 30)
            };

            existingActions.Controls.AddRange(new Control[] { btnRefreshAdmins, btnEditAdmin, btnDeleteAdmin, lblExistingNote });
            existingTab.Controls.Add(existingActions);
            existingTab.Controls.Add(adminGrid);

            Label lblAddUsername = new Label { Text = "Username", Left = 40, Top = 50, Width = 140 };
            TextBox txtAddUsername = new TextBox { Left = 210, Top = 46, Width = 260 };
            Label lblAddDisplay = new Label { Text = "Display Name", Left = 40, Top = 105, Width = 140 };
            TextBox txtAddDisplay = new TextBox { Left = 210, Top = 101, Width = 260 };
            Label lblAddPassword = new Label { Text = "Password", Left = 40, Top = 160, Width = 140 };
            TextBox txtAddPassword = new TextBox { Left = 210, Top = 156, Width = 260, UseSystemPasswordChar = true };
            Label lblAddConfirm = new Label { Text = "Confirm Password", Left = 40, Top = 215, Width = 160 };
            TextBox txtAddConfirm = new TextBox { Left = 210, Top = 211, Width = 260, UseSystemPasswordChar = true };
            Button btnCreateAdmin = CreateAdminActionButton("CREATE ADMIN", 210, 280, Color.SaddleBrown, Color.White);

            addTab.Controls.AddRange(new Control[]
            {
                lblAddUsername, txtAddUsername,
                lblAddDisplay, txtAddDisplay,
                lblAddPassword, txtAddPassword,
                lblAddConfirm, txtAddConfirm,
                btnCreateAdmin
            });

            tabs.TabPages.Add(existingTab);
            tabs.TabPages.Add(addTab);
            managerForm.Controls.Add(tabs);

            void LoadAdminGrid()
            {
                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        DataTable admins = db.Select(
                            @"SELECT AdminId AS [Admin ID],
                                     Username,
                                     ISNULL(DisplayName, '') AS [Display Name],
                                     CreatedAt AS [Created At]
                              FROM AdminUsers
                              ORDER BY Username",
                            new Dictionary<string, object> { });
                        adminGrid.DataSource = admins;

                        if (adminGrid.Columns["Created At"] != null)
                        {
                            adminGrid.Columns["Created At"].DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading admins: " + ex.Message);
                }
            }

            btnRefreshAdmins.Click += (s, e) => LoadAdminGrid();

            btnCreateAdmin.Click += (s, e) =>
            {
                string username = txtAddUsername.Text.Trim();
                string displayName = txtAddDisplay.Text.Trim();
                string password = txtAddPassword.Text;
                string confirmPassword = txtAddConfirm.Text;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Username and password are required.");
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Password and confirmation do not match.");
                    return;
                }

                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        object existing = db.ExecuteScalar("SELECT COUNT(1) FROM AdminUsers WHERE Username = @username",
                            new Dictionary<string, object> { ["@username"] = username });

                        if (Convert.ToInt32(existing) > 0)
                        {
                            MessageBox.Show("That admin username already exists.");
                            return;
                        }

                        db.CRUD(
                            "INSERT INTO AdminUsers (Username, [Password], DisplayName) VALUES (@username, @password, @displayName)",
                            new Dictionary<string, object>
                            {
                                ["@username"] = username,
                                ["@password"] = DBconnection.HashPassword(password),
                                ["@displayName"] = string.IsNullOrWhiteSpace(displayName) ? DBNull.Value : displayName
                            });
                    }

                    DBconnection.Log("Admin", "Admin Added", "History", $"Created admin account '{username}'.");
                    txtAddUsername.Clear();
                    txtAddDisplay.Clear();
                    txtAddPassword.Clear();
                    txtAddConfirm.Clear();
                    tabs.SelectedTab = existingTab;
                    LoadAdminGrid();
                    RefreshHistoryView();
                    MessageBox.Show("Admin account created successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating admin: " + ex.Message);
                }
            };

            btnEditAdmin.Click += (s, e) =>
            {
                if (adminGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an admin to edit.");
                    return;
                }

                DataGridViewRow row = adminGrid.SelectedRows[0];
                int adminId = Convert.ToInt32(row.Cells["Admin ID"].Value);
                string currentUsername = row.Cells["Username"].Value?.ToString() ?? string.Empty;
                string currentDisplayName = row.Cells["Display Name"].Value?.ToString() ?? string.Empty;

                Form editForm = new Form
                {
                    Width = 430,
                    Height = 330,
                    Text = "Edit Admin",
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    BackColor = Color.Tan,
                    Font = new Font("Verdana", 9F)
                };

                Label lblUsername = new Label { Text = "Username", Left = 20, Top = 25, Width = 120 };
                TextBox txtUsername = new TextBox { Left = 160, Top = 22, Width = 220, Text = currentUsername };
                Label lblDisplay = new Label { Text = "Display Name", Left = 20, Top = 70, Width = 120 };
                TextBox txtDisplay = new TextBox { Left = 160, Top = 67, Width = 220, Text = currentDisplayName };
                Label lblPassword = new Label { Text = "New Password", Left = 20, Top = 115, Width = 120 };
                TextBox txtPassword = new TextBox { Left = 160, Top = 112, Width = 220, UseSystemPasswordChar = true };
                Label lblConfirm = new Label { Text = "Confirm Password", Left = 20, Top = 160, Width = 130 };
                TextBox txtConfirm = new TextBox { Left = 160, Top = 157, Width = 220, UseSystemPasswordChar = true };
                Label lblHint = new Label { Left = 20, Top = 200, Width = 360, Height = 35, Text = "Leave password blank if you only want to rename the admin." };
                Button btnSave = CreateAdminActionButton("SAVE", 160, 245, Color.SaddleBrown, Color.White);

                btnSave.Click += (sender, args) =>
                {
                    string newUsername = txtUsername.Text.Trim();
                    string newDisplayName = txtDisplay.Text.Trim();
                    string newPassword = txtPassword.Text;
                    string confirmPassword = txtConfirm.Text;

                    if (string.IsNullOrWhiteSpace(newUsername))
                    {
                        MessageBox.Show("Username is required.");
                        return;
                    }

                    if (!string.IsNullOrEmpty(newPassword) && newPassword != confirmPassword)
                    {
                        MessageBox.Show("Password and confirmation do not match.");
                        return;
                    }

                    try
                    {
                        using (DBconnection db = new DBconnection(ConStr))
                        {
                            object duplicate = db.ExecuteScalar(
                                "SELECT COUNT(1) FROM AdminUsers WHERE Username = @username AND AdminId <> @id",
                                new Dictionary<string, object> { ["@username"] = newUsername, ["@id"] = adminId });

                            if (Convert.ToInt32(duplicate) > 0)
                            {
                                MessageBox.Show("That username is already used by another admin.");
                                return;
                            }

                            if (string.IsNullOrEmpty(newPassword))
                            {
                                db.CRUD(
                                    "UPDATE AdminUsers SET Username = @username, DisplayName = @displayName WHERE AdminId = @id",
                                    new Dictionary<string, object>
                                    {
                                        ["@username"] = newUsername,
                                        ["@displayName"] = string.IsNullOrWhiteSpace(newDisplayName) ? DBNull.Value : newDisplayName,
                                        ["@id"] = adminId
                                    });
                            }
                            else
                            {
                                db.CRUD(
                                    "UPDATE AdminUsers SET Username = @username, DisplayName = @displayName, [Password] = @password WHERE AdminId = @id",
                                    new Dictionary<string, object>
                                    {
                                        ["@username"] = newUsername,
                                        ["@displayName"] = string.IsNullOrWhiteSpace(newDisplayName) ? DBNull.Value : newDisplayName,
                                        ["@password"] = DBconnection.HashPassword(newPassword),
                                        ["@id"] = adminId
                                    });
                            }
                        }

                        DBconnection.Log("Admin", "Admin Updated", "History", $"Updated admin account '{newUsername}'.");
                        editForm.DialogResult = DialogResult.OK;
                        editForm.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating admin: " + ex.Message);
                    }
                };

                editForm.Controls.AddRange(new Control[]
                {
                    lblUsername, txtUsername,
                    lblDisplay, txtDisplay,
                    lblPassword, txtPassword,
                    lblConfirm, txtConfirm,
                    lblHint, btnSave
                });

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAdminGrid();
                    RefreshHistoryView();
                }
            };

            btnDeleteAdmin.Click += (s, e) =>
            {
                if (adminGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an admin to delete.");
                    return;
                }

                DataGridViewRow row = adminGrid.SelectedRows[0];
                int adminId = Convert.ToInt32(row.Cells["Admin ID"].Value);
                string username = row.Cells["Username"].Value?.ToString() ?? string.Empty;

                if (MessageBox.Show($"Delete admin '{username}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        object adminCount = db.ExecuteScalar("SELECT COUNT(1) FROM AdminUsers", new Dictionary<string, object>());
                        if (Convert.ToInt32(adminCount) <= 1)
                        {
                            MessageBox.Show("At least one admin account must remain.");
                            return;
                        }

                        db.CRUD("DELETE FROM AdminUsers WHERE AdminId = @id", new Dictionary<string, object> { ["@id"] = adminId });
                    }

                    DBconnection.Log("Admin", "Admin Deleted", "History", $"Deleted admin account '{username}'.");
                    LoadAdminGrid();
                    RefreshHistoryView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting admin: " + ex.Message);
                }
            };

            LoadAdminGrid();
            managerForm.ShowDialog(this);
        }

        private void ShowUserMonitor()
        {
            Form monitorForm = new Form
            {
                Width = 1000,
                Height = 700,
                Text = "User Activity Monitor",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.FromArgb(245, 236, 224),
                Font = new Font("Verdana", 9F)
            };

            TabControl tabs = new TabControl { Dock = DockStyle.Fill };
            TabPage loginTab = new TabPage("User Sign-Ins") { BackColor = Color.WhiteSmoke };
            TabPage orderTab = new TabPage("User Orders") { BackColor = Color.WhiteSmoke };

            // --- TAB 1: USER SIGN-INS ---
            DataGridView loginGrid = CreateMonitorGrid();
            Panel loginActions = new Panel { Dock = DockStyle.Bottom, Height = 80 };
            Button btnExportLogins = CreateAdminActionButton("EXPORT SIGN-INS", 20, 15, Color.SaddleBrown, Color.White);
            btnExportLogins.Width = 220;
            loginActions.Controls.Add(btnExportLogins);
            loginTab.Controls.Add(loginGrid);
            loginTab.Controls.Add(loginActions);

            // --- TAB 2: USER ORDERS ---
            DataGridView orderGrid = CreateMonitorGrid();
            Panel orderActions = new Panel { Dock = DockStyle.Bottom, Height = 80 };
            Button btnExportOrders = CreateAdminActionButton("EXPORT ORDERS", 20, 15, Color.SaddleBrown, Color.White);
            btnExportOrders.Width = 220;
            orderActions.Controls.Add(btnExportOrders);
            orderTab.Controls.Add(orderGrid);
            orderTab.Controls.Add(orderActions);

            tabs.TabPages.Add(loginTab);
            tabs.TabPages.Add(orderTab);
            monitorForm.Controls.Add(tabs);

            void LoadLoginData()
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    DataTable dt = db.Select(
                        @"SELECT LogID AS [ID], TimeStamp AS [Time], [User], Details 
                          FROM AuditLogs 
                          WHERE Action LIKE 'Customer logged in%' 
                          ORDER BY TimeStamp DESC", new Dictionary<string, object>());
                    loginGrid.DataSource = dt;
                    if (loginGrid.Columns["Time"] != null) loginGrid.Columns["Time"].DefaultCellStyle.Format = "MMM dd, hh:mm tt";
                }
            }

            void LoadOrderData()
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    DataTable dt = db.Select(
                        @"SELECT OrderDate AS [Date], firstName + ' ' + lastName AS [Customer], 
                                 paymentMethod AS [Payment], TotalAmount AS [Total], orderSummary AS [Details]
                          FROM Customers ORDER BY OrderDate DESC", new Dictionary<string, object>());
                    orderGrid.DataSource = dt;
                    if (orderGrid.Columns["Date"] != null) orderGrid.Columns["Date"].DefaultCellStyle.Format = "MMM dd, hh:mm tt";
                    if (orderGrid.Columns["Total"] != null) orderGrid.Columns["Total"].DefaultCellStyle.Format = "P 0.00";
                }
            }

            btnExportLogins.Click += (s, e) => ExportDataGridToCsv(loginGrid, "user-signins");
            btnExportOrders.Click += (s, e) => ExportDataGridToCsv(orderGrid, "user-orders");

            monitorForm.Load += (s, e) => { LoadLoginData(); LoadOrderData(); };
            monitorForm.ShowDialog(this);
        }

        private DataGridView CreateMonitorGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None
            };
        }

        private void ExportDataGridToCsv(DataGridView grid, string prefix)
        {
            if (grid.Rows.Count == 0) { MessageBox.Show("No data to export."); return; }
            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV|*.csv", FileName = $"{prefix}-{DateTime.Now:yyyyMMdd}.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            var headers = new List<string>();
                            foreach (DataGridViewColumn col in grid.Columns) headers.Add(EscapeCsvValue(col.HeaderText));
                            sw.WriteLine(string.Join(",", headers));

                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                var cells = new List<string>();
                                foreach (DataGridViewCell cell in row.Cells) cells.Add(EscapeCsvValue(cell.Value?.ToString() ?? ""));
                                sw.WriteLine(string.Join(",", cells));
                            }
                        }
                        MessageBox.Show("Export successful!");
                    }
                    catch (Exception ex) { MessageBox.Show("Export failed: " + ex.Message); }
                }
            }
        }

        private Button CreateAdminActionButton(string text, int left, int top, Color backColor, Color foreColor)
        {
            Button button = new Button
            {
                Text = text,
                Left = left,
                Top = top,
                Width = 170,
                Height = 46,
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Verdana", 10F, FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            return button;
        }

        private void WireNavigation()
        {
            // Set consistent widths for the top navigation buttons.
            int btnWidth = 230;
            btnHistoryToDashboard.Size = new Size(btnWidth, 60);
            btnHistoryToSales.Size = new Size(btnWidth, 60);
            btnHistoryToCustomers.Size = new Size(btnWidth, 60);
            btnHistory.Size = new Size(btnWidth, 60);
            btnHistoryLogout.Size = new Size(130, 60);

            // Set positions in sequence
            btnHistoryToSales.Left = btnHistoryToDashboard.Right;
            btnHistoryToCustomers.Left = btnHistoryToSales.Right;
            btnHistory.Left = btnHistoryToCustomers.Right;
            btnHistoryLogout.Left = btnHistory.Right;

            btnHistoryToDashboard.Click += (s, e) => Navigate(new Dashboard());
            btnHistoryToSales.Click += (s, e) => Navigate(new Sales());
            btnHistoryToCustomers.Click += (s, e) => Navigate(new Customers());

            // Highlight the current tab
            btnHistory.BackColor = Color.FromArgb(75, 54, 33);

            btnHistoryLogout.Click += (s, e) =>
            {
                new Login() { Location = this.Location, StartPosition = FormStartPosition.Manual }.Show();
                this.Close();
            };
        }

        private void HighlightActiveTab()
        {
            // Already handled in WireNavigation for consistency
        }

        private void Navigate(Form target)
        {
            target.Location = this.Location;
            target.StartPosition = FormStartPosition.Manual;
            target.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnHistoryToCustomers_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click_1(object sender, EventArgs e)
        {

        }
    }
}
