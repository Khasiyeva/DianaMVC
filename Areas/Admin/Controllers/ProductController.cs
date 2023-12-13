using DianaMVC.Areas.Admin.ViewModels;
using DianaMVC.DAL;
using DianaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DianaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            List<Product> product = _context.Products.ToList();

            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }


            Product product = new Product()
            {
                Name = createProductVM.Name,
                Price = createProductVM.Price,
                Description = createProductVM.Description,
                ImgUrl = createProductVM.ImgUrl

            };

            
            return View();
        }
    }
}
