using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string?> CheckUserType(int userId, CancellationToken cancellationToken)
        {
            return await _userRepository.CheckUserType(userId, cancellationToken);
        }
    }
}
