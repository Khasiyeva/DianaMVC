using DianaMVC.DAL;
using Microsoft.AspNetCore.Mvc;

namespace DianaMVC.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
