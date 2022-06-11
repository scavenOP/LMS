using LMS.Models;
using System.Linq;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class AddController : Controller
    {
        private ApplicationDbContext _context;
        public AddController()
        {
            _context = new ApplicationDbContext();



        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Add
        public ActionResult Book()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Book(Book book)
        {
            var ChekAuthor = _context.Authors.SingleOrDefault(a => a.Name == book.Author.Name);
            var CheckPublishers = _context.Publishers.SingleOrDefault(a => a.Name == book.Publisher.Name);


            if (ChekAuthor == null)
            {
                Author author = new Author();
                author.Name = book.Author.Name;
                _context.Authors.Add(author);
                _context.SaveChanges();
                System.Diagnostics.Debug.WriteLine("author added");


            }

            if (CheckPublishers == null)
            {
                Publisher publisher1 = new Publisher();
                publisher1.Name = book.Publisher.Name;
                _context.Publishers.Add(publisher1);
                System.Diagnostics.Debug.WriteLine("pub added");
                _context.SaveChanges();

            }


            Author author1 = _context.Authors.SingleOrDefault(a => a.Name == book.Author.Name);
            Publisher publisher2 = _context.Publishers.SingleOrDefault(a => a.Name == book.Publisher.Name);

            book.AuthorId = author1.Id;
            book.PublisherId = publisher2.Id;




            return RedirectToAction("Created", book);

        }

        public ActionResult Created(Book book)
        {
            ApplicationDbContext _testcontext = new ApplicationDbContext();
            _testcontext.Books.Add(book);
            _testcontext.SaveChanges();

            return View("Book");
        }
    }
}