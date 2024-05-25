using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OFOrder_LUCIA11507.Infrastructure;
using OFOrder_LUCIA11507.Models;

namespace OFOrder_LUCIA11507.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodItemsController : Controller
    {
        private readonly AppDbContext _context;
        public FoodItemsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Shop(int p = 1)
        {
            int pageSize = 20;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)_context.FoodItems.Count() / pageSize);

            return View(await _context.FoodItems.OrderByDescending(p => p.ID).Include(p => p.Category).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
        }
    }
}
