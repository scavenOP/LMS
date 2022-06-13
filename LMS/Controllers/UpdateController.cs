using LMS.Models;
using System.Linq;
using System.Web.Mvc;

namespace LMS.Controllers
{
    [Authorize(Roles = "Staff")]
    public class UpdateController : Controller
    {
        protected ApplicationDbContext _context;

        public UpdateController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Update
        public ActionResult Author(int id)
        {
            var author = _context.Authors.SingleOrDefault(a => a.Id == id);
            return View(author);
        }
        [HttpPost]
        public ActionResult Author(Author author)
        {
            var AuthorinDb = _context.Authors.SingleOrDefault(a => a.Id == author.Id);
            AuthorinDb.Name = author.Name;
            AuthorinDb.About = author.About;
            AuthorinDb.DOB = author.DOB;
            _context.SaveChanges();
            return Redirect("/Dashboard/Staff");
        }
    }
}