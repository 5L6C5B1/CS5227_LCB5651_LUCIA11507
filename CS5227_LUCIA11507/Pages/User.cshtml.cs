using CS5227_LUCIA11507.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages
{
    [Authorize]
    public class UserModel : PageModel
    {
        private readonly UserManager<AppUser> userManager;
        public AppUser? appUser;
        public UserModel(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
            var task = userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
        }
    }
}
