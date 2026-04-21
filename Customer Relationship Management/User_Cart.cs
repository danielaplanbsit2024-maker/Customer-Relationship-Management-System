using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Customer_Relationship_Management
{
    public partial class User_Cart : Form
    {
        public string CurrentUser { get; private set; }
        private readonly string ConStr = DBconnection.ConnectionString;

        public User_Cart(string username)
        {
            InitializeComponent();
            CurrentUser = username;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.Load += (s, e) => LoadCartData();
            this.Load += (s, e) => UpdateCartCounter();
        }

        private Label cartQuantityBadge;

        private void UpdateCartCounter()
        {
            if (cartQuantityBadge == null)
            {
                cartQuantityBadge = new Label();
                cartQuantityBadge.AutoSize = true;
                cartQuantityBadge.Font = new Font("Verdana", 10F, FontStyle.Bold);
                cartQuantityBadge.ForeColor = Color.Red;
                cartQuantityBadge.BackColor = Color.Transparent;
                cartQuantityBadge.Location = new Point(954, 13);
                panel3.Controls.Add(cartQuantityBadge);
                cartQuantityBadge.BringToFront();
            }
            cartQuantityBadge.Text = DBconnection.GetCartCount(CurrentUser).ToString();
        }

        private void LoadCartData()
        {
            try
            {
                using (DBconnection db = new DBconnection(ConStr))
                {
                    var uid = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u", new Dictionary<string, object> { ["@u"] = CurrentUser });
                    if (uid == null || uid == DBNull.Value) return;

                    string sql = "SELECT prdDescription AS [ITEM], '29' AS [PRICE], COUNT(prdDescription) AS [QTY] FROM Products WHERE id = @id GROUP BY prdDescription";
                    dataGridView1.DataSource = db.Select(sql, new Dictionary<string, object> { ["@id"] = uid });

                    if (!dataGridView1.Columns.Contains("btnDelete"))
                    {
                        dataGridView1.Columns.Add(new DataGridViewButtonColumn { Name = "btnDelete", HeaderText = "ACTION", Text = "Remove", UseColumnTextForButtonValue = true, FlatStyle = FlatStyle.Flat });
                    }
                    CalculateSummary();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void CalculateSummary()
        {
            double subtotal = 0;
            int totalQty = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int qty = Convert.ToInt32(row.Cells["QTY"].Value);
                totalQty += qty;
                subtotal += qty * Convert.ToDouble(row.Cells["PRICE"].Value);
            }

            label7.Text = totalQty.ToString();
            label8.Text = $"P {subtotal:N2}";

            if (totalQty > 0)
            {
                label9.Text = "P 45.00";
                label10.Text = $"P {(subtotal + 45):N2}";
            }
            else
            {
                label9.Text = "P 0.00";
                label10.Text = "P 0.00";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                object itemObj = dataGridView1.Rows[e.RowIndex].Cells["ITEM"].Value;
                if (itemObj == null) return;

                string item = itemObj.ToString()!;

                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        var uid = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u",
                            new Dictionary<string, object> { ["@u"] = CurrentUser });

                        if (uid == null) return;

                        // Remove just ONE instance of the item (decrement)
                        string sql = "DELETE TOP (1) FROM Products WHERE prdDescription = @n AND id = @id";
                        db.CRUD(sql, new Dictionary<string, object> { ["@n"] = item, ["@id"] = uid });
                    }
                    LoadCartData();
                    UpdateCartCounter();
                }
                catch (Exception ex) { MessageBox.Show("Error deleting item: " + ex.Message); }
            }
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            StringBuilder sb = new StringBuilder();
            double sub = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string name = row.Cells["ITEM"].Value.ToString();
                int q = Convert.ToInt32(row.Cells["QTY"].Value);
                double p = Convert.ToDouble(row.Cells["PRICE"].Value);
                sb.AppendLine($"{name.PadRight(20)} x{q} ... P{q * p:N2}");
                sub += q * p;
            }

            new User_Cart_Checkout(CurrentUser, sb.ToString(), sub + 45) { Location = this.Location }.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear cart?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (DBconnection db = new DBconnection(ConStr))
                    {
                        var uid = db.ExecuteScalar("SELECT Id FROM Users WHERE username = @u",
                            new Dictionary<string, object> { ["@u"] = CurrentUser });

                        if (uid != null)
                        {
                            db.CRUD("DELETE FROM Products WHERE id = @id", new Dictionary<string, object> { ["@id"] = uid });
                        }
                    }
                    LoadCartData();
                    UpdateCartCounter();
                }
                catch (Exception ex) { MessageBox.Show("Error clearing cart: " + ex.Message); }
            }
        }

        private void Navigate<T>(Func<string, T> f) where T : Form
        {
            var form = f(CurrentUser); form.Location = this.Location; form.StartPosition = FormStartPosition.Manual; form.Show(); this.Hide();
        }

        private void button1_Click(object sender, EventArgs e) => Navigate(u => new User_Products(u));
        private void button2_Click(object sender, EventArgs e) => Navigate(u => new User_Home(u));
        private void button5_Click(object sender, EventArgs e) => Navigate(u => new User_Reviews(u));
        private void button4_Click(object sender, EventArgs e) => btnProceed_Click(sender, e);

        private void User_Cart_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}