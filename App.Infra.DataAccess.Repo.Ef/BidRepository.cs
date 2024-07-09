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
    public class BidRepository : IBidRepository
    {
        private readonly AchareDbContext _dbContext;

        public BidRepository(AchareDbContext achareDbContext)
        {
            _dbContext = achareDbContext;
        }
        public async Task Create(BidDto bid, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == bid.OrderId);
            var expert = await _dbContext.Experts.FirstOrDefaultAsync(x => x.Id == bid.ExpertId);
            if (order != null && order != null)
            {
                _dbContext.Bids.Add(new Bid
                {
                    OrderId = bid.OrderId,
                    Order = order,
                    ExpertId = bid.ExpertId,
                    Expert = expert,
                    ExprtSujestFee = bid.ExprtSujestFee,
                    Status = Status.Pending,
                    StatusId = (int)Status.Pending
                });
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var enetiy = await _dbContext.Bids.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (enetiy != null)
            {
                _dbContext.Bids.Remove(enetiy);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }
        public async Task<List<BidDto>> GetAll(int expertId, CancellationToken cancellationToken)
        {
            List<BidDto> bid = await _dbContext.Bids
                 .Select(x => new BidDto
                 {
                     OrderId = x.OrderId,
                     ExpertId = x.ExpertId,
                     ExprtSujestFee = x.ExprtSujestFee,
                     StatusId = x.StatusId
                 }).Where(b => b.ExpertId == expertId).ToListAsync(cancellationToken);
            return bid;
        }
        public async Task<(BidDto?, bool)> GetById(int bidId, CancellationToken cancellationToken)
        {
            BidDto? bid = await _dbContext.Bids
                .Select(x => new BidDto
                {
                    OrderId = x.OrderId,
                    ExpertId = x.ExpertId,
                    ExprtSujestFee = x.ExprtSujestFee,
                    StatusId = x.StatusId
                }).FirstOrDefaultAsync(b => b.Id == bidId, cancellationToken);
            return (bid != null) ? (bid, true) : (null, false);
        }
        public async Task<bool> Update(BidDto bidDto, CancellationToken cancellationToken)
        {
            var bid = await _dbContext.Bids
                .FirstOrDefaultAsync(x => x.Id == bidDto.Id, cancellationToken);
            var expert = await _dbContext.Experts
                .FirstOrDefaultAsync(x => x.Id == bidDto.ExpertId);
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(x => x.Id == bidDto.OrderId);
            if (bid != null)
            {
                bid.ExpertId = bidDto.ExpertId;
                bid.Expert = expert;
                bid.OrderId = bidDto.OrderId;
                bid.Order = order;
                bid.ExprtSujestFee = bidDto.ExprtSujestFee;
                bid.StatusId = bidDto.StatusId;
                bid.Status = (Status)bidDto.StatusId;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
//public int Id { get; set; }
//public string ExprtSujestFee { get; set; }
//public int OrderId { get; set; }
//public int ExpertId { get; set; }
//public int StatusId
//{
//    get; set;
