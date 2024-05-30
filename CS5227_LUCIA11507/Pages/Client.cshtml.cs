using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS5227_LUCIA11507.Pages
{
    [Authorize(Roles = "client")]
    public class ClientModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
