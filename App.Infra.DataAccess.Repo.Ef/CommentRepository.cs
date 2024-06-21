using App.Domain.Core.OrderAgg.Data.Repositories;
using App.Domain.Core.OrderAgg.DTOs;
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
    public class CommentRepository : ICommentRepository
    {
        private readonly AchareDbContext _dbContext;

        public CommentRepository(AchareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(CancellationToken cancellationToken, string text, int scor = 0, bool isAccept = false, int expertId = 0, int customerId = 0)
        {
            var expert = await _dbContext.Experts.FirstOrDefaultAsync(x => x.Id == expertId);
            if (expert != null)
            {
                _dbContext.Comments.Add(new Comment
                {
                    Text = text,
                    Score = scor,
                    IsAccept = isAccept,
                    ExpertId = expertId,
                    CustomerId = customerId
                });
                await _dbContext.SaveChangesAsync();
            }
            
        }

        public Task Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<(CommentDto, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(CommentDto commentDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
