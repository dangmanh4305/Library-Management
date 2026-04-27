using MySqlConnector;
using QLTV.DBConnections;
using System;
using System.Data;

namespace QLTV.Controllers
{
    public class BookController
    {
        // ================= GET ALL =================
        public DataTable GetAllBooks()
        {
            string query = @"
                SELECT 
                    b.BookID,
                    b.Title,
                    b.ISBN,
                    b.CategoryID,
                    c.CategoryName,
                    b.TotalQuantity,
                    b.AvailableQuantity,
                    b.IsRare
                FROM Books b
                LEFT JOIN Categories c ON b.CategoryID = c.CategoryID
            ";

            return DBConnection.GetDataTable(query);
        }

        // ================= ADD BOOK =================
        public bool AddBook(string title, string isbn, int categoryId, bool isRare, int totalQuantity)
        {
            string query = @"
                INSERT INTO Books 
                (Title, ISBN, CategoryID, IsRare, TotalQuantity, AvailableQuantity) 
                VALUES (@title, @isbn, @categoryId, @isRare, @total, @total)
            ";

            MySqlParameter[] parameters = {
                new MySqlParameter("@title", title),
                new MySqlParameter("@isbn", isbn),
                new MySqlParameter("@categoryId", categoryId),
                new MySqlParameter("@isRare", isRare),
                new MySqlParameter("@total", totalQuantity)
            };

            int result = DBConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // ================= UPDATE =================
        public bool UpdateBook(int bookId, string title, string isbn, int categoryId, bool isRare)
        {
            string query = @"
                UPDATE Books 
                SET Title = @title, ISBN = @isbn, CategoryID = @categoryId, IsRare = @isRare
                WHERE BookID = @id
            ";

            MySqlParameter[] parameters = {
                new MySqlParameter("@title", title),
                new MySqlParameter("@isbn", isbn),
                new MySqlParameter("@categoryId", categoryId),
                new MySqlParameter("@isRare", isRare),
                new MySqlParameter("@id", bookId)
            };

            int result = DBConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // ================= DELETE =================
        public bool DeleteBook(int bookId)
        {
            string query = "DELETE FROM Books WHERE BookID = @id";

            MySqlParameter[] parameters = {
                new MySqlParameter("@id", bookId)
            };

            int result = DBConnection.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        // ================= SEARCH =================
        public DataTable SearchBooks(string keyword)
        {
            string query = @"
                SELECT 
                    b.BookID,
                    b.Title,
                    b.ISBN,
                    b.CategoryID,
                    c.CategoryName,
                    b.TotalQuantity,
                    b.AvailableQuantity,
                    b.IsRare
                FROM Books b
                LEFT JOIN Categories c ON b.CategoryID = c.CategoryID
                WHERE b.Title LIKE @kw OR b.ISBN LIKE @kw
            ";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@kw", "%" + keyword + "%")
            };

            return DBConnection.GetDataTable(query, parameters);
        }

        // ================= CATEGORY =================
        public DataTable GetCategories()
        {
            string query = "SELECT CategoryID, CategoryName FROM Categories";
            return DBConnection.GetDataTable(query);
        }

        public int AddCategory(string name)
        {
            string query = @"
                INSERT INTO Categories(CategoryName) 
                VALUES(@name);
                SELECT LAST_INSERT_ID();
            ";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@name", name)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        // ================= VALIDATE =================
        public bool IsISBNExists(string isbn)
        {
            string query = "SELECT COUNT(*) FROM Books WHERE ISBN = @isbn";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@isbn", isbn)
            };

            object result = DBConnection.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }
}