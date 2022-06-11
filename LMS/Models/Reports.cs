using System;

namespace LMS.Models
{
    public class Reports
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Staff Staff { get; set; }
        public int StaffId { get; set; }

    }
}