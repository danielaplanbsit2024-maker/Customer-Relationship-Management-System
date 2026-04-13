using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Customer_Relationship_Management
{
    internal class DBconnection : IDisposable
    {
        private SqlConnection conn;
        SqlCommand cmd;
        private string ConStr;

        public DBconnection(string conStr)
        {
            ConStr = conStr;
            conn = new SqlConnection(ConStr);
            conn.Open();
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
