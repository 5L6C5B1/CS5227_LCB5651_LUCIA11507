using System.Net.Http.Headers;

namespace OFOrder_LUCIA11507.Models
{
    public class CartItem
    {
        public long FoodItemID { get; set; }
        public string FoodItemName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { 
            get{ return Quantity * Price; }
        }

        public string Image { get; set; }

        public CartItem()
        {

        }

        public CartItem(FoodItem fooditem)
        {
            FoodItemID = fooditem.ID;
            FoodItemName = fooditem.Name;
            Price = fooditem.Price;
            Quantity = 1;
            Image = fooditem.Image;
        }
    }
}
