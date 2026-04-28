namespace QLTV.Views.Admin
{
    partial class frmAdmin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1_Click = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânSựToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trangCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.quảnLýNhânSựToolStripMenuItem,
            this.báoCáoThốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangCáNhânToolStripMenuItem,
            this.toolStripMenuItem1_Click,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.thoátToolStripMenuItem.Text = "Đăng xuất";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1_Click
            // 
            this.toolStripMenuItem1_Click.Name = "toolStripMenuItem1_Click";
            this.toolStripMenuItem1_Click.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem1_Click.Text = "Đổi mật khẩu";
            this.toolStripMenuItem1_Click.Click += new System.EventHandler(this.toolStripMenuItem1_Click_Click);
            // 
            // quảnLýNhânSựToolStripMenuItem
            // 
            this.quảnLýNhânSựToolStripMenuItem.Name = "quảnLýNhânSựToolStripMenuItem";
            this.quảnLýNhânSựToolStripMenuItem.Size = new System.Drawing.Size(160, 29);
            this.quảnLýNhânSựToolStripMenuItem.Text = "Quản lý Nhân sự";
            this.quảnLýNhânSựToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânSựToolStripMenuItem_Click);
            // 
            // báoCáoThốngKêToolStripMenuItem
            // 
            this.báoCáoThốngKêToolStripMenuItem.Name = "báoCáoThốngKêToolStripMenuItem";
            this.báoCáoThốngKêToolStripMenuItem.Size = new System.Drawing.Size(182, 29);
            this.báoCáoThốngKêToolStripMenuItem.Text = "Báo cáo - Thống kê";
            this.báoCáoThốngKêToolStripMenuItem.Click += new System.EventHandler(this.báoCáoThốngKêToolStripMenuItem_Click);
            // 
            // trangCáNhânToolStripMenuItem
            // 
            this.trangCáNhânToolStripMenuItem.Name = "trangCáNhânToolStripMenuItem";
            this.trangCáNhânToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.trangCáNhânToolStripMenuItem.Text = "Trang cá nhân";
            this.trangCáNhânToolStripMenuItem.Click += new System.EventHandler(this.trangCáNhânToolStripMenuItem_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAdmin";
            this.Text = "frmAdmin";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânSựToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1_Click;
        private System.Windows.Forms.ToolStripMenuItem trangCáNhânToolStripMenuItem;
    }
}