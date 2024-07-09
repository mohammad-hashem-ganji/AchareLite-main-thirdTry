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
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public async Task Create(BidDto bid, CancellationToken cancellationToken)
        {
            await _bidRepository.Create(bid, cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _bidRepository.Delete(id, cancellationToken);
        }

        public async Task<List<BidDto>> GetAll(int expertId, CancellationToken cancellationToken)
        {
            return await _bidRepository.GetAll(expertId,cancellationToken);
        }

        public async Task<(BidDto?, bool)> GetById(int bidId, CancellationToken cancellationToken)
        {
            return await _bidRepository.GetById(bidId, cancellationToken);
        }

        public async Task<bool> Update(BidDto bidDto, CancellationToken cancellationToken)
        {
            return await _bidRepository.Update(bidDto, cancellationToken);
        }
    }
}
