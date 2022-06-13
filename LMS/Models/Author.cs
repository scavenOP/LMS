using System;

namespace LMS.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string About { get; set; }
    }
}