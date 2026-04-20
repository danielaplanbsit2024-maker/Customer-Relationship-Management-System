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
            EnsureSchemaUpdated();
        }

        private void EnsureSchemaUpdated()
        {
            try
            {
                // Check and add OrderDate if missing
                CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'OrderDate')
                       ALTER TABLE Customers ADD OrderDate DATETIME DEFAULT GETDATE();");

                // Check and add TotalAmount if missing
                CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'TotalAmount')
                       ALTER TABLE Customers ADD TotalAmount DECIMAL(18, 2) DEFAULT 0;");

                // Check and add LoyaltyPoints if missing
                CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'LoyaltyPoints')
                       ALTER TABLE Customers ADD LoyaltyPoints INT DEFAULT 0;");

                // Check and add LastVisitDate if missing
                CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'LastVisitDate')
                       ALTER TABLE Customers ADD LastVisitDate DATETIME NULL;");

                // Initialize existing NULL data to 0
                CRUD("UPDATE Customers SET LoyaltyPoints = 0 WHERE LoyaltyPoints IS NULL;");
                CRUD("UPDATE Customers SET TotalAmount = 0 WHERE TotalAmount IS NULL;");

                // Create CustomerProfiles table for Normalization
                CRUD(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('CustomerProfiles') AND type = 'U')
                       CREATE TABLE CustomerProfiles (
                           id INT PRIMARY KEY, 
                           firstName NVARCHAR(50), 
                           lastName NVARCHAR(50), 
                           phoneNo NVARCHAR(20), 
                           deliveryAdd NVARCHAR(MAX), 
                           LoyaltyPoints INT DEFAULT 0
                       );");
                
                // Migrate existing unique customers to the new Profiles table if empty
                CRUD(@"IF NOT EXISTS (SELECT TOP 1 * FROM CustomerProfiles)
                       INSERT INTO CustomerProfiles (id, firstName, lastName, phoneNo, deliveryAdd, LoyaltyPoints)
                       SELECT id, MAX(firstName), MAX(lastName), MAX(phoneNo), MAX(deliveryAdd), MAX(LoyaltyPoints)
                       FROM Customers GROUP BY id;");

                // Ensure Products (cart) has Price column
                CRUD(@"IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Products') AND name = 'Price')
                       ALTER TABLE Products ADD Price DECIMAL(18, 2) DEFAULT 0;");

                // Create AuditLogs table for History
                CRUD(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('AuditLogs') AND type = 'U')
                       CREATE TABLE AuditLogs (
                           LogID INT IDENTITY(1,1) PRIMARY KEY,
                           TimeStamp DATETIME DEFAULT GETDATE(),
                           [User] NVARCHAR(100),
                           Action NVARCHAR(100),
                           Module NVARCHAR(100),
                           Details NVARCHAR(MAX)
                       );");

                // Create AdminUsers table for maintainable admin authentication and CRUD.
                CRUD(@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('AdminUsers') AND type = 'U')
                       CREATE TABLE AdminUsers (
                           AdminId INT IDENTITY(1,1) PRIMARY KEY,
                           Username NVARCHAR(50) NOT NULL UNIQUE,
                           [Password] NVARCHAR(100) NOT NULL,
                           DisplayName NVARCHAR(100) NULL,
                           CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
                       );");

                CRUD(@"IF NOT EXISTS (SELECT 1 FROM AdminUsers WHERE Username = 'admin')
                       INSERT INTO AdminUsers (Username, [Password], DisplayName)
                       VALUES ('admin', 'admin123', 'Default Administrator');");
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
