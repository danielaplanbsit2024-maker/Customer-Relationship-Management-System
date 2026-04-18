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

        private void WireNavigation()
        {
            // Hide and Reposition for a clean sequence
            btnHistoryToItems.Visible = false;
            btnHistoryToCategories.Visible = false;

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

            btnMinimizeHistory.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
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
    }
}
