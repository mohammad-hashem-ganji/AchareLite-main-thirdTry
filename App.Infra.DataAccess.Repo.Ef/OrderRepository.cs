using App.Domain.Core.Member.Entities;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly AchareDbContext _dbContext;

        public OrderRepository(AchareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(string title, int serviceId, CancellationToken cancellationToken, int customerId = 0)
        {
            var service = await _dbContext.Services.FirstOrDefaultAsync(s => s.Id == serviceId);
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            if (service != null && customer != null )
            {
                _dbContext.Add(new Order
                {
                    Title = title,
                    ServiseId = serviceId,
                    Service = service,
                    CustomerId = customerId,
                    Customer = customer,
                    StatusId = (int)Status.Pending,
                    Status = Status.Pending,
                });
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var enetiy = await _dbContext.Orders.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (enetiy != null)
            {
                _dbContext.Orders.Remove(enetiy);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            List<OrderDto> orders = await _dbContext.Orders
                .Include(a => a.Bids  )
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CustomerId = x.CustomerId,
                    ServiseId = x.ServiseId,
                    StatusId = x.StatusId,
                    BidsId = x.Bids!.Select(c => c.Id).ToList()
                }).ToListAsync(cancellationToken);
            return orders;
        }

        public async Task<(OrderDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            OrderDto? order = await _dbContext.Orders
                .Include(a =>a.Bids)
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CustomerId = x.CustomerId,
                    ServiseId = x.ServiseId,
                    StatusId = x.StatusId,
                    BidsId = x.Bids!.Select(c =>c.Id).ToList()
                }).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
            return (order != null) ? (order, true) : (null, false);
        }
        public async Task<List<OrderDto>?> GetCustomerOrders(int id, CancellationToken cancellationToken)
        {
            List<OrderDto>? orders = await _dbContext.Orders
                .Include(a => a.Bids)
                .Where(x => x.CustomerId == id)
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CustomerId = x.CustomerId,
                    ServiseId = x.ServiseId,
                    StatusId = x.StatusId,
                    BidsId = x.Bids!.Select(c => c.Id).ToList()
                }).ToListAsync();
            return (orders != null) ? (orders) : (null);
        }

        public async Task<bool> Update(OrderDto orderDto, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
            .FirstOrDefaultAsync(m => m.Id == orderDto.Id, cancellationToken);
            if (order != null)
            {
                order.Title = orderDto.Title;
                order.CustomerId = orderDto.CustomerId;
                order.StatusId = orderDto.StatusId;
                order.ServiseId = orderDto.ServiseId;
                order.Status = (Status)orderDto.StatusId;
                _dbContext.Update(order);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
