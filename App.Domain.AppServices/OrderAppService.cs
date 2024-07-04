using App.Domain.Core.CategoryService.Services;
using App.Domain.Core.Member.Services;
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
        private readonly IServiceService _serviceService;
        private readonly ICustomerService _customerService;
        public OrderAppService(IOrderService orderService, IServiceService serviceService, ICustomerService customerService)
        {
            _orderService = orderService;
            _serviceService = serviceService;
            _customerService = customerService;
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
        public async Task<OrderDto> InitializOrderDto(CancellationToken cancellationToken, string serviceName = "", int serviceId = 0, int customerId = 0, int statusId = 0)
        {
            return await _orderService.InitializOrderDto(cancellationToken, serviceName, serviceId, customerId, statusId);
        }
        public async Task<List<OrderDto>> ShowOrderInDifferentStatus(int status, CancellationToken cancellationToken)
        {
            List<OrderDto> orders = await _orderService.GetAll(cancellationToken);
            List<OrderDto> spesificOrdersStatus = new();
            foreach (var order in orders)
            {
                order.ServiceName = await _serviceService.GetServiceName(order.ServiseId, cancellationToken);
                order.CustomerName = await _customerService.GetCustomerName(order.CustomerId, cancellationToken);
            }
            spesificOrdersStatus = orders.Where(order => order.StatusId == status).ToList();
            if (spesificOrdersStatus != null)
            {
                return spesificOrdersStatus;
            }
            else
            {
                throw new Exception($"هیچ درخواستی با : {status} پیدا نشد");
            }
            
        }

    }
}
