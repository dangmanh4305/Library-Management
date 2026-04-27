using LibraryManagement.UI.Views.Librarian;
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

namespace QLTV.Views.Librarian
{
    public partial class frmLibrarian : Form
    {
        public frmLibrarian()
        {
            InitializeComponent();
        }

        private bool KiemTraTonTai(Form frm)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == frm.Name)
                {
                    f.Activate();
                    return true;
                }
            }
            return false;
        }

        private void mnuReaderManager_Click(object sender, EventArgs e)
        {
            // Bạn dán code gọi form frmReaderManager vào đây nhé:
            frmReaderManager frm = new frmReaderManager();
            if (!KiemTraTonTai(frm))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void mnuLoan_Click(object sender, EventArgs e)
        {
            // Khởi tạo form Quản lý Mượn Trả
            frmLoan frm = new frmLoan();
            if (!KiemTraTonTai(frm))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void mnuReaderManager_Click_1(object sender, EventArgs e)
        {
            frmReaderManager frm = new frmReaderManager();
            if (!KiemTraTonTai(frm))
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            var form = new QLTV.Views.Auth.frmChangePassword();
            form.ShowDialog();
        }

 
    }
}
