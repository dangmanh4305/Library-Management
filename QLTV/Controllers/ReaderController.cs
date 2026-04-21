using System;
using System.Collections.Generic;
using MySqlConnector;
using QLTV.DBConnections;
using QLTV.Models;

namespace QLTV.Controllers
{
    public class ReaderController
    {
        public bool AddReader(Reader reader, out string error)
        {
            error = null;
            const string sql = @"INSERT INTO Readers (FullName, Phone, Email, CardExpiryDate, Status)
                                 VALUES (@FullName, @Phone, @Email, @CardExpiryDate, @Status);
                                 SELECT LAST_INSERT_ID();";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FullName", reader.FullName ?? string.Empty);
                cmd.Parameters.AddWithValue("@Phone", reader.Phone ?? string.Empty);
                cmd.Parameters.AddWithValue("@Email", (object)reader.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CardExpiryDate", (object)reader.CardExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", reader.Status ?? "Active");

                try
                {
                    conn.Open();
                    var idObj = cmd.ExecuteScalar();
                    if (idObj != null && int.TryParse(idObj.ToString(), out int newId))
                    {
                        reader.ReaderID = newId;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public bool UpdateReader(Reader reader, out string error)
        {
            error = null;
            const string sql = @"UPDATE Readers
                                 SET FullName = @FullName,
                                     Phone = @Phone,
                                     Email = @Email,
                                     CardExpiryDate = @CardExpiryDate,
                                     Status = @Status
                                 WHERE ReaderID = @ReaderID;";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@FullName", reader.FullName ?? string.Empty);
                cmd.Parameters.AddWithValue("@Phone", reader.Phone ?? string.Empty);
                cmd.Parameters.AddWithValue("@Email", (object)reader.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CardExpiryDate", (object)reader.CardExpiryDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", reader.Status ?? "Active");
                cmd.Parameters.AddWithValue("@ReaderID", reader.ReaderID);

                try
                {
                    conn.Open();
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public bool DeleteReader(int readerId, out string error)
        {
            error = null;
            const string sql = @"DELETE FROM Readers WHERE ReaderID = @ReaderID;";
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ReaderID", readerId);
                try
                {
                    conn.Open();
                    var rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        public Reader GetReaderById(int readerId)
        {
            const string sql = @"SELECT ReaderID, FullName, Phone, Email, CardExpiryDate, Status, CreatedAt
                                 FROM Readers
                                 WHERE ReaderID = @ReaderID;";
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@ReaderID", readerId);
                try
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            var r = new Reader
                            {
                                ReaderID = rdr.GetInt32("ReaderID"),
                                FullName = rdr["FullName"] as string,
                                Phone = rdr["Phone"] as string,
                                Email = rdr["Email"] as string,
                                Status = rdr["Status"] as string,
                                CreatedAt = rdr.GetDateTime("CreatedAt")
                            };

                            if (rdr["CardExpiryDate"] != DBNull.Value)
                                r.CardExpiryDate = rdr.GetDateTime("CardExpiryDate");
                            else
                                r.CardExpiryDate = null;

                            return r;
                        }
                        return null;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public List<Reader> GetAllReaders()
        {
            var list = new List<Reader>();
            const string sql = @"SELECT ReaderID, FullName, Phone, Email, CardExpiryDate, Status, CreatedAt
                                 FROM Readers
                                 ORDER BY ReaderID DESC;";
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                try
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var r = new Reader
                            {
                                ReaderID = rdr.GetInt32("ReaderID"),
                                FullName = rdr["FullName"] as string,
                                Phone = rdr["Phone"] as string,
                                Email = rdr["Email"] as string,
                                Status = rdr["Status"] as string,
                                CreatedAt = rdr.GetDateTime("CreatedAt")
                            };
                            if (rdr["CardExpiryDate"] != DBNull.Value)
                                r.CardExpiryDate = rdr.GetDateTime("CardExpiryDate");
                            list.Add(r);
                        }
                    }
                }
                catch
                {
                    // ignore, return empty list
                }
            }
            return list;
        }

        public List<Reader> SearchReaders(string q)
        {
            var list = new List<Reader>();
            if (string.IsNullOrWhiteSpace(q))
                return GetAllReaders();

            q = q.Trim();
            int id;
            bool isNumber = int.TryParse(q, out id);

            const string sql = @"SELECT ReaderID, FullName, Phone, Email, CardExpiryDate, Status, CreatedAt
                                 FROM Readers
                                 WHERE (@isNumber = 1 AND ReaderID = @Id)
                                    OR FullName LIKE @like
                                    OR Phone LIKE @like
                                 ORDER BY ReaderID DESC;";

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@isNumber", isNumber ? 1 : 0);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@like", "%" + q + "%");

                try
                {
                    conn.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            var r = new Reader
                            {
                                ReaderID = rdr.GetInt32("ReaderID"),
                                FullName = rdr["FullName"] as string,
                                Phone = rdr["Phone"] as string,
                                Email = rdr["Email"] as string,
                                Status = rdr["Status"] as string,
                                CreatedAt = rdr.GetDateTime("CreatedAt")
                            };
                            if (rdr["CardExpiryDate"] != DBNull.Value)
                                r.CardExpiryDate = rdr.GetDateTime("CardExpiryDate");
                            list.Add(r);
                        }
                    }
                }
                catch
                {
                    // ignore
                }
            }
            return list;
        }
    }
}
