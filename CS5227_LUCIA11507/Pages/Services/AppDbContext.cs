using Microsoft.EntityFrameworkCore;

namespace CS5227_LUCIA11507.Pages.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

    }
}
