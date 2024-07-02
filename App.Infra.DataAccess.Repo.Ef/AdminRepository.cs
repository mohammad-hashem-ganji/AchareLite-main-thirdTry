using App.Domain.Core.Member.DTOs;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.Ef
{
    public class AdminRepository 
    {
        private readonly AchareDbContext _dbContext;

        public AdminRepository(AchareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
