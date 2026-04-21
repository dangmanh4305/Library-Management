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
    }
}