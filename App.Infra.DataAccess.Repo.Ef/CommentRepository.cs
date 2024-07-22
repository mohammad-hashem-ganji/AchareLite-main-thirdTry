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

        public async Task Create(CommentDto comment, CancellationToken cancellationToken)
        {
            var expert = await _dbContext.Experts.FirstOrDefaultAsync(x => x.Id == comment.ExpertId);
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == comment.CustomerId);
            if (expert != null && customer != null)
            {
                _dbContext.Comments.Add(new Comment
                {
                    Text = comment.Text,
                    Score = comment.Score,
                    IsAccept = comment.IsAccept,
                    ExpertId = comment.ExpertId,
                    Expert = expert,
                    CustomerId = comment.CustomerId,
                    Customer = customer
                });
                int item = await _dbContext.SaveChangesAsync(cancellationToken);
                item.GetType();
            }

        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            Comment? comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment != null)
            {
                _dbContext.Remove(comment);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            List<CommentDto> comments = await _dbContext.Comments
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    CustomerId = c.CustomerId,
                    ExpertId = c.ExpertId,
                    IsAccept = c.IsAccept,
                    Score = c.Score,
                    Text = c.Text,
                }).ToListAsync(cancellationToken);
            return comments;
        }

        public async Task<(CommentDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            CommentDto? commentDto = await _dbContext.Comments
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    CustomerId = c.CustomerId,
                    ExpertId = c.ExpertId,
                    IsAccept = c.IsAccept,
                    Score = c.Score,
                    Text = c.Text
                }).FirstOrDefaultAsync(x => x.Id == id);
            return (commentDto != null) ? (commentDto, true) : (null, false);
        }
        public async Task<List<CommentDto>?> GetExpertComments(int expertId, CancellationToken cancellationToken)
        {
            List<CommentDto> comments = await _dbContext.Comments
                .Where(c => c.ExpertId == expertId && c.IsAccept)
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    Text = c.Text,
                    Score = c.Score,
                    ExpertId = c.ExpertId,
                    ExpertName = c.Expert != null ? c.Expert.FirstName : string.Empty,
                    CustomerId = c.CustomerId,
                    CustomerName = c.Customer != null ? c.Customer.FirstName : string.Empty
                })
                .ToListAsync(cancellationToken);

            return comments;
        }

        public async Task<bool> Update(CommentDto commentDto, CancellationToken cancellationToken)
        {
            Comment? comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == commentDto.Id);
            if (comment != null)
            {
                comment.CustomerId = commentDto.CustomerId;
                comment.ExpertId = commentDto.ExpertId;
                comment.Score = commentDto.Score;
                comment.IsAccept = commentDto.IsAccept;
                comment.Text = commentDto.Text;
                _dbContext.Update(comment);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
