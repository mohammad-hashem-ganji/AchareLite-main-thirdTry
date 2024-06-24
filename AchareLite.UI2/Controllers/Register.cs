using App.Domain.Core.Member.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class Register : Controller
    {
        private readonly IAccountAppService _accountAppService;

        public Register(IAccountAppService accountAppServices)
        {
            _accountAppService = accountAppServices;
        }

        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public bool IsExpert { get; set; }
            public bool IsCstomer { get; set; }
        }
        public async Task<IActionResult> RegisterView() => View(Input);
        public async Task<IActionResult> RegisterConfirm( string returnUrl = null)
        {
            if (Input.IsCstomer && Input.IsExpert)
            {
                ModelState.AddModelError(string.Empty, "همزمان نمیتوانید هم خبرنگار باشید هم بیننده خبر");
                return RedirectToAction("RegisterView", "Register");
            }

            returnUrl ??= Url.Content("~/");

            var result = await _accountAppService.Register(Input.Email, Input.Password,
                Input.IsCstomer, Input.IsExpert);

            if (result.Count == 0)
            {
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return RedirectToAction("RegisterView", "Register");
        }
    }
}

