using App.Domain.Core.Member.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AchareLite.UI2.Controllers
{
    public class Login : Controller
    {
        private readonly IAccountAppService _accountAppServices;
        private readonly IUserAppService _userAppServices;
        public Login(IAccountAppService accountAppServices, IUserAppService userAppServices)
        {
            _accountAppServices = accountAppServices;
            _userAppServices = userAppServices;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }

        }
        public async Task<IActionResult> LoginView() => View(Input);
        public async Task<IActionResult> LoginConfirm(CancellationToken cancellationToken) //string returnUrl = null
        {
           // returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid) return RedirectToAction("LoginView", "Login");

            var succeededLogin = await _accountAppServices.Login(Input.Email, Input.Password);         
            if (succeededLogin)
            {
                    return RedirectToAction("CheckRole", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور اشتباه است");
                return RedirectToAction("LoginView", "Login");
            }
        }
    }
}
