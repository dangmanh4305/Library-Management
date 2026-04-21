using System;
using System.Windows.Forms;
using QLTV.Controllers;
using QLTV.Models;
using QLTV.Views.Admin;
using QLTV.Views.Librarian;
using QLTV.Views.WarehouseManager;

namespace QLTV.Views.Auth
{
    public partial class frmLogin : Form
    {
        // Khởi tạo AuthController một lần duy nhất ở đây là đủ
        private AuthController _auth = new AuthController();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi hàm đăng nhập thông qua biến _auth đã khai báo ở trên
            bool success = _auth.Login(username, password);

            if (success)
            {
                // Chuyển toàn bộ luồng xử lý giao diện xuống hàm OpenMainFormByRole
                OpenMainFormByRole();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear(); // Xóa mật khẩu sai
                txtPassword.Focus(); // Đưa con trỏ chuột quay lại ô mật khẩu
            }
        }

        private void OpenMainFormByRole()
        {
            Form mainForm = null;

            // Rẽ nhánh dựa vào Role lưu trong UserSession
            switch (UserSession.Role)
            {
                case "Admin":
                    mainForm = new frmAdmin();
                    break;
                case "Librarian":
                    mainForm = new frmLibrarian();
                    break;
                case "WarehouseManager":
                    mainForm = new frmWarehouseManager();
                    break;
                default:
                    MessageBox.Show("Tài khoản chưa được cấp quyền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Cài đặt: Khi tắt form chính thì form Login sẽ hiện lại
            mainForm.FormClosed += (s, e) =>
            {
                this.Show();
                txtPassword.Clear(); // Xóa mật khẩu cũ cho an toàn khi đăng xuất
            };

            // Bước 1: Ẩn form Login đi trước cho gọn màn hình
            this.Hide();

            // Bước 2: Gọi form Chào mừng (Splash Screen) lên TRƯỚC TIÊN
            frmHome splash = new frmHome();

            // Dùng ShowDialog() để chặn luồng. 
            // Code sẽ dừng ở dòng này chờ đúng 3 giây cho đến khi Timer ở frmHome tắt form đi.
            splash.ShowDialog();

            // Bước 3: Sau khi form Chào mừng tự tắt đi, lúc này mới mở Form chính lên
            mainForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Bấm Enter ở ô mật khẩu sẽ tự động click nút Đăng nhập
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true; // Chặn tiếng "bíp" của Windows
            }
        }

        // 2 hàm này do lỡ click đúp trên Designer sinh ra, nếu không dùng cứ để trống nhé
        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }
    }
}