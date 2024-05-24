using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OFOrder_LUCIA11507.Infrastructure.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public CategoriesViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(await _context.Categories.ToListAsync());
    }
}
