using LMS.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
        public ActionResult Book()
        {
            return View();
        }
        /*public ActionResult Book(int id)
        {
            var user = _context.User.SingleOrDefault(c => c.Email == User.Identity.Name);
            ViewBag.booksissue = user.booksissued;
            if (user.booksissued>=2)
            {
                return Content("You already have rented 2 books. You need to return them to rent more.");
            }
            Reports report = new Reports();
            ViewBag.bookName = _context.Books.SingleOrDefault(x => x.Id == id).Name;
            ViewBag.bookId = _context.Books.SingleOrDefault(x => x.Id == id).Id;

            return View(report);
        }*/
        [HttpPost]
        public ActionResult Book(Reports report)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == report.BookId);
            if (book == null)
            {
                return Content("No Such Book Found");
            }
            var user = _context.User.SingleOrDefault(c => c.Email == report.user_mail);
            if (user == null)
            {
                return Content("No Such User");

            }
            ViewBag.booksissue = user.booksissued;
            if (user.booksissued >= 2)
            {
                return Content("You already have rented 2 books. You need to return them to rent more.");
            }




            _context.Reports.Add(report);

            
            book.Quantity = book.Quantity - 1;

            
            user.booksissued += 1;
            _context.SaveChanges();
            return Redirect("/Search/Book");
        }
        public ActionResult Return()
        {
            var reports = _context.Reports.Include(r => r.Book).ToList();
            return View(reports);
        }

        public ActionResult Returned(int id)
        {
            var report = _context.Reports.SingleOrDefault(x => x.Id == id);
            var book = _context.Books.SingleOrDefault(x => x.Id == report.BookId);
            var user = _context.User.SingleOrDefault(c => c.Email == report.user_mail);
            _context.Reports.Remove(report);
            user.booksissued -= 1;
            book.Quantity += 1;
            _context.Books.AddOrUpdate(book);
            _context.User.AddOrUpdate(user);
            _context.SaveChanges();
            return RedirectToAction("Return");
        }

        

    }
}