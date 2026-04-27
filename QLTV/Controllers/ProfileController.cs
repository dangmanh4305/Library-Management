using System.Data;
using MySqlConnector;
using QLTV.DBConnections;

namespace QLTV.Controllers
{
    public class ProfileController
    {
        // Lấy thông tin user
        public DataTable GetProfile(int userId)
        {
            string query = @"
        SELECT 
            u.Username,
            u.FullName,
            u.Status,
            r.RoleName
        FROM users u
        LEFT JOIN roles r ON u.RoleID = r.RoleID
        WHERE u.UserID = @id
    ";

            MySqlParameter[] parameters =
            {
        new MySqlParameter("@id", userId)
    };

            return DBConnection.GetDataTable(query, parameters);
        }

        // Cập nhật profile
        public bool UpdateProfile(int userId, string name)
        {
            string query = @"UPDATE Users 
                     SET FullName=@name
                     WHERE UserID=@id";

            MySqlParameter[] parameters =
            {
        new MySqlParameter("@name", name),
        new MySqlParameter("@id", userId)
    };

            return DBConnection.ExecuteNonQuery(query, parameters) > 0;
        }

        // Đổi mật khẩu
        public bool ChangePassword(int userId, string oldPass, string newPass)
        {
            string checkQuery = @"SELECT COUNT(*) FROM Users 
                          WHERE UserID=@id AND PasswordHash=@old";

            MySqlParameter[] checkParams =
            {
        new MySqlParameter("@id", userId),
        new MySqlParameter("@old", oldPass)
    };

            int count = System.Convert.ToInt32(
                DBConnection.ExecuteScalar(checkQuery, checkParams)
            );

            if (count == 0) return false;

            string updateQuery = @"UPDATE Users 
                           SET PasswordHash=@new 
                           WHERE UserID=@id";

            MySqlParameter[] updateParams =
            {
        new MySqlParameter("@new", newPass),
        new MySqlParameter("@id", userId)
    };

            return DBConnection.ExecuteNonQuery(updateQuery, updateParams) > 0;
        }
    }
}