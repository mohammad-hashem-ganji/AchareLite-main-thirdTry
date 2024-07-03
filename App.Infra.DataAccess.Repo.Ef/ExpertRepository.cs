using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.DTOs;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.Ef
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly AchareDbContext _dbContext;

        public ExpertRepository(AchareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExpertDto?> GetById(int expertId, CancellationToken cancellationToken)
        {
            ExpertDto? expert = await _dbContext.Experts
                .Include(x => x.Services)
                .Include(x => x.Comments)
                .Select(x => new ExpertDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ApplicationUserId = x.ApplicationUserId,
                    NCode = x.NCode,
                    CommentIds = x.Comments.Select(x => x.Id).ToList(),
                    ServiceIds = x.Services.Select(x => x.Id).ToList()
                }).FirstOrDefaultAsync(m => m.Id == expertId, cancellationToken);
            return (expert == null) ? null : expert;
        }
    }
}
