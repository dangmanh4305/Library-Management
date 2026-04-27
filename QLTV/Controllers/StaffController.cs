using MySql.Data.MySqlClient;
using QLTV.Models;
using System;
using System.Data;
using System.Windows.Forms; // Thêm thư viện này để dùng MessageBox

namespace QLTV.Controllers
{
    public class StaffController
    {
        // ⚠️ QUAN TRỌNG: Sửa 'your_password' thành mật khẩu MySQL của máy bạn!
        private string connectionString = "Server=localhost;Database=LibraryManagement;Uid=root;Pwd=manh12345;";

        // 1. Lấy danh sách nhân viên để hiển thị lên DataGridView
        public DataTable GetAllStaffs()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    // JOIN với bảng Roles để lấy tên quyền hiển thị
                    string query = @"SELECT u.UserID, u.Username, u.FullName, u.Phone, u.Email, u.Status, r.RoleName
                                     FROM Users u
                                     INNER JOIN Roles r ON u.RoleID = r.RoleID";

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
            catch (MySql.Data.MySqlClient.MySqlException mex)
            {
                // If the database schema does not have Phone/Email columns, try a fallback query that provides NULL columns
                if (mex.Message != null && mex.Message.Contains("Unknown column"))
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            string fallback = @"SELECT u.UserID, u.Username, u.FullName, NULL AS Phone, NULL AS Email, u.Status, r.RoleName
                                               FROM Users u
                                               INNER JOIN Roles r ON u.RoleID = r.RoleID";
                            using (MySqlCommand cmd = new MySqlCommand(fallback, conn))
                            {
                                conn.Open();
                                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                                {
                                    da.Fill(dt);
                                }
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Lỗi kết nối hoặc truy vấn Database (fallback):\n" + ex2.Message, "Lỗi Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi kết nối hoặc truy vấn Database:\n" + mex.Message, "Lỗi Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối hoặc truy vấn Database:\n" + ex.Message, "Lỗi Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // 2. Thêm nhân viên mới
        public bool AddStaff(User staff)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Users (Username, PasswordHash, FullName, Phone, Email, Status, RoleID) 
                                     VALUES (@Username, @PasswordHash, @FullName, @Phone, @Email, @Status, @RoleID)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", staff.Username);
                        // Cần băm mật khẩu trước khi truyền vào đây (tạm thời lưu text thường để test)
                        cmd.Parameters.AddWithValue("@PasswordHash", staff.PasswordHash);
                        cmd.Parameters.AddWithValue("@FullName", staff.FullName);
                        cmd.Parameters.AddWithValue("@Phone", staff.Phone);
                        cmd.Parameters.AddWithValue("@Email", staff.Email);
                        cmd.Parameters.AddWithValue("@Status", staff.Status);
                        cmd.Parameters.AddWithValue("@RoleID", staff.RoleID);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên:\n" + ex.Message, "Lỗi Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool UpdateStaff(User staff)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    // Lưu ý: Thường thì không cho phép sửa Username sau khi đã tạo
                    string query = @"UPDATE Users 
                                     SET FullName = @FullName, Phone = @Phone, Email = @Email, Status = @Status, RoleID = @RoleID 
                                     WHERE UserID = @UserID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", staff.FullName);
                        cmd.Parameters.AddWithValue("@Phone", staff.Phone);
                        cmd.Parameters.AddWithValue("@Email", staff.Email);
                        cmd.Parameters.AddWithValue("@Status", staff.Status);
                        cmd.Parameters.AddWithValue("@RoleID", staff.RoleID);
                        cmd.Parameters.AddWithValue("@UserID", staff.UserID); // Dựa vào ID để biết đang sửa ai

                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên:\n" + ex.Message, "Lỗi Controller", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // 4. Xóa nhân viên
        public bool DeleteStaff(int userId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE UserID = @UserID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi khóa ngoại (VD: Xóa nhân viên đã từng lập phiếu mượn thì MySQL sẽ chặn lại)
                MessageBox.Show("Không thể xóa nhân viên này vì dữ liệu đang ràng buộc với Phiếu mượn!\nChi tiết: " + ex.Message, "Lỗi Ràng Buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public DataTable GetRoles()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT RoleID, RoleName FROM Roles";
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
                MessageBox.Show("Lỗi load chức vụ: " + ex.Message);
            }
            return dt;
        }
    }
}