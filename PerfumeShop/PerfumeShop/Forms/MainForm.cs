using System;
using System.Windows.Forms;

namespace PerfumeShop.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            new ProductsForm().ShowDialog();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            new SalesForm().ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            new SalesHistoryForm().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}