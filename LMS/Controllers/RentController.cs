using LMS.Models;
using System.Linq;
using System.Web.Mvc;

namespace LMS.Controllers
{
    public class RentController : Controller
    {
        protected ApplicationDbContext _context;

        public RentController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Rent
        public ActionResult Book(int id)
        {
            Reports report = new Reports();
            ViewBag.bookName = _context.Books.SingleOrDefault(x => x.Id == id).Name;
            ViewBag.bookId = _context.Books.SingleOrDefault(x => x.Id == id).Id;

            return View(report);
        }
        [HttpPost]
        public ActionResult Book(Reports report)
        {
            _context.Reports.Add(report);

            var book = _context.Books.SingleOrDefault(x => x.Id == report.BookId);
            book.Quantity = book.Quantity - 1;
            _context.SaveChanges();
            return Redirect("/Search/Book");
        }

    }
}