using App.Domain.Core.Member.AppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AchareLiteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Register : ControllerBase
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
        [HttpPost]
        [Route(nameof(RegisterConfirm))]
        public async Task<bool> RegisterConfirm(InputModel Input)
        {
            if (Input.IsCstomer && Input.IsExpert)
            {
                return false;
            }

          
            var result = await _accountAppService.Register(Input.Email, Input.Password,
                Input.IsCstomer, Input.IsExpert);

            if (result.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
