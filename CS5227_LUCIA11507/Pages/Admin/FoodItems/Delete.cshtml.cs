using CS5227_LUCIA11507.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages.Admin.FoodItems
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment e;
        private readonly AppDbContext context;

        public DeleteModel(IWebHostEnvironment e, AppDbContext context)
        {
            this.e = e;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if(id == null)
            {
                Response.Redirect("/Admin/FoodItems/Items");
                return;
            }

            var foodItem = context.FoodItems.Find(id);
            if (foodItem == null)
            {
                Response.Redirect("/Admin/FoodItems/Items");
                return;
            }

            string imagePath = e.WebRootPath + "/fooditems/" + foodItem.ImageFileName;
            System.IO.File.Delete(imagePath);

            context.FoodItems.Remove(foodItem);
            context.SaveChanges();

            Response.Redirect("/Admin/FoodItems/Items");
        }
    }
}
