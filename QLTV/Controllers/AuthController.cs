using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;
using QLTV.DBConnections;
using QLTV.Models;

namespace QLTV.Controllers
{
    public class AuthController
    {
        // Đăng nhập: kiểm tra username + password trong bảng Users
        // Trả về true nếu hợp lệ và lưu thông tin vào UserSession
        public bool Login(string username, string password)
        {
            try
            {
                string query = @"SELECT u.UserID, u.Username, u.FullName, r.RoleName, u.Status
                                 FROM Users u
                                 LEFT JOIN Roles r ON u.RoleID = r.RoleID
                                 WHERE u.Username = @username AND u.PasswordHash = @password LIMIT 1";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@username", username),
                    new MySqlParameter("@password", password)
                };

                DataTable dt = DBConnection.GetDataTable(query, parameters);

                if (dt != null && dt.Rows.Count == 1)
                {
                    var row = dt.Rows[0];
                    UserSession.UserId = Convert.ToInt32(row["UserID"]);
                    UserSession.Username = row["Username"]?.ToString();
                    UserSession.FullName = row["FullName"]?.ToString();
                    UserSession.Role = row["RoleName"] == DBNull.Value ? string.Empty : row["RoleName"].ToString();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xác thực tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void Logout()
        {
        }
    }
}
