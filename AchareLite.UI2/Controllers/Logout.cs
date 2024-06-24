using App.Domain.Core.Member.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class Logout : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Logout(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IActionResult> LogoutConfirm(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {

                return RedirectToAction("RegisterView", "Register");
            }
        }
    }
}
