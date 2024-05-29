using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CS5227_LUCIA11507.Model
{
    public class FoodItemDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Category { get; set; }
        [Required]
        public string Price { get; set; }
        public string? Description { get; set; }
        [MaxLength(100)]
        public IFormFile? ImageFile { get; set; }
    }
}
