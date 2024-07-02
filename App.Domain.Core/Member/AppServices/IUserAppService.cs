using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.AppServices
{
    public interface IUserAppService
    {
        Task<string?> CheckUserType(int userId, CancellationToken cancellationToken);
    }
}
