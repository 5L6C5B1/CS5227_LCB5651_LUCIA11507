using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OFOrder_LUCIA11507.Infrastructure;
using OFOrder_LUCIA11507.Models;

namespace OFOrder_LUCIA11507.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodItemsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FoodItemsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Shop(int p = 1)
        {
            int pageSize = 6;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.FoodItems.Count() / pageSize);

            return View(await _context.FoodItems.OrderByDescending(p => p.ID).Include(p => p.Category).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "ID", "Name");
            return View();
        }
    }
}
