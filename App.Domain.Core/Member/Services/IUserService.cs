using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.Services
{
    public interface IUserService
    {
        Task<string?> CheckUserType(int userId, CancellationToken cancellationToken);
    }
}
