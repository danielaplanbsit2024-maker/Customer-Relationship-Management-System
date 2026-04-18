using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class Dashboard : Form
    {
        private string ConStr = DBconnection.ConnectionString;

        public Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
            WireNavigation();
        }

        private void WireNavigation()
        {
            // Hide and Reposition
            btnDashboardToItems.Visible = false;
            btnDashboardToCategories.Visible = false;
            
            btnDashboardToSales.Left = 0;
            btnDashboardToCustomers.Left = btnDashboardToSales.Right;
            btnDashboardToHistory.Left = btnDashboardToCustomers.Right;
            btnDashboardLogout.Left = 1026;

            // Logout
            btnDashboardLogout.Click += (s, e) => {
                new Login() { Location = this.Location, StartPosition = FormStartPosition.Manual }.Show();
                this.Close();
            };

            // Navigation Buttons
            btnDashboardToSales.Click += (s, e) => Navigate(new Sales());
            btnDashboardToCustomers.Click += (s, e) => Navigate(new Customers());
            btnDashboardToHistory.Click += (s, e) => Navigate(new History());

            // Minimize
            btnMinimizeDashboard.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
        }

        private void Navigate(Form target)
        {
            target.Location = this.Location;
            target.StartPosition = FormStartPosition.Manual;
            target.Show();
            this.Close(); // Close current for security/memory as requested
        }

        private void LoadDashboardData()
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    // 1. TODAY'S SALES
                    string salesSql = "SELECT SUM(TotalAmount) FROM Customers WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)";
                    object sales = db.ExecuteScalar(salesSql);
                    decimal totalSales = sales != DBNull.Value ? Convert.ToDecimal(sales) : 0;
                    label2.Text = $"PHP {totalSales:N2}";

                    // 2. VS YESTERDAY (Calculation for trend)
                    string yesterdaySql = "SELECT SUM(TotalAmount) FROM Customers WHERE CAST(OrderDate AS DATE) = CAST(DATEADD(day, -1, GETDATE()) AS DATE)";
                    object ySales = db.ExecuteScalar(yesterdaySql);
                    decimal yesterdaySales = ySales != DBNull.Value ? Convert.ToDecimal(ySales) : 0;
                    
                    if (yesterdaySales > 0)
                    {
                        decimal diff = ((totalSales - yesterdaySales) / yesterdaySales) * 100;
                        label3.Text = $"vs. Yesterday: {(diff >= 0 ? "+" : "")}{diff:F1}%";
                    }
                    else label3.Text = "vs. Yesterday: 0.0%";

                    // 3. TRANSACTIONS
                    string transSql = "SELECT COUNT(*) FROM Customers WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)";
                    label5.Text = db.ExecuteScalar(transSql)?.ToString() ?? "0";

                    // 4. NEW CUSTOMERS (Unique IDs that appeared today for the first time)
                    string newCustSql = @"
                        SELECT COUNT(*) FROM (
                            SELECT id, MIN(OrderDate) as FirstOrder 
                            FROM Customers 
                            GROUP BY id
                        ) t WHERE CAST(FirstOrder AS DATE) = CAST(GETDATE() AS DATE)";
                    label8.Text = db.ExecuteScalar(newCustSql)?.ToString() ?? "0";

                    // 5. TOP SELLING (Simplified to show highest transaction amount)
                    string topSellingSql = "SELECT MAX(TotalAmount) FROM Customers";
                    object topVal = db.ExecuteScalar(topSellingSql);
                    label11.Text = $"PHP {(topVal != DBNull.Value ? Convert.ToDecimal(topVal) : 0):N2}";
                }
            }
            catch (Exception ex) { MessageBox.Show("Dashboard Load Error: " + ex.Message); }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboardToSales_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
