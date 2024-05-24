using Microsoft.EntityFrameworkCore;
using OFOrder_LUCIA11507.Models;

namespace OFOrder_LUCIA11507.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
