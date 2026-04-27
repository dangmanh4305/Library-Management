using QLTV.Views.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV.Views.Admin
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private bool KiemTraTonTai(Form frm)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == frm.GetType())
                {
                    f.Activate();
                    return true;
                }
            }
            return false;
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Trống
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            // ĐÃ XÓA SẠCH code gọi frmHome ở đây!
            // Lý do: Theo luồng Splash Screen mới, frmHome đã được gọi chớp nhoáng từ lúc Đăng Nhập.
            // Khi frmAdmin này mở lên thì frmHome đã làm xong nhiệm vụ và tự tắt rồi.
        }

        // --- SỰ KIỆN GỌI FORM ĐỔI MẬT KHẨU ---
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Khởi tạo Form Đổi mật khẩu từ thư mục Auth
            frmChangePassword frm = new frmChangePassword();

            // Ép Form hiện ra ở chính giữa màn hình
            frm.StartPosition = FormStartPosition.CenterScreen;

            // Dùng ShowDialog() để bắt buộc người dùng phải tắt form đổi pass mới được thao tác tiếp trên form Admin
            frm.ShowDialog();
        }

        private void quảnLýNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStaffManager frm = new frmStaffManager();
            if (!KiemTraTonTai(frm))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDashboard frm = new frmDashboard();
            if (!KiemTraTonTai(frm))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripMenuItem1_Click_Click(object sender, EventArgs e)
        {
            var form = new QLTV.Views.Auth.frmChangePassword();
            form.ShowDialog();
        }
    }
}