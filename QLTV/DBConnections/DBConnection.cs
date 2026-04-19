using System;
using System.Data;
using System.Configuration;
using MySqlConnector;

namespace QLTV.DBConnections
{
    public class DBConnection
    {
        // Tự động đọc chuỗi kết nối từ file App.config lúc nãy
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString;

        // Hàm tạo kết nối
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // Hàm dùng cho các lệnh: Thêm (INSERT), Sửa (UPDATE), Xóa (DELETE)
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Hàm dùng cho lệnh: Lấy dữ liệu (SELECT) đổ ra bảng (DataGridView)
        public static DataTable GetDataTable(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection conn = GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}