using QLTV.Controllers; 
using System;
using System.Data;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace LibraryManagement.UI.Views.Librarian
{
    public partial class frmLoan : Form
    {
        // Khởi tạo Controller
        private LoanController loanCtrl = new LoanController();

        public frmLoan()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form vừa mở lên
        private void frmQuanLyMuonTra_Load(object sender, EventArgs e)
        {
            LoadDataQuaHan();
        }

        // Hàm xử lý đổ dữ liệu
        private void LoadDataQuaHan()
        {
            try
            {
                // Gọi hàm lấy dữ liệu
                var dtQuaHan = loanCtrl.LấyDanhSachQuaHan();

                // KHÚC NÀY RẤT QUAN TRỌNG: Nối tên cột trong SQL với tên cột bạn vừa tạo trên giao diện
                dgvDanhSachQuaHan.AutoGenerateColumns = false; // Tắt tự động tạo cột mới

                // Map DataPropertyName (Sử dụng đúng Name cột bạn đã đặt)
                colTenDocGia.DataPropertyName = "TenDocGia";
                colLienHe.DataPropertyName = "LienHe";
                colTenSach.DataPropertyName = "TenSachMuon";
                colMaSachMuon.DataPropertyName = "MaSachMuon"; 
                colNgayTre.DataPropertyName = "SoNgayTre";
                colTienPhat.DataPropertyName = "TongTienPhat";

                // Đổ data vào bảng
                dgvDanhSachQuaHan.DataSource = dtQuaHan;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách quá hạn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ giao diện
            string maDocGia = txtMaDocGiaMuon.Text.Trim();
            string maSach = txtMaSachMuon.Text.Trim();
            int soNgay = int.Parse(cboSoNgayMuon.Text); // Lấy số ngày mượn

            // Giả sử Thủ thư đang đăng nhập có ID là 2 (Trong hệ thống thật sẽ lấy từ form Đăng nhập truyền sang)
            int thuthuID = 2;

            if (string.IsNullOrEmpty(maDocGia) || string.IsNullOrEmpty(maSach))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã độc giả và Mã sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi Controller thực thi
            bool thanhCong = loanCtrl.LapPhieuMuon(maDocGia, maSach, soNgay, thuthuID);

            if (thanhCong)
            {
                MessageBox.Show("Lập phiếu mượn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Xóa trắng ô nhập để chuẩn bị quét sách tiếp theo
                txtMaDocGiaMuon.Clear();
                txtMaSachMuon.Clear();
            }
            else
            {
                MessageBox.Show("Lỗi! Vui lòng kiểm tra lại Mã sách hoặc Mã độc giả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimSachTra_Click(object sender, EventArgs e)
        {
            string maDocGia = txtMaDocGiaTra.Text.Trim(); // Ô nhập mã độc giả ở tab 2
            if (string.IsNullOrEmpty(maDocGia))
            {
                MessageBox.Show("Vui lòng nhập Mã Độc Giả cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dt = loanCtrl.LaySachDangMuon(maDocGia);
            dgvSachDangMuon.AutoGenerateColumns = false;

            // BẠN LƯU Ý: Đổi tên các col bên dưới (colMaSach, colTenSach...) cho KHỚP với Name các cột bạn tạo ở bảng dgvSachDangMuon nhé
            colMaSach.DataPropertyName = "MaSach";
            colTenSach.DataPropertyName = "TenSach";
            colNgayMuon.DataPropertyName = "NgayMuon";
            colHanTra.DataPropertyName = "HanTra";

            dgvSachDangMuon.DataSource = dt;
        }

        private void dgvSachDangMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            // Kiểm tra xem người dùng có click trúng vào cột Nút bấm (colThaoTac) không
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Lấy toàn bộ dữ liệu của cái dòng vừa bị click
                DataTable dt = (DataTable)dgvSachDangMuon.DataSource;
                DataRow row = dt.Rows[e.RowIndex];

                int loanDetailId = Convert.ToInt32(row["LoanDetailID"]);
                int copyId = Convert.ToInt32(row["CopyID"]);
                DateTime hanTra = Convert.ToDateTime(row["HanTra"]);

                // Logic tính toán: Nếu quá hạn thì phạt 5.000 VNĐ / ngày
                int soNgayTre = (DateTime.Now.Date - hanTra.Date).Days;
                int tienPhat = 0;
                string lyDo = "";

                if (soNgayTre > 0)
                {
                    tienPhat = soNgayTre * 5000;
                    lyDo = "Trả trễ hạn " + soNgayTre + " ngày";

                    DialogResult dr = MessageBox.Show($"⚠️ CẢNH BÁO QUÁ HẠN!\nSách này đã trễ {soNgayTre} ngày.\nPhí phạt cần thu: {tienPhat:N0} VNĐ.\n\nXác nhận Độc giả đã nộp phạt và nhận lại sách?", "Thu tiền phạt", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No) return; // Nếu chưa nộp tiền thì hủy thao tác trả sách
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Xác nhận nhận lại sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;
                }

                // Gọi Controller gọi lệnh cất sách vào kho
                if (loanCtrl.ThucHienTraSach(loanDetailId, copyId, tienPhat, lyDo))
                {
                    MessageBox.Show("Đã hoàn tất trả sách!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Tự động load lại bảng để dòng vừa trả biến mất
                    btnTimSachTra.PerformClick();
                }
            }
        }

        private void dgvDanhSachQuaHan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaDocGiaMuon_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem bảng có dữ liệu không (Tên bảng dgvDanhSachQuaHan nhớ sửa lại cho đúng với Name bạn đặt nhé)
            if (dgvDanhSachQuaHan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Mở hộp thoại cho phép người dùng chọn nơi lưu file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx"; // Chỉ lưu đuôi .xlsx
            sfd.Title = "Lưu danh sách quá hạn";
            sfd.FileName = "DanhSachQuaHan_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx"; // Gợi ý tên file có ngày tháng

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Dùng ClosedXML để tạo file Excel mới
                    using (XLWorkbook workbook = new XLWorkbook())
                    {
                        // Tạo một Sheet tên là "Quá Hạn"
                        var worksheet = workbook.Worksheets.Add("Quá Hạn");

                        // 3.1. In dòng Tiêu đề cột (Lấy từ Header của DataGridView)
                        for (int i = 0; i < dgvDanhSachQuaHan.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvDanhSachQuaHan.Columns[i].HeaderText;
                            // Tô đậm chữ tiêu đề cho đẹp
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                            worksheet.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                        }

                        // 3.2. Đổ dữ liệu từng dòng từ DataGridView xuống Excel
                        for (int i = 0; i < dgvDanhSachQuaHan.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvDanhSachQuaHan.Columns.Count; j++)
                            {
                                // Kiểm tra dữ liệu null để tránh bị lỗi văng app
                                var cellValue = dgvDanhSachQuaHan.Rows[i].Cells[j].Value;
                                worksheet.Cell(i + 2, j + 1).Value = cellValue != null ? cellValue.ToString() : "";
                            }
                        }

                        // 3.3. Tự động giãn cột cho vừa khít với chữ (cực kỳ xịn)
                        worksheet.Columns().AdjustToContents();

                        // 4. Lưu file lại vào đường dẫn người dùng vừa chọn
                        workbook.SaveAs(sfd.FileName);

                        MessageBox.Show("Xuất file Excel thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}