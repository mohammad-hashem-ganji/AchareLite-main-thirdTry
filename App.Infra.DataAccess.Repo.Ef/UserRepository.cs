using App.Domain.Core.Member.Data.Repositories;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.Ef
{
    public class UserRepository : IUserRepository
    {
        private readonly AchareDbContext _dbContext;

        public UserRepository(AchareDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string?> CheckUserType(int userId, CancellationToken cancellationToken)
        {
            if (await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == userId) != null)
            {
                return "Customer";
            }
            if (await _dbContext.Admins.FirstOrDefaultAsync(c => c.Id == userId) != null)
            {
                return "Admin";
            }
            if (await _dbContext.Experts.FirstOrDefaultAsync(c => c.Id == userId) != null)
            {
                return "Expert";
            }
            else
            {
                return null;
            }
        }



    }
}
///////////////////////////////////////////


