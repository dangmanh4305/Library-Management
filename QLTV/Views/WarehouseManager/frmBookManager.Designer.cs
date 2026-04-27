namespace QLTV.Views.WarehouseManager
{
    partial class frmBookManager
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.TextBox txtCategoryId;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.CheckBox chkIsRare;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtSearch;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.chkIsRare = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.qly = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBooks
            // 
            this.dgvBooks.ColumnHeadersHeight = 34;
            this.dgvBooks.Location = new System.Drawing.Point(103, 110);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersWidth = 62;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(760, 200);
            this.dgvBooks.TabIndex = 2;
            this.dgvBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBooks_CellClick);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(179, 352);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(228, 26);
            this.txtTitle.TabIndex = 3;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(179, 382);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(228, 26);
            this.txtISBN.TabIndex = 4;
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(179, 412);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(228, 26);
            this.txtCategoryId.TabIndex = 5;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(179, 442);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(228, 26);
            this.txtQuantity.TabIndex = 6;
            // 
            // chkIsRare
            // 
            this.chkIsRare.Location = new System.Drawing.Point(179, 472);
            this.chkIsRare.Name = "chkIsRare";
            this.chkIsRare.Size = new System.Drawing.Size(104, 24);
            this.chkIsRare.TabIndex = 7;
            this.chkIsRare.Text = "Sách hiếm";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(429, 352);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(429, 432);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(429, 472);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(429, 392);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(91, 352);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Tên sách";
            // 
            // lblISBN
            // 
            this.lblISBN.Location = new System.Drawing.Point(91, 382);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(100, 23);
            this.lblISBN.TabIndex = 13;
            this.lblISBN.Text = "ISBN";
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(91, 412);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 23);
            this.lblCategory.TabIndex = 14;
            this.lblCategory.Text = "Thể loại";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(91, 442);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 23);
            this.lblQuantity.TabIndex = 15;
            this.lblQuantity.Text = "Số lượng";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(663, 326);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 26);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // qly
            // 
            this.qly.AutoSize = true;
            this.qly.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qly.ForeColor = System.Drawing.SystemColors.Highlight;
            this.qly.Location = new System.Drawing.Point(87, 35);
            this.qly.Name = "qly";
            this.qly.Size = new System.Drawing.Size(452, 64);
            this.qly.TabIndex = 16;
            this.qly.Text = "QUẢN LÝ SÁCH";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(593, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tìm kiếm";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBookManager
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 565);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qly);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtCategoryId);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.chkIsRare);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblQuantity);
            this.Name = "frmBookManager";
            this.Text = "Quản lý sách";
            this.Load += new System.EventHandler(this.frmBookManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label qly;
        private System.Windows.Forms.Label label1;
    }
}