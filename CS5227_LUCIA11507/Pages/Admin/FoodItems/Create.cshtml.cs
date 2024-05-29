using CS5227_LUCIA11507.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages.Admin.FoodItems
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public FoodItemDto FoodItemDto { get; set; } = new FoodItemDto();
        public void OnGet()
        {
        }
    }
}
