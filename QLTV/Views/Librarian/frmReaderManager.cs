using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLTV.Controllers;
using QLTV.Models;

namespace QLTV.Views.Librarian
{
    public partial class frmReaderManager : Form
    {
        private readonly ReaderController _controller;
        private BindingSource _bs;

        public frmReaderManager()
        {
            InitializeComponent();
            _controller = new ReaderController();
            _bs = new BindingSource();

            // NOTE: btnAdd and btnSearch are already wired in the Designer.
            // Removing duplicate subscriptions here prevents handlers from running twice
            // which caused two dialog instances to open (close once, another stays).
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            btnX.Click += (s, e) => this.Close();
        }

        private void frmReaderManager_Load(object sender, EventArgs e)
        {
            LoadReaders();
            // Setup placeholder behavior
            txtSearch.GotFocus += (s, ev) =>
            {
                if (txtSearch.Text == "Nhập mã số thẻ, tên sđt") txtSearch.Text = "";
            };
            txtSearch.LostFocus += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text)) txtSearch.Text = "Nhập mã số thẻ, tên sđt";
            };
        }

        private void LoadReaders(string query = null)
        {
            try
            {
                List<Reader> list;
                if (string.IsNullOrWhiteSpace(query) || query == "Nhập mã số thẻ, tên sđt")
                    list = _controller.GetAllReaders();
                else
                    list = _controller.SearchReaders(query);

                _bs.DataSource = list;
                dataGridView1.DataSource = _bs;

                // Ensure button columns show their text (kept for backward compatibility)
                if (dataGridView1.Columns["btnEdit"] != null && dataGridView1.Columns["btnEdit"] is DataGridViewButtonColumn)
                {
                    var col = (DataGridViewButtonColumn)dataGridView1.Columns["btnEdit"];
                    col.UseColumnTextForButtonValue = true;
                    col.Text = "Sửa";
                    col.Width = 60;
                }
                if (dataGridView1.Columns["btnDel"] != null && dataGridView1.Columns["btnDel"] is DataGridViewButtonColumn)
                {
                    var col = (DataGridViewButtonColumn)dataGridView1.Columns["btnDel"];
                    col.UseColumnTextForButtonValue = true;
                    col.Text = "Xóa";
                    col.Width = 60;
                }

                // Adjust column headers
                if (dataGridView1.Columns["ReaderID"] != null)
                {
                    dataGridView1.Columns["ReaderID"].HeaderText = "Mã độc giả";
                    dataGridView1.Columns["ReaderID"].Width = 80;
                }
                if (dataGridView1.Columns["FullName"] != null)
                {
                    dataGridView1.Columns["FullName"].HeaderText = "Họ tên";
                    dataGridView1.Columns["FullName"].Width = 200;
                }
                if (dataGridView1.Columns["Phone"] != null)
                {
                    dataGridView1.Columns["Phone"].HeaderText = "SĐT";
                    dataGridView1.Columns["Phone"].Width = 120;
                }
                if (dataGridView1.Columns["Email"] != null)
                {
                    dataGridView1.Columns["Email"].HeaderText = "Email";
                    dataGridView1.Columns["Email"].Width = 180;
                }
                if (dataGridView1.Columns["CardExpiryDate"] != null)
                {
                    dataGridView1.Columns["CardExpiryDate"].HeaderText = "Ngày hết hạn";
                    dataGridView1.Columns["CardExpiryDate"].Width = 120;
                }
                if (dataGridView1.Columns["Status"] != null)
                {
                    dataGridView1.Columns["Status"].HeaderText = "Trạng thái";
                    dataGridView1.Columns["Status"].Width = 100;
                }
                if (dataGridView1.Columns["CreatedAt"] != null)
                {
                    dataGridView1.Columns["CreatedAt"].HeaderText = "Tạo lúc";
                    dataGridView1.Columns["CreatedAt"].Visible = false; // ẩn mặc định
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi nạp dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var q = txtSearch.Text;
            LoadReaders(q);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnSearch_Click(sender, EventArgs.Empty);
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as Reader;
                if (row == null) return;

                using (var frm = new frmAddEditReader())
                {
                    // set edit mode
                    frm.LoadReaderForEdit(row.ReaderID);
                    var dr = frm.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        LoadReaders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở sửa độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var colName = dataGridView1.Columns[e.ColumnIndex].Name;
                var row = dataGridView1.Rows[e.RowIndex].DataBoundItem as Reader;
                if (row == null) return;

                if (colName == "btnEdit")
                {
                    using (var frm = new frmAddEditReader())
                    {
                        frm.LoadReaderForEdit(row.ReaderID);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            LoadReaders();
                        }
                    }
                }
                else if (colName == "btnDel")
                {
                    var confirm = MessageBox.Show($"Bạn có chắc muốn xóa độc giả '{row.FullName}' (ID: {row.ReaderID})?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        string error;
                        var ok = _controller.DeleteReader(row.ReaderID, out error);
                        if (ok)
                        {
                            MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadReaders();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi xóa: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new frmAddEditReader())
            {
                frm.PrepareForAdd();
                var dr = frm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    LoadReaders();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // xử lý nút Sửa: lấy dòng đang chọn, mở form sửa
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 độc giả để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dataGridView1.SelectedRows[0].DataBoundItem as Reader;
            if (selected == null)
            {
                MessageBox.Show("Không thể đọc dữ liệu độc giả đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var frm = new frmAddEditReader())
                {
                    frm.LoadReaderForEdit(selected.ReaderID);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadReaders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            // xử lý nút Xóa: lấy dòng đang chọn, xác nhận, gọi controller xóa
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 độc giả để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dataGridView1.SelectedRows[0].DataBoundItem as Reader;
            if (selected == null)
            {
                MessageBox.Show("Không thể đọc dữ liệu độc giả đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa độc giả '{selected.FullName}' (ID: {selected.ReaderID})?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                string error;
                var ok = _controller.DeleteReader(selected.ReaderID, out error);
                if (ok)
                {
                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReaders();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}