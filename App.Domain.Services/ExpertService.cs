using App.Domain.Core.Member.Data.Repositories;
using App.Domain.Core.Member.DTOs;
using App.Domain.Core.Member.Services;
using App.Domain.Core.OrderAgg.Data.Repositories;
using App.Domain.Core.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ExpertService : IExpertService
    {
        private readonly IExpertRepository _expertRepository;
        private readonly IBidRepository _bidRepository;
        private readonly IOrderRepository _orderRepository;
        public ExpertService(IExpertRepository expertRepository, IBidRepository bidRepository, IOrderRepository orderRepository)
        {
            _expertRepository = expertRepository;
            _bidRepository = bidRepository;
            _orderRepository = orderRepository;
        }

        public async Task<ExpertDto?> GetById(int expertId, CancellationToken cancellationToken) => await _expertRepository.GetById(expertId, cancellationToken);
        public async Task<string?> GetExpertName(int expertId, CancellationToken cancellationToken)
        {
            var expert = await _expertRepository.GetById(expertId, cancellationToken);
            if (expert != null)
            {
                if (expert.FirstName != null)
                {
                    return expert.FirstName;
                }
                else
                {
                    return "متخصص نام خود را وارد نکرده است";
                }
            }
            else
            {
                return "متخصص پیدا نشد";
            }
        }

        public async Task<bool> Update(ExpertDto model, CancellationToken cancellationToken)
        {
            return await _expertRepository.Update(model, cancellationToken);
        }
        public async Task<(List<BidDto>, List<OrderDto>)> ShowBidInDifferentStatus(int expertId,int statusId, CancellationToken cancellationToken)
        {
            List<BidDto> expertBids = await _bidRepository.GetAll(expertId, cancellationToken);
            List<BidDto> Bids = expertBids.Where(bid => bid.StatusId == statusId).ToList();
            List<OrderDto> allOrders = await _orderRepository.GetAll(cancellationToken);
            List<OrderDto> ordersForExpert = allOrders
                .Where(order => Bids.Any(bid => bid.OrderId == order.Id))
                .ToList();
            return (Bids, ordersForExpert);
        }
    }
}
