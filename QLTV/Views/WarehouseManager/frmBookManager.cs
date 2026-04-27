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
        Timer searchTimer = new Timer();

        public frmBookManager()
        {
            InitializeComponent();
        }

        private void frmBookManager_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            LoadBooks();
            LoadCategories();
            cbCategory.DropDownStyle = ComboBoxStyle.DropDown;

            this.ActiveControl = txtTitle;
            this.BackColor = Color.FromArgb(245, 247, 250);

            searchTimer.Interval = 400;
            searchTimer.Tick += SearchTimer_Tick;
        }

        // ================= LOAD =================
        private void LoadBooks()
        {
            dgvBooks.DataSource = bookController.GetAllBooks();
            FormatGrid();
        }

        // ================= FORMAT GRID =================
        private void FormatGrid()
        {
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Set width cố định
            dgvBooks.Columns["BookID"].Width = 70;
            dgvBooks.Columns["Title"].Width = 400;
            dgvBooks.Columns["ISBN"].Width = 120;
            dgvBooks.Columns["CategoryName"].Width = 150;
            dgvBooks.Columns["TotalQuantity"].Width = 70;
            dgvBooks.Columns["AvailableQuantity"].Width = 60;
            dgvBooks.Columns["IsRare"].Width = 100;


            dgvBooks.Columns["BookID"].HeaderText = "Mã sách";
            dgvBooks.Columns["Title"].HeaderText = "Tên sách";
            dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
            dgvBooks.Columns["CategoryName"].HeaderText = "Thể loại";
            dgvBooks.Columns["TotalQuantity"].HeaderText = "Tổng số";
            dgvBooks.Columns["AvailableQuantity"].HeaderText = "Còn lại";
            dgvBooks.Columns["IsRare"].HeaderText = "Sách hiếm";

            // Ẩn ID
            dgvBooks.Columns["CategoryID"].Visible = false;
        }

        // ================= CLICK GRID =================
        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBooks.Rows[e.RowIndex];

                selectedBookId = Convert.ToInt32(row.Cells["BookID"].Value);
                txtTitle.Text = row.Cells["Title"].Value.ToString();
                txtISBN.Text = row.Cells["ISBN"].Value.ToString();
                cbCategory.SelectedValue = row.Cells["CategoryID"].Value;
                txtQuantity.Text = row.Cells["TotalQuantity"].Value.ToString();
                chkIsRare.Checked = Convert.ToBoolean(row.Cells["IsRare"].Value);
            }
        }
        private void LoadCategories()
        {
            cbCategory.DataSource = bookController.GetCategories();
            cbCategory.DisplayMember = "CategoryName";
            cbCategory.ValueMember = "CategoryID";

            cbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        // ================= VALIDATE =================
        private bool ValidateInput(out int categoryId, out int quantity)
        {
            categoryId = 0;
            quantity = 0;

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!");
                return false;
            }

            if (cbCategory.SelectedValue == null)
            {
                MessageBox.Show("Chọn thể loại!");
                return false;
            }

            categoryId = Convert.ToInt32(cbCategory.SelectedValue);

            if (!int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Số lượng phải là số!");
                return false;
            }

            return true;
        }

        // ================= ADD =================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // ===== VALIDATE =====
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Nhập tên sách!");
                    txtTitle.Focus();
                    return;
                }

                if (!int.TryParse(txtQuantity.Text, out int quantity))
                {
                    MessageBox.Show("Số lượng phải là số!");
                    txtQuantity.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtISBN.Text))
                {
                    MessageBox.Show("Nhập ISBN!");
                    txtISBN.Focus();
                    return;
                }

                if (bookController.IsISBNExists(txtISBN.Text))
                {
                    MessageBox.Show("ISBN đã tồn tại!",
                                    "Cảnh báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    txtISBN.Focus();
                    return;
                }

                // ===== CATEGORY =====
                int categoryId;

                if (cbCategory.SelectedValue != null &&
                    int.TryParse(cbCategory.SelectedValue.ToString(), out categoryId))
                {
                }
                else
                {
                    string newCategory = cbCategory.Text.Trim();

                    if (string.IsNullOrEmpty(newCategory))
                    {
                        MessageBox.Show("Nhập thể loại!");
                        return;
                    }

                    categoryId = bookController.AddCategory(newCategory);

                    LoadCategories();
                    cbCategory.SelectedValue = categoryId;
                }

                // ===== INSERT BOOK =====
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
            catch (MySqlConnector.MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("ISBN đã tồn tại!",
                                    "Lỗi trùng dữ liệu",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi database: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        // ================= UPDATE =================
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

            MessageBox.Show(result ? "Cập nhật thành công!" : "Thất bại!");

            if (result)
            {
                LoadBooks();
                ClearForm();
            }
        }

        // ================= DELETE =================
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

                MessageBox.Show(result ? "Xóa thành công!" : "Thất bại!");

                if (result)
                {
                    LoadBooks();
                    ClearForm();
                }
            }
        }

        // ================= REFRESH =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Clear();
            LoadBooks();
            ClearForm();
        }

        // ================= CLEAR =================
        private void ClearForm()
        {
            txtTitle.Clear();
            txtISBN.Clear();
            txtQuantity.Clear();
            chkIsRare.Checked = false;
            selectedBookId = -1;
        }

        // ================= SEARCH REALTIME =================
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
            {
                LoadBooks();
            }
            else
            {
                dgvBooks.DataSource = bookController.SearchBooks(keyword);
                FormatGrid();
            }
        }

        // ================= STYLE =================
        private void StyleDataGridView()
        {
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.BackgroundColor = Color.White;

            dgvBooks.DefaultCellStyle.Font = new Font("Times New Roman", 10);

            dgvBooks.EnableHeadersVisualStyles = false;

            dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvBooks.ColumnHeadersDefaultCellStyle.Font =
                new Font("Times New Roman", 11, FontStyle.Bold);

            dgvBooks.ColumnHeadersHeight = 30;

            dgvBooks.RowTemplate.Height = 35;
            dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

    }
}