using QLTV.DBConnections;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLTV.Controllers
{
    public class LoanController
    {
        // =========================================================
        // 1. HÀM LẤY DANH SÁCH ĐỘC GIẢ QUÁ HẠN CHƯA TRẢ SÁCH
        // =========================================================
        public DataTable LấyDanhSachQuaHan()
        {
            string query = @"
                SELECT 
                    r.FullName AS TenDocGia, 
                    CONCAT(IFNULL(r.Email, 'Không có'), ' - ', r.Phone) AS LienHe, 
                    b.Title AS TenSachMuon, 
                    bc.Barcode AS MaSachMuon, 
                    DATEDIFF(CURDATE(), l.DueDate) AS SoNgayTre, 
                    (DATEDIFF(CURDATE(), l.DueDate) * 5000) AS TongTienPhat
                FROM Loans l
                JOIN LoanDetails ld ON l.LoanID = ld.LoanID
                JOIN Readers r ON l.ReaderID = r.ReaderID
                JOIN BookCopies bc ON ld.CopyID = bc.CopyID
                JOIN Books b ON bc.BookID = b.BookID
                WHERE ld.ReturnDate IS NULL 
                  AND l.DueDate < CURDATE();";

            return DBConnection.GetDataTable(query);
        }

        // =========================================================
        // 2. HÀM LẬP PHIẾU MƯỢN SÁCH MỚI
        // =========================================================
        public bool LapPhieuMuon(string maDocGia, string barcodeSach, int soNgayMuon, int userIdLapPhieu)
        {
            try
            {
                string query = @"
                    -- 1. Tạo phiếu mượn mới vào bảng Loans
                    INSERT INTO Loans (ReaderID, UserID, BorrowDate, DueDate, Status) 
                    VALUES (@maDocGia, @UserID, NOW(), DATE_ADD(NOW(), INTERVAL @soNgay DAY), 'Borrowing');
                    
                    -- 2. Thêm chi tiết phiếu mượn 
                    INSERT INTO LoanDetails (LoanID, CopyID, Status) 
                    SELECT LAST_INSERT_ID(), CopyID, 'Borrowing' 
                    FROM BookCopies WHERE Barcode = @barcode LIMIT 1;
                    
                    -- 3. Cập nhật trạng thái sách thành 'Borrowed'
                    UPDATE BookCopies SET Status = 'Borrowed' WHERE Barcode = @barcode;";

                MySqlConnector.MySqlParameter[] kieuDuLieu = new MySqlConnector.MySqlParameter[]
                {
                    new MySqlConnector.MySqlParameter("@maDocGia", maDocGia),
                    new MySqlConnector.MySqlParameter("@barcode", barcodeSach),
                    new MySqlConnector.MySqlParameter("@soNgay", soNgayMuon),
                    new MySqlConnector.MySqlParameter("@UserID", userIdLapPhieu)
                };

                int result = DBConnection.ExecuteNonQuery(query, kieuDuLieu);
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết từ MySQL (Lập phiếu mượn): " + ex.Message, "Phát hiện lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // =========================================================
        // 3. HÀM LẤY DANH SÁCH SÁCH ĐANG MƯỢN CỦA 1 ĐỘC GIẢ
        // =========================================================
        public DataTable LaySachDangMuon(string maDocGia)
        {
            string query = @"
                SELECT 
                    ld.LoanDetailID,
                    bc.CopyID,
                    bc.Barcode AS MaSach, 
                    b.Title AS TenSach, 
                    l.BorrowDate AS NgayMuon, 
                    l.DueDate AS HanTra
                FROM Loans l
                JOIN LoanDetails ld ON l.LoanID = ld.LoanID
                JOIN BookCopies bc ON ld.CopyID = bc.CopyID
                JOIN Books b ON bc.BookID = b.BookID
                WHERE l.ReaderID = @maDocGia AND ld.ReturnDate IS NULL;";

            MySqlConnector.MySqlParameter[] kieuDuLieu = new MySqlConnector.MySqlParameter[]
            {
                new MySqlConnector.MySqlParameter("@maDocGia", maDocGia)
            };

            return DBConnection.GetDataTable(query, kieuDuLieu);
        }

        // =========================================================
        // 4. HÀM THỰC HIỆN TRẢ SÁCH VÀ GHI NHẬN PHẠT
        // =========================================================
        public bool ThucHienTraSach(int loanDetailId, int copyId, int tienPhat, string lyDoPhat)
        {
            try
            {
                string query = @"
                    -- 1. Cập nhật ngày trả vào phiếu mượn
                    UPDATE LoanDetails SET ReturnDate = NOW() WHERE LoanDetailID = @loanDetailId;
                    
                    -- 2. Đổi trạng thái sách trên kệ thành 'Available'
                    UPDATE BookCopies SET Status = 'Available' WHERE CopyID = @copyId;
                ";

                // Nếu có tiền phạt thì chạy thêm lệnh nhét vào bảng Fines
                if (tienPhat > 0)
                {
                    query += @"
                    INSERT INTO Fines (LoanDetailID, Amount, Reason, Status) 
                    VALUES (@loanDetailId, @tienPhat, @lyDo, 'Paid');";
                }

                MySqlConnector.MySqlParameter[] kieuDuLieu = new MySqlConnector.MySqlParameter[]
                {
                    new MySqlConnector.MySqlParameter("@loanDetailId", loanDetailId),
                    new MySqlConnector.MySqlParameter("@copyId", copyId),
                    new MySqlConnector.MySqlParameter("@tienPhat", tienPhat),
                    new MySqlConnector.MySqlParameter("@lyDo", lyDoPhat)
                };

                return DBConnection.ExecuteNonQuery(query, kieuDuLieu) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi CSDL khi trả sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}