﻿using App.Domain.Core.OrderAgg.Data.Repositories;
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
            _dbContext.Orders.Add(new Order
            {
                Title = title,
                ServiseId = serviceId,
                CustomerId = customerId
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var enetiy = await _dbContext.Orders
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (enetiy != null)
            {
                _dbContext.Orders.Remove(enetiy);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            List<OrderDto> orders = await _dbContext.Orders
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CustomerId = x.CustomerId,
                    ServiseId = x.ServiseId,
                    StatusId = x.StatusId,
                    Bids = x.Bids
                }).ToListAsync(cancellationToken);
            return orders;
        }

        public async Task<(OrderDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            OrderDto? order = await _dbContext.Orders
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CustomerId = x.CustomerId,
                    ServiseId = x.ServiseId,
                    StatusId = x.StatusId,
                    Bids = x.Bids,
                }).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
            return (order != null) ? (order, true) : (null, false);
        }

        public async Task<List<OrderDto>?> GetCustomerOrders(int id, CancellationToken cancellationToken)
        {
            List<OrderDto>? orders = await _dbContext.Orders
                .Select(x => new OrderDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    CustomerId = x.CustomerId,
                    ServiseId = x.ServiseId,
                    StatusId = x.StatusId,
                    Bids = x.Bids,
                }).Where(x => x.CustomerId == id).ToListAsync();
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
