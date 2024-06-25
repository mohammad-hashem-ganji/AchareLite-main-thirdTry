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
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;
        public OrderAppService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Create(string Title, int serviceId, CancellationToken cancellationToken, int CustomerId = 0)
        {
            await _orderService.Create(Title, serviceId, cancellationToken, CustomerId);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _orderService.Delete(id, cancellationToken);
        }

        public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _orderService.GetAll(cancellationToken);
        }

        public async Task<(OrderDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            return await _orderService.GetById(id, cancellationToken);
        }

        public async Task<List<OrderDto>?> GetCustomerOrders(int id, CancellationToken cancellationToken)
        {
            return await _orderService.GetCustomerOrders(id, cancellationToken);
        }

        public async Task<bool> Update(OrderDto order, CancellationToken cancellationToken)
        {
            return await _orderService.Update(order, cancellationToken);
        }
    }
}
