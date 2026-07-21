using System;
using System.Data.SQLite;
using System.Windows.Forms;
using PerfumeShop.Database;

namespace PerfumeShop.Forms
{
    public partial class AddEditProductForm : Form
    {
        private int? productId = null;

        public AddEditProductForm(int? id = null)
        {
            InitializeComponent();
            productId = id;

            if (productId.HasValue)
            {
                LoadProduct();
                lblTitle.Text = "Редагування товару";
            }
            else
            {
                lblTitle.Text = "Новий товар";
            }
        }

        private void LoadProduct()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                string q = $"SELECT * FROM Products WHERE Id={productId}";
                using (var cmd = new SQLiteCommand(q, conn))
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        txtName.Text = rd["Name"].ToString();
                        txtBrand.Text = rd["Brand"].ToString();
                        numPrice.Value = Convert.ToDecimal(rd["Price"]);
                        numQuantity.Value = Convert.ToDecimal(rd["Quantity"]);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string brand = txtBrand.Text.Trim();
            double price = Convert.ToDouble(numPrice.Value);
            int qty = Convert.ToInt32(numQuantity.Value);

            if (name == "" || brand == "")
            {
                MessageBox.Show("Заповніть всі поля!");
                return;
            }

            string q;

            if (productId == null)
            {
                q = $"INSERT INTO Products (Name, Brand, Price, Quantity) VALUES ('{name}', '{brand}', {price}, {qty})";
            }
            else
            {
                q = $@"UPDATE Products 
                       SET Name='{name}', Brand='{brand}', Price={price}, Quantity={qty}
                       WHERE Id={productId}";
            }

            DatabaseHelper.Execute(q);

            MessageBox.Show("Збережено!");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}