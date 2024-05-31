using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS5227_LUCIA11507.Model
{
    public class Cart
    {
        public Cart(FoodItem fooditem)
        {
            ID = fooditem.ID;
            Name = fooditem.Name;
            Price = fooditem.Price;
            Quantity = 1;
        }

        public Cart()
        {

        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [Precision(16, 2)]
        public decimal Price { get; set; }
        public int FoodItemID { get; set; }
        public FoodItem FoodItem { get; set; }
        public int Quantity { get; set; }
    }
}
