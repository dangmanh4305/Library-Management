using QLTV.Controllers;
using QLTV.Models;
using System;
using System.Data;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;

namespace QLTV
{
    public partial class frmStaffManager : Form
    {
        // Khai báo Controller
        private StaffController staffController;

        public frmStaffManager()
        {
            InitializeComponent();
            // Khởi tạo Controller
            staffController = new StaffController();
            LoadComboBoxes();
            CustomizeUI();
        }

        private void LoadComboBoxes()
        {
            DataTable dtRoles = staffController.GetRoles();
            cbRole.DataSource = dtRoles;
            cbRole.DisplayMember = "RoleName"; // Hiển thị chữ cho người dùng xem
            cbRole.ValueMember = "RoleID";     // Giấu ID (1,2,3) ở dưới để lưu Database
        }
        private void CustomizeUI()
        {
            // 1. Đổi màu nền Form và Font chữ tổng thể
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.StartPosition = FormStartPosition.CenterScreen; // Tự động căn giữa màn hình khi mở

            // 2. Lột xác DataGridView (Bảng dữ liệu)
            dgvStaff.BackgroundColor = System.Drawing.Color.White;
            dgvStaff.BorderStyle = BorderStyle.None;
            dgvStaff.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStaff.RowHeadersVisible = false; // Ẩn cột mũi tên ngoài cùng bên trái
            dgvStaff.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Bấm 1 ô chọn cả dòng
            dgvStaff.AllowUserToAddRows = false; // Ẩn dòng trống dưới cùng
            dgvStaff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động giãn cột cho kín bảng

            // 3. Trang trí Tiêu đề cột (Header)
            dgvStaff.EnableHeadersVisualStyles = false; // BẮT BUỘC có dòng này mới đổi màu được
            dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185); // Xanh dương đậm
            dgvStaff.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvStaff.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dgvStaff.ColumnHeadersHeight = 40;

            // 4. Trang trí các dòng dữ liệu
            dgvStaff.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219); // Màu xanh nhạt khi bôi đen
            dgvStaff.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvStaff.RowTemplate.Height = 35; // Tăng chiều cao dòng nhìn cho thoáng
            dgvStaff.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240); // Hiệu ứng ngựa vằn (Trắng/Xám nhạt)
        }

        private void LoadData()
        {
            DataTable dt = staffController.GetAllStaffs();
            dgvStaff.DataSource = dt;

            if (dgvStaff.Columns.Count > 0)
            {
                dgvStaff.Columns["UserID"].HeaderText = "Mã NV";
                dgvStaff.Columns["Username"].HeaderText = "Tài Khoản";
                dgvStaff.Columns["FullName"].HeaderText = "Họ Tên";
                dgvStaff.Columns["Phone"].HeaderText = "Số điện thoại";
                dgvStaff.Columns["Email"].HeaderText = "Email";
                dgvStaff.Columns["Status"].HeaderText = "Trạng thái";
                dgvStaff.Columns["RoleName"].HeaderText = "Chức vụ";
            }
        }

        // Sự kiện khi bấm nút Tải danh sách
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập ít nhất Tài khoản và Họ tên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ĐÃ XÓA ĐOẠN BẮT LỖI ÉP KIỂU CŨ Ở ĐÂY VÌ BÂY GIỜ CHỌN COMBOBOX RẤT AN TOÀN

            User newUser = new User
            {
                Username = txtUsername.Text,
                PasswordHash = "123", // Tạm để 123 cho mọi tài khoản mới
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Status = cbStatus.Text,
                RoleID = Convert.ToInt32(cbRole.SelectedValue) // Lấy thẳng giá trị ẩn (1,2,3)
            };

            if (staffController.AddStaff(newUser))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo");
                LoadData(); // Load lại bảng ngay lập tức
                ClearForm(); // Xóa trắng các ô nhập
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ bảng để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ĐÃ XÓA ĐOẠN BẮT LỖI ÉP KIỂU CŨ Ở ĐÂY

            User editUser = new User
            {
                UserID = Convert.ToInt32(txtUserID.Text), // ID thì an toàn vì lấy từ bảng và TextBox ReadOnly
                FullName = txtFullName.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text,
                Status = cbStatus.Text,
                RoleID = Convert.ToInt32(cbRole.SelectedValue) // Lấy thẳng giá trị ẩn (1,2,3)
            };

            if (staffController.UpdateStaff(editUser))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo");
                LoadData();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên từ bảng để xóa!", "Cảnh báo");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int userId = Convert.ToInt32(txtUserID.Text);
                if (staffController.DeleteStaff(userId))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    LoadData();
                    ClearForm();
                }
            }
        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Tránh click vào tiêu đề cột bị lỗi
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];

                txtUserID.Text = row.Cells["UserID"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cbStatus.Text = row.Cells["Status"].Value.ToString();
                cbRole.Text = row.Cells["RoleName"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            txtUserID.Clear();
            txtUsername.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            if (cbRole.Items.Count > 0) cbRole.SelectedIndex = 0;
            cbStatus.SelectedIndex = -1;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvStaff.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở hộp thoại cho phép người dùng chọn nơi lưu file
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Khởi tạo file Excel
                        using (ExcelPackage excel = new ExcelPackage())
                        {
                            // Tạo 1 sheet mới tên là "DanhSachNhanVien"
                            var workSheet = excel.Workbook.Worksheets.Add("DanhSachNhanVien");

                            // 1. In dòng Tiêu đề cột (Header) từ DataGridView ra Excel
                            for (int i = 1; i <= dgvStaff.Columns.Count; i++)
                            {
                                workSheet.Cells[1, i].Value = dgvStaff.Columns[i - 1].HeaderText;
                                // Bôi đậm dòng tiêu đề cho đẹp
                                workSheet.Cells[1, i].Style.Font.Bold = true;
                            }

                            // 2. In toàn bộ Dữ liệu từ DataGridView ra Excel
                            for (int i = 0; i < dgvStaff.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvStaff.Columns.Count; j++)
                                {
                                    // Excel bắt đầu từ ô [2, 1] (hàng 2, cột 1) vì hàng 1 là tiêu đề rồi
                                    workSheet.Cells[i + 2, j + 1].Value = dgvStaff.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            // Tự động căn chỉnh độ rộng các cột cho vừa với chữ
                            workSheet.Cells[workSheet.Dimension.Address].AutoFitColumns();

                            // Lưu file
                            FileInfo excelFile = new FileInfo(sfd.FileName);
                            excel.SaveAs(excelFile);

                            MessageBox.Show("Xuất file Excel thành công rực rỡ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi xuất file (có thể do file đang được mở ở nơi khác):\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}