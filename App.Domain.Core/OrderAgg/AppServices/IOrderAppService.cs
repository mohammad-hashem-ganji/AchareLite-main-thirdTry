using App.Domain.Core.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.AppServices
{
    public interface IOrderAppService
    {
        Task Create(string Title, int serviceId, CancellationToken cancellationToken, int CustomerId = 0);
        Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
        Task<(OrderDto?, bool)> GetById(int id, CancellationToken cancellationToken);
        Task<List<OrderDto>?> GetCustomerOrders(int id, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<bool> Update(OrderDto order, CancellationToken cancellationToken);
    }
}
