﻿using App.Domain.Core.OrderAgg.Data.Repositories;
using App.Domain.Core.OrderAgg.DTOs;
using App.Domain.Core.OrderAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderReposetory;

        public OrderService(IOrderRepository orderReposetory)
        {
            _orderReposetory = orderReposetory;
        }

        public async Task Create(string Title, int serviceId, CancellationToken cancellationToken, int CustomerId = 0)
        {
            await _orderReposetory.Create(Title, serviceId, cancellationToken, CustomerId);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _orderReposetory.Delete(id, cancellationToken);
        }

        public async Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _orderReposetory.GetAll(cancellationToken);
        }

        public async Task<(OrderDto?, bool)> GetById(int id, CancellationToken cancellationToken)
        {
            return await _orderReposetory.GetById(id, cancellationToken);
        }

        public async Task<List<OrderDto>?> GetCustomerOrders(int id, CancellationToken cancellationToken)
        {
            return await _orderReposetory.GetCustomerOrders(id, cancellationToken);
        }

        public Task<bool> Update(OrderDto order, CancellationToken cancellationToken)
        {
            return _orderReposetory.Update(order, cancellationToken);
        }
    }
}