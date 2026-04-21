namespace QLTV.Models
{
    public static class UserSession
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }

        public static void Clear()
        {
            UserId = 0; Username = null; FullName = null; Role = null;
        }

        public static bool IsAdmin() => Role == "Admin";
        public static bool IsLibrarian() => Role == "Librarian";
        public static bool IsWarehouse() => Role == "WarehouseManager";
    }
}