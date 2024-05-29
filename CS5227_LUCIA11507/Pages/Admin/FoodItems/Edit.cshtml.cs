using CS5227_LUCIA11507.Model;
using CS5227_LUCIA11507.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages.Admin.FoodItems
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment e;
        private readonly AppDbContext context;

        [BindProperty]
        public FoodItemDto FoodItemDto { get; set; } = new FoodItemDto();
        public FoodItem FoodItem { get; set; } = new FoodItem();

        public string errorMessage = "";
        public string successMessage = "";

        public EditModel(IWebHostEnvironment e, AppDbContext context)
        {
            this.e = e;
            this.context = context;
        }

        public void OnGet(int? id)
        {
            if (id == null)
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

            FoodItemDto.Name = foodItem.Name;
            FoodItemDto.Category = foodItem.Category;
            FoodItemDto.Price = foodItem.Price;
            FoodItemDto.Description = foodItem.Description;

            FoodItem = foodItem;
        }

        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin/FoodItems/Items");
                return;
            }

            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields.";
                return;
            }

            var foodItem = context.FoodItems.Find(id);
            if (foodItem == null)
            {
                Response.Redirect("/Admin/FoodItems/Items");
                return;
            }

            string newFileName = foodItem.ImageFileName;
            if(FoodItemDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(FoodItemDto.ImageFile.FileName);
                string imagePath = e.WebRootPath + "/fooditems/" + newFileName;
                using (var stream = System.IO.File.Create(imagePath))
                {
                    FoodItemDto.ImageFile.CopyTo(stream);
                }

                string oldImagePath = e.WebRootPath + "/fooditems/" + foodItem.ImageFileName;
                System.IO.File.Delete(oldImagePath);
            }

            foodItem.Name = FoodItemDto.Name;
            foodItem.Category = FoodItemDto.Category;
            foodItem.Price = FoodItemDto.Price;
            foodItem.Description = FoodItemDto.Description ?? "";
            foodItem.ImageFileName = newFileName;

            context.SaveChanges();

            FoodItem = foodItem;
            successMessage = "Item successfully updated.";

            Response.Redirect("/Admin/FoodItems/Items");
        }
    }
}
