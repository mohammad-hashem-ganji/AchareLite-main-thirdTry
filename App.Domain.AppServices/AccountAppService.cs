using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class AccountAppService : IAccountAppService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountAppService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = await _userManager.Users
             .Include(u => u.Expert)
             .Include(x => x.Customer)
             .FirstOrDefaultAsync(u => u.Email == email);
            var result = await _signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<List<IdentityError>> Register(string email, string password, bool isCustomer, bool isExpert)
        {
            var role = string.Empty;
            var user = CreateUser();

            user.UserName = email;
            user.Email = email;
            
            if (isExpert)
            {
                role = "Expert";
                user.Expert = new Expert()
                {
                };
            }

            if (isCustomer)
            {
                role = "Customer";
                user.Customer = new Customer()
                {

                };
            }

            var result = await _userManager.CreateAsync(user, password);

            if (isExpert)
            {
                var userExpertId = user.Expert!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userExpertId", userExpertId.ToString()));
            }


            if (isCustomer)
            {
                var userCustomerId = user.Customer!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userCustomerId", userCustomerId.ToString()));
            }


            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, role);

            return (List<IdentityError>)result.Errors;
        }
        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                                                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }
    }
}
