using Microsoft.AspNetCore.Mvc;
using OFOrder_LUCIA11507.Infrastructure;
using OFOrder_LUCIA11507.Models;
using OFOrder_LUCIA11507.Models.ViewModels;
using System.Net.Http.Headers;

namespace OFOrder_LUCIA11507.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Shop()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }

        public async Task<IActionResult> Add(long id)
        {
            FoodItem fooditem = await _context.FoodItems.FindAsync(id);
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartitem = cart.Where(c => c.FoodItemID == id).FirstOrDefault();
            if(cartitem == null)
            {
                cart.Add(new CartItem(fooditem));
            }
            else
            {
                cartitem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);
            TempData["Success"] = "Added product to cart.";
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
