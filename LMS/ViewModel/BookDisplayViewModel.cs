using LMS.Models;
using System.Collections.Generic;

namespace LMS.ViewModel
{
    public class BookDisplayViewModel
    {
        public IEnumerable<Book> RelatedBooks { get; set; }
        public Book Book { get; set; }
    }
}