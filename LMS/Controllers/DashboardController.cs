using LMS.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace LMS.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        private ApplicationDbContext _context;
        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Dashboard
        [Authorize(Roles = "Staff")]
        public ActionResult Staff()
        {
            ViewBag.Count = _context.Authors.Where(a => a.About == null).ToList().Count;
            return View();
        }
        public ActionResult AuthorsToBeUpdated()
        {
            var authors = _context.Authors.Where(a => a.About == null).ToList();
            return View(authors);
        }
        public ActionResult user()
        {
            var Email = User.Identity.Name;
            ViewBag.Name = User.Identity.Name;
            var reports = _context.Reports.Include(c => c.Book).Where(b => b.user_mail == Email).ToList();
            return View("User", reports);
        }
    }
}