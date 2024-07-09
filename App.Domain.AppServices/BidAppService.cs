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
    public class BidAppService : IBidAppService
    {
        private readonly IBidService _bidService;

        public BidAppService(IBidService bidService)
        {
            _bidService = bidService;
        }

        public async Task Create(BidDto bid, CancellationToken cancellationToken)
        {
            await _bidService.Create(bid, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _bidService.Delete(id, cancellationToken);
        }

        public async Task<List<BidDto>> GetAll(int expertId, CancellationToken cancellationToken)
        {
            return await _bidService.GetAll(expertId,cancellationToken);
        }

        public async Task<(BidDto?, bool)> GetById(int bidId, CancellationToken cancellationToken)
        {
            return await _bidService.GetById(bidId, cancellationToken);
        }

        public async Task<bool> Update(BidDto bidDto, CancellationToken cancellationToken)
        {
            return await _bidService.Update(bidDto, cancellationToken);
        }
    }
}
