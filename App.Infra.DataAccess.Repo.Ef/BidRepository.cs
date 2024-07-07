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
    public class BidRepository
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
        public async Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
        {
            List<BidDto> bid = await _dbContext.Bids
                 .Select(x => new BidDto
                 {
                     OrderId = x.OrderId,
                     ExpertId = x.ExpertId,
                     ExprtSujestFee = x.ExprtSujestFee,
                     StatusId = x.StatusId
                 }).ToListAsync(cancellationToken);
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
    }
}
//public int Id { get; set; }
//public string ExprtSujestFee { get; set; }
//public int OrderId { get; set; }
//public int ExpertId { get; set; }
//public int StatusId
//{
//    get; set;
