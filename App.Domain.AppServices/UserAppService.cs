using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;

        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<string?> CheckUserType(int userId, CancellationToken cancellationToken)
        {
            return await _userService.CheckUserType(userId, cancellationToken);
        }
    }
}
