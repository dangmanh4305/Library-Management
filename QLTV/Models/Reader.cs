using System;

namespace QLTV.Models
{
    public class Reader
    {
        public int ReaderID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CardExpiryDate { get; set; }
        public string Status { get; set; } // 'Active','Expired','Suspended'
        public DateTime CreatedAt { get; set; }
    }
}
