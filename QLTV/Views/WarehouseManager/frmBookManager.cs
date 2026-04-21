using QLTV.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLTV.Views.WarehouseManager
{
    public partial class frmBookManager : Form
    {
        BookController bookController = new BookController();
        int selectedBookId = -1;

        public frmBookManager()
        {
            InitializeComponent();
        }
        Timer searchTimer = new Timer();

        private void frmBookManager_Load(object sender, EventArgs e)
        {
            LoadBooks();
            this.ActiveControl = txtTitle;
            searchTimer.Interval = 400; // 0.4s
            searchTimer.Tick += SearchTimer_Tick;
            this.BackColor = Color.FromArgb(245, 247, 250);

            StyleButtons();
            StyleLabels();
            StyleDataGridView();
            StyleTextBox();
        }

        private void LoadBooks()
        {
            dgvBooks.DataSource = bookController.GetAllBooks();
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBooks.Rows[e.RowIndex];

                selectedBookId = Convert.ToInt32(row.Cells["BookID"].Value);
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                txtCategoryId.Text = row.Cells["CategoryID"].Value.ToString();
                txtQuantity.Text = row.Cells["TotalQuantity"].Value.ToString();
                chkIsRare.Checked = Convert.ToBoolean(row.Cells["IsRare"].Value);
            }
        }

        private bool ValidateInput(out int categoryId, out int quantity)
        {
            categoryId = 0;
            quantity = 0;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!");
                return false;
            }

            if (!int.TryParse(txtCategoryId.Text, out categoryId) ||
                !int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Thể loại và số lượng phải là số!");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out int categoryId, out int quantity)) return;

            bool result = bookController.AddBook(
                txtTitle.Text,
                txtISBN.Text,
                categoryId,
                chkIsRare.Checked,
                quantity
            );

            MessageBox.Show(result ? "Thêm thành công!" : "Thêm thất bại!");
            if (result)
            {
                LoadBooks();
                ClearForm();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show("Vui lòng chọn sách!");
                return;
            }

            if (!ValidateInput(out int categoryId, out int quantity)) return;

            bool result = bookController.UpdateBook(
                selectedBookId,
                txtTitle.Text,
                txtISBN.Text,
                categoryId,
                chkIsRare.Checked
            );

            MessageBox.Show(result ? "Cập nhật thành công!" : "Cập nhật thất bại!");
            if (result)
            {
                LoadBooks();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show("Chọn sách để xóa!");
                return;
            }

            if (MessageBox.Show("Xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = bookController.DeleteBook(selectedBookId);
                MessageBox.Show(result ? "Xóa thành công!" : "Xóa thất bại!");
                if (result)
                {
                    LoadBooks();
                    ClearForm();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
            ClearForm();
        }

        private void ClearForm()
        {
            txtTitle.Clear();
            txtISBN.Clear();
            txtCategoryId.Clear();
            txtQuantity.Clear();
            chkIsRare.Checked = false;
            selectedBookId = -1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }
        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();

            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
                LoadBooks();
            else
                dgvBooks.DataSource = bookController.SearchBooks(keyword);
        }
        private void StyleButtons()
        {
            Button[] buttons = { btnAdd, btnUpdate, btnDelete, btnRefresh };

            foreach (var btn in buttons)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Height = 40;
                btn.Width = 100;
                btn.Cursor = Cursors.Hand;
            }

            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnUpdate.BackColor = Color.FromArgb(52, 152, 219);
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnRefresh.BackColor = Color.FromArgb(155, 89, 182);

            btnAdd.ForeColor = btnUpdate.ForeColor =
            btnDelete.ForeColor = btnRefresh.ForeColor = Color.White;
        }

        private void StyleLabels()
        {
            Label[] labels = { lblTitle, lblISBN, lblCategory, lblQuantity, label1 };

            foreach (var lbl in labels)
            {
                lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(52, 73, 94);
            }

            qly.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            qly.ForeColor = Color.FromArgb(41, 128, 185);
        }

        private void StyleDataGridView()
        {
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvBooks.RowTemplate.Height = 35;
            dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            dgvBooks.GridColor = Color.LightGray;
        }

        private void StyleTextBox()
        {
            TextBox[] tbs = { txtTitle, txtISBN, txtCategoryId, txtQuantity, txtSearch };

            foreach (var tb in tbs)
            {
                tb.Font = new Font("Segoe UI", 10);
                tb.Height = 30;
            }
        }
    }
}