using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace PerfumeShop.Database
{
    internal static class DatabaseHelper
    {
        private static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db");
        private static readonly string ConnectionString = $"Data Source={DbPath};Version=3;";

        public static void Initialize()
        {
            if (!File.Exists(DbPath))
            {
                SQLiteConnection.CreateFile(DbPath);

                string initSql = File.ReadAllText(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "InitDatabase.sql")
                );

                using (var conn = GetConnection())
                {
                    conn.Open();
                    using (var cmd = new SQLiteCommand(initSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        public static DataTable GetDataTable(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var da = new SQLiteDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static void Execute(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}