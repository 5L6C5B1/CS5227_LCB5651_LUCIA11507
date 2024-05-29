using CS5227_LUCIA11507.Model;
using CS5227_LUCIA11507.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages.Admin.FoodItems
{
    public class ItemsModel : PageModel
    {
        private readonly AppDbContext context;

        public List<FoodItem> FoodItems { get; set; } = new List<FoodItem>();

        public ItemsModel(AppDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            FoodItems = context.FoodItems.ToList();
        }
    }
}
