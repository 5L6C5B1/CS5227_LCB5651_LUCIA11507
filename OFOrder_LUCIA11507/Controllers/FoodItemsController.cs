using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OFOrder_LUCIA11507.Infrastructure;
using OFOrder_LUCIA11507.Models;

namespace OFOrder_LUCIA11507.Controllers
{
    public class FoodItemsController : Controller
    {
        private readonly AppDbContext _context;

        public FoodItemsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Shop(string categorySlug = "", int p = 1)
        {
            int pageSize = 6;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = categorySlug;

            if (categorySlug == "")
            {
                ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.FoodItems.Count() / pageSize);

                return View(await _context.FoodItems.OrderByDescending(p => p.ID).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
            }

            Category category = await _context.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Shop");

            var fooditemsByCategory = _context.FoodItems.Where(p => p.CategoryID == category.ID);
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)fooditemsByCategory.Count() / pageSize);

            return View(await fooditemsByCategory.OrderByDescending(p => p.ID).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
        }
    }
}
