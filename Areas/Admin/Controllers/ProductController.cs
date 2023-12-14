using DianaMVC.Areas.Admin.ViewModels;
using DianaMVC.DAL;
using DianaMVC.Helpers;
using DianaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DianaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        AppDbContext _context;
        IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env = null )
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Product> product = _context.Products.ToList();

            return View(product);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Colors=await _context.Colors.ToListAsync();
            ViewBag.Size=await _context.Sizes.ToListAsync();
            ViewBag.Material=await _context.Materials.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM createProductVM)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Colors = await _context.Colors.ToListAsync();
            ViewBag.Size = await _context.Sizes.ToListAsync();
            ViewBag.Material = await _context.Materials.ToListAsync();

            if (!ModelState.IsValid)
            {
                return View("Error");
            }


            Product product = new Product()
            {
                Name = createProductVM.Name,
                Price = createProductVM.Price,
                Description = createProductVM.Description,
                ImgUrl = createProductVM.ImgUrl,
                CategoryId = createProductVM.CategoryId,
                ProductImages=new List<ProductImage>() 
                

            };



            if (!createProductVM.MainPhoto.CheckContent("image/"))
            {
                ModelState.AddModelError("MainPhoto", "Enter the correct format");
                return View();
            }

            if (!createProductVM.MainPhoto.CheckLength(3000))
            {
                ModelState.AddModelError("MainPhoto", "The maximum can be 3mb");
                return View();
            }

            if (!createProductVM.HoverPhoto.CheckContent("image/"))
            {
                ModelState.AddModelError("HoverPhoto", "Enter the correct format");
                return View();
            }

            if (!createProductVM.HoverPhoto.CheckLength(3000))
            {
                ModelState.AddModelError("HoverPhoto", "The maximum can be 3mb");
                return View();
            }

            ProductImage mainImage = new ProductImage()
            {
                IsPrime = true,
                ImgUrl = createProductVM.MainPhoto.Upload(_env.WebRootPath, @"\Upload\Products\"),
                Product = product
            };

            ProductImage hoverImage = new ProductImage()
            {
                IsPrime = false,
                ImgUrl = createProductVM.HoverPhoto.Upload(_env.WebRootPath, @"\Upload\Products\"),
                Product = product
            };

            TempData["Error"] = "";
            product.ProductImages.Add(mainImage);
            product.ProductImages.Add(hoverImage);
            if (createProductVM.Photos != null)
            {
                foreach (var item in createProductVM.Photos)
                {
                    if (!item.CheckContent("image/"))
                    {
                        TempData["Error"] += $"{item.FileName} the type is not correct \t";
                        continue;
                    }

                    if (!item.CheckLength(3000))
                    {
                        TempData["Error"] += $"{item.FileName} more than 3mb \t";
                        continue;
                    }

                    ProductImage photo = new ProductImage()
                    {
                        IsPrime = null,
                        ImgUrl = item.Upload(_env.WebRootPath, @"\Upload\Products\"),
                        Product = product
                    };
                    product.ProductImages.Add(photo);
                }
            }


            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Product product = await _context.Products.Include(p => p.Category)
                .Include(p => p.ProductMaterials)
                .ThenInclude(p => p.Material)
                .Include(p => p.ProductColors)
                .ThenInclude(p => p.Color)
                .Include(p=>p.ProductImages)
                .Where(p => p.Id == id).FirstOrDefaultAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM updateProductVM)
        {


            return View();
        }

    }
}
