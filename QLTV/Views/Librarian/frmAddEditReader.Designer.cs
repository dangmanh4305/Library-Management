namespace QLTV.Views.Librarian
{
    partial class frmAddEditReader
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
            this.btnX = new System.Windows.Forms.Button();
            this.lbAdd = new System.Windows.Forms.Label();
            this.lbEdit = new System.Windows.Forms.Label();
            this.lbReaderID = new System.Windows.Forms.Label();
            this.txtReadID = new System.Windows.Forms.TextBox();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.lbFullname = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lbPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtCardExpiryDate = new System.Windows.Forms.TextBox();
            this.lbCardExpiryDate = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnX
            // 
            this.btnX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(763, -1);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(36, 37);
            this.btnX.TabIndex = 5;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            // 
            // lbAdd
            // 
            this.lbAdd.AutoSize = true;
            this.lbAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdd.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbAdd.Location = new System.Drawing.Point(272, 27);
            this.lbAdd.Name = "lbAdd";
            this.lbAdd.Size = new System.Drawing.Size(194, 26);
            this.lbAdd.TabIndex = 6;
            this.lbAdd.Text = "THÊM ĐỘC GIẢ";
            // 
            // lbEdit
            // 
            this.lbEdit.AutoSize = true;
            this.lbEdit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEdit.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbEdit.Location = new System.Drawing.Point(294, 27);
            this.lbEdit.Name = "lbEdit";
            this.lbEdit.Size = new System.Drawing.Size(169, 26);
            this.lbEdit.TabIndex = 7;
            this.lbEdit.Text = "SỬA ĐỘC GIẢ";
            // 
            // lbReaderID
            // 
            this.lbReaderID.AutoSize = true;
            this.lbReaderID.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbReaderID.Location = new System.Drawing.Point(108, 64);
            this.lbReaderID.Name = "lbReaderID";
            this.lbReaderID.Size = new System.Drawing.Size(86, 21);
            this.lbReaderID.TabIndex = 8;
            this.lbReaderID.Text = "Mã độc giả";
            // 
            // txtReadID
            // 
            this.txtReadID.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtReadID.Location = new System.Drawing.Point(248, 64);
            this.txtReadID.Name = "txtReadID";
            this.txtReadID.Size = new System.Drawing.Size(372, 29);
            this.txtReadID.TabIndex = 9;
            // 
            // txtFullname
            // 
            this.txtFullname.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtFullname.Location = new System.Drawing.Point(248, 121);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(372, 29);
            this.txtFullname.TabIndex = 11;
            // 
            // lbFullname
            // 
            this.lbFullname.AutoSize = true;
            this.lbFullname.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbFullname.Location = new System.Drawing.Point(108, 121);
            this.lbFullname.Name = "lbFullname";
            this.lbFullname.Size = new System.Drawing.Size(56, 21);
            this.lbFullname.TabIndex = 10;
            this.lbFullname.Text = "Họ tên";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtPhone.Location = new System.Drawing.Point(248, 177);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(372, 29);
            this.txtPhone.TabIndex = 13;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbPhone.Location = new System.Drawing.Point(108, 177);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(101, 21);
            this.lbPhone.TabIndex = 12;
            this.lbPhone.Text = "Số điện thoại";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtEmail.Location = new System.Drawing.Point(248, 237);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(372, 29);
            this.txtEmail.TabIndex = 15;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbEmail.Location = new System.Drawing.Point(108, 237);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(48, 21);
            this.lbEmail.TabIndex = 14;
            this.lbEmail.Text = "Email";
            // 
            // txtCardExpiryDate
            // 
            this.txtCardExpiryDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtCardExpiryDate.Location = new System.Drawing.Point(248, 294);
            this.txtCardExpiryDate.Name = "txtCardExpiryDate";
            this.txtCardExpiryDate.Size = new System.Drawing.Size(372, 29);
            this.txtCardExpiryDate.TabIndex = 17;
            // 
            // lbCardExpiryDate
            // 
            this.lbCardExpiryDate.AutoSize = true;
            this.lbCardExpiryDate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbCardExpiryDate.Location = new System.Drawing.Point(108, 294);
            this.lbCardExpiryDate.Name = "lbCardExpiryDate";
            this.lbCardExpiryDate.Size = new System.Drawing.Size(64, 21);
            this.lbCardExpiryDate.TabIndex = 16;
            this.lbCardExpiryDate.Text = "Hạn thẻ";
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.txtStatus.Location = new System.Drawing.Point(248, 351);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(372, 29);
            this.txtStatus.TabIndex = 19;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbStatus.Location = new System.Drawing.Point(108, 351);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(79, 21);
            this.lbStatus.TabIndex = 18;
            this.lbStatus.Text = "Trạng thái";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(205, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 30);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Gray;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(462, 397);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 30);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // frmAddEditReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnX;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.txtCardExpiryDate);
            this.Controls.Add(this.lbCardExpiryDate);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.lbFullname);
            this.Controls.Add(this.txtReadID);
            this.Controls.Add(this.lbReaderID);
            this.Controls.Add(this.lbEdit);
            this.Controls.Add(this.lbAdd);
            this.Controls.Add(this.btnX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddEditReader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditReader";
            this.Load += new System.EventHandler(this.frmAddEditReader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label lbAdd;
        private System.Windows.Forms.Label lbEdit;
        private System.Windows.Forms.Label lbReaderID;
        private System.Windows.Forms.TextBox txtReadID;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Label lbFullname;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.TextBox txtCardExpiryDate;
        private System.Windows.Forms.Label lbCardExpiryDate;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
    }
}