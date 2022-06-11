using LMS.Models;
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
    }
}