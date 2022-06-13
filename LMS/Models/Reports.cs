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

        public string user_mail { get; set; }

    }
}