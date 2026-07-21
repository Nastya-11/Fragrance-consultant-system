using System;
using System.Data.SQLite;
using PerfumeShop.Database;

namespace PerfumeShop.Services
{
    public class SaleService
    {
        public int CreateSale(DateTime saleDate, double total)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO Sales (SaleDate, Total) VALUES (@date, @total)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", saleDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.ExecuteNonQuery();

                    return (int)conn.LastInsertRowId;
                }
            }
        }

        public void AddSaleItem(int saleId, int productId, int qty, double price)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "INSERT INTO SaleItems (SaleId, ProductId, Quantity, Price) VALUES (@sale, @prod, @qty, @price)";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@sale", saleId);
                    cmd.Parameters.AddWithValue("@prod", productId);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int GetProductStock(int productId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "SELECT Quantity FROM Products WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void ReduceProductQuantity(int productId, int qty)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                string query = "UPDATE Products SET Quantity = Quantity - @qty WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}