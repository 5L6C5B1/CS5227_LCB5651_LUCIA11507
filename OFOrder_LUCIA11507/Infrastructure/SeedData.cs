using Microsoft.EntityFrameworkCore;
using OFOrder_LUCIA11507.Models;

namespace OFOrder_LUCIA11507.Infrastructure
{
    public class SeedData
    {
        public static void SeedDatabase(AppDbContext context)
        {
            context.Database.Migrate();
            if(!context.FoodItems.Any())
            {
                Category food = new Category { Name = "Food", Slug = "food" };
                Category drinks = new Category { Name = "Drinks", Slug = "drinks" };
                Category desserts = new Category { Name = "Desserts", Slug = "desserts" };

                context.FoodItems.AddRange(
                    new FoodItem
                    {
                        Name = "Old World Steak",
                        Slug = "old world steak",
                        Description = "200 year-old steak fresh off the grill, very fresh despite its age.",
                        Price = 31.00,
                        Category = food,
                        Image = "brahminsteak.png"
                    },
                    new FoodItem
                    {
                        Name = "THE SANDWICH",
                        Slug = "the sandwich",
                        Description = "The classic sandwich eaten by every American.",
                        Price = 5.00,
                        Category = food,
                        Image = "sandwich.png"
                    },
                    new FoodItem
                    {
                        Name = "Planeta Caldereta",
                        Slug = "planeta caldereta",
                        Description = "Beef stew with vegetables and spices.",
                        Price = 14.90,
                        Category = food,
                        Image = "caldereta.png"
                    },
                    new FoodItem
                    {
                        Name = "Pepperoni Pizza",
                        Slug = "pepperoni pizza",
                        Description = "Best enjoyed in the sewers with renaissance turtles.",
                        Price = 10.80,
                        Category = food,
                        Image = "pizza.png"
                    },
                    new FoodItem
                    {
                        Name = "8-bites",
                        Slug = "8-bites",
                        Description = "A meal set with a beef burger, fries, and cola in low resolution.",
                        Price = 8.00,
                        Category = food,
                        Image = "lowres.jpg"
                    },
                    new FoodItem
                    {
                        Name = "Old World Noodles",
                        Slug = "old world noodles",
                        Description = "It could be ramen.",
                        Price = 7.00,
                        Category = food,
                        Image = "noodles.png"
                    },
                    new FoodItem
                    {
                        Name = "Sierra Madre Mocktail",
                        Slug = "sierra madre mocktail",
                        Description = "Tropical fruits blended and mixed with cloud residue.",
                        Price = 5.80,
                        Category = drinks,
                        Image = "mocktail.png"
                    },
                    new FoodItem
                    {
                        Name = "Chocolate Frappe",
                        Slug = "chocolate frappe",
                        Description = "Yummers. Thirst quenching chocolate with ice and milk. Quenched thirst.",
                        Price = 4.80,
                        Category = drinks,
                        Image = "frappe.png"
                    },
                    new FoodItem
                    {
                        Name = "Cyber Midnight",
                        Slug = "cyber midnight",
                        Description = "This mocktail takes you to 2050, literally. Contains slight radiation.",
                        Price = 2.50,
                        Category = drinks,
                        Image = "dbhdrink.jpg"
                    },
                    new FoodItem
                    {
                        Name = "Nuclear Soda",
                        Slug = "nuclear soda",
                        Description = "This poppy soda survived the nuclear blast of the Great War just for you.",
                        Price = 2.00,
                        Category = drinks,
                        Image = "soda.png"
                    },
                    new FoodItem
                    {
                        Name = "Biohazard",
                        Slug = "biohazard",
                        Description = "It tastes better than it looks.",
                        Price = 0.01,
                        Category = drinks,
                        Image = "biohazard.jpg"
                    },
                    new FoodItem
                    {
                        Name = "Water",
                        Slug = "water",
                        Description = "Water.",
                        Price = 1.00,
                        Category = drinks,
                        Image = "water.png"
                    },
                    new FoodItem
                    {
                        Name = "Eden's Sweetrolls",
                        Slug = "edens sweetrolls",
                        Description = "Feeling stressed? Have 3 cinnamon sweetrolls.",
                        Price = 7.00,
                        Category = desserts,
                        Image = "sweetrolls.png"
                    },
                    new FoodItem
                    {
                        Name = "Pollyanna",
                        Slug = "pollyanna",
                        Description = "A slice of apple pie topped with raspberry and whipped cream on top.",
                        Price = 6.50,
                        Category = desserts,
                        Image = "pollyanna.png"
                    },
                    new FoodItem
                    {
                        Name = "Pompeii",
                        Slug = "pompeii",
                        Description = "A birthday cake sized chocolate lava cake.",
                        Price = 50.00,
                        Category = desserts,
                        Image = "pompeii.png"
                    },
                    new FoodItem
                    {
                        Name = "Old World Doughnut",
                        Slug = "old world doughnut",
                        Description = "A vanilla doughnut decorated with a mint, strawberry, and blueberry glaze.",
                        Price = 1.50,
                        Category = desserts,
                        Image = "doughnut.png"
                    },
                    new FoodItem
                    {
                        Name = "Black Mesa",
                        Slug = "black mesa",
                        Description = "A black forest cake made artificially from a research facility in Upper Michigan, USA.",
                        Price = 19.40,
                        Category = desserts,
                        Image = "blackmesa.jpg"
                    },
                    new FoodItem
                    {
                        Name = "Ocean Waves",
                        Slug = "ocean waves",
                        Description = "Sea salt flavoured ice cream popsicles.",
                        Price = 5.00,
                        Category = desserts,
                        Image = "icecream.jpg"
                    });
                context.SaveChanges();
            }
        }
    }
}
