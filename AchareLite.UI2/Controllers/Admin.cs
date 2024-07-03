using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using App.Domain.Core.OrderAgg.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AchareLite.UI2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Admin : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly ICustomerAppService _customerAppService;

        public Admin(IOrderAppService orderAppService, IServiceAppService serviceAppService, ICustomerAppService customerAppService)
        {
            _orderAppService = orderAppService;
            _serviceAppService = serviceAppService;
            _customerAppService = customerAppService;
        }
        public async Task<IActionResult> ShowPendingOrders(CancellationToken cancellationToken)
        {
            List<OrderDto> orders = await _orderAppService.GetAll(cancellationToken);
            List<OrderDto> notCheckedOrdersStatus = new();
            foreach (var order in orders)
            {
                order.ServiceName = await _serviceAppService.GetServiceName(order.ServiseId, cancellationToken);
                order.CustomerName = await _customerAppService.GetCustomerName(order.CustomerId, cancellationToken);
            }
            notCheckedOrdersStatus = orders.Where(order => order.StatusId== (int)Status.Pending).ToList();
            ViewData["orders"] = notCheckedOrdersStatus;
            return View();
        }
        public async Task<IActionResult> ShowOrdersInProgress(CancellationToken cancellationToken)
        {
            List<OrderDto> orders = await _orderAppService.GetAll(cancellationToken);
            List<OrderDto> inProgressOrdersStatus = new();
            foreach (var order in orders)
            {
                order.ServiceName = await _serviceAppService.GetServiceName(order.ServiseId, cancellationToken);
                order.CustomerName = await _customerAppService.GetCustomerName(order.CustomerId, cancellationToken);
            }
            inProgressOrdersStatus = orders.Where(order => order.StatusId == (int)Status.InProgress).ToList();
            ViewData["orders"] = inProgressOrdersStatus;
            return View();
        }
        public async Task<IActionResult> ShowCompletedOrders(CancellationToken cancellationToken)
        {
            List<OrderDto> orders = await _orderAppService.GetAll(cancellationToken);
            List<OrderDto> CompleteOrdersStatus = new();
            foreach (var order in orders)
            {
                order.ServiceName = await _serviceAppService.GetServiceName(order.ServiseId, cancellationToken);
                order.CustomerName = await _customerAppService.GetCustomerName(order.CustomerId, cancellationToken);
            }
            CompleteOrdersStatus = orders.Where(order => order.StatusId == (int)Status.Completed).ToList();
            ViewData["orders"] = CompleteOrdersStatus;
            return View();
        }
        public async Task<IActionResult> ChangeOrderStatus(int orderId, int NewStatus, CancellationToken cancellationToken)
        {
            (OrderDto?, bool) order = await _orderAppService.GetById(orderId, cancellationToken);
            if (order.Item2 != false)
            {
                order.Item1.StatusId = NewStatus;
              bool result = await _orderAppService.Update(order.Item1, cancellationToken);
            }
            return RedirectToAction("ShowOrders", "Admin");
        }
    }
}



