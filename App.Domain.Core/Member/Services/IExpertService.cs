using App.Domain.Core.Member.DTOs;
using App.Domain.Core.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Member.Services
{
    public interface IExpertService
    {
        Task<ExpertDto?> GetById(int expertId, CancellationToken cancellationToken);
        Task<string?> GetExpertName(int expertId, CancellationToken cancellationToken);
        Task<bool> Update(ExpertDto model, CancellationToken cancellationToken);
        Task<(List<BidDto>, List<OrderDto>)> ShowBidInDifferentStatus(int expertId,int statusId, CancellationToken cancellationToken);
    }
}
