using CS5227_LUCIA11507.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace CS5227_LUCIA11507.Pages.Services
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) {
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "name";

            var manager = new IdentityRole("manager");
            admin.NormalizedName = "manager";

            var client = new IdentityRole("client");
            admin.NormalizedName = "client";

            builder.Entity<IdentityRole>().HasData(admin, manager, client);
        }
        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
