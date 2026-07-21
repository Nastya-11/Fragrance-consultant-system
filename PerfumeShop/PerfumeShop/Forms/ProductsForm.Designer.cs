namespace PerfumeShop.Forms
{
    partial class ProductsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView gridProducts;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.TextBox txtSearchBrand;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.Label lblSearchBrand;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gridProducts = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.txtSearchBrand = new System.Windows.Forms.TextBox();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.lblSearchBrand = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).BeginInit();
            this.SuspendLayout();

            // gridProducts
            this.gridProducts.AllowUserToAddRows = false;
            this.gridProducts.AllowUserToDeleteRows = false;
            this.gridProducts.AllowUserToResizeRows = false;
            this.gridProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProducts.Location = new System.Drawing.Point(25, 100);
            this.gridProducts.MultiSelect = false;
            this.gridProducts.Name = "gridProducts";
            this.gridProducts.ReadOnly = true;
            this.gridProducts.RowHeadersVisible = false;
            this.gridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProducts.Size = new System.Drawing.Size(650, 300);
            this.gridProducts.TabIndex = 0;
            this.gridProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProducts_CellContentClick);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(540, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 40);
            this.btnAdd.Text = "Додати";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // txtSearchName
            this.txtSearchName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchName.Location = new System.Drawing.Point(130, 20);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(180, 25);
            this.txtSearchName.TextChanged += new System.EventHandler(this.SearchChanged);

            // txtSearchBrand
            this.txtSearchBrand.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchBrand.Location = new System.Drawing.Point(130, 60);
            this.txtSearchBrand.Name = "txtSearchBrand";
            this.txtSearchBrand.Size = new System.Drawing.Size(180, 25);
            this.txtSearchBrand.TextChanged += new System.EventHandler(this.SearchChanged);

            // lblSearchName
            this.lblSearchName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearchName.Location = new System.Drawing.Point(25, 20);
            this.lblSearchName.Size = new System.Drawing.Size(100, 25);
            this.lblSearchName.Text = "Назва:";

            // lblSearchBrand
            this.lblSearchBrand.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearchBrand.Location = new System.Drawing.Point(25, 60);
            this.lblSearchBrand.Size = new System.Drawing.Size(100, 25);
            this.lblSearchBrand.Text = "Бренд:";

            // ProductsForm
            this.ClientSize = new System.Drawing.Size(700, 420);
            this.Controls.Add(this.lblSearchName);
            this.Controls.Add(this.lblSearchBrand);
            this.Controls.Add(this.txtSearchName);
            this.Controls.Add(this.txtSearchBrand);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProductsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товари";

            ((System.ComponentModel.ISupportInitialize)(this.gridProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}