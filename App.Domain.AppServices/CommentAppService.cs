using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using App.Domain.Core.OrderAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService _commentService;

        public CommentAppService(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task Create(CancellationToken cancellationToken, string text, int scor = 0, bool isAccept = false, int expertId = 0, int customerId = 0)
        {
            await _commentService.Create(cancellationToken, text, scor, isAccept, expertId, customerId);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _commentService.Delete(id, cancellationToken);
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _commentService.GetAll(cancellationToken);
        }

        public async Task<(CommentDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            return await _commentService.GetById(id, cancellationToken);
        }

        public async Task<List<CommentDto>> GetExpertComments(int expertId, CancellationToken cancellationToken)
        {
            return await _commentService.GetExpertComments(expertId, cancellationToken);
        }

        public async Task<bool> Update(CommentDto commentDto, CancellationToken cancellationToken)
        {
            return await _commentService.Update(commentDto, cancellationToken);
        }
        public async Task<List<CommentDto>> GetUnacceptedComments(CancellationToken cancellationToken)
        {
            return await _commentService.GetUnacceptedComments(cancellationToken);
        }
    }
}
