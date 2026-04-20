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
                    string sql = @"SELECT LogID AS [Log ID],
                                          TimeStamp AS [Timestamp],
                                          [User],
                                          Action,
                                          Module,
                                          Details AS [Description / Notes]
                                   FROM AuditLogs
                                   WHERE 1 = 1";
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
            if (currentHistoryData.Rows.Count == 0)
            {
                MessageBox.Show("There are no logs to export.");
                return;
            }

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                dialog.FileName = $"audit-logs-{DateTime.Now:yyyyMMdd-HHmmss}.csv";
                dialog.Title = "Export Audit Logs";

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    using (StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.UTF8))
                    {
                        for (int columnIndex = 0; columnIndex < currentHistoryData.Columns.Count; columnIndex++)
                        {
                            if (columnIndex > 0)
                            {
                                writer.Write(",");
                            }

                            writer.Write(EscapeCsvValue(currentHistoryData.Columns[columnIndex].ColumnName));
                        }

                        writer.WriteLine();

                        foreach (DataRow row in currentHistoryData.Rows)
                        {
                            for (int columnIndex = 0; columnIndex < currentHistoryData.Columns.Count; columnIndex++)
                            {
                                if (columnIndex > 0)
                                {
                                    writer.Write(",");
                                }

                                writer.Write(EscapeCsvValue(row[columnIndex]?.ToString() ?? string.Empty));
                            }

                            writer.WriteLine();
                        }
                    }

                    MessageBox.Show("Logs exported successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting logs: " + ex.Message);
                }
            }
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
                            new Dictionary<string, object>());
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
                                ["@password"] = password,
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
                                        ["@password"] = newPassword,
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
            // Hide and Reposition for a clean sequence

            btnHistoryToSales.Left = btnHistoryToDashboard.Right;
            btnHistoryToCustomers.Left = btnHistoryToSales.Right;
            btnHistory.Left = btnHistoryToCustomers.Right;
            btnHistoryLogout.Left = 1026; // Far right

            btnHistoryToDashboard.Click += (s, e) => Navigate(new Dashboard());
            btnHistoryToSales.Click += (s, e) => Navigate(new Sales());
            btnHistoryToCustomers.Click += (s, e) => Navigate(new Customers());

            btnHistoryLogout.Click += (s, e) =>
            {
                new Login() { Location = this.Location, StartPosition = FormStartPosition.Manual }.Show();
                this.Close();
            };
        }

        private void HighlightActiveTab()
        {
            btnHistory.BackColor = Color.FromArgb(75, 54, 33);
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
    }
}
