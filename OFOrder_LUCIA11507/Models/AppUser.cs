using Microsoft.AspNetCore.Identity;

namespace OFOrder_LUCIA11507.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}
