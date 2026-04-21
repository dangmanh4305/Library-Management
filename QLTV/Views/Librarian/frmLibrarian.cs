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

        private void mnuReaderManager_Click(object sender, EventArgs e)
        {
            // Bạn dán code gọi form frmReaderManager vào đây nhé:
            frmReaderManager frm = new frmReaderManager();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuLoan_Click(object sender, EventArgs e)
        {
            // Khởi tạo form Quản lý Mượn Trả
            frmLoan frm = new frmLoan();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
