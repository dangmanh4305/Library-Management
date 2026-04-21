using System;
using System.Data;
using MySqlConnector;

namespace QLTV.DBConnections
{
    public class BookDAO
    {
        // 1. Lấy danh sách sách
        public static DataTable GetAllBooks()
        {
            string query = "SELECT * FROM Books";
            return DBConnection.GetDataTable(query);
        }

        // 2. Thêm sách
        public static int InsertBook(string title, string isbn, int categoryId, bool isRare, int totalQuantity)
        {
            string query = @"INSERT INTO Books 
                            (Title, ISBN, CategoryID, IsRare, TotalQuantity, AvailableQuantity) 
                            VALUES (@title, @isbn, @categoryId, @isRare, @total, @total)";

            MySqlParameter[] parameters = {
                new MySqlParameter("@title", title),
                new MySqlParameter("@isbn", isbn),
                new MySqlParameter("@categoryId", categoryId),
                new MySqlParameter("@isRare", isRare),
                new MySqlParameter("@total", totalQuantity)
            };

            return DBConnection.ExecuteNonQuery(query, parameters);
        }

        // 3. Sửa sách
        public static int UpdateBook(int bookId, string title, string isbn, int categoryId, bool isRare)
        {
            string query = @"UPDATE Books 
                             SET Title = @title, ISBN = @isbn, CategoryID = @categoryId, IsRare = @isRare
                             WHERE BookID = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@title", title),
                new MySqlParameter("@isbn", isbn),
                new MySqlParameter("@categoryId", categoryId),
                new MySqlParameter("@isRare", isRare),
                new MySqlParameter("@id", bookId)
            };

            return DBConnection.ExecuteNonQuery(query, parameters);
        }

        // 4. Xóa sách
        public static int DeleteBook(int bookId)
        {
            string query = "DELETE FROM Books WHERE BookID = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@id", bookId)
            };

            return DBConnection.ExecuteNonQuery(query, parameters);
        }
    }
}