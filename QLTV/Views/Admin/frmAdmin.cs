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
        // 💡 Gợi ý nhỏ: Nhìn tên hàm này là mình biết bạn chưa đổi (Name) của Menu "Hệ thống" 
        // thành "mnuSystem" như bài trước mình hướng dẫn nè. 
        // Bạn nhớ quay lại tab Design đổi lại cho code chuẩn và chuyên nghiệp nhé!
        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            // ĐÃ XÓA SẠCH code gọi frmHome ở đây!
            // Lý do: Theo luồng Splash Screen mới, frmHome đã được gọi chớp nhoáng từ lúc Đăng Nhập.
            // Khi frmAdmin này mở lên thì frmHome đã làm xong nhiệm vụ và tự tắt rồi.
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
            frmLogin frm = new frmLogin();
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (KiemTraTonTai(frm))
                {
                    foreach (Form f in Application.OpenForms)
                    {
                        if (f is frmLogin)
                        {
                            f.Activate();
                            break;
                        }
                    }
                }
                this.Close();
                frm.Show();
            }
        }


    }
}