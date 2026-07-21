using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using PerfumeShop.Database;
using PerfumeShop.Services;

namespace PerfumeShop.Forms
{
    public partial class SalesForm : Form
    {
        private double currentPrice = 0;

        public SalesForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string q = "SELECT Id, Name, Price FROM Products";
                using (var cmd = new SQLiteCommand(q, conn))
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        cmbProducts.Items.Add(new ProductItem(
                            Convert.ToInt32(rd["Id"]),
                            rd["Name"].ToString(),
                            Convert.ToDouble(rd["Price"])
                        ));
                    }
                }
            }
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cmbProducts.SelectedItem as ProductItem;
            if (item != null)
            {
                currentPrice = item.Price;
                lblPriceValue.Text = currentPrice.ToString("0.00");
                UpdateTotal();
            }
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            double total = currentPrice * (int)numQty.Value;
            lblTotalValue.Text = total.ToString("0.00");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Виберіть товар!");
                return;
            }

            var product = cmbProducts.SelectedItem as ProductItem;
            int qty = (int)numQty.Value;
            double total = currentPrice * qty;

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                using (var tr = conn.BeginTransaction())
                {
                    string qStock = "SELECT Quantity FROM Products WHERE Id = @id";
                    var cmdStock = new SQLiteCommand(qStock, conn);
                    cmdStock.Parameters.AddWithValue("@id", product.Id);

                    int currentStock = Convert.ToInt32(cmdStock.ExecuteScalar());

                    if (qty > currentStock)
                    {
                        MessageBox.Show($"Недостатньо товару!\nНа складі: {currentStock}.");
                        tr.Rollback();
                        return;
                    }

                    string q1 = "INSERT INTO Sales (SaleDate, Total) VALUES (datetime('now'), @total)";
                    var cmd1 = new SQLiteCommand(q1, conn);
                    cmd1.Parameters.AddWithValue("@total", total);
                    cmd1.ExecuteNonQuery();

                    long saleId = conn.LastInsertRowId;

                    string q2 = "INSERT INTO SaleItems (SaleId, ProductId, Quantity, Price) VALUES (@sale, @prod, @qty, @price)";
                    var cmd2 = new SQLiteCommand(q2, conn);
                    cmd2.Parameters.AddWithValue("@sale", saleId);
                    cmd2.Parameters.AddWithValue("@prod", product.Id);
                    cmd2.Parameters.AddWithValue("@qty", qty);
                    cmd2.Parameters.AddWithValue("@price", currentPrice);
                    cmd2.ExecuteNonQuery();

                    string q3 = "UPDATE Products SET Quantity = Quantity - @qty WHERE Id = @id";
                    var cmd3 = new SQLiteCommand(q3, conn);
                    cmd3.Parameters.AddWithValue("@qty", qty);
                    cmd3.Parameters.AddWithValue("@id", product.Id);
                    cmd3.ExecuteNonQuery();

                    tr.Commit();
                }
            }

            var productsForm = Application.OpenForms["ProductsForm"] as ProductsForm;
            if (productsForm != null)
            {
                productsForm.Invoke(new Action(() => productsForm.LoadProducts()));
            }

            MessageBox.Show("Продаж оформлено!");
            this.Close();
        }

        private class ProductItem
        {
            public int Id { get; }
            public string Name { get; }
            public double Price { get; }

            public ProductItem(int id, string name, double price)
            {
                Id = id;
                Name = name;
                Price = price;
            }

            public override string ToString() => Name;
        }
    }
}