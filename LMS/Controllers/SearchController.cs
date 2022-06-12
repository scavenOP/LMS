using LMS.Models;
using LMS.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext _context;

        public SearchController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Book()
        {
            var Books = _context.Books.ToList();
            return View(Books);
        }
        public ActionResult DisplayBook(int id)
        {
            BookDisplayViewModel viewModel = new BookDisplayViewModel();
            var Book = _context.Books.Include(c => c.Author).Include(c => c.Publisher).SingleOrDefault(b => b.Id == id);
            var related_books = _context.Books.Where(c => c.Catagory == Book.Catagory).ToList();
            viewModel.Book = Book;
            viewModel.RelatedBooks = related_books;
            return View(viewModel);
        }

        public ActionResult Author()
        {
            var Authors = _context.Authors.ToList();
            return View(Authors);

        }
        public ActionResult DisplayAuthor(int id)
        {
            AuthorDisplayViewModel model = new AuthorDisplayViewModel();
            model.Author = _context.Authors.SingleOrDefault(b => b.Id == id);
            model.Books = _context.Books.Where(b => b.AuthorId == id).ToList();
            return View(model);
        }
    }
}