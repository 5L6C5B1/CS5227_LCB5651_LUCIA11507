using CS5227_LUCIA11507.Model;
using CS5227_LUCIA11507.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages.Admin.FoodItems
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment e;
        private readonly AppDbContext context;

        [BindProperty]
        public FoodItemDto FoodItemDto { get; set; } = new FoodItemDto();

        public CreateModel(IWebHostEnvironment e, AppDbContext context)
        {
            this.e = e;
            this.context = context;
        }
        public void OnGet()
        {
        }

        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost()
        {
            // make sure image file is not left empty
            if(FoodItemDto.ImageFile == null)
            {
                ModelState.AddModelError("FoodItemDto.ImageFile", "The image file is required.");
            }

            // if none of the fields are filled, display message
            if (!ModelState.IsValid)
            {
                errorMessage = "Please provide all the required fields.";
                return;
            }

            // save image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(FoodItemDto.ImageFile!.FileName);
            string imagePath = e.WebRootPath + "/fooditems/" + newFileName;
            using(var stream = System.IO.File.Create(imagePath))
            {
                FoodItemDto.ImageFile.CopyTo(stream);
            }

            // save new item in database
            FoodItem foodItem = new FoodItem()
            {
                Name = FoodItemDto.Name,
                Category = FoodItemDto.Category,
                Price = FoodItemDto.Price,
                Description = FoodItemDto.Description ?? "",
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now
            };
            context.FoodItems.Add(foodItem);
            context.SaveChanges();

            // clear form
            FoodItemDto.Name = "";
            FoodItemDto.Category = "";
            FoodItemDto.Price = 0;
            FoodItemDto.Description = "";
            FoodItemDto.ImageFile = null;

            ModelState.Clear();
            successMessage = "Item successfully created.";

            Response.Redirect("/Admin/FoodItems/Items");
        }
    }
}
