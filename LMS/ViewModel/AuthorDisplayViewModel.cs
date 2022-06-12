using LMS.Models;
using System.Collections.Generic;

namespace LMS.ViewModel
{
    public class AuthorDisplayViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public Author Author { get; set; }
    }
}