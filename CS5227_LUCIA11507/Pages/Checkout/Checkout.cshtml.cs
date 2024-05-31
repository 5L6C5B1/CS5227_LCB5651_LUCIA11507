using CS5227_LUCIA11507.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages.Checkout
{
    public class CheckoutModel : PageModel
    {
        public List<Cart> Carts { get; set; }

        public decimal TotalPrice => CalculateTotalPrice();

        private decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in Carts)
            {
                total += item.Price;
            }
            return total;
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Confirmation");
        }

        public class CartItem
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}
