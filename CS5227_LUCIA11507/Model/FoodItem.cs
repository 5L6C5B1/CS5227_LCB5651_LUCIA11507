using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CS5227_LUCIA11507.Model
{
    public class FoodItem
    {
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Category { get; set; }
        [Precision(16, 2)]
        public string Price { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImageFileName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
