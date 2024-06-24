using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.AppServices
{
    public interface IAccountAppService
    {
        Task<List<IdentityError>> Register(string email, string password, bool isCustomer, bool isExpert);
        Task<bool> Login(string email, string password);

    }
}
