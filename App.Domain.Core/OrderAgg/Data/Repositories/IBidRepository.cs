using App.Domain.Core.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.Data.Repositories
{
    public interface IBidRepository
    {
        Task Create(BidDto bid, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<List<BidDto>> GetAll(int expertId, CancellationToken cancellationToken);
        Task<(BidDto?, bool)> GetById(int bidId, CancellationToken cancellationToken);
        Task<bool> Update(BidDto bidDto, CancellationToken cancellationToken);
        Task<List<BidDto>> GetBidsByOrderId(int orderId,int statusId, CancellationToken cancellationToken);
    }
}
