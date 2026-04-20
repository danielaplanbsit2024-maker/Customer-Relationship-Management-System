using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class Sales : Form
    {
        private string ConStr = DBconnection.ConnectionString;

        public Sales()
        {
            InitializeComponent();
            WireNavigation();
            HighlightActiveTab();

            // UI Setup
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Initialize filters to current day
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;

            this.Load += (s, e) => LoadSalesData();

            btnDashboardLogout.Click += (s, e) => LoadSalesData(); // Apply Filters
            button3.Click += (s, e) => ClearFilters();
            btnExportToExcel.Click += (s, e) => ExportToExcel();
            button6.Click += (s, e) => ViewReceipt(); // View Receipts
            button5.Click += (s, e) => IssueRefund(); // Issue Refund
        }

        private void ViewReceipt()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to view receipt.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string invoice = row.Cells["InvoiceID"].Value.ToString();
            string date = row.Cells["Date and Time"].Value.ToString();
            string customer = row.Cells["Customer Name"].Value.ToString();
            string method = row.Cells["OrderID"].Value.ToString();
            string total = row.Cells["Total"].Value.ToString();

            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    string sql = "SELECT orderSummary FROM Customers WHERE id = @id";
                    object summary = db.ExecuteScalar(sql, new Dictionary<string, object> { ["@id"] = invoice });

                    string receipt = $"\n - - - - - BIG BREW RECEIPT - - - - -\n\n" +
                                     $"INVOICE ID: {invoice}\n" +
                                     $"DATE: {date}\n" +
                                     $"CUSTOMER: {customer}\n" +
                                     $"PAYMENT: {method}\n" +
                                     $"\n-------------------------------------\n" +
                                     $"ITEMS:\n{summary}\n" +
                                     $"-------------------------------------\n" +
                                     $"TOTAL PAID: P{Convert.ToDouble(total):N2}\n\n" +
                                     $" - - - - - THANK YOU! - - - - - ";

                    MessageBox.Show(receipt, "Transaction Receipt");
                }
            }
            catch (Exception ex) { MessageBox.Show("Error viewing receipt: " + ex.Message); }
        }

        private void IssueRefund()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to refund.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            string invoice = row.Cells["InvoiceID"].Value.ToString();
            string customer = row.Cells["Customer Name"].Value.ToString();

            var confirm = MessageBox.Show($"Are you sure you want to refund this order?\n\nInvoice: {invoice}\nCustomer: {customer}",
                "Confirm Refund", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        db.CRUD("DELETE FROM Customers WHERE id = @id", new Dictionary<string, object> { ["@id"] = invoice });
                    }
                    MessageBox.Show("Refund processed successfully.");
                    LoadSalesData();
                }
                catch (Exception ex) { MessageBox.Show("Error processing refund: " + ex.Message); }
            }
        }

        private void LoadSalesData()
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    string sql = @"SELECT id AS [InvoiceID], OrderDate AS [Date and Time], 
                                   (firstName + ' ' + lastName) AS [Customer Name], 
                                   paymentMethod AS [OrderID], 'Beverage' AS [Category], 
                                   (TotalAmount - 45) AS [Subtotal], '45.00' AS [Add-ons], 
                                   TotalAmount AS [Total] 
                                   FROM Customers 
                                   WHERE CAST(OrderDate AS DATE) BETWEEN CAST(@start AS DATE) AND CAST(@end AS DATE)";

                    var parameters = new Dictionary<string, object>
                    {
                        ["@start"] = dateTimePicker1.Value,
                        ["@end"] = dateTimePicker2.Value
                    };

                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        sql += " AND (firstName LIKE @search OR lastName LIKE @search OR id LIKE @search)";
                        parameters["@search"] = "%" + textBox1.Text.Trim() + "%";
                    }

                    DataTable dt = db.Select(sql, parameters);
                    dataGridView1.DataSource = dt;

                    // Hide placeholders if data exists
                    label16.Visible = dt.Rows.Count == 0;
                    label5.Visible = dt.Rows.Count == 0;

                    UpdateTotals(dt);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error loading sales: " + ex.Message); }
        }

        private void UpdateTotals(DataTable dt)
        {
            double total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDouble(row["Total"]);
            }

            label17.Text = $"TOTAL FOR PERIOD: PHP {total:N2}";
            label6.Text = $"Transactions: {dt.Rows.Count}";
        }

        private void ClearFilters()
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            textBox1.Clear();
            LoadSalesData();
        }

        private void ExportToExcel()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = $"Sales_Export_{DateTime.Now:yyyyMMdd_HHmm}.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        // Headers
                        var headerLine = new List<string>();
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            headerLine.Add($"\"{col.HeaderText}\"");
                        }
                        sb.AppendLine(string.Join(",", headerLine));

                        // Rows
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                var rowLine = new List<string>();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    rowLine.Add($"\"{cell.Value?.ToString().Replace("\"", "\"\"")}\"");
                                }
                                sb.AppendLine(string.Join(",", rowLine));
                            }
                        }

                        System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Sales data exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data: " + ex.Message);
                    }
                }
            }
        }

        private void WireNavigation()
        {
            // Hide and Reposition

            btnSales.Left = btnSalesToDashboard.Right;
            btnSalesToCustomers.Left = btnSales.Right;
            btnSalesToHistory.Left = btnSalesToCustomers.Right;
            btnSalesLogout.Left = 1026;

            btnSalesToDashboard.Click += (s, e) => Navigate(new Dashboard());
            btnSalesToCustomers.Click += (s, e) => Navigate(new Customers());
            btnSalesToHistory.Click += (s, e) => Navigate(new History());

            btnSalesLogout.Click += (s, e) =>
            {
                new Login() { Location = this.Location, StartPosition = FormStartPosition.Manual }.Show();
                this.Close();
            };
        }

        private void HighlightActiveTab()
        {
            btnSales.BackColor = Color.FromArgb(75, 54, 33); // Darker brown for active
        }

        private void Navigate(Form target)
        {
            target.Location = this.Location;
            target.StartPosition = FormStartPosition.Manual;
            target.Show();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSalesToCustomers_Click(object sender, EventArgs e)
        {

        }
    }
}
