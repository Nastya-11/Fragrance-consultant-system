namespace PerfumeShop.Forms
{
    partial class SalesHistoryForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView gridSales;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.gridSales = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();

            // panelMain
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Location = new System.Drawing.Point(15, 15);
            this.panelMain.Size = new System.Drawing.Size(650, 380);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Controls.Add(this.gridSales);

            // lblTitle
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(180, 10);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.Text = "Історія продажів";

            // gridSales
            this.gridSales.Location = new System.Drawing.Point(20, 60);
            this.gridSales.Size = new System.Drawing.Size(610, 300);
            this.gridSales.ReadOnly = true;
            this.gridSales.AllowUserToAddRows = false;
            this.gridSales.AllowUserToDeleteRows = false;
            this.gridSales.RowHeadersVisible = false;
            this.gridSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // SalesHistoryForm
            this.ClientSize = new System.Drawing.Size(680, 420);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Історія продажів";

            ((System.ComponentModel.ISupportInitialize)(this.gridSales)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}