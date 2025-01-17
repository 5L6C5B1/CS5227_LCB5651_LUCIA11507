using CS5227_LUCIA11507.Model;
using CS5227_LUCIA11507.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OFOrder_LUCIA11507.Infrastructure;
using static CS5227_LUCIA11507.Pages.Checkout.CheckoutModel;

namespace CS5227_LUCIA11507.Pages
{
    public class CartModel : PageModel
    {
        private readonly AppDbContext _context;
        public List<FoodItem> FoodItems;
        public List<Cart> CartItems;
        public CartModel(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult GetCart()
        {
            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart") ?? new List<Cart>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return Page();
        }

        public async Task<IActionResult> Add(long id)
        {
            FoodItem fooditem = await _context.FoodItems.FindAsync(id);

            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart") ?? new List<Cart>();

            Cart cartItem = cart.Where(c => c.FoodItemID == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new Cart(fooditem));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "Item added to cart.";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Remove(long id)
        {
            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart");

            Cart cartItem = cart.Where(c => c.FoodItemID == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.FoodItemID == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Item removed from cart.";

            return RedirectToPage("/Cart");
        }

        public async Task<IActionResult> Delete(long id)
        {
            List<Cart> cart = HttpContext.Session.GetJson<List<Cart>>("Cart");

            cart.RemoveAll(p => p.FoodItemID == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Item removed from cart.";

            return RedirectToPage("/Cart");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToPage("/Cart");
        }
    }
}
