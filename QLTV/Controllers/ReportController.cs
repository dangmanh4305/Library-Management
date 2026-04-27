using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLTV.Controllers
{
    public class ReportController
    {
        // Nhớ đổi lại thành mật khẩu của máy bạn nhé!
        private string connectionString = "Server=localhost;Database=LibraryManagement;Uid=root;Pwd=;";
        // No external logger used here to keep dependencies minimal.

        // 1. Lấy tổng số sách đang cho mượn
        public int GetTotalBorrowedBooks()
        {
            int total = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    // Đếm số cuốn sách đang có trạng thái 'Borrowed'
                    string query = "SELECT COUNT(*) FROM BookCopies WHERE Status = 'Borrowed'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        total = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tổng số sách đang cho mượn:\n" + ex.Message, "Lỗi ReportController", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return total;
        }

        // 2. Lấy tổng doanh thu tiền phạt đã thu được
        public decimal GetTotalRevenue()
        {
            decimal total = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT IFNULL(SUM(Amount), 0) FROM Fines WHERE Status = 'Paid'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        total = Convert.ToDecimal(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy tổng doanh thu:\n" + ex.Message, "Lỗi ReportController", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return total;
        }

        // 3. Lấy Top 5 sách được mượn nhiều nhất (để vẽ biểu đồ)
        public DataTable GetTopBorrowedBooks()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT b.Title, COUNT(ld.CopyID) AS SoLanMuon
                                     FROM LoanDetails ld
                                     JOIN BookCopies bc ON ld.CopyID = bc.CopyID
                                     JOIN Books b ON bc.BookID = b.BookID
                                     GROUP BY b.BookID
                                     ORDER BY SoLanMuon DESC
                                     LIMIT 5";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu Top sách mượn:\n" + ex.Message, "Lỗi ReportController", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
    }
}