﻿using App.Domain.Core.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.Data.Repositories
{
    public interface ICommentRepository
    {
        Task Create(CommentDto comment, CancellationToken cancellationToken0);
        Task< List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<(CommentDto?, bool)> GetById(int id, CancellationToken cancellationToken);
        Task<bool> Update(CommentDto commentDto, CancellationToken cancellationToken);
        Task<List<CommentDto>?> GetExpertComments(int expertId, CancellationToken cancellationToken);
    }
}
