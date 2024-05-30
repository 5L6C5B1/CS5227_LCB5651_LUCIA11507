using CS5227_LUCIA11507.Model;
using CS5227_LUCIA11507.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages
{
    public class ShopModel : PageModel
    {
        private readonly AppDbContext _context;
        public ShopModel(AppDbContext context)
        {
            _context = context;
        }
        public List<FoodItem> FoodItems { get; set; }
        public void OnGet()
        {
            FoodItems = _context.FoodItems.ToList();
        }
    }
}
