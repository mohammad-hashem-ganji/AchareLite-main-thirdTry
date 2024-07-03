
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.OrderAgg.Data.Repositories;
using App.Domain.Core.OrderAgg.DTOs;
using App.Domain.Core.OrderAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IExpertAppService _expertAppService;

        public CommentService(ICommentRepository commentRepository, IExpertAppService expertAppService)
        {
            _commentRepository = commentRepository;
            _expertAppService = expertAppService;
        }

        public async Task Create(CancellationToken cancellationToken, string text, int scor = 0, bool isAccept = false, int expertId = 0, int customerId = 0)
        {
            await _commentRepository.Create(cancellationToken, text, scor, isAccept, expertId, customerId);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _commentRepository.Delete(id, cancellationToken);
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _commentRepository.GetAll(cancellationToken);
        }

        public async Task<(CommentDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetById(id, cancellationToken);
        }

        public async Task<bool> Update(CommentDto commentDto, CancellationToken cancellationToken)
        {
            return await _commentRepository.Update(commentDto, cancellationToken);
        }
        public async Task<List<CommentDto>> GetExpertComments(int expertId,CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetExpertComments(expertId, cancellationToken);
            return comments;
        }
    }
}
