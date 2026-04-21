using System;
using System.Data;
using QLTV.DBConnections;
using MySqlConnector;
namespace QLTV.Controllers
{
    public class BookController
    {
        // 1. Lấy danh sách sách
        public DataTable GetAllBooks()
        {
            return BookDAO.GetAllBooks();
        }

        // 2. Thêm sách
        public bool AddBook(string title, string isbn, int categoryId, bool isRare, int totalQuantity)
        {
            int result = BookDAO.InsertBook(title, isbn, categoryId, isRare, totalQuantity);
            return result > 0;
        }

        // 3. Sửa sách
        public bool UpdateBook(int bookId, string title, string isbn, int categoryId, bool isRare)
        {
            int result = BookDAO.UpdateBook(bookId, title, isbn, categoryId, isRare);
            return result > 0;
        }

        // 4. Xóa sách
        public bool DeleteBook(int bookId)
        {
            int result = BookDAO.DeleteBook(bookId);
            return result > 0;
        }
        public DataTable SearchBooks(string keyword)
        {
            string query = @"SELECT * FROM Books 
                     WHERE Title LIKE @kw OR ISBN LIKE @kw";

            MySqlParameter[] parameters =
            {
        new MySqlParameter("@kw", "%" + keyword + "%")
    };

            return DBConnection.GetDataTable(query, parameters);
        }
    }
}