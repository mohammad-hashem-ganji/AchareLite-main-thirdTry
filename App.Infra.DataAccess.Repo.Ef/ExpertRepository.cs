using App.Domain.Core.CategoryService.Entities;
using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.OrderAgg.Entities;
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
                    Mobile = x.Mobile,
                    CommentIds = x.Comments.Select(x => x.Id).ToList(),
                    ServiceIds = x.Services.Select(x => x.Id).ToList()
                }).FirstOrDefaultAsync(m => m.Id == expertId, cancellationToken);
            return (expert == null) ? null : expert;
        }
        public async Task<bool> Update(ExpertDto model, CancellationToken cancellationToken)
        {
            var expert = await _dbContext.Experts
                .Include(x => x.Services) // Include related Services collection
                .Include(x => x.Comments) // Include related Comments collection
                .FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);

            if (expert != null)
            {
                expert.FirstName = model.FirstName;
                expert.LastName = model.LastName;
                expert.NCode = model.NCode;
                expert.Mobile = model.Mobile;
                //expert.Address = model.Address;
                expert.Services ??= new List<Service>();
                expert.Comments ??= new List<Comment>();
                expert.Services.Clear();
                expert.Comments.Clear();
                if (model.ServiceIds != null)
                {
                    foreach (var serviceId in model.ServiceIds)
                    {
                        var service = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == serviceId, cancellationToken);
                        if (service != null)
                        {
                            expert.Services.Add(service); 
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                if (model.CommentIds != null)
                {
                    foreach (var commentId in model.CommentIds)
                    {
                        var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);
                        if (comment != null)
                        {
                            expert.Comments.Add(comment);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
