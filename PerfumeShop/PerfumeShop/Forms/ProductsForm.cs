using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using PerfumeShop.Database;

namespace PerfumeShop.Forms
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        public void LoadProducts()
        {
            string name = txtSearchName.Text.Trim();
            string brand = txtSearchBrand.Text.Trim();

            string query = "SELECT * FROM Products WHERE 1=1";

            if (name != "")
                query += $" AND Name LIKE '%{name}%'";

            if (brand != "")
                query += $" AND Brand LIKE '%{brand}%'";

            gridProducts.DataSource = DatabaseHelper.GetDataTable(query);
            AddActionButtons();
        }

        private void AddActionButtons()
        {
            if (gridProducts.Columns.Contains("edit")) return;

            DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
            editCol.Name = "edit";
            editCol.HeaderText = "Редагувати";
            editCol.Text = "✏️";
            editCol.UseColumnTextForButtonValue = true;
            editCol.Width = 80;

            DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn();
            deleteCol.Name = "delete";
            deleteCol.HeaderText = "Видалити";
            deleteCol.Text = "🗑️";
            deleteCol.UseColumnTextForButtonValue = true;
            deleteCol.Width = 80;

            gridProducts.Columns.Add(editCol);
            gridProducts.Columns.Add(deleteCol);
        }

        private void SearchChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddEditProductForm().ShowDialog();
            LoadProducts();
        }

        private void gridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(gridProducts.Rows[e.RowIndex].Cells["Id"].Value);

            if (gridProducts.Columns[e.ColumnIndex].Name == "edit")
            {
                new AddEditProductForm(id).ShowDialog();
                LoadProducts();
            }
            else if (gridProducts.Columns[e.ColumnIndex].Name == "delete")
            {
                if (MessageBox.Show("Видалити товар?", "Підтвердження",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DatabaseHelper.Execute($"DELETE FROM Products WHERE Id={id}");
                    LoadProducts();
                }
            }
        }
    }
}