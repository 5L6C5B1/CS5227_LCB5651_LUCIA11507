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
            int pageSize = 20;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodItem fooditem)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "ID", "Name", fooditem.CategoryID);
            if (ModelState.IsValid)
            {
                fooditem.Slug = fooditem.Name.ToLower().Replace(" ", "-");

                var slug = await _context.FoodItems.FirstOrDefaultAsync(p => p.Slug == fooditem.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Item already exists.");
                    return View(fooditem);
                }

                
                if(fooditem.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "/media/fooditems");
                    string imageName = Guid.NewGuid().ToString() + "_" + fooditem.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await fooditem.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    fooditem.Image = imageName;
                }
                _context.Add(fooditem);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Item successfully created.";
                return RedirectToAction("Shop");
            }
            return View(fooditem);
        }

        public async Task<IActionResult> Edit(long id)
        {
            FoodItem fooditem = await _context.FoodItems.FindAsync(id);
            ViewBag.Categories = new SelectList(_context.Categories, "ID", "Name", fooditem.CategoryID);
            return View(fooditem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FoodItem fooditem)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "ID", "Name", fooditem.CategoryID);
            if (ModelState.IsValid)
            {
                fooditem.Slug = fooditem.Name.ToLower().Replace(" ", "-");

                var slug = await _context.FoodItems.FirstOrDefaultAsync(p => p.Slug == fooditem.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Item already exists.");
                    return View(fooditem);
                }


                if (fooditem.ImageUpload != null)
                {
                    string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "/media/fooditems");
                    string imageName = Guid.NewGuid().ToString() + "_" + fooditem.ImageUpload.FileName;

                    string filePath = Path.Combine(uploadsDir, imageName);

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await fooditem.ImageUpload.CopyToAsync(fs);
                    fs.Close();

                    fooditem.Image = imageName;
                }
                _context.Update(fooditem);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Item successfully edited.";
            }
            return View(fooditem);
        }

        public async Task<IActionResult> Delete(long id)
        {
            FoodItem fooditem = await _context.FoodItems.FindAsync(id);

            if (!string.Equals(fooditem.Image, "noimage.png"))
            {
                string uploadsDir = Path.Combine(_webHostEnvironment.WebRootPath, "/media/fooditems");
                string oldImagePath = Path.Combine(uploadsDir, fooditem.Image);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _context.FoodItems.Remove(fooditem);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Item successfully deleted.";

            return RedirectToAction("Shop");
        }
    }
}
