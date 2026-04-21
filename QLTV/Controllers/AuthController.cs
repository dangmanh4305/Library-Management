using MySql.Data.MySqlClient;
using QLTV.Models;
using System.Data.SqlClient;

namespace QLTV.Controllers
{
    public class AuthController
    {
        public bool Login(string username, string password)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT u.UserID, u.FullName, r.RoleName
                                   FROM Users u
                                   JOIN Roles r ON u.RoleID = r.RoleID
                                   WHERE u.Username = @u 
                                     AND u.PasswordHash = @p 
                                     AND u.Status = 'Active'";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserSession.UserId = reader.GetInt32("UserID");
                                UserSession.Username = username;
                                UserSession.FullName = reader.GetString("FullName");
                                UserSession.Role = reader.GetString("RoleName");
                                return true;
                            }
                        }
                    }
                }
            }
            catch { }
            return false;
        }

        public bool ChangePassword(int userId, string oldPass, string newPass)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string checkSql = "SELECT COUNT(*) FROM Users WHERE UserID=@id AND PasswordHash=@old";
                    using (var cmd = new MySqlCommand(checkSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.Parameters.AddWithValue("@old", oldPass);
                        int count = int.Parse(cmd.ExecuteScalar().ToString());
                        if (count == 0) return false;
                    }

                    string updateSql = "UPDATE Users SET PasswordHash=@new WHERE UserID=@id";
                    using (var cmd = new MySqlCommand(updateSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@new", newPass);
                        cmd.Parameters.AddWithValue("@id", userId);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
