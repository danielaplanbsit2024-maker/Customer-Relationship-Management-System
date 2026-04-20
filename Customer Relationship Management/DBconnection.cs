using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Customer_Relationship_Management
{
    internal class DBconnection : IDisposable
    {
        public static string ConnectionString { get; } = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;";
        
        private SqlConnection? conn;
        private string ConStr;

        public DBconnection(string? conStr = null)
        {
            ConStr = conStr ?? ConnectionString;
            conn = new SqlConnection(ConStr);
            conn.Open();
        }

        public static void EnsureSchemaUpdated()
        {
            try
            {
                using (DBconnection db = new DBconnection())
                {
                    // Check and add OrderDate if missing
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'OrderDate')
                       ALTER TABLE Customers ADD OrderDate DATETIME DEFAULT GETDATE();");

                    // Check and add TotalAmount if missing
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'TotalAmount')
                       ALTER TABLE Customers ADD TotalAmount DECIMAL(18, 2) DEFAULT 0;");

                    // Check and add LoyaltyPoints if missing
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'LoyaltyPoints')
                       ALTER TABLE Customers ADD LoyaltyPoints INT DEFAULT 0;");

                    // Check and add LastVisitDate if missing
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'LastVisitDate')
                       ALTER TABLE Customers ADD LastVisitDate DATETIME NULL;");

                    // Initialize existing NULL data to 0
                    db.CRUD("UPDATE Customers SET LoyaltyPoints = 0 WHERE LoyaltyPoints IS NULL;");
                    db.CRUD("UPDATE Customers SET TotalAmount = 0 WHERE TotalAmount IS NULL;");

                    // Create CustomerProfiles table for Normalization
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('CustomerProfiles') AND type = 'U')
                       CREATE TABLE CustomerProfiles (
                           id INT PRIMARY KEY, 
                           firstName NVARCHAR(50), 
                           lastName NVARCHAR(50), 
                           phoneNo NVARCHAR(20), 
                           deliveryAdd NVARCHAR(MAX), 
                           LoyaltyPoints INT DEFAULT 0
                       );");

                    // Migrate existing unique customers to the new Profiles table if empty
                    db.CRUD(@"IF NOT EXISTS (SELECT TOP 1 * FROM CustomerProfiles)
                       INSERT INTO CustomerProfiles (id, firstName, lastName, phoneNo, deliveryAdd, LoyaltyPoints)
                       SELECT id, MAX(firstName), MAX(lastName), MAX(phoneNo), MAX(deliveryAdd), MAX(LoyaltyPoints)
                       FROM Customers GROUP BY id;");

                    // Ensure Products (cart) has Price column
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Products') AND name = 'Price')
                       ALTER TABLE Products ADD Price DECIMAL(18, 2) DEFAULT 0;");

                    // Create AuditLogs table for History
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('AuditLogs') AND type = 'U')
                       CREATE TABLE AuditLogs (
                           LogID INT IDENTITY(1,1) PRIMARY KEY,
                           TimeStamp DATETIME DEFAULT GETDATE(),
                           [User] NVARCHAR(100),
                           Action NVARCHAR(100),
                           Module NVARCHAR(100),
                           Details NVARCHAR(MAX)
                       );");

                    // Create AdminUsers table for maintainable admin authentication and CRUD.
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('AdminUsers') AND type = 'U')
                       CREATE TABLE AdminUsers (
                           AdminId INT IDENTITY(1,1) PRIMARY KEY,
                           Username NVARCHAR(50) NOT NULL UNIQUE,
                           [Password] NVARCHAR(100) NOT NULL,
                           DisplayName NVARCHAR(100) NULL,
                           CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
                       );");

                    // Create EWallet table for digital payments
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('EWallet') AND type = 'U')
                       CREATE TABLE EWallet (
                           EWalletId INT IDENTITY(1,1) PRIMARY KEY,
                           Id INT,
                           walletName NVARCHAR(100),
                           phoneNo NVARCHAR(20),
                           amount DECIMAL(18, 2),
                           TransactionDate DATETIME DEFAULT GETDATE()
                       );");

                    db.CRUD(@"IF NOT EXISTS (SELECT 1 FROM AdminUsers WHERE Username = 'admin')
                       INSERT INTO AdminUsers (Username, [Password], DisplayName)
                       VALUES ('admin', '" + HashPassword("admin123") + @"', 'Default Administrator');");

                    // Ensure Users table exists and password column is long enough for hashes (SHA-256 is 64 hex chars)
                    db.CRUD(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('Users') AND type = 'U')
                       CREATE TABLE Users (
                           Id INT IDENTITY(1,1) PRIMARY KEY,
                           username NVARCHAR(50) NOT NULL UNIQUE,
                           password NVARCHAR(100) NOT NULL,
                           userType NVARCHAR(20) DEFAULT 'Customer'
                       );
                       ELSE
                       BEGIN
                           IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users' AND COLUMN_NAME = 'password' AND (CHARACTER_MAXIMUM_LENGTH < 64 AND CHARACTER_MAXIMUM_LENGTH <> -1))
                               ALTER TABLE Users ALTER COLUMN password NVARCHAR(100) NOT NULL;
                       END");
                }
            }
            catch { /* Silently handle if already exists or table locked */ }
        }

        public static void Log(string user, string action, string module, string details)
        {
            try
            {
                using (DBconnection db = new DBconnection())
                {
                    string sql = "INSERT INTO AuditLogs ([User], Action, Module, Details) VALUES (@u, @a, @m, @d)";
                    db.CRUD(sql, new Dictionary<string, object>
                    {
                        ["@u"] = user, ["@a"] = action, ["@m"] = module, ["@d"] = details
                    });
                }
            }
            catch { /* non-critical */ }
        }

        public int CRUD(string SQL, System.Collections.Generic.IDictionary<string, object>? parameters = null)
        {
            using (SqlCommand cmd = new SqlCommand(SQL, conn))
            {
                if (parameters != null)
                {
                    foreach (var kv in parameters)
                    {
                        cmd.Parameters.AddWithValue(kv.Key, kv.Value ?? DBNull.Value);
                    }
                }
                return cmd.ExecuteNonQuery();
            }
        }



        public object? ExecuteScalar(string SQL, System.Collections.Generic.IDictionary<string, object>? parameters = null)
        {
            using (SqlCommand cmd = new SqlCommand(SQL, conn))
            {
                if (parameters != null)
                {
                    foreach (var kv in parameters)
                    {
                        cmd.Parameters.AddWithValue(kv.Key, kv.Value ?? DBNull.Value);
                    }
                }
                return cmd.ExecuteScalar();
            }
        }

        public static int GetCartCount(string username)
        {
            if (string.IsNullOrEmpty(username)) return 0;
            try
            {
                using (DBconnection db = new DBconnection())
                {
                    var count = db.ExecuteScalar("SELECT COUNT(*) FROM Products WHERE id = (SELECT Id FROM Users WHERE username = @u)",
                        new Dictionary<string, object> { ["@u"] = username });
                    return Convert.ToInt32(count);
                }
            }
            catch { return 0; }
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var builder = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Prevents non-numeric input in a textbox.
        /// </summary>
        public static void BindNumericOnly(System.Windows.Forms.TextBox txt, bool allowDecimal = false)
        {
            txt.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (!allowDecimal || e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (allowDecimal && e.KeyChar == '.' && txt.Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            };
        }

        public static void SaveReceipt(string invoiceId, string customerName, string paymentMethod, string summary, decimal total)
        {
            try
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string folder = Path.Combine(appData, "BigBrewCRM", "Receipts");
                
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string fileName = Path.Combine(folder, $"Receipt_{invoiceId}.txt");
                string content = $"\n - - - - - BIG BREW RECEIPT - - - - -\n\n" +
                                 $"INVOICE ID: {invoiceId}\n" +
                                 $"DATE: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n" +
                                 $"CUSTOMER: {customerName}\n" +
                                 $"PAYMENT: {paymentMethod}\n" +
                                 $"\n-------------------------------------\n" +
                                 $"ITEMS:\n{summary}\n" +
                                 $"-------------------------------------\n" +
                                 $"TOTAL PAID: P{total:N2}\n\n" +
                                 $" - - - - - THANK YOU! - - - - - ";

                File.WriteAllText(fileName, content);
            }
            catch { /* non-critical */ }
        }

        public void Dispose()
        {
            if (conn != null)
            {
                try { conn.Close(); } catch { }
                conn.Dispose();
                conn = null;
            }
        }

        public DataTable Select(string sql, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConStr))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            conn.Open();
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Helpful for debugging SQL errors
                throw new Exception("Database Select Error: " + ex.Message);
            }
            return dt;
        }
    }
}
