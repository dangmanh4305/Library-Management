using System;
using System.Windows.Forms;
using QLTV.Controllers;
using QLTV.Models;

namespace QLTV.Views.Auth
{
    public partial class frmChangePassword : Form
    {
        private AuthController _auth = new AuthController();

        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            // Hiển thị tên tài khoản đang đăng nhập, khóa không cho sửa
            txtTaiKhoan.Text = UserSession.Username;
            txtTaiKhoan.ReadOnly = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtMatKhauCu.Text;
            string matKhauMoi = txtMatKhauMoi.Text;
            string xacNhan = txtXacNhan.Text;

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(matKhauCu) ||
                string.IsNullOrEmpty(matKhauMoi) ||
                string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra độ dài
            if (matKhauMoi.Length < 3)
            {
                MessageBox.Show("Mật khẩu mới phải ít nhất 3 ký tự!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra khớp
            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacNhan.Clear();
                txtXacNhan.Focus();
                return;
            }

            // Kiểm tra mật khẩu mới không được giống cũ
            if (matKhauMoi == matKhauCu)
            {
                MessageBox.Show("Mật khẩu mới không được giống mật khẩu cũ!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi controller đổi mật khẩu
            bool result = _auth.ChangePassword(
                UserSession.UserId, matKhauCu, matKhauMoi);

            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!\nVui lòng đăng nhập lại.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauCu.Clear();
                txtMatKhauCu.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}