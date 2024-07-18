using App.Domain.Core.OrderAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.OrderAgg.Data.Repositories
{
    public interface IOrderRepository
    {
        Task Create(string Title, int serviceId, CancellationToken cancellationToken, int CustomerId = 0);
        Task <List<OrderDto>> GetAll(CancellationToken cancellationToken);
        Task<(OrderDto?, bool)> GetById(int id, CancellationToken cancellationToken);
        Task<List<OrderDto>?> GetCustomerOrders(int id,int bidStatusId, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task<bool> Update(OrderDto order, CancellationToken cancellationToken);
    }
}
//public int Id { get; set; }
//public string Title { get; set; }
//public int ServiseId { get; set; }
//public Service Service { get; set; }
//public int StatusId { get; set; }
//public Status Status { get; set; }
//public Customer Customer { get; set; }
//public int CustomerId { get; set; }
//public ICollection<Bid>? Bids { get; set; }