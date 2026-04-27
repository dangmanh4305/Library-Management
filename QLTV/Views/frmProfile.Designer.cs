using System.Drawing;

namespace QLTV.Views
{
    partial class frmProfile
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtRole;

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnChangePass;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblRole;

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.txtName.Location = new System.Drawing.Point(374, 143);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(340, 30);
            this.txtName.TabIndex = 9;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.txtUsername.Location = new System.Drawing.Point(374, 193);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(340, 30);
            this.txtUsername.TabIndex = 10;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // txtRole
            // 
            this.txtRole.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.txtRole.Location = new System.Drawing.Point(374, 251);
            this.txtRole.Name = "txtRole";
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(340, 30);
            this.txtRole.TabIndex = 13;
            this.txtRole.TextChanged += new System.EventHandler(this.txtRole_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Lime;
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.btnUpdate.Location = new System.Drawing.Point(464, 389);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 45);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.BackColor = System.Drawing.Color.Yellow;
            this.btnChangePass.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.btnChangePass.Location = new System.Drawing.Point(856, 389);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(180, 45);
            this.btnChangePass.TabIndex = 15;
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(50, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRANG CÁ NHÂN";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.lblName.Location = new System.Drawing.Point(224, 143);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Họ tên";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.lblUser.Location = new System.Drawing.Point(224, 193);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(100, 23);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "Username";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.lblRole.Location = new System.Drawing.Point(224, 251);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 23);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Vai trò";
            this.lblRole.Click += new System.EventHandler(this.lblRole_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 800);
            this.panelLeft.TabIndex = 0;
            this.panelLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeft_Paint);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Location = new System.Drawing.Point(200, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 100);
            this.panelTop.TabIndex = 1;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.label1.Location = new System.Drawing.Point(224, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Trạng thái";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.txtStatus.Location = new System.Drawing.Point(374, 310);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(340, 30);
            this.txtStatus.TabIndex = 17;
            this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.label2.Location = new System.Drawing.Point(723, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.label2.TabIndex = 20;
            this.label2.Text = "Mật khẩu mới";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.txtNewPass.Location = new System.Drawing.Point(917, 195);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(255, 30);
            this.txtNewPass.TabIndex = 21;
            this.txtNewPass.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.label3.Location = new System.Drawing.Point(726, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Mật khẩu cũ";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.txtOldPass.Location = new System.Drawing.Point(917, 142);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(255, 30);
            this.txtOldPass.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.label4.Location = new System.Drawing.Point(720, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 23);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nhập lại mật khẩu mới";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.txtConfirmPass.Location = new System.Drawing.Point(917, 251);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(255, 30);
            this.txtConfirmPass.TabIndex = 23;
            // 
            // frmProfile
            // 
            this.ClientSize = new System.Drawing.Size(1199, 700);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnChangePass);
            this.Name = "frmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang cá nhân";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmPass;
    }
}