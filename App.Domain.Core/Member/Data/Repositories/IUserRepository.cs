using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.Data.Repositories
{
    public interface IUserRepository
    {
         Task<string?> CheckUserType(int userId, CancellationToken cancellationToken);
    }
}
