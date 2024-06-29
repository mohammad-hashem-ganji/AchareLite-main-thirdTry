using App.Domain.Core.CategoryService.AppServices;

using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    public class Order : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IServiceAppService _serviceAppService;
        [BindProperty]
        public InputModel Input { get; set; }


        public class InputModel
        {
            public string ServiceDescription { get; set; }
            public string ServiceName { get; set; }
            public bool CustomerName { get; set; }
            
        }
        public Order(IOrderAppService orderAppService, IServiceAppService serviceAppService)
        {
            _orderAppService = orderAppService;
            _serviceAppService = serviceAppService;
        }
        public async Task<IActionResult> ShowListOfOrders(CancellationToken cancellationToken) => View();
        public async Task<IActionResult> Create(int id, CancellationToken cancellationToken)
        {
            var customerId = int.Parse(User.Claims.First().Value);
            //find customer adress to show and edit   *****
            OrderDto orderDto = new();
            orderDto.ServiceName = await _serviceAppService.GetServiceName(id, cancellationToken);
            orderDto.ServiseId = id;
            orderDto.CustomerId = customerId;
            ViewData["orderDto"] = orderDto;
            return View();
        }
        public async Task<IActionResult> AddOrder(string title,int customerId, int serviceId, CancellationToken cancellationToken)
        {

            await _orderAppService.Create(title, serviceId, cancellationToken, customerId);
            return RedirectToAction("ShowLisOfOrders", "Order");
        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _orderAppService.Delete(id, cancellationToken);
            return RedirectToAction("ShowLisOfOrders", "Order");
        }
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            (OrderDto?, bool) orderDto = await _orderAppService.GetById(id, cancellationToken);
            ViewData["editOrderDto"] = orderDto.Item1;
            return View();
        }
        public async Task<IActionResult> Update(OrderDto orderDto, CancellationToken cancellationToken)
        {
            await _orderAppService.Update(orderDto, cancellationToken);
            return RedirectToAction("ShowLisOfOrders", "Order");
        }

    }
}
