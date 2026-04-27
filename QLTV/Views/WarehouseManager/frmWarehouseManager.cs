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

namespace QLTV.Views.WarehouseManager
{
    public partial class frmWarehouseManager : Form
    {
        public frmWarehouseManager()
        {
            InitializeComponent();
        }

        private bool KiemTraTonTai(Form frm)
        {
            foreach (Form f in this.MdiChildren)
            {
                // Compare types rather than Name to avoid false matches
                if (f.GetType() == frm.GetType())
                {
                    f.Activate();
                    return true;
                }
            }
            return false;
        }
        private void mnuReaderManager_Click(object sender, EventArgs e)
        {
            frmBookManager frm = new frmBookManager();
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

        private void mnuDoiMatKhau_Click_Click(object sender, EventArgs e)
        {
            var form = new QLTV.Views.Auth.frmChangePassword();
            form.ShowDialog();
        }
    }
}
