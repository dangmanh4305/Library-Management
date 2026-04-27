using System;
using System.Data;
using System.Windows.Forms;
using QLTV.Controllers;

namespace QLTV.Views
{
    public partial class frmProfile : Form
    {
        ProfileController profileController = new ProfileController();
        int currentUserId;

        public frmProfile(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            LoadProfile();

            // 🔒 readonly
            txtUsername.ReadOnly = true;
            txtRole.ReadOnly = true;
        }

        // ================= LOAD =================
        private void LoadProfile()
        {
            DataTable dt = profileController.GetProfile(currentUserId);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                txtUsername.Text = row["Username"].ToString();
                txtName.Text = row["FullName"].ToString();
                txtRole.Text = row["RoleName"].ToString();

                // 👇 thêm dòng này
                txtStatus.Text = row["Status"].ToString();
            }
        }

        // ================= UPDATE NAME =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Nhập họ tên!");
                return;
            }

            bool result = profileController.UpdateProfile(currentUserId, name);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
                LoadProfile();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

         //================= CHANGE PASSWORD =================
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text.Trim();
            string newPass = txtNewPass.Text.Trim();
            string confirm = txtConfirmPass.Text.Trim();

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Nhập đầy đủ mật khẩu!");
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            bool result = profileController.ChangePassword(currentUserId, oldPass, newPass);

            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");

                txtOldPass.Clear();
                txtNewPass.Clear();
                txtConfirmPass.Clear();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu cũ!");
            }
        }
    }
}