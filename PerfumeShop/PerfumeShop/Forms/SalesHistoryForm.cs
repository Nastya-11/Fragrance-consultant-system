using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using PerfumeShop.Database;

namespace PerfumeShop.Forms
{
    public partial class SalesHistoryForm : Form
    {
        public SalesHistoryForm()
        {
            InitializeComponent();
            LoadSales();
        }

        private void LoadSales()
        {
            string query = @"
                SELECT s.Id as SaleId, s.SaleDate as Дата, p.Name as Товар, si.Quantity as Кількість, si.Price as Ціна
                FROM Sales s
                INNER JOIN SaleItems si ON s.Id = si.SaleId
                INNER JOIN Products p ON si.ProductId = p.Id
                ORDER BY s.Id DESC";

            gridSales.DataSource = DatabaseHelper.GetDataTable(query);
        }
    }
}