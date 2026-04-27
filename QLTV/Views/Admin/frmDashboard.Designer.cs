namespace QLTV
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblBorrowed = new System.Windows.Forms.Label();
            this.chartTopBooks = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.Location = new System.Drawing.Point(166, 85);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(165, 24);
            this.lblRevenue.TabIndex = 0;
            this.lblRevenue.Text = "Tổng Doanh Thu: ";
            // 
            // lblBorrowed
            // 
            this.lblBorrowed.AutoSize = true;
            this.lblBorrowed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorrowed.Location = new System.Drawing.Point(486, 85);
            this.lblBorrowed.Name = "lblBorrowed";
            this.lblBorrowed.Size = new System.Drawing.Size(167, 24);
            this.lblBorrowed.TabIndex = 1;
            this.lblBorrowed.Text = "Sách Đang Mượn: ";
            // 
            // chartTopBooks
            // 
            this.chartTopBooks.Location = new System.Drawing.Point(22, 209);
            this.chartTopBooks.Name = "chartTopBooks";
            this.chartTopBooks.Size = new System.Drawing.Size(766, 229);
            this.chartTopBooks.TabIndex = 2;
            this.chartTopBooks.Text = "cartesianChart1";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartTopBooks);
            this.Controls.Add(this.lblBorrowed);
            this.Controls.Add(this.lblRevenue);
            this.Name = "frmDashboard";
            this.Text = "frmDashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label lblBorrowed;
        private LiveCharts.WinForms.CartesianChart chartTopBooks;
    }
}