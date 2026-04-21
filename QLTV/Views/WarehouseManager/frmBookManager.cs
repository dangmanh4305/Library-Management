using System;
using System.Data;
using System.Windows.Forms;

namespace QLTV.Views.WarehouseManager
{
    public partial class frmBookManager : Form
    {
        public frmBookManager()
        {
            InitializeComponent();
        }

        // Sự kiện chạy khi form vừa mở lên
        private void frmWarehouseManager_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            frmBookManager frm = new frmBookManager();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        // ================= CÁC NÚT CHỨC NĂNG =================

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }
            // TODO: Viết lệnh INSERT INTO Books (Title, ISBN, CategoryID, IsRare, TotalQuantity, AvailableQuantity) VALUES (...)
            MessageBox.Show("Chức năng Thêm đang hoàn thiện!", "Thông báo");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách từ bảng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // TODO: Viết lệnh UPDATE Books SET Title = ..., ISBN = ... WHERE BookID = ...
            MessageBox.Show("Chức năng Sửa đang hoàn thiện!", "Thông báo");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBookID.Text))
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách từ bảng để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa cuốn sách này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // TODO: Viết lệnh DELETE FROM Books WHERE BookID = ...
                MessageBox.Show("Chức năng Xóa đang hoàn thiện!", "Thông báo");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            // TODO: Viết lệnh SELECT * FROM Books WHERE Title LIKE '%keyword%'
            MessageBox.Show("Đang tìm kiếm: " + keyword, "Thông báo");
        }

        // ================= SỰ KIỆN CLICK VÀO BẢNG DỮ LIỆU =================

        // Cập nhật lại: Click vào bất kỳ đâu trên dòng cũng sẽ đổ dữ liệu lên TextBox
        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tránh lỗi khi click vào dòng tiêu đề (RowIndex = -1)
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                // Đổ dữ liệu từ lưới lên các ô nhập liệu dựa theo đúng tên cột trong CSDL
                txtBookID.Text = row.Cells["BookID"].Value?.ToString();
                txtTitle.Text = row.Cells["Title"].Value?.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value?.ToString();

                // Set số lượng
                if (row.Cells["TotalQuantity"].Value != null)
                    numTotalQty.Value = Convert.ToDecimal(row.Cells["TotalQuantity"].Value);

                txtAvailableQty.Text = row.Cells["AvailableQuantity"].Value?.ToString();

                // Set checkbox sách hiếm
                if (row.Cells["IsRare"].Value != null)
                    chkIsRare.Checked = Convert.ToBoolean(row.Cells["IsRare"].Value);

                // Ghi chú: cmbCategory sẽ cần code gán ValueMember/DisplayMember sau khi lấy từ DB
                // cmbCategory.SelectedValue = row.Cells["CategoryID"].Value; 
            }
        }

        // ================= HÀM HỖ TRỢ =================

        private void ClearForm()
        {
            txtBookID.Clear();
            txtTitle.Clear();
            txtISBN.Clear();
            txtSearch.Clear();

            numTotalQty.Value = 0;
            txtAvailableQty.Clear();
            chkIsRare.Checked = false;

            if (cmbCategory.Items.Count > 0) cmbCategory.SelectedIndex = 0;

            txtTitle.Focus();
        }

        private void frmBookManager_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        
    }
}