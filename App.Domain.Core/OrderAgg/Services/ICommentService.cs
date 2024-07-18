using App.Domain.Core.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.Services
{
    public interface ICommentService
    {
        Task Create(CommentDto comment, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<(CommentDto?, bool)> GetById(int id, CancellationToken cancellationToken);
        Task<bool> Update(CommentDto commentDto, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetExpertComments(int expertId, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetUnacceptedComments(CancellationToken cancellationToken);
    }
}
