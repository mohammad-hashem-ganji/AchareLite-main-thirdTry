using App.Domain.Core.Member.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AchareLite.UI2.Controllers
{
    public class Login : Controller
    {
        private readonly IAccountAppService _accountAppServices;

        public Login(IAccountAppService accountAppServices)
        {
            _accountAppServices = accountAppServices;
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
        public async Task<IActionResult> LoginConfirm() //string returnUrl = null
        {
           // returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid) return RedirectToAction("LoginView", "Login");

            var succeededLogin = await _accountAppServices.Login(Input.Email, Input.Password);

            if (succeededLogin)
                return RedirectToAction("ShowListOfMainCategories", "MainCategory");
            //return LocalRedirect(returnUrl);

            else
            {
                ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور اشتباه است");
                return RedirectToAction("LoginView", "Login");
            }
        }
    }
}
